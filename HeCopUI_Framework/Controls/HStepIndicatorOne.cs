﻿using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public class HStepIndicatorOne : Control
    {
        public HStepIndicatorOne()
        {

            SetStyle(GetAppResources.SetControlStyles(), true);
        }

        private int step = 3;
        public int Steps
        {
            get { return step; }
            set
            {
                if (value <= 1) step = 2;
                else step = value;
                Invalidate();
            }
        }

        private int radisbi = 20;
        public int RadiusBig
        {
            get { return radisbi; }
            set
            {
                radisbi = value; Invalidate();
            }
        }

        private int radisSma = 15;
        public int RadiusSmall
        {
            get { return radisSma; }
            set
            {
                radisSma = value; Invalidate();
            }
        }

        private int bgHe = 10;
        public int BGHeight
        {
            get { return bgHe; }
            set
            {
                bgHe = value; Invalidate();
            }
        }

        Color indicatorBarColor1 = Global.PrimaryColors.BaseProgressBarColor1;
        public Color IndicatorBarColor1
        {
            get { return indicatorBarColor1; }
            set
            {
                indicatorBarColor1 = value; Invalidate();
            }
        }

        private Color indicatorStepColor1 = Global.PrimaryColors.ProgressBarColor1;

        public Color IndicatorStepColor1
        {
            get { return indicatorStepColor1; }
            set
            {
                indicatorStepColor1 = value; Invalidate();
            }
        }

        Color indicatorBarColor2 = Global.PrimaryColors.BaseProgressBarColor2;
        public Color IndicatorBarColor2
        {
            get { return indicatorBarColor2; }
            set
            {
                indicatorBarColor2 = value; Invalidate();
            }
        }

        private Color indicatorStepColor2 = Color.DodgerBlue;

        public Color IndicatorStepColor2
        {
            get { return indicatorStepColor2; }
            set
            {
                indicatorStepColor2 = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int steps = step;
            int radiusBig = radisbi;
            int radiusSmall = radisSma;
            int bgHeight = bgHe;

            var gradientRect = new Rectangle(ClientRectangle.X + (ClientRectangle.Width - radiusBig * 2) / (steps - 1),
                                             ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig - 1, radiusBig * 2, radiusBig * 2);

            var lightGrayBrush = new LinearGradientBrush(ClientRectangle, indicatorBarColor1, indicatorBarColor2, LinearGradientMode.Vertical);
            //var darkGrayBrush = new LinearGradientBrush(gradientRect, Color.DarkGray, Color.Gray, LinearGradientMode.Vertical);
            var lightGreenBrush = new LinearGradientBrush(ClientRectangle, indicatorStepColor1, indicatorStepColor2, LinearGradientMode.Vertical);
            //var darkGreenBrush = new LinearGradientBrush(ClientRectangle, Color.YellowGreen, Color.ForestGreen, LinearGradientMode.Vertical);

            //g.FillRectangle(darkGrayBrush, ClientRectangle.X + radiusBig, ClientRectangle.Y + ClientRectangle.Height / 2 - bgHeight / 2 - 1,
            //                ClientRectangle.Width - radiusBig * 2, bgHeight);

            g.FillRectangle(lightGrayBrush, ClientRectangle.X + radiusBig, ClientRectangle.Y + ClientRectangle.Height / 2 - bgHeight / 2,
                            ClientRectangle.Width - radiusBig * 2, bgHeight);

            for (int i = 1; i <= steps; i++)
            {
                //g.FillEllipse(darkGrayBrush, ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1),
                //              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig - 1, radiusBig * 2, radiusBig * 2);
                g.FillEllipse(lightGrayBrush, ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1),
                              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusBig, radiusBig * 2, radiusBig * 2);
            }
            //-1
            for (int i = 1; i <= values; i++)
            {
                //g.FillEllipse(darkGreenBrush,
                //              ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1) + radiusBig - radiusSmall,
                //              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusSmall - 1, radiusSmall * 2, radiusSmall * 2);
                g.FillEllipse(lightGreenBrush,
                              ClientRectangle.X + ((ClientRectangle.Width - radiusBig * 2) / (steps - 1)) * (i - 1) + radiusBig - radiusSmall,
                              ClientRectangle.Y + ClientRectangle.Height / 2 - radiusSmall, radiusSmall * 2, radiusSmall * 2);
            }

        }

        private int values = 1;
        public int Value
        {
            get { return values; }
            set
            {
                if (value <= 2) values = 2;
                else values = value;
                Invalidate();
            }
        }
    }
}
