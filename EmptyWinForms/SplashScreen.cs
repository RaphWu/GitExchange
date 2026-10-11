using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EmptyWinForms
{
    /// <summary>
    /// 顯示應用程式初始化狀態並提供取消啟動的介面。
    /// </summary>
    internal sealed class SplashScreen : Form
    {
        private const int MaxMessageCount = 9;

        private readonly Label _statusLabel;
        private readonly TextBox _messageTextBox;
        private readonly Button _cancelButton;

        private readonly LinkedList<string> _messages = new LinkedList<string>();

        private bool _allowClose;

        /// <summary>
        /// 當使用者要求取消啟動時觸發。
        /// </summary>
        internal event EventHandler? AbortClicked;

        /// <summary>
        /// 建立啟動畫面及其 UI 控制項。
        /// </summary>
        public SplashScreen()
        {
            Text = "Application Startup";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            ClientSize = new Size(620, 340);
            BackColor = Color.White;

            _statusLabel = new Label
            {
                AutoSize = false,
                Location = new Point(18, 18),
                Size = new Size(584, 28),
                Font = new Font(
                    SystemFonts.MessageBoxFont.FontFamily,
                    11F,
                    FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "準備啟動..."
            };

            _messageTextBox = new TextBox
            {
                Location = new Point(18, 52),
                Size = new Size(584, 230),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                WordWrap = true,
                TabStop = false
            };

            _cancelButton = new Button
            {
                Location = new Point(482, 296),
                Size = new Size(120, 28),
                Text = "取消啟動",
                UseVisualStyleBackColor = true
            };

            _cancelButton.Click += CancelButton_Click;
            FormClosing += SplashScreen_FormClosing;

            Controls.Add(_statusLabel);
            Controls.Add(_messageTextBox);
            Controls.Add(_cancelButton);
        }

        /// <summary>
        /// 顯示一則初始化進度訊息。
        /// </summary>
        internal void Report(string message)
        {
            if (IsDisposed || string.IsNullOrWhiteSpace(message))
                return;

            // 本方法允許由非 UI 執行緒呼叫，但不使用同步 Invoke。
            if (InvokeRequired)
            {
                try
                {
                    BeginInvoke(new Action<string>(Report), message);
                }
                catch (InvalidOperationException)
                {
                    // 表單正在關閉或已失去可用的視窗控制代碼。
                }

                return;
            }

            _statusLabel.Text = message;
            _messages.AddLast($"{DateTime.Now:HH:mm:ss}  {message}");
            while (_messages.Count > MaxMessageCount)
            {
                _messages.RemoveFirst();
            }

            _messageTextBox.Lines = _messages.ToArray();
            _messageTextBox.SelectionStart = _messageTextBox.TextLength;
            _messageTextBox.ScrollToCaret();
        }

        /// <summary>
        /// 設定取消按鈕是否可操作。
        /// </summary>
        internal void SetCancelEnabled(bool enabled)
        {
            if (IsDisposed)
                return;

            if (InvokeRequired)
            {
                try
                {
                    BeginInvoke(new Action<bool>(SetCancelEnabled), enabled);
                }
                catch (InvalidOperationException)
                {
                    // 表單關閉時不再處理 UI 更新。
                }

                return;
            }

            _cancelButton.Enabled = enabled;
        }

        /// <summary>
        /// 由生命週期協調器正式關閉啟動畫面。
        /// </summary>
        internal void CloseFromOwner()
        {
            _allowClose = true;

            if (!IsDisposed)
            {
                Close();
            }
        }

        /// <summary>
        /// 將使用者的關閉要求轉換為取消事件，避免直接關閉啟動畫面。
        /// </summary>
        private void SplashScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowClose)
                return;

            // Alt+F4 等關閉要求也必須經過統一的停止流程。
            e.Cancel = true;
            AbortClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// 回報使用者按下取消啟動按鈕。
        /// </summary>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            AbortClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
