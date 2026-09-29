using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EmptyWinForms
{
    public partial class Form1 : Form
    {
        // ---------------------------------------------------------
        // 1. Win32 API 與 結構宣告
        // ---------------------------------------------------------
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_INPUT = 0x00FF;
        private const int RID_INPUT = 0x10000003;

        private IntPtr _hookID = IntPtr.Zero;
        private LowLevelKeyboardProc _proc;

        // 記錄你想要攔截的「目標鍵盤 Handle」（透過 Raw Input 取得）
        private static IntPtr _targetDeviceHandle = IntPtr.Zero;
        // 標記當前是否正在按下該目標鍵盤的按鍵
        private static bool _isTargetKeyboardActive = false;

        public Form1()
        {
            InitializeComponent();
            SetupTestControls();

            // 設定 Hook Delegate 避免被 GC 回收
            _proc = HookCallback;
        }

        private void SetupTestControls()
        {
            this.Text = "Raw Input + LL Hook 範例";

            textBox1.Text = "在這裡測試輸入存檔檔名...";
            label1.Text = 
                "說明：\n" +
                "1. 程式啟動後會自動註冊 Raw Input 與鍵盤 Hook。\n" +
                "2. 當偵測到特定副鍵盤輸入時，該按鍵會被攔截，不會影響其他 App。\n" +
                "3. 你上方的 TextBox 依然可以正常打字（不受 RIDEV_NOLEGACY 限制）。";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. 註冊 Raw Input (僅用來接收與辨識 hDevice，不加 RIDEV_NOLEGACY 以免影響本機 TextBox)
            RegisterRawInputDevices();

            // 2. 安裝全域低階鍵盤勾子
            _hookID = SetHook(_proc);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 程式關閉時務必解除 Hook
            UnhookWindowsHookEx(_hookID);
        }

        // ---------------------------------------------------------
        // 2. Raw Input 註冊與訊息處理 (用來辨識硬體裝置)
        // ---------------------------------------------------------
        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTDEVICE
        {
            public ushort usUsagePage;
            public ushort usUsage;
            public uint dwFlags;
            public IntPtr hwndTarget;
        }

        [DllImport("user32.dll")]
        static extern bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices, uint uiNumDevices, uint cbSize);

        [DllImport("user32.dll")]
        static extern uint GetRawInputData(IntPtr hRawInput, uint uiCommand, IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

        private void RegisterRawInputDevices()
        {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];
            rid[0].usUsagePage = 0x01; // Generic Desktop Controls
            rid[0].usUsage = 0x06;     // Keyboard
            rid[0].dwFlags = 0;        // **注意：這裡不加 RIDEV_NOLEGACY**，讓系統正常保留傳統訊息給 TextBox
            rid[0].hwndTarget = this.Handle;

            RegisterRawInputDevices(rid, 1, (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICE)));
        }

        // 覆寫 WndProc 來接收 Raw Input，藉此抓出你要鎖定的特定鍵盤 hDevice
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_INPUT)
            {
                uint dwSize = 0;
                GetRawInputData(
                    m.LParam,
                    RID_INPUT,
                    IntPtr.Zero,
                    ref dwSize,
                    (uint)Marshal.SizeOf(typeof(RAWINPUTheader)));

                if (dwSize > 0)
                {
                    IntPtr pData = Marshal.AllocHGlobal((int)dwSize);
                    try
                    {
                        if (GetRawInputData(
                            m.LParam,
                            RID_INPUT,
                            pData,
                            ref dwSize,
                            (uint)Marshal.SizeOf(typeof(RAWINPUTheader))) == dwSize)
                        {
                            RAWINPUTheader header = (RAWINPUTheader)Marshal.PtrToStructure(pData, typeof(RAWINPUTheader));

                            // header.hDevice 就是這支按鍵對應的實體鍵盤代碼！
                            // 你可以在這裡印出或比對：if (header.hDevice == 你的目標副鍵盤Handle)
                            _targetDeviceHandle = header.hDevice;
                        }
                    }
                    finally
                    {
                        Marshal.FreeHGlobal(pData);
                    }
                }
            }
            base.WndProc(ref m);
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RAWINPUTheader
        {
            public uint dwType;
            public uint dwSize;
            public IntPtr hDevice;
            public IntPtr wParam;
        }

        // ---------------------------------------------------------
        // 3. Low-Level Keyboard Hook (用來攔截並防止影響其他 App)
        //    防止特定鍵盤影響其他 App，但自己 App 的文字輸入框（如存檔檔名）仍能正常運作
        // ---------------------------------------------------------
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        // 核心 Hook 回呼函式：在這裡決定是否「吃掉」按鍵
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                KBDLLHOOKSTRUCT kbStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));

                // 【關鍵邏輯】
                // 如果你希望「特定副鍵盤」完全不影響其他 App：
                // 當前若偵測到是該副鍵盤（透過你剛剛在 WndProc 記錄的 _targetDeviceHandle）正在送出訊號
                // 你可以在這裡回傳 (IntPtr)1 來攔截它！

                // 範例條件：如果你想針對某個裝置進行攔截
                // if (_targetDeviceHandle == 你的目標副鍵盤Handle)
                // {
                //     return (IntPtr)1; // 回傳 1 代表攔截，其他 App 絕對收不到這個按鍵
                // }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
