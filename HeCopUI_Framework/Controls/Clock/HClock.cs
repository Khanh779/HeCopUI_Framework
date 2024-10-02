using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Clock
{
    public class HClock : Control
    {
        Color hrColor = Color.White;
        Color minColor = Color.LightBlue;
        Color secColor = Color.Cyan;
        Color ticksColor = Color.WhiteSmoke;

        Color clockBackColor1 = Color.FromArgb(45, 45, 45);
        Color clockBackColor2 = Color.FromArgb(64, 64, 64);

        Timer timer;

        public HClock()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            timer = new Timer { Interval = 900 };
            timer.Tick += (s, e) => Invalidate();
            timer.Start();
        }

        public Color HourHandColor
        {
            get => hrColor;
            set { hrColor = value; Invalidate(); }
        }

        public Color MinuteHandColor
        {
            get => minColor;
            set { minColor = value; Invalidate(); }
        }

        public Color SecondHandColor
        {
            get => secColor;
            set { secColor = value; Invalidate(); }
        }

        public Color TicksColor
        {
            get => ticksColor;
            set { ticksColor = value; Invalidate(); }
        }

        public Color ClockBackColor1
        {
            get { return clockBackColor1; }
            set
            {
                clockBackColor1 = value;
                Invalidate();
            }
        }

        public Color ClockBackColor2
        {
            get { return clockBackColor2; }
            set
            {
                clockBackColor2 = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var brush = new LinearGradientBrush(ClientRectangle, clockBackColor1, clockBackColor2, 45f))
                g.FillEllipse(brush, ClockBounds(5));

            DrawClockFace(g, ClockBounds(5), 0);
            DrawHands(g, ClockBounds());

            int sizeRad = 8;
            using (SolidBrush sb = new SolidBrush(Color.DarkGray))
                g.FillEllipse(sb, Width / 2 - sizeRad, Height / 2 - sizeRad, sizeRad * 2, sizeRad * 2);
        }

        RectangleF ClockBounds(float offset = 0)
        {
            float radius = Math.Min(Width, Height) / 2 - offset;
            return new RectangleF((Width - 2 * radius) / 2, (Height - 2 * radius) / 2, 2 * radius, 2 * radius);
        }

        private void DrawClockFace(Graphics g, RectangleF rectClockBounds, float offSetTick = 0)
        {
            RectangleF clockBounds = rectClockBounds;
            float cx = clockBounds.X + clockBounds.Width / 2;
            float cy = clockBounds.Y + clockBounds.Height / 2;
            float radius = clockBounds.Width / 2;

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            for (int i = 0; i < 60; i++)
            {
                double angle = i * 6 * Math.PI / 180;
                float x1 = cx + (radius - 10) * (float)Math.Cos(angle);
                float y1 = cy + (radius - 10) * (float)Math.Sin(angle);
                float x2 = cx + radius * (float)Math.Cos(angle);
                float y2 = cy + radius * (float)Math.Sin(angle);
                using (var penTick = new Pen(ticksColor, (i % 5 == 0) ? 2 : 1))
                    g.DrawLine(penTick, x1, y1, x2, y2);

                if (i % 5 == 0)
                {
                    string number = (i / 5 == 0) ? "12" : (i / 5).ToString();
                    SizeF numberSize = g.MeasureString(number, Font);
                    float nx = cx + (radius - 20 - offSetTick) * (float)Math.Cos(angle) - numberSize.Width / 2;
                    float ny = cy + (radius - 20 - offSetTick) * (float)Math.Sin(angle) - numberSize.Height / 2;
                    using (var sb = new SolidBrush(ticksColor))
                        g.DrawString(number, Font, sb, nx, ny);
                }
            }
        }

        private void DrawHands(Graphics g, RectangleF rectClockBounds)
        {
            DateTime now = DateTime.Now;
            RectangleF clockBounds = rectClockBounds;
            float cx = clockBounds.X + clockBounds.Width / 2;
            float cy = clockBounds.Y + clockBounds.Height / 2;
            float radius = clockBounds.Width / 2;


            DrawHandleClock(g, cx, cy, radius - 50, (now.Hour % 12) * 30 + now.Minute * 0.5, hrColor, 6);
            DrawHandleClock(g, cx, cy, radius - 30, now.Minute * 6, minColor, 4);
            DrawHandleClock(g, cx, cy, radius - 20, now.Second * 6, secColor, 2);
        }


        private void DrawHandleClock(Graphics g, float cx, float cy, float length, double angle, Color color, float width)
        {
            angle = angle * Math.PI / 180;
            float x = cx + length * (float)Math.Cos(angle - Math.PI / 2);
            float y = cy + length * (float)Math.Sin(angle - Math.PI / 2);
            using (var pen = new Pen(color, width))
                g.DrawLine(pen, cx, cy, x, y);
        }

    }
}
