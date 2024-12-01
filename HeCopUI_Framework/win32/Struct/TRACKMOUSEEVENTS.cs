using System;

namespace HeCopUI_Framework.Win32.Struct
{
    public struct TRACKMOUSEEVENTS
    {
#pragma warning disable
        public uint cbSize;

        public uint dwFlags;

        public IntPtr hWnd;

        public uint dwHoverTime;
    }
}
