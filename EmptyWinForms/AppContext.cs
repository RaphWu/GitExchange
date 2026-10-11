using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Microsoft.Extensions.Logging;

namespace EmptyWinForms
{
    /// <summary>
    /// 定義應用程式核心模組的初始化與停止流程。
    /// </summary>
    public interface IApplicationLifecycle
    {
        /// <summary>初始化應用程式核心模組。</summary>
        Task InitializeAsync(CancellationToken cancellationToken, IProgress<string> progress);

        /// <summary>停止已啟動的應用程式核心模組。</summary>
        Task StopAsync(CancellationToken cancellationToken);
    }

    /// <summary>
    /// 定義應用程式的主視窗。
    /// </summary>
    public interface IMainWindow
    {
        /// <summary>取得應用程式的主視窗。</summary>
        Form View { get; }
    }

    /// <summary>
    /// 管理應用程式啟動、主視窗切換、停止流程與執行緒生命週期。
    /// </summary>
    internal sealed class AppStartupContext : ApplicationContext
    {
        private const int ShutdownTimeoutSeconds = 30;
        private const int SW_RESTORE = 9;

        private readonly IContainer _container;
        private readonly ILogger<AppStartupContext> _logger;
        private readonly string _activationPipeName;
        private readonly SplashScreen _splash;

        private readonly CancellationTokenSource _startupCts = new CancellationTokenSource();
        private readonly CancellationTokenSource _activationCts = new CancellationTokenSource();

        private IApplicationLifecycle? _lifecycle;
        private Form? _mainForm;
        private SynchronizationContext? _uiContext;

        private Task? _initializationTask;
        private Task? _activationTask;
        private Task? _shutdownTask;

        private bool _isShuttingDown;
        private bool _allowMainFormClose;

        private int _disposeStarted;
        private int _finishStarted;
        private int _cancellationSourcesDisposed;

        /// <summary>
        /// 初始化應用程式生命週期協調器。
        /// </summary>
        public AppStartupContext(
            IContainer container,
            ILoggerFactory loggerFactory,
            string activationPipeName)
        {
            _container = container ?? throw new ArgumentNullException(nameof(container));

            if (loggerFactory == null)
                throw new ArgumentNullException(nameof(loggerFactory));

            _activationPipeName = activationPipeName
                ?? throw new ArgumentNullException(nameof(activationPipeName));

            _logger = loggerFactory.CreateLogger<AppStartupContext>();

            _splash = new SplashScreen();
            _splash.Shown += Splash_Shown;
            _splash.AbortClicked += Splash_AbortClicked;

            // 等待 Application.Run() 啟動訊息迴圈後再顯示 Splash。
            Application.Idle += Application_Idle;
        }

        /// <summary>
        /// 在 WinForms 訊息迴圈進入 Idle 時顯示啟動畫面。
        /// </summary>
        private void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;

            if (Volatile.Read(ref _disposeStarted) != 0)
                return;

            // 此時已進入 UI 執行緒的訊息迴圈。
            _uiContext = SynchronizationContext.Current
                ?? new WindowsFormsSynchronizationContext();

