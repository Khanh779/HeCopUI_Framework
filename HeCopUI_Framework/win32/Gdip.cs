using System;
using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32
{

    internal class Gdip
    {
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public static extern int GdipCreateHICONFromBitmap(HandleRef nativeBitmap, out IntPtr hicon);
    }
}