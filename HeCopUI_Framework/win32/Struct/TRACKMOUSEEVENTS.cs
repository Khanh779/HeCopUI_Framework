using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