            try
            {
                _splash.Show();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "無法顯示啟動畫面。");
                BeginShutdown("無法顯示啟動畫面");
            }
        }

        /// <summary>
        /// 啟動背景監聽與應用程式初始化。
        /// </summary>
        private void Splash_Shown(object sender, EventArgs e)
        {
            if (_isShuttingDown || _initializationTask != null)
                return;

            _uiContext = SynchronizationContext.Current
                ?? _uiContext;

            _logger.LogInformation("開始初始化應用程式。");
            _splash.Report("開始初始化應用程式...");

            // 所有背景工作均保存 Task，並於停止流程中等待。
            _activationTask = ListenForActivationAsync(_activationCts.Token);
            _initializationTask = InitializeApplicationAsync();
        }

        /// <summary>
        /// 在背景執行緒中初始化應用程式核心模組。
        /// </summary>
        private async Task InitializeApplicationAsync()
        {
            try
            {
                // Progress 在 UI 執行緒建立，回呼會回到原本的同步環境。
                var progress = new Progress<string>(message =>
                {
                    if (!_isShuttingDown && !_splash.IsDisposed)
                    {
                        _splash.Report(message);
                    }
                });

                await Task.Run(async () =>
                {
                    // 建構子不應連線硬體；實際啟動由 InitializeAsync 執行。
                    _lifecycle = _container.Resolve<IApplicationLifecycle>();

                    await _lifecycle.InitializeAsync(
                        _startupCts.Token,
                        progress).ConfigureAwait(false);
                }, _startupCts.Token).ConfigureAwait(false);

                _logger.LogInformation("核心模組初始化完成。");

                PostToUi(ShowMainWindow);
            }
            catch (OperationCanceledException) when (_startupCts.IsCancellationRequested)
            {
                _logger.LogInformation("應用程式初始化已取消。");
                PostToUi(() => BeginShutdown("使用者取消或初始化取消"));
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "應用程式初始化失敗。");
                PostToUi(() => HandleStartupFailure(ex));
            }
        }

        /// <summary>
        /// 初始化完成後解析並顯示主視窗。
        /// </summary>
        private void ShowMainWindow()
        {
            if (_isShuttingDown)
                return;

            try
            {
                IMainWindow window = _container.Resolve<IMainWindow>();
                Form? form = window?.View;

                if (form == null || form.IsDisposed)
                {
                    throw new InvalidOperationException("IMainWindow 未提供有效的主視窗。");
                }

                _mainForm = form;

                // ApplicationContext 只在主視窗真正關閉時退出。
                MainForm = _mainForm;
                _mainForm.FormClosing += MainForm_FormClosing;

                _splash.Hide();

                _mainForm.Show();
                ActivateWindow(_mainForm);

                _logger.LogInformation("主視窗已顯示。");
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "主視窗啟動失敗。");

                MessageBox.Show(
                    _splash,
                    "主視窗啟動失敗。" +
                    Environment.NewLine +
                    ex.Message,
                    "啟動失敗",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                BeginShutdown("主視窗啟動失敗");
            }
        }

        /// <summary>
        /// 顯示初始化錯誤並開始停止流程。
        /// </summary>
        private void HandleStartupFailure(Exception exception)
        {
            if (_isShuttingDown)
                return;

            MessageBox.Show(
                _splash,
                "應用程式初始化失敗。" +
                Environment.NewLine +
                exception.Message,
                "初始化失敗",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            BeginShutdown("應用程式初始化失敗");
        }

        /// <summary>
        /// 當使用者要求關閉主視窗時，先攔截關閉並執行服務停止流程。
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowMainFormClose)
                return;

            e.Cancel = true;
            BeginShutdown("使用者關閉主視窗");
        }

        /// <summary>
        /// 處理啟動畫面取消事件。
        /// </summary>
        private void Splash_AbortClicked(object sender, EventArgs e)
        {
            BeginShutdown("使用者取消啟動");
        }

        /// <summary>
        /// 啟動冪等的關閉流程。
        /// </summary>
        private void BeginShutdown(string reason)
        {
            if (_isShuttingDown)
                return;

            _isShuttingDown = true;

            _logger.LogInformation("開始停止應用程式：{Reason}", reason);

            _splash.SetCancelEnabled(false);

            CancelSafely(_startupCts);
            CancelSafely(_activationCts);

            // ShutdownCoreAsync 內部捕捉並記錄例外，不將未觀察工作留在背景。
            _shutdownTask = ShutdownCoreAsync(reason);
        }

        /// <summary>
        /// 等待初始化與監聽工作結束，再停止核心服務。
        /// </summary>
        private async Task ShutdownCoreAsync(string reason)
        {
            try
            {
                if (_initializationTask != null)
                {
                    try
                    {
                        await _initializationTask.ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "等待初始化工作結束時發生例外。");
                    }
                }

                if (_activationTask != null)
                {
                    try
                    {
                        await _activationTask.ConfigureAwait(false);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "等待啟用監聽工作結束時發生例外。");
                    }
                }

                IApplicationLifecycle? lifecycle = _lifecycle;

                if (lifecycle != null)
                {
                    try
                    {
                        using (var timeoutCts = new CancellationTokenSource(
                            TimeSpan.FromSeconds(ShutdownTimeoutSeconds)))
                        {
                            await Task.Run(() => lifecycle.StopAsync(timeoutCts.Token))
                                .ConfigureAwait(false);
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        _logger.LogWarning(ex, "服務停止流程已取消或超過指定的停止期限。");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "停止應用程式核心服務時發生例外。");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "執行關閉流程時發生例外。");
            }
            finally
            {
                _logger.LogInformation("服務停止流程結束：{Reason}", reason);

                // 初始化與監聽工作均已結束，現在才能釋放取消來源。
                DisposeCancellationSources();

                PostToUi(FinishShutdown);
            }
        }

        /// <summary>
        /// 在 UI 執行緒完成關閉程序。
        /// </summary>
        private void FinishShutdown()
        {
            if (Interlocked.Exchange(ref _finishStarted, 1) != 0)
                return;

            _splash.Shown -= Splash_Shown;
            _splash.AbortClicked -= Splash_AbortClicked;

            try
            {
                if (!_splash.IsDisposed)
                {
                    _splash.CloseFromOwner();
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "關閉啟動畫面時發生例外。");
            }

            if (_mainForm != null && !_mainForm.IsDisposed)
            {
                try
                {
                    // 服務停止完成後才允許主視窗關閉。
                    _allowMainFormClose = true;
                    _mainForm.Close();

                    // ApplicationContext 會在 MainForm 關閉時退出訊息迴圈。
                    return;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "關閉主視窗時發生例外。");
                }
            }

            ExitThread();
        }

        /// <summary>
        /// 背景等待 Named Pipe 連線，收到連線後通知 UI 啟用視窗。
        /// </summary>
        /// <param name="cancellationToken">取消監聽的來源。</param>
        private async Task ListenForActivationAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    using (var server = new NamedPipeServerStream(
                        _activationPipeName,
                        PipeDirection.In,
                        1,
                        PipeTransmissionMode.Byte,
                        PipeOptions.Asynchronous))
                    {
                        await server.WaitForConnectionAsync(cancellationToken)
                            .ConfigureAwait(false);
                    }

                    PostToUi(ActivateCurrentWindow);
                }
                catch (OperationCanceledException)
                    when (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    if (cancellationToken.IsCancellationRequested)
                        break;

                    _logger.LogWarning(ex, "單一執行個體啟用監聽發生例外。");

                    try
                    {
                        await Task.Delay(250, cancellationToken)
                            .ConfigureAwait(false);
                    }
                    catch (OperationCanceledException)
                        when (cancellationToken.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 將目前應用程式視窗切換至前景。
        /// </summary>
        private void ActivateCurrentWindow()
        {
            if (_isShuttingDown)
                return;

            Form target = (_mainForm != null && !_mainForm.IsDisposed && _mainForm.Visible)
                ? _mainForm
                : _splash;

            if (target.IsDisposed)
                return;

            if (!target.Visible)
                target.Show();

            ActivateWindow(target);
        }

        /// <summary>
        /// 嘗試還原並啟用指定視窗。
        /// </summary>
        private static void ActivateWindow(Form form)
        {
            if (form == null || form.IsDisposed)
                return;

            if (form.WindowState == FormWindowState.Minimized)
            {
                form.WindowState = FormWindowState.Normal;
            }

            form.Activate();

            if (form.IsHandleCreated)
            {
                NativeMethods.ShowWindow(form.Handle, SW_RESTORE);
                NativeMethods.SetForegroundWindow(form.Handle);
            }
        }

        /// <summary>
        /// 將操作排入 UI 執行緒，避免背景工作直接操作 WinForms 控制項。
        /// </summary>
        private void PostToUi(Action action)
        {
            if (action == null || Volatile.Read(ref _disposeStarted) != 0)
                return;

            SynchronizationContext? context = _uiContext;

            if (context == null)
            {
                _logger.LogError("UI 同步環境尚未建立，無法派送 UI 工作。");
                return;
            }

            try
            {
                context.Post(_ =>
                {
                    if (Volatile.Read(ref _disposeStarted) != 0)
                        return;

                    try
                    {
                        action();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "執行 UI 回呼時發生例外。");

                        if (!_isShuttingDown)
                        {
                            BeginShutdown("UI 回呼發生例外");
                        }
                    }
                }, null);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "無法將工作派送至 UI 執行緒。");
            }
        }

        /// <summary>
        /// 安全地要求背景工作取消。
        /// </summary>
        private void CancelSafely(CancellationTokenSource source)
        {
            if (Volatile.Read(ref _cancellationSourcesDisposed) != 0)
                return;

            try
            {
                if (!source.IsCancellationRequested)
                {
                    source.Cancel();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "取消背景工作時發生例外。");
            }
        }

        /// <summary>
        /// 釋放已不再被背景工作使用的取消來源。
        /// </summary>
        private void DisposeCancellationSources()
        {
            if (Interlocked.Exchange(ref _cancellationSourcesDisposed, 1) != 0)
                return;

            _startupCts.Dispose();
            _activationCts.Dispose();
        }

        /// <summary>
        /// 釋放應用程式生命週期協調器的資源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && Interlocked.Exchange(ref _disposeStarted, 1) == 0)
            {
                Application.Idle -= Application_Idle;

                _splash.Shown -= Splash_Shown;
                _splash.AbortClicked -= Splash_AbortClicked;

                if (Volatile.Read(ref _cancellationSourcesDisposed) == 0)
                {
                    CancelSafely(_startupCts);
                    CancelSafely(_activationCts);

                    bool initializationCompleted =
                        _initializationTask == null ||
                        _initializationTask.IsCompleted;

                    bool activationCompleted =
                        _activationTask == null ||
                        _activationTask.IsCompleted;

                    bool shutdownCompleted =
                        _shutdownTask == null ||
                        _shutdownTask.IsCompleted;

                    if (initializationCompleted &&
                        activationCompleted &&
                        shutdownCompleted)
                    {
                        DisposeCancellationSources();
                    }
                }

                if (!_splash.IsDisposed)
                {
                    _splash.CloseFromOwner();
                }

                if (_mainForm != null && !_mainForm.IsDisposed)
                {
                    _allowMainFormClose = true;
                    _mainForm.Close();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>P/Invoke 讓已存在程式跳到前景</summary>
        private static class NativeMethods
        {
            [DllImport("user32.dll")]
            internal static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll")]
            internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        }
    }
}
