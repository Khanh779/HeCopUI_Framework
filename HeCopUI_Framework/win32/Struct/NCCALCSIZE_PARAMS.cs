using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NCCALCSIZE_PARAMS
    {
        public RECT rcOldWindow;
        public RECT rcNewWindow;
        public RECT rcClient;
        //public RECT rectProposed;
        public IntPtr lppos;

    }
}
