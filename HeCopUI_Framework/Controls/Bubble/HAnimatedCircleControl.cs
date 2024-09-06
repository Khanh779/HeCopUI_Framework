using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Bubble
{
    public class HAnimatedCircleControl : Control
    {
        private Timer timer;
        private float angleOffset = 0;
        private float waveAmplitude = 5;
        private float waveFrequency = 4;
        private float hue = 0;

        public HAnimatedCircleControl()
        {
            this.DoubleBuffered = true;
            timer = new Timer();
            timer.Interval = 30; // Thời gian cập nhật (ms)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angleOffset += 0.05f;
            if (angleOffset > Math.PI * 2) angleOffset -= (float)(Math.PI * 2);

            hue += 1;
            if (hue > 360) hue -= 360;
            this.Invalidate(); // Yêu cầu vẽ lại control
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float centerX = this.Width / 2f;
            float centerY = this.Height / 2f;
            float radius = Math.Min(this.Width, this.Height) / 2f - 10;

            PointF[] points = new PointF[360];
            for (int i = 0; i < points.Length; i++)
            {
                float angle = i * (float)Math.PI / 180f;
                float wave = (float)Math.Sin(angle * waveFrequency + angleOffset) * waveAmplitude;
                float r = radius + wave;

                points[i] = new PointF(
                    centerX + (float)Math.Cos(angle) * r,
                    centerY + (float)Math.Sin(angle) * r
                );
            }

            // Tạo hiệu ứng gradient
            //using (GraphicsPath path = new GraphicsPath())
            //{
            //    path.AddPolygon(points);
            //    using (PathGradientBrush brush = new PathGradientBrush(path))
            //    {
            //        brush.CenterColor = Color.FromArgb(255, 0, 255, 255); // Màu trung tâm
            //        brush.SurroundColors = new Color[] { Color.FromArgb(255, 0, 128, 255) }; // Màu viền
            //        g.FillPath(brush, path);
            //    }
            //}

            // Chuyển đổi hue thành màu RGB
            Color centerColor = ColorFromHSV(hue, 1, 1);
            Color surroundColor = ColorFromHSV((hue + 180) % 360, 1, 1);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddPolygon(points);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = centerColor;
                    brush.SurroundColors = new Color[] { surroundColor };
                   g.FillPath(brush, path);
                }
            }
        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }
    }
}
