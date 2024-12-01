using System.Drawing;

namespace HeCopUI_Framework.Win32.Struct
{
    public struct POINT
    {
        public int x;

        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public POINT(Point point)
        {
            x = point.X;
            y = point.Y;
        }

        public override string ToString()
        {
            return $"x:{x}, y:{y}";
        }
    }
}
