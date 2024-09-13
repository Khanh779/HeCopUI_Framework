using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace HeCopUI_Framework.Controls.Bubble
{
    public class HGreenCircleControl : Control
    {

        public HGreenCircleControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.ContainerControl | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
        }

        public int ProgressValue { get; set; } = 34; // Giá trị phần trăm

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ nền gradient mờ dần
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Tạo vùng hiệu ứng mờ bên ngoài
            using (GraphicsPath outerCircle = new GraphicsPath())
            {
                outerCircle.AddEllipse(0, 0, Width , Height );

                using (PathGradientBrush pgb = new PathGradientBrush(outerCircle))
                {
                    pgb.CenterColor = Color.FromArgb(100, 100, 255, 100); // Màu ở trung tâm
                    pgb.SurroundColors = new Color[] { Color.FromArgb(10, 200, 150, 100) }; // Màu viền

                    g.FillPath(pgb, outerCircle);
                }
            }

            // Tạo vòng tròn màu nền xanh ở giữa
            using (GraphicsPath innerCircle = new GraphicsPath())
            {
                int padding = 20;
                innerCircle.AddEllipse(padding, padding, Width - 2 * padding, Height - 2 * padding);

                using (LinearGradientBrush lgb = new LinearGradientBrush(ClientRectangle, Color.LightGreen, Color.Green, LinearGradientMode.ForwardDiagonal))
                {
                    g.FillPath(lgb, innerCircle);
                }
            }

            // Vẽ giá trị phần trăm
            string percentageText = ProgressValue.ToString() + "%";
            Font font = new Font("Arial", 24, FontStyle.Bold);
            SizeF textSize = g.MeasureString(percentageText, font);
            PointF textPosition = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
            g.DrawString(percentageText, font, Brushes.Green, textPosition);
        }
    }

}
