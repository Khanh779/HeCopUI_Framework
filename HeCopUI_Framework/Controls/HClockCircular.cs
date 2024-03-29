﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(HClockCircular), "Bitmaps.CircleProgress.bmp")]
    public partial class HClockCircular : UserControl
    {
        const float PI = 3.141592654F;

        DateTime dTime;

        float fRadius, fCenterX, fCenterY, fCenterCircleRadius, fHourLength;
        float fMinLength, fSecLength, fHourThickness, fMinThickness, fSecThickness;
        bool bDraw5MinuteTicks = true;
        bool bDraw1MinuteTicks = true;
        float fTicksThickness = 3;


        Color hrColor = Color.FromArgb(0, 168, 148);
        Color minColor = Color.FromArgb(62, 86, 189);
        Color secColor = Color.RoyalBlue;
        Color circleColor = Color.Lime;
        Color ticksColor = Color.Gray;

        public HClockCircular()
        {
            timer1 = new Timer();
            timer1.Interval = 1000;
            SetStyle(GetAppResources.SetControlStyles(), true);

            DoubleBuffered = true;



            timer1.Tick += timer1_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {
            dTime = DateTime.Now;
            this.OnResize(e);
            base.OnLoad(e);
        }

        protected override void OnCreateControl()
        {

            base.OnCreateControl();
        }



        public int Interval
        {
            get { return timer1.Interval; }
            set
            {
                timer1.Interval = value; Invalidate();
            }
        }

        Timer timer1;



        private void timer1_Tick(object sender, EventArgs e)
        {
            this.dTime = DateTime.Now;
            this.Refresh();
        }

        private void DrawLine(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(color, fThickness),
                fCenterX - (float)(fLength / 9 * System.Math.Sin(fRadians)),
                fCenterY + (float)(fLength / 9 * System.Math.Cos(fRadians)),
                fCenterX + (float)(fLength * System.Math.Sin(fRadians)),
                fCenterY - (float)(fLength * System.Math.Cos(fRadians)));
        }
        private void DrawPolygon(float fThickness, float fLength, Color color, float fRadians, System.Windows.Forms.PaintEventArgs e)
        {

            PointF A = new PointF((float)(fCenterX + fThickness * 2 * System.Math.Sin(fRadians + PI / 2)),
                (float)(fCenterY - fThickness * 2 * System.Math.Cos(fRadians + PI / 2)));
            PointF B = new PointF((float)(fCenterX + fThickness * 2 * System.Math.Sin(fRadians - PI / 2)),
                (float)(fCenterY - fThickness * 2 * System.Math.Cos(fRadians - PI / 2)));
            PointF C = new PointF((float)(fCenterX + fLength * System.Math.Sin(fRadians)),
                (float)(fCenterY - fLength * System.Math.Cos(fRadians)));
            PointF D = new PointF((float)(fCenterX - fThickness * 4 * System.Math.Sin(fRadians)),
                (float)(fCenterY + fThickness * 4 * System.Math.Cos(fRadians)));
            PointF[] points = { A, D, B, C };
            e.Graphics.FillPolygon(new SolidBrush(color), points);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            float fRadHr = (dTime.Hour % 12 + dTime.Minute / 60F) * 30 * PI / 180;
            float fRadMin = (dTime.Minute) * 6 * PI / 180;
            float fRadSec = (dTime.Second) * 6 * PI / 180;
            GetAppResources.GetControlGraphicsEffect(e.Graphics);
            DrawPolygon(this.fHourThickness, this.fHourLength, hrColor, fRadHr, e);
            DrawPolygon(this.fMinThickness, this.fMinLength, minColor, fRadMin, e);
            DrawLine(this.fSecThickness, this.fSecLength, secColor, fRadSec, e);


            for (int i = 0; i < 60; i++)
            {
                if (this.bDraw5MinuteTicks == true && i % 5 == 0) // Draw 5 minute ticks
                {
                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                        fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                        fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                        fCenterX + (float)(this.fRadius / 1.65F * System.Math.Sin(i * 6 * PI / 180)),
                        fCenterY - (float)(this.fRadius / 1.65F * System.Math.Cos(i * 6 * PI / 180)));
                }
                else if (this.bDraw1MinuteTicks == true) // draw 1 minute ticks
                {

                    e.Graphics.DrawLine(new Pen(ticksColor, fTicksThickness),
                        fCenterX + (float)(this.fRadius / 1.50F * System.Math.Sin(i * 6 * PI / 180)),
                        fCenterY - (float)(this.fRadius / 1.50F * System.Math.Cos(i * 6 * PI / 180)),
                        fCenterX + (float)(this.fRadius / 1.55F * System.Math.Sin(i * 6 * PI / 180)),
                        fCenterY - (float)(this.fRadius / 1.55F * System.Math.Cos(i * 6 * PI / 180)));
                }
            }

            //draw circle at center
            e.Graphics.FillEllipse(new SolidBrush(circleColor), fCenterX - fCenterCircleRadius / 2, fCenterY - fCenterCircleRadius / 2, fCenterCircleRadius, fCenterCircleRadius);
        }



        protected override void OnResize(EventArgs e)
        {
            this.Width = this.Height;
            this.fRadius = this.Height / 2;
            this.fCenterX = this.ClientSize.Width / 2;
            this.fCenterY = this.ClientSize.Height / 2;
            this.fHourLength = (float)this.Height / 3 / 1.85F;
            this.fMinLength = (float)this.Height / 3 / 1.20F;
            this.fSecLength = (float)this.Height / 3 / 1.15F;
            this.fHourThickness = (float)this.Height / 100;
            this.fMinThickness = (float)this.Height / 150;
            this.fSecThickness = (float)this.Height / 200;
            this.fCenterCircleRadius = this.Height / 50;
            timer1.Start();
            base.OnResize(e);
        }
        public Color HourHandColor
        {
            get { return this.hrColor; }
            set { this.hrColor = value; }
        }

        public Color MinuteHandColor
        {
            get { return this.minColor; }
            set { this.minColor = value; }
        }

        public Color SecondHandColor
        {
            get { return this.secColor; }
            set
            {
                this.secColor = value;
                this.circleColor = value;
            }
        }

        public Color TicksColor
        {
            get { return this.ticksColor; }
            set { this.ticksColor = value; }
        }

        public bool Draw1MinuteTicks
        {
            get { return this.bDraw1MinuteTicks; }
            set { this.bDraw1MinuteTicks = value; }
        }

        public bool Draw5MinuteTicks
        {

            get { return this.bDraw5MinuteTicks; }
            set { this.bDraw5MinuteTicks = value; }
        }



    }
}
