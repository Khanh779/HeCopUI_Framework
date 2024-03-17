using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    public partial class HDotRing : Control
    {
        private List<EllipseInfo> ellipses = new List<EllipseInfo>();
        private Color foregroundColor = Color.FromArgb(241, 241, 241);
        private Timer animationTimer;
        private int ellipseSize = 8;
        int radius = 50;

        public HDotRing()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);

            animationTimer = new Timer();
            animationTimer.Interval = 30;
            animationTimer.Tick += UpdateAnimation;
            animationTimer.Start();

            InitializeEllipses();
        }

        private void InitializeEllipses()
        {
            int numEllipses = 4;
            for (int i = 0; i < numEllipses; i++)
            {
                EllipseInfo ellipse = new EllipseInfo();
                ellipse.Angle = fromPointToAngle(ellipseSize/2, ellipseSize/2)*i/2;
                ellipse.UpdatePosition(1);
                ellipse.EllipseSize = ellipseSize;
                ellipses.Add(ellipse);
            }
        }

    
        private void UpdateAnimation(object sender, EventArgs e)
        {
            foreach (EllipseInfo ellipse in ellipses)
            {
                var a = ellipses.IndexOf(ellipse);
                ellipse.UpdatePosition(ellipse.Angle>= 180 ? a- 1: a+ 1);
            }

            Invalidate();
        }

        int fromPointToAngle(int x, int y)
        {
            int angle = (int)(Math.Atan2(y - Height / 2, x - Width / 2) * 180 / Math.PI);
            if (angle < 0)
                angle += 360;
            return angle;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            foreach (EllipseInfo ellipse in ellipses)
            {
                using (SolidBrush brush = new SolidBrush(foregroundColor))
                {
                    float x = Width / 2 + (radius -  ellipse.EllipseSize) * (float)Math.Cos(ellipse.Angle * Math.PI / 180);
                    float y = Height / 2 + (radius - ellipse.EllipseSize) * (float)Math.Sin(ellipse.Angle * Math.PI / 180);
                    e.Graphics.FillEllipse(brush, x- ellipseSize/2, y - ellipseSize/2, ellipseSize, ellipseSize);
                }
            }
        }


        private void DrawProgressRing3D(Graphics g, SizeF size)
        {
            foreach (EllipseInfo ellipse in ellipses)
            {
                PointF position = ellipse.GetPosition(size);

                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(position.X - ellipseSize / 2, position.Y - ellipseSize / 2, ellipseSize, ellipseSize);

                    using (PathGradientBrush brush = new PathGradientBrush(path))
                    {
                        brush.CenterPoint = position;

                        // Set up the ColorBlend for the gradient
                        ColorBlend colorBlend = new ColorBlend
                        {
                            Colors = new Color[]
                            {
                        Color.FromArgb(255, ellipse.Color),
                        Color.FromArgb(128, ellipse.Color),
                        Color.FromArgb(0, ellipse.Color)
                            },
                            Positions = new float[]
                            {
                        0.0f,
                        0.5f,
                        1.0f
                            }
                        };

                        brush.InterpolationColors = colorBlend;

                        // Set the focus scale to create the 3D effect
                        brush.FocusScales = new PointF(1, 0);

                        // Draw the ellipse
                        g.FillEllipse(brush, position.X - ellipseSize / 2, position.Y - ellipseSize / 2, ellipseSize, ellipseSize);
                    }
                }
            }
        }

    }


    // EllipseInfo class (you can adjust properties as needed)
    public class EllipseInfo
    {
        public float Angle { get; set; }
        public int EllipseSize { get; set; }

        public Color Color { get; set; } = Color.FromArgb(241, 241, 241);

        public void UpdatePosition(float speed)
        {
            Angle += speed;
            if (Angle >= 360)
                Angle =0;
        }

        public PointF GetPosition(SizeF size, int radius=0)
        {
            PointF position = new PointF
            {
                X = size.Width / 2 +(radius- EllipseSize) * (float)Math.Cos(Angle * Math.PI / 180),
                Y = size.Height / 2 +(radius- EllipseSize) * (float)Math.Sin(Angle * Math.PI / 180)
            };
            return position;
        }
    }
}
