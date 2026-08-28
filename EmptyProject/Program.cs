using ACadSharp;
using ACadSharp.IO;

class Program
{
    /// <summary>
    /// 註冊監聽原始輸入設備。
    /// </summary>
    /// <param name="pRawInputDevices">原始輸入裝置集。</param>
    /// <param name="uiNumDevices">裝置集的元素個數。</param>
    /// <param name="cbSize">原始輸入裝置資訊所佔用的位元組數。</param>
    /// <returns>若執行成功則傳回 true，否則為 false，可透過呼叫 GetLastError 方法來取得更多關於失敗的資訊。</returns>
    [DllImport("User32.dll", SetLastError = true)]
    internal static extern bool RegisterRawInputDevices(
        RawInputDevice[] pRawInputDevices,
        uint uiNumDevices,
        uint cbSize);

    /// <summary>
    /// 定義原始資料設備訊息。
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct RawInputDevice
    {
        /// <summary>頂層集合用法頁，介面裝置用法頁。</summary>
        internal HidUsagePage usUsagePage;

        /// <summary>頂層集合用法，即監聽設備標識。</summary>
        internal HidUsage usUsage;

        /// <summary>
        /// 模式標識，指示如何解釋處理由用法頁和用法提供的信息。<br/>
        /// 預設為 Zero 時，作業系統會在已經註冊的應用程式視窗獲得焦點時，傳送頂級集合指定的裝置原始數據。
        /// </summary>
        internal RawInputDeviceFlags dwFlags;

        /// <summary>與監聽裝置關聯的目標視窗句柄，如果為空，則遵循鍵盤焦點。</summary>
        internal IntPtr hwndTarget;
    }

    public RawKeyBoard(IntPtr hwnd, bool captureOnlyInForeground)
    {
        var rid = new RawInputDevice[1];

        rid[0].usUsagePage = HidUsagePage.GENERIC;
        rid[0].usUsage = HidUsage.Keyboard;
        rid[0].dwFlags =
            (captureOnlyInForeground
                ? RawInputDeviceFlags.UNDEFINE
                : RawInputDeviceFlags.RIDEV_INPUTSINK)
            | RawInputDeviceFlags.RIDEV_DEVNOTIFY;
        rid[0].hwndTarget = hwnd;

        if (!Win32API.RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
        {
            throw new ApplicationException("註冊設備失敗！");
        }
    }

    protected override void WndProc(ref Message message)
    {
        switch (message.Msg)
        {
            case WinMessage.WM_INPUT:
                {
                    keyBoardDriver.ProcessRawInput(message.LParam);
                }
                break;
            case WinMessage.WM_USB_DEVICECHANGE:
                {
                    keyBoardDriver.EnumerateDevices();
                }
                break;
        }
        base.WndProc(ref message);
    }


    [DllImport("User32.dll", SetLastError = true)]
    internal static extern int GetRawInputData(
        IntPtr hRawInput,
        RawInputDataCommand command,
        [Out] IntPtr pData,
        [In, Out] ref int size,
        int sizeHeader);



    /// <summary>
    /// 包含來自裝置的原始輸入
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct RAWINPUT
    {
        [FieldOffset(0)]
        internal RAWMOUSE mouse;
        [FieldOffset(0)]
        internal RAWKEYBOARD keyboard;
        [FieldOffset(0)]
        internal RAWHID hid;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWHID
    {
        public uint dwSizHid;
        public uint dwCount;
        public byte bRawData;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct RAWMOUSE
    {
        [FieldOffset(0)]
        public ushort usFlags;
        [FieldOffset(4)]
        public uint ulButtons;
        [FieldOffset(4)]
        public ushort usButtonFlags;
        [FieldOffset(6)]
        public ushort usButtonData;
        [FieldOffset(8)]
        public uint ulRawButtons;
        [FieldOffset(12)]
        public int lLastX;
        [FieldOffset(16)]
        public int lLastY;
        [FieldOffset(20)]
        public uint ulExtraInformation;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RAWKEYBOARD
    {
        public ushort Makecode;
        public ushort Flags;
        private readonly ushort Reserved;
        public ushort VKey;
        public uint Message;
        public uint ExtraInformation;
    }

    public int ProcessRawInput(IntPtr hdevice)
    {
        if (deviceList.Count == 0) return 0;
        var dwSize = 0;
        Win32API.GetRawInputData(hdevice, RawInputDataCommand.RID_INPUT, IntPtr.Zero, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader)));
        if (dwSize != Win32API.GetRawInputData(hdevice, RawInputDataCommand.RID_INPUT, out _rawBuffer, ref dwSize, Marshal.SizeOf(typeof(Rawinputheader))))
        {
            return 1;
        }
        int virtualKey = _rawBuffer.data.keyboard.VKey;
        int makeCode = _rawBuffer.data.keyboard.Makecode;
        int flags = _rawBuffer.data.keyboard.Flags;
        if (virtualKey == WinMessage.KEYBOARD_OVERRUN_MAKE_CODE) return 0;
        var isE0BitSet = ((flags & WinMessage.RI_KEY_E0) != 0);
        KeyPressEvent keyPressEvent;
        if (deviceList.ContainsKey(_rawBuffer.header.hDevice))
        {
            lock (padLock)
            {
                keyPressEvent = deviceList[_rawBuffer.header.hDevice];
            }
        }
        else
        {
            return 2;
        }
        var isBreakBitSet = ((flags & WinMessage.RI_KEY_BREAK) != 0);
        keyPressEvent.KeyPressState = isBreakBitSet ? "BREAK" : "MAKE";
        keyPressEvent.Message = _rawBuffer.data.keyboard.Message;
        keyPressEvent.VKeyName = KeyMapper.GetKeyName(VirtualKeyCorrection(virtualKey, isE0BitSet, makeCode)).ToUpper();
        keyPressEvent.VKey = virtualKey;
        if (KeyPressed != null)
        {
            hotkeyPressEvent.CheckKey(keyPressEvent);
            KeyPressed(this, new RawKeyEventArg(keyPressEvent));
        }
        if (hotkeyPressEvent.hotActived)
        {
            OnHotKeyPressed(this, new RawHotKeyEventArg(hotkeyPressEvent));
        }
        return 0;
    }


    static void Main()
    {

        var dwSize = 0;
        Win32.GetRawInputData(
            hdevice,
            RawInputDataCommand.RID_INPUT,
            IntPtr.Zero,
            ref dwSize,
            Marshal.SizeOf(typeof(Rawinputheader)));

        if (dwSize == Win32.GetRawInputData(
            hdevice,
            RawInputDataCommand.RID_INPUT,
            out _rawBuffer,
            ref dwSize,
            Marshal.SizeOf(typeof(Rawinputheader))))
        {
            //dosomething...
        }


    }
}