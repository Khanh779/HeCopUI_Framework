using System.Runtime.InteropServices;

namespace HeCopUI_Framework.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ARGB
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;
    }
}
