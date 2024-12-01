using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {
        public IntPtr hwnd;
        public IntPtr hwndAfter;
        public int x;
        public int y;
        public int cx;
        public int cy;
#pragma warning disable CS3003 // Type is not CLS-compliant
        public uint flags;
#pragma warning restore CS3003 // Type is not CLS-compliant
    }
}
