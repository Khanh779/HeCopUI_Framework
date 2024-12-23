﻿using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct WNDCLASS
    {
#pragma warning disable
        public uint style;

        public IntPtr lpfnWndProc;

        public int cbClsExtra;

        public int cbWndExtra;

        public IntPtr hInstance;

        public IntPtr hIcon;

        public IntPtr hCursor;

        public IntPtr hbrBackground;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszMenuName;

        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpszClassName;
    }

}
