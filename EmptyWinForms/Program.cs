using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using Autofac;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace EmptyWinForms
{
    /// <summary>
    /// 應用程式的唯一進入點與 Composition Root。
    /// </summary>
    internal static class Program
    {
        private const string MutexName = @"Local\Company.Product.UniqueAppMutex";

        private static int _uiExceptionHandled;

        /// <summary>
        /// 啟動應用程式，建立全域資源並執行應用程式生命週期。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            bool createdNew = false;

            try
            {
                string pipeName = CreateActivationPipeName();

                using (var mutex = new Mutex(
                    initiallyOwned: true,
                    name: MutexName,
                    createdNew: out createdNew))
                {
                    // 已存在的程序不擁有此 Mutex，不可呼叫 ReleaseMutex。
                    if (!createdNew)
                    {
                        if (!TrySignalExistingInstance(pipeName))
                        {
                            MessageBox.Show(
                                "程式已在執行，但無法傳送視窗啟用訊號。",
                                "程式已執行",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                        return;
                    }

                    try
                    {
                        ConfigureLogging();
                        RegisterGlobalExceptionHandlers();
                        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        // LoggerFactory 由 Program 擁有。
                        using (var loggerFactory = new LoggerFactory())
                        {
                            // LoggerFactory 不負責關閉 Serilog。
                            loggerFactory.AddSerilog(Log.Logger, dispose: false);

                            // 資源釋放順序：
                            // AppStartupContext → Container → LoggerFactory → Serilog。
                            using (var container = BuildContainer(loggerFactory))
                            using (var appContext = new AppStartupContext(
                                container,
                                loggerFactory,
                                pipeName))
                            {
                                Application.Run(appContext);
                            }
                        }
                    }
                    finally
                    {
                        // 建立 Mutex 的執行緒就是持有 Mutex 的執行緒。
                        mutex.ReleaseMutex();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "應用程式啟動失敗。");

                try
                {
                    MessageBox.Show(
                        "應用程式無法啟動。" +
                        Environment.NewLine +
                        ex.Message,
                        "啟動失敗",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // 啟動錯誤處理不得再拋出例外。
                }
            }
            finally
            {
                // 全程序最後才關閉 Serilog。
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// 建立 Serilog 日誌服務。
        /// </summary>
        private static void ConfigureLogging()
        {
            string logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "Company",
                "Product",
                "Logs");

            Directory.CreateDirectory(logDirectory);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override(
                    "Microsoft",
                    LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .Enrich.WithProperty(
                    "Application",
                    "Company.Product")
                .WriteTo.File(
                    Path.Combine(logDirectory, "application-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 31,
                    shared: true)
                .CreateLogger();

            Log.Information("應用程式程序啟動。");
        }

        /// <summary>
        /// 建立 Autofac Container，集中註冊全域服務與應用程式模組。
        /// </summary>
        /// <param name="loggerFactory">由 Program 擁有的 ILoggerFactory。</param>
        private static IContainer BuildContainer(ILoggerFactory loggerFactory)
        {
            var builder = new ContainerBuilder();

            // ILoggerFactory 由 Program 擁有，不由 Container 釋放。
            builder.RegisterInstance(loggerFactory)
                .As<ILoggerFactory>()
                .SingleInstance()
                .ExternallyOwned();

            // Serilog ILogger 由 Program 的 Log.CloseAndFlush() 統一關閉。
            builder.RegisterInstance(Log.Logger)
                .As<Serilog.ILogger>()
                .SingleInstance()
                .ExternallyOwned();

            // 提供 Microsoft.Extensions.Logging.ILogger<T>。
            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();

            RegisterApplicationServices(builder);

            return builder.Build();
        }

        /// <summary>
        /// 註冊應用程式專屬的模組、服務與主視窗。
        /// </summary>
        /// <param name="builder">Autofac ContainerBuilder。</param>
        private static void RegisterApplicationServices(ContainerBuilder builder)
        {
            // 必須在此加入實際方案的註冊，例如：
            //
            // builder.RegisterModule<CoreModule>();
            // builder.RegisterModule<MachineModule>();
            //
            // builder.RegisterType<ApplicationLifecycle>()
            //     .As<IApplicationLifecycle>()
            //     .SingleInstance();
            //
            // builder.RegisterType<MainForm>()
            //     .As<IMainWindow>()
            //     .SingleInstance()
            //     .ExternallyOwned();
        }

        /// <summary>
        /// 註冊全域例外記錄。
        /// </summary>
        private static void RegisterGlobalExceptionHandlers()
        {
            Application.ThreadException += OnUiThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        /// <summary>
        /// 記錄 UI 執行緒中未處理的例外，並要求應用程式正常退出。
        /// </summary>
        private static void OnUiThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try { Log.Fatal(e.Exception, "未處理的 UI 執行緒例外。"); }
            catch { } // 不讓日誌錯誤覆蓋原始例外。

            if (Interlocked.Exchange(ref _uiExceptionHandled, 1) == 0)
            {
                try
                {
                    MessageBox.Show(
                        "應用程式發生未處理的例外，將嘗試停止服務並關閉。" +
                        Environment.NewLine +
                        e.Exception.Message,
                        "執行錯誤",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch
                {
                    // 不讓錯誤提示再次造成未處理例外。
                }
            }

            try { Application.Exit(); }
            catch { } // 全域例外處理不得再拋出例外。
        }

        /// <summary>
        /// 記錄非 UI 執行緒的未處理例外。
        /// </summary>
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                if (e.ExceptionObject is Exception ex)
                {
                    Log.Fatal(ex, "發生未處理的非 UI 執行緒例外。");
                }
                else
                {
                    Log.Fatal("發生未處理的非 UI 例外：{ExceptionObject}", e.ExceptionObject);
                }
            }
            finally
            {
                // 程序可能即將終止，盡可能先寫入日誌。
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// 建立依使用者與 Windows 工作階段區分的具名管道名稱。
        /// </summary>
        private static string CreateActivationPipeName()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            using (Process process = Process.GetCurrentProcess())
            {
                string userId = identity.User != null
                    ? identity.User.Value
                    : Environment.UserName;

                string safeUserId = new string(userId.Select(c => char.IsLetterOrDigit(c) ? c : '_')
                    .ToArray());

                return "Company_Product_Activation_"
                    + process.SessionId
                    + "_"
                    + safeUserId;
            }
        }

        /// <summary>
        /// 通知既有程序啟用視窗。
        /// </summary>
        /// <param name="pipeName">具名管道名稱。</param>
        private static bool TrySignalExistingInstance(string pipeName)
        {
            for (int attempt = 0; attempt < 12; attempt++)
            {
                try
                {
                    using (var client = new NamedPipeClientStream(
                        ".",
                        pipeName,
                        PipeDirection.Out,
                        PipeOptions.None))
                    {
                        client.Connect(150);
                        return true;
                    }
                }
                catch (Exception ex) when (ex is IOException || ex is TimeoutException)
                {
                    Thread.Sleep(100);
                }
            }

            return false;
        }
    }
}