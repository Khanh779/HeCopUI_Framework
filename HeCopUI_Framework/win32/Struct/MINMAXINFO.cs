using System.Drawing;

namespace HeCopUI_Framework.Win32.Struct
{
    public struct MINMAXINFO
    {
#pragma warning disable
        public Point reserved;

        public Size maxSize;

        public Point maxPosition;

        public Size minTrackSize;

        public Size maxTrackSize;


    }
}
