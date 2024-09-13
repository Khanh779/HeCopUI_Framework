

using HeCopUI_Framework.Win32;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Extensions
{
    internal class Utilites
    {
        /// <summary>
        /// The Brush with two colors one center another surounding the center based on the given rectangle area.
        /// </summary>
        /// <param name="CenterColor">The Center color of the rectangle.</param>
        /// <param name="SurroundColor">The Surrounding color of the rectangle.</param>
        /// <param name="P">The Point of surrounding.</param>
        /// <param name="Rect">The Rectangle of the brush.</param>
        /// <returns>The Brush with two colors one center another surounding the center.</returns>
        public static PathGradientBrush GlowBrush(Color CenterColor, Color SurroundColor, Point P, Rectangle Rect)
        {
            GraphicsPath GP = new GraphicsPath { FillMode = FillMode.Winding };
            GP.AddRectangle(Rect);
            return new PathGradientBrush(GP)
            {
                CenterColor = CenterColor,
                SurroundColors = new[] { SurroundColor },
                FocusScales = P
            };
        }

        /// <summary>
        /// The Brush from RGBA color.
        /// </summary>
        /// <param name="R">Red.</param>
        /// <param name="G">Green.</param>
        /// <param name="B">Blue.</param>
        /// <param name="A">Alpha.</param>
        /// <returns>The Brush from given RGBA color.</returns>
        public SolidBrush SolidBrushRGBColor(int R, int G, int B, int A = 0)
        {
            return new SolidBrush(Color.FromArgb(A, R, G, B));
        }

        /// <summary>
        /// The Brush from HEX color.
        /// </summary>
        /// <param name="C_WithoutHash">HEX Color without hash.</param>
        /// <returns>The Brush from given HEX color.</returns>
        public SolidBrush SolidBrushHTMlColor(string C_WithoutHash)
        {
            return new SolidBrush(HexColor(C_WithoutHash));
        }

        /// <summary>
        /// The Pen from RGBA color.
        /// </summary>
        /// <param name="red">Red.</param>
        /// <param name="green">Green.</param>
        /// <param name="blue">Blue.</param>
        /// <param name="alpha">Alpha.</param>
        /// <param name="size"></param>
        /// <returns>The Pen from given RGBA color.</returns>
        public Pen PenRGBColor(int red, int green, int blue, int alpha, float size)
        {
            return new Pen(Color.FromArgb(alpha, red, green, blue), size);
        }

        /// <summary>
        /// The Pen from HEX color.
        /// </summary>
        /// <param name="colorWithoutHash">HEX Color without hash.</param>
        /// <param name="size">The size of the pen.</param>
        /// <returns></returns>
        public Pen PenHTMlColor(string colorWithoutHash, float size = 1)
        {
            return new Pen(HexColor(colorWithoutHash), size);
        }

        /// <summary>
        /// Gets Color based on given hex color string.
        /// </summary>
        /// <param name="hexColor">Hex Color</param>
        /// <returns>The Color based on given hex color string</returns>
        public Color HexColor(string hexColor)
        {
            return ColorTranslator.FromHtml(hexColor);
        }

        /// <summary>
        /// The Color from HEX by alpha property.
        /// </summary>
        /// <param name="alpha">Alpha.</param>
        /// <param name="hexColor">HEX Color with hash.</param>
        /// <returns>The Color from HEX with given ammount of transparency</returns>
        public Color GetAlphaHexColor(int alpha, string hexColor)
        {
            return Color.FromArgb(alpha, ColorTranslator.FromHtml(hexColor));
        }

        // Check and create handle of control
        // Credits :
        //     control invalidate does not trigger the paint event of hidden or invisible control
        //     see https://stackoverflow.com/questions/38137654
        //     force create handle
        //     see https://stackoverflow.com/questions/1807921/
        /// <summary>
        /// Initialize the Handle of Control and child controls if their handle were not created
        /// </summary>
        public void InitControlHandle(Control ctrl)
        {
            if (ctrl.IsHandleCreated)
                return;
            var unused = ctrl.Handle;
            foreach (Control child in ctrl.Controls)
            {
                InitControlHandle(child);
            }
        }

        /// <summary>
        /// Setting smoothness for hand type cursor especially while hovering controls.
        /// </summary>
        /// <param name="message">Windows message api.</param>
        public void SmoothCursor(ref Message message)
        {
            if (message.Msg != (int)Win32.Enums.WindowMessages.WM_SETCURSOR)
                return;
            Win32.User32.SetCursor(Win32.User32.LoadCursor(IntPtr.Zero, (int)Win32.Enums.IconDataCursorFlags.IDC_HAND));
            message.Result = IntPtr.Zero;
        }

    }
}