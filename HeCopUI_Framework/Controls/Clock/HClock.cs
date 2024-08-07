﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Clock
{
    public class HClock : Control
    {
        Color hrColor = Color.FromArgb(0, 168, 148);
        Color minColor = Color.FromArgb(62, 86, 189);
        Color secColor = Color.RoyalBlue;
        Color ticksColor = Color.Gray;

        public HClock()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);
            timer = new Timer();
            timer.Interval = 600;
            timer.Tick += (s, e) => Invalidate();

            timer.Start();
        }

        Timer timer;

        public Color HourHandColor
        {
            get { return this.hrColor; }
            set { this.hrColor = value; Invalidate(); }
        }

        public Color MinuteHandColor
        {
            get { return this.minColor; }
            set { this.minColor = value; Invalidate(); }
        }

        public Color SecondHandColor
        {
            get { return this.secColor; }
            set
            {
                this.secColor = value;
                Invalidate();
            }
        }

        public Color TicksColor
        {
            get { return this.ticksColor; }
            set { this.ticksColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawClockFace(g);
            DrawHands(g);
        }

        private void DrawClockFace(Graphics g)
        {
            int w = this.Width;
            int h = this.Height;
            float cx = w / 2;
            float cy = h / 2;
            float radius = Math.Min(cx, cy);

            for (int i = 0; i < 60; i++)
            {
                double angle = i * 6 * Math.PI / 180;
                float x1 = (int)(cx + (radius - 10) * Math.Cos(angle));
                float y1 = (int)(cy + (radius - 10) * Math.Sin(angle));
                float x2 = (int)(cx + radius * Math.Cos(angle));
                float y2 = (int)(cy + radius * Math.Sin(angle));
                using (var penTick = new Pen(this.ticksColor, (i % 5 == 0) ? 2 : 1))
                    g.DrawLine(penTick, x1, y1, x2, y2);

                if (i % 5 == 0)
                {
                    string number = (i / 5 == 0) ? "12" : (i / 5).ToString();
                    SizeF numberSize = g.MeasureString(number, this.Font);
                    float nx = (float)(cx + (radius - 30) * Math.Cos(angle) - numberSize.Width / 2);
                    float ny = (float)(cy + (radius - 30) * Math.Sin(angle) - numberSize.Height / 2);
                    using (var brushTick = new SolidBrush(this.ticksColor))
                        g.DrawString(number, this.Font, brushTick, nx, ny);
                }
            }
        }

        private void DrawHands(Graphics g)
        {
            int w = this.Width;
            int h = this.Height;
            float cx = w / 2;
            float cy = h / 2;
            float radius = Math.Min(cx, cy);

            DateTime now = DateTime.Now;
            DrawHandleClock(g, cx, cy, radius - 50, (now.Hour % 12) * 30 + now.Minute * 0.5, this.hrColor, 6);
            DrawHandleClock(g, cx, cy, radius - 30, now.Minute * 6, this.minColor, 4);
            DrawHandleClock(g, cx, cy, radius - 20, now.Second * 6, this.secColor, 2);
        }

        private void DrawHandleClock(Graphics g, float cx, float cy, float length, double angle, Color color, float width)
        {
            angle = angle * Math.PI / 180;
            float x = (float)(cx + length * Math.Cos(angle - Math.PI / 2));
            float y = (float)(cy + length * Math.Sin(angle - Math.PI / 2));
            using (var pen = new Pen(color, width))
                g.DrawLine(pen, cx, cy, x, y);
        }
    }
}
