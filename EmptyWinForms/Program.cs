using System;
using System.Windows.Forms;

namespace EmptyWinForms
{
    /// <summary>
    /// 應用程式的唯一進入點與 Composition Root。
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 啟動應用程式，建立全域資源並執行應用程式生命週期。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}