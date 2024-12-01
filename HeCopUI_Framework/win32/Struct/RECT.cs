using System;
using System.Drawing;

namespace HeCopUI_Framework.Win32.Struct
{
    public struct RECT
    {
        public int left;

        public int top;

        public int right;

        public int bottom;

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Left
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Right
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Top
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
            }
        }

#pragma warning disable CS3005 // Identifier differing only in case is not CLS-compliant
        public int Bottom
#pragma warning restore CS3005 // Identifier differing only in case is not CLS-compliant
        {
            get
            {
                return bottom;
            }
            set
            {
                bottom = value;
            }
        }

        public POINT Location
        {
            get
            {
                return new POINT(left, top);
            }
            set
            {
                right -= left - value.x;
                bottom -= bottom - value.y;
                left = value.x;
                top = value.y;
            }
        }

        public int Width
        {
            get
            {
                return Math.Abs(right - left);
            }
            set
            {
                right = left + value;
            }
        }

        public int Height
        {
            get
            {
                return Math.Abs(bottom - top);
            }
            set
            {
                bottom = top + value;
            }
        }

        public RECT(int left, int top, int width, int height)
        {
            this.left = left;
            this.top = top;
            right = this.left + width;
            bottom = this.top + height;
        }

        public RECT(Rectangle r)
        {
            left = r.Left;
            top = r.Top;
            right = r.Right;
            bottom = r.Bottom;
        }

        public Rectangle ToRectangle()
        {
            return Rectangle.FromLTRB(Left, Top, Right, Bottom);
        }

        public void Inflate(int width, int height)
        {
            Left -= width;
            Top -= height;
            Right += width;
            Bottom += height;
        }

        public void Set(Rectangle rect)
        {
            left = rect.Left;
            top = rect.Top;
            right = rect.Right;
            bottom = rect.Bottom;
        }

        public override string ToString()
        {
            return $"x:{Left},y:{Top},width:{Right - Left},height:{Bottom - Top}";
        }

        public static explicit operator Rectangle(RECT rect)
        {
            return new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);
        }
    }
}
