using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    public partial class HDotProgressRing : Control
    {

        public HDotProgressRing()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            v = new System.Windows.Forms.Timer();
            //v.Interval = Interval;
            v.Tick += V_Tick;

        }

        private void V_Tick(object sender, EventArgs e)
        {
            //v.Interval = Interval;
            if (ProgressStyle == Style.Style1 || ProgressStyle == Style.Style4)
            {
                if (_value + 1 <= dotCount)
                    _value++;
                else
                    _value = 0;
            }

            else if (ProgressStyle == Style.Style5 || ProgressStyle == Style.Style7)
            {
                if (_value < dotCount) _value += 0.5f;
                else _value = 1;



            }
            else if (ProgressStyle == Style.Style6)
            {
                dotPosition = (dotPosition + 1) % (dotCount + 1);

            }
            else
            {
                angle += 10;
                if (angle >= 360) angle = 0;
            }
            Invalidate();
        }

        System.Windows.Forms.Timer v;
        float dotPosition = 0;

        protected override void OnCreateControl()
        {
            if (base.IsHandleCreated)
                if (start)
                    v.Start();
            base.OnCreateControl();
        }

        bool supprtra = true;
        public bool SupportTransparent
        {
            get { return supprtra; }
            set
            {
                supprtra = value; Invalidate();
            }
        }


        float _value = 0;

        int interval = 50;

        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value;
                if (IsHandleCreated) v.Interval = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (supprtra)
            {
                Helper.GraphicsHelper.MakeTransparent(this, e.Graphics);
            }
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                switch (ProgressStyle)
                {
                    case Style.Style1:
                        Style1(e);
                        break;
                    case Style.Style2:
                        Style2(e);
                        break;
                    case Style.Style3:
                        Style3(e);
                        break;
                    case Style.Style4:
                        Style4(e);
                        break;
                    case Style.Style5:
                        Style5(e);
                        break;
                    case Style.Style6:
                        Style6(e);
                        break;
                    case Style.Style7:
                        Style7(e);
                        break;
                    case Style.Style8:
                        Style8(e.Graphics);
                        break;

                }
            }

            base.OnPaint(e);

        }




        private bool start = true;
        public bool StartAnimation
        {
            get { return start; }
            set
            {
                start = value; Invalidate();
                if (start == true)
                {
                    if (IsHandleCreated)
                        if (!DesignMode)
                            v.Start();
                }
                if (start == false)
                {

                    v.Stop();
                }
            }
        }

        int angle = -90;

        public enum Style { Style1, Style2, Style3, Style4, Style5, Style6, Style7, Style8 }

        private Style _style = Style.Style1;
        public Style ProgressStyle
        {
            get { return _style; }
            set
            {
                _style = value; Invalidate(); FixedSize();
            }
        }

        private int radius = 5;
        public int Radius
        {
            get { return radius; }
            set { radius = value; Invalidate(); }
        }

        private int dotCount = 8;
        public int DotCount
        {
            get { return dotCount; }
            set
            {
                dotCount = value;
                if (value < 2) dotCount = 2;
                Invalidate();
            }
        }
        int next = 0;
        Color dotColor = Global.PrimaryColors.BackNormalColor1;
        public Color DotColor
        {
            get { return dotColor; }
            set
            {
                dotColor = value; Invalidate();
            }
        }


        void Style1(PaintEventArgs e)
        {

            float uan = 360 / dotCount;


            e.Graphics.TranslateTransform(Width / 2.0F, Height / 2.0F);
            e.Graphics.RotateTransform(uan * _value - 90);

            for (int i = 1; i <= dotCount; i++)
            {
                int alphaValue = (255.0F * (i / (float)dotCount)) > 255.0 ? 0 : (int)(255.0F * (i / (float)dotCount));
                int alpha = alphaValue;

                Color drawColor = Color.FromArgb(alpha, dotColor);

                using (SolidBrush brush = new SolidBrush(drawColor))
                {

                    float dotX = (float)((Width / 2 - radius * 2) * Math.Cos((i * uan) * Math.PI / 180));
                    float dotY = (float)((Height / 2 - radius * 2) * Math.Sin((i * uan) * Math.PI / 180));
                    //size;
                    e.Graphics.FillEllipse(brush, dotX - radius, dotY - radius, radius * 2, radius * 2);

                }
            }



        }

        void Style2(PaintEventArgs e)
        {
            float uan = 360 / dotCount;
            //e.Graphics.RotateTransform(-90);
            //e.Graphics.TranslateTransform(Width/2.0F, Height / 2.0F);
            int length = Math.Min(Width, Height);
            PointF center = new PointF(length / 2, length / 2);

            for (int i = 1; i <= dotCount; i++)
            {

                float dotX = center.X + (float)((Width / 2 - radius * 2) * Math.Cos((i * uan + angle) * Math.PI / 180));
                float dotY = center.Y + (float)((Width / 2 - radius * 2) * Math.Sin((i * uan + angle) * Math.PI / 180));

                using (Brush brush = new SolidBrush(dotColor))
                    e.Graphics.FillEllipse(brush, dotX - radius, dotY - radius, radius * 2, radius * 2);
            }
        }

        void Style3(PaintEventArgs e)
        {
            //e.Graphics.RotateTransform(-90);
            int length = Math.Min(Width, Height);
            PointF center = new PointF(length / 2, length / 2);
            float bigRadius = length / 2 - radius - (dotCount - 1);
            float unitAngle = 360 / dotCount;
            next++;
            next = next >= dotCount ? 0 : next;
            int a = 0;
            for (int i = next; i < next + dotCount; i++)
            {
                int factor = i % dotCount;
                float c1X = center.X + (float)(bigRadius * Math.Cos(((unitAngle) * factor - 90) * Math.PI / 180));
                float c1Y = center.Y + (float)(bigRadius * Math.Sin(((unitAngle) * factor - 90) * Math.PI / 180));
                float currRad = radius * 2 + a;
                PointF c1 = new PointF(c1X - currRad / 2, c1Y - currRad / 2);
                e.Graphics.FillEllipse(new SolidBrush(dotColor), c1.X, c1.Y, currRad, currRad);
                //using (Pen pen = new Pen(Color.White, 2))
                //e.Graphics.DrawEllipse(pen, c1.X, c1.Y, 2 * currRad, 2 * currRad);
                a++;
            }

        }

        void Style4(PaintEventArgs e)
        {
            float uan = 360 / DotCount;
            e.Graphics.TranslateTransform(Width / 2, Height / 2);
            e.Graphics.RotateTransform(uan * _value - 90);
            for (int i = 0; i < dotCount; i++)
            {
                float dotX = (float)((Width / 2 - radius * 2) * Math.Cos((i * uan) * Math.PI / 180));
                float dotY = (float)((Height / 2 - radius * 2) * Math.Sin((i * uan) * Math.PI / 180));

                using (Brush brush = new SolidBrush((i == 0) ? dotColor : Color.FromArgb(90, dotColor.R, dotColor.G, dotColor.B)))
                    e.Graphics.FillEllipse(brush, dotX - radius, dotY - radius, radius * 2, radius * 2);

            }
        }

        List<int> ints = new List<int>();

        void Style5(PaintEventArgs e)
        {
            using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(160 - (150 * _value / dotCount)), DotColor)))
            {
                var rippleSize = (float)((radius * 4 + 2) * _value / dotCount) - 2;
                e.Graphics.FillEllipse(new SolidBrush(dotColor), new RectangleF(Width / 2 - radius, Height / 2 - radius, radius * 2, radius * 2));
                e.Graphics.DrawEllipse(new Pen(rippleBrush, radius), new RectangleF(Width / 2 - rippleSize / 2, Height / 2 - rippleSize / 2, rippleSize, rippleSize));
            }
        }

        void Style7(PaintEventArgs e)
        {
            using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(160 - (150 * _value / dotCount)), DotColor)))
            {
                var rippleSize = (float)((radius * 4 + 2) * _value / dotCount) - 2;
                e.Graphics.FillEllipse(rippleBrush, new RectangleF(Width / 2 - rippleSize / 2, Height / 2 - rippleSize / 2, rippleSize, rippleSize));
            }
        }

        void Style6(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(DotColor))
            {
                float height = radius * 2;

                // Draw the dots
                for (int i = 1; i <= dotCount; i++)
                {
                    float x = (int)((Width) * (i) / (dotCount + 1) - height / 2.0);
                    float y = (int)(Height / 2.0 - height / 2.0);

                    if (i == dotPosition)
                    {
                        // Draw the active dot with the same color as the text
                        e.Graphics.FillEllipse(brush, x + 1, y, height, height);
                    }
                    else
                    {
                        // Draw the inactive dots with half the opacity of the text color
                        Color inactiveColor = Color.FromArgb(90, DotColor);
                        using (SolidBrush inactiveBrush = new SolidBrush(inactiveColor))
                        {
                            e.Graphics.FillEllipse(inactiveBrush, x + 1, y, height, height);
                        }
                    }
                }
            }
        }

        void Style8(Graphics g)
        {
            float x = Width / 2;
            float y = Height / 2;
            LinearGradientBrush lb = new LinearGradientBrush(ClientRectangle, DotColor, DotColor, 2);

            var ro = angle;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = -1; i < dotCount; i++)
            {
                if (i > -1)
                {
                    float douangle = i * (360 / (dotCount - 1)) + ro;
                    float toadoX = (float)(x + (radius * 4 - 2) * Math.Cos(douangle * Math.PI / 180));
                    float toadoY = (float)(y + (radius * 4 - 2) * Math.Sin(douangle * Math.PI / 180));

                    //  if (!_Reverse)
                    {
                        if (douangle <= 360 && douangle >= 0)
                        {
                            g.FillEllipse(lb, toadoX - radius, toadoY - radius, radius * 2, radius * 2); // Center the dot
                        }
                    }
                    //else
                    //{
                    //    if (douangle <= MaxAngle && douangle >= MinAngle)
                    //    {
                    //        g.FillEllipse(lb, toadoX - LoaderThickness, toadoY - LoaderThickness, LoaderThickness * 2, LoaderThickness * 2); // Center the dot
                    //    }
                    //}
                }

            }
        }

        void FixedSize()
        {
            if (ProgressStyle != Style.Style6)
                Size = new Size(Math.Min(Width, Height), Math.Min(Width, Height));
        }

        protected override void OnResize(EventArgs e)
        {
            FixedSize();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            FixedSize();
            base.OnSizeChanged(e);
        }

    }



}
