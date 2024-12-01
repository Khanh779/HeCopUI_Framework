using HeCopUI_Framework.Structs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Helper
{
    /// <summary>
    /// Defines the <see cref="HeCopUI_Framework.Helper.DrawHelper" />
    /// </summary>
    internal static class DrawHelper
    {
        /// <summary>
        /// Creates a graphics path representing a rectangle with rounded corners.
        /// </summary>
        /// <param name="rectf">The rectangle to create the rounded corner rectangle from.</param>
        /// <param name="radius">The corner radius values for each corner.</param>
        /// <param name="offset">The offset for the rounded corners. Default is 0.</param>
        /// <returns>A graphics path representing the rounded corner rectangle.</returns>
        public static GraphicsPath SetRoundedCornerRectangle(RectangleF rectf, CornerRadius radius, float offset = 0)
        {
            GraphicsPath path = new GraphicsPath();
            var x = rectf.X;
            var y = rectf.Y;
            var width = rectf.Width;
            var height = rectf.Height;

            if (radius.All != 0)
            {
                // Tính toán kích thước các góc với kiểm tra offset
                var topLeft = (int)Math.Max(Math.Min(radius.TopLeft, Math.Min(rectf.Width, rectf.Height)) - offset, 1) * 2;
                var topRight = (int)Math.Max(Math.Min(radius.TopRight, Math.Min(rectf.Width, rectf.Height)) - offset, 1) * 2;
                var bottomLeft = (int)Math.Max(Math.Min(radius.BottomLeft, Math.Min(rectf.Width, rectf.Height)) - offset, 1) * 2;
                var bottomRight = (int)Math.Max(Math.Min(radius.BottomRight, Math.Min(rectf.Width, rectf.Height)) - offset, 1) * 2;

                if (offset > 0) offset /= 2; // Chia offset chỉ nếu nó lớn hơn 0

                // Top-Left Arc
                path.AddArc(new RectangleF(x + offset, y + offset, topLeft, topLeft), 180, 90);
                // Top-Right Arc
                path.AddArc(new RectangleF(x + width - offset - topRight, y + offset, topRight, topRight), 270, 90);
                // Bottom-Right Arc
                path.AddArc(new RectangleF(x + width - offset - bottomRight, y + height - offset - bottomRight, bottomRight, bottomRight), 0, 90);
                // Bottom-Left Arc
                path.AddArc(new RectangleF(x + offset, y + height - offset - bottomLeft, bottomLeft, bottomLeft), 90, 90);

                // Close line (Left)
                path.AddLine(new PointF(x + offset, y + offset + topLeft / 2), new PointF(x + offset, y + height - offset - bottomLeft / 2));
            }
            else
            {
                // Nếu không có góc bo, thêm hình chữ nhật
                path.AddRectangle(new RectangleF(x + offset, y + offset, width - offset, height - offset));
            }

            return path;
        }


        public static GraphicsPath RoundRect(RectangleF rectangle, Padding borderRadius, float offset = 0)
        {
            GraphicsPath path = new GraphicsPath();

            // Điều chỉnh hình chữ nhật theo offset
            rectangle = new RectangleF(rectangle.X + offset, rectangle.Y + offset, rectangle.Width - offset, rectangle.Height - offset);

            // Tính toán đường kính cho từng góc
            float diameterTopLeft = borderRadius.Left * 2;
            float diameterTopRight = borderRadius.Top * 2;
            float diameterBottomRight = borderRadius.Right * 2;
            float diameterBottomLeft = borderRadius.Bottom * 2;

            // Thêm các góc bo
            AddArc(rectangle.X, rectangle.Y, diameterTopLeft, 180f, 90f); // Top-Left Arc
            AddArc(rectangle.Right - diameterTopRight, rectangle.Y, diameterTopRight, 270f, 90f); // Top-Right Arc
            AddArc(rectangle.Right - diameterBottomRight, rectangle.Bottom - diameterBottomRight, diameterBottomRight, 0f, 90f); // Bottom-Right Arc
            AddArc(rectangle.X, rectangle.Bottom - diameterBottomLeft, diameterBottomLeft, 90f, 90f); // Bottom-Left Arc

            // Đóng hình
            path.CloseFigure();
            return path;

            // Hàm phụ để thêm arc vào path
            void AddArc(float x, float y, float diameter, float startAngle, float sweepAngle)
            {
                if (diameter > 0f)
                {
                    RectangleF rect = new RectangleF(x, y, diameter, diameter);
                    path.AddArc(rect, startAngle, sweepAngle);
                }
                else
                {
                    float num4 = 1E-06f;
                    RectangleF rect2 = new RectangleF(x, y, num4, num4);
                    path.AddArc(rect2, startAngle, sweepAngle);
                }
            }
        }


        /// <summary>
        /// Draws a blurred version of the provided graphics path.
        /// </summary>
        /// <param name="graphics">The graphics object used for drawing.</param>
        /// <param name="color">The color of the blurred path.</param>
        /// <param name="graphicsPath">The graphics path to blur and draw.</param>
        /// <param name="max_alpha">The maximum alpha value.</param>
        /// <param name="pen_width">The width of the pen used for drawing.</param>
        public static void DrawBlurred(Graphics graphics, Color color, GraphicsPath graphicsPath, int max_alpha, int pen_width)
        {
            float tmp = max_alpha / pen_width; float actualAlpha = tmp;
            for (int tmp_width = pen_width; tmp_width > 0; tmp_width--)
            {
                Pen blurredPen = new Pen(Color.FromArgb((int)actualAlpha, color), tmp_width) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                actualAlpha += tmp;
                graphics.DrawPath(blurredPen, graphicsPath);
            }
        }

        /// <summary>
        /// Generates a graphics path representing a rounded rectangle with specified radius and width.
        /// </summary>
        /// <param name="Rect">The rectangle to create the rounded rectangle from.</param>
        /// <param name="radius">The corner radius for all corners.</param>
        /// <param name="width">The width of the border. Default is 0.</param>
        /// <returns>A graphics path representing the rounded rectangle.</returns>
        public static GraphicsPath GetRoundPath(RectangleF Rect, float radius, float width = 0)
        {
            //Fix radius to rect size
            radius = (int)Math.Max((Math.Min(radius, Math.Min(Rect.Width, Rect.Height)) - width), 1) * 2;
            //radius *= 2;
            var r2 = (radius / 2f); var w2 = (width / 2f);
            GraphicsPath GraphPath = new GraphicsPath();
            if (radius != 0)
            {
                //Top-Left Arc
                GraphPath.AddArc(Rect.X + w2, Rect.Y + w2, radius, radius, 180, 90);
                //Top-Right Arc
                GraphPath.AddArc(Rect.X + Rect.Width - radius - w2, Rect.Y + w2, radius, radius, 270, 90);
                //Bottom-Right Arc
                GraphPath.AddArc(Rect.X + Rect.Width - w2 - radius, Rect.Y + Rect.Height - w2 - radius, radius, radius, 0, 90);
                //Bottom-Left Arc
                GraphPath.AddArc(Rect.X + w2, Rect.Y - w2 + Rect.Height - radius, radius, radius, 90, 90);
                //Close line ( Left)           
                GraphPath.AddLine(Rect.X + w2, Rect.Y + Rect.Height - r2 - w2, Rect.X + w2, Rect.Y + r2 + w2);
            }
            if (radius == 0) GraphPath.AddRectangle(new RectangleF(Rect.X + w2, Rect.Y + w2, Rect.Width - w2, Rect.Height - w2));
            return GraphPath;
        }


        /// <summary>
        /// Creates a path gradient brush for the provided graphics path.
        /// </summary>
        /// <param name="path">The graphics path to create the brush from.</param>
        /// <param name="bound">The bounding rectangle of the graphics path.</param>
        /// <param name="color1">The center color of the brush.</param>
        /// <param name="color2">The surrounding color of the brush.</param>
        /// <param name="InOut">Indicates whether the center color should be applied inward or outward. Default is true.</param>
        /// <returns>A path gradient brush.</returns>
        public static PathGradientBrush PathBrush(GraphicsPath path, RectangleF bound, Color color1, Color color2, bool InOut = true)
        {
            using (PathGradientBrush brush = new PathGradientBrush(path))
            {

                brush.CenterColor = InOut ? color1 : color2;
                brush.SurroundColors = new Color[] { InOut ? color2 : color1 };
                return brush;
            }
        }

        /// <summary>
        /// Create path rounded edge rectangle border with different radius.
        /// </summary>
        /// <param name="bounds">Gets or sets rectangle of control. <seealso cref="Rectangle">bounds</seealso></param>
        /// <param name="radiusTopLeft">Gets or sets corner radius top left.</param>
        /// <param name="radiusTopRight">Gets or sets corner radius top right. </param>
        /// <param name="radiusBottomLeft">Gets or sets corner radius bottom left.</param>
        /// <param name="radiusBottomRight">Gets or sets corner radius bottom right. </param>
        /// <param name="borderSize">Gets or sets size of border corner. <para>By default the value is <see>0</see>.</para></param>
        /// <returns></returns>
        public static GraphicsPath RoundedRect(RectangleF bounds, float radiusTopLeft, float radiusTopRight, float radiusBottomLeft, float radiusBottomRight, float borderSize = 0)
        {
            float radius1 = radiusTopLeft;
            float radius2 = radiusTopRight;
            float radius3 = radiusBottomLeft;
            float radius4 = radiusBottomRight;
            float width = borderSize;
            radius1 *= 2; radius2 *= 2; radius3 *= 3; radius4 *= 2;
            float w2 = width / 2;
            float diameter1 = radius1 * 2;
            float diameter2 = radius2 * 2;
            float diameter3 = radius3 * 2;
            float diameter4 = radius4 * 2;

            RectangleF arc1 = new RectangleF(bounds.Location, new SizeF(diameter1, diameter1));
            RectangleF arc2 = new RectangleF(bounds.Location, new SizeF(diameter2, diameter2));
            RectangleF arc3 = new RectangleF(bounds.Location, new SizeF(diameter3, diameter3));
            RectangleF arc4 = new RectangleF(bounds.Location, new SizeF(diameter4, diameter4));
            GraphicsPath path = new GraphicsPath();
            arc1.X += w2;
            // top left arc  
            arc1.Y += (w2);
            if (radius1 == 0) path.AddLine(arc1.Location, arc1.Location);
            else path.AddArc(arc1, 180, 90);
            // top right arc  
            arc2.X = bounds.Right - diameter2 - w2; arc2.Y += (w2);
            if (radius2 == 0) path.AddLine(arc2.Location, arc2.Location);
            else path.AddArc(arc2, 270, 90);
            // bottom right arc 
            arc4.X = bounds.Right - diameter4 - w2;
            arc4.Y = bounds.Bottom - diameter4 - w2;
            if (radius4 == 0) path.AddLine(arc4.Location, arc4.Location);
            else path.AddArc(arc4, 0, 90);
            // bottom left arc 
            arc3.X = bounds.Right - diameter3 - w2;
            arc3.Y = bounds.Bottom - diameter3 - w2;
            arc3.X = bounds.Left + w2;
            if (radius3 == 0) path.AddLine(arc3.Location, arc3.Location);
            else path.AddArc(arc3, 90, 90);
            path.AddLine(new PointF(arc1.Location.X, arc1.Location.Y + radius1), arc3.Location);
            //path.ClearMarkers();
            //path.CloseFigure();

            return path;
        }

        /// <summary>
        /// The BlendColor
        /// </summary>
        /// <param name="backgroundColor">The backgroundColor<see cref="Color"/></param>
        /// <param name="frontColor">The frontColor<see cref="Color"/></param>
        /// <param name="blend">The blend<see cref="double"/></param>
        /// <returns>The <see cref="Color"/></returns>
        public static Color BlendColor(Color backgroundColor, Color frontColor, double blend)
        {
            var ratio = blend / 255d;
            var invRatio = 1d - ratio;
            var a = (int)((backgroundColor.A * invRatio) + (frontColor.A * ratio));
            var r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            var g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            var b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// The BlendColor
        /// </summary>
        /// <param name="backgroundColor">The backgroundColor<see cref="Color"/></param>
        /// <param name="frontColor">The frontColor<see cref="Color"/></param>
        /// <returns>The <see cref="Color"/></returns>
        public static Color BlendColor(Color backgroundColor, Color frontColor)
        {
            return BlendColor(backgroundColor, frontColor, frontColor.A);
        }



        /// <summary>
        /// Draws a round shadow around the specified rectangle.
        /// </summary>
        /// <param name="g">The graphics object used for drawing.</param>
        /// <param name="bounds">The rectangle to draw the shadow around.</param>
        public static void DrawRoundShadow(Graphics g, Rectangle bounds)
        {
            using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(12, 0, 0, 0)))
            {
                g.FillEllipse(shadowBrush, new Rectangle(bounds.X - 2, bounds.Y - 1, bounds.Width + 4, bounds.Height + 6));
                g.FillEllipse(shadowBrush, new Rectangle(bounds.X - 1, bounds.Y - 1, bounds.Width + 2, bounds.Height + 4));
                g.FillEllipse(shadowBrush, new Rectangle(bounds.X - 0, bounds.Y - 0, bounds.Width + 0, bounds.Height + 2));
                g.FillEllipse(shadowBrush, new Rectangle(bounds.X - 0, bounds.Y + 2, bounds.Width + 0, bounds.Height + 0));
                g.FillEllipse(shadowBrush, new Rectangle(bounds.X - 0, bounds.Y + 1, bounds.Width + 0, bounds.Height + 0));
            }
        }



    }


}