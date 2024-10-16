using HeCopUI_Framework.Structs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    [ToolboxBitmap(typeof(HProgressBar), "Bitmaps.Progress.bmp")]
    public partial class HProgressBar : Control
    {
        int interval = 10;
        int locx = 0;

        public HProgressBar()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            ForeColor = Color.White;
            BorderColor = Color.Silver;
            tmrIndi = new System.Windows.Forms.Timer();
            tmrIndi.Tick += TmrIndi_Tick1;
            tmrIndi.Interval = interval;
        }

        protected override void OnCreateControl()
        {
            if (IsHandleCreated)
                // if (!DesignMode)
                tmrIndi.Start();
            base.OnCreateControl();
        }

        private void TmrIndi_Tick1(object sender, EventArgs e)
        {
            switch (animationMode)
            {
                case Enums.ProgressAnimationMode.Indeterminate:
                    int a = ((Or == Orientation.Horizontal) ? Width - 1 : Height - 1);
                    if (locx >= a) locx = 0 - (int)(((PV - MV) * a) / MAV);
                    else  locx += 2;
                   
                    break;
                case Enums.ProgressAnimationMode.Value:
                    if (AnV != PV)
                    {
                        if (AnV < PV)
                        {
                            AnV += 1;
                        }
                        if (AnV > PV) AnV -= 1;
                    }
                    else tmrIndi.Stop();
                    break;
                case Enums.ProgressAnimationMode.None:
                    tmrIndi.Stop();
                    break;

            }

            Invalidate();
        }

        private System.Windows.Forms.Timer tmrIndi;

        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF recPro;
            RectangleF recf;

            if (Or == Orientation.Horizontal)
            {
                recPro = new RectangleF(0.5f, 0.5f, Width - 1, Height - 1);
                recf = new RectangleF(0, 0, Width - 0.5f, Height);
            }
            else // Orientation.Vertical
            {
                recPro = new RectangleF(0.5f, 0.5f, Width - 1, Height - 1);
                recf = new RectangleF(0, 0, Width, Height - 0.5f);
            }

            GetAppResources.GetControlGraphicsEffect(e.Graphics);

            using (Bitmap bitm = new Bitmap(Width, Height))
            using (Graphics g = Graphics.FromImage(bitm))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recf, Radius, 0))
            using (LinearGradientBrush LB = new LinearGradientBrush(recPro, BPC1, BPC2, Linear))
            using (LinearGradientBrush LB1 = new LinearGradientBrush(recPro, PC1, PC2, Linear))
            {
                switch (AnimationMode)
                {
                    case Enums.ProgressAnimationMode.None:
                        if(Or== Orientation.Horizontal)
                        recPro.Width = (float)(((PV - MV) * recf.Width) / MAV);
                        else recPro.Height = (float)(((PV - MV) * recf.Height) / MAV);
                        break;
                    case Enums.ProgressAnimationMode.Value:
                        if (Or == Orientation.Horizontal)
                            recPro.Width = (float)(((AnV - MV) * recf.Width) / MAV);
                        else recPro.Height = (float)(((AnV - MV) * recf.Height) / MAV);
                        break;
                    case Enums.ProgressAnimationMode.Indeterminate:
                        break;
                }

                using (GraphicsPath GPV = (AnimationMode == Enums.ProgressAnimationMode.Indeterminate) ? HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(
                    0.5f + (Or == Orientation.Horizontal ? locx : 0),
                    0.5f + (Or == Orientation.Vertical ? locx : 0),
                    (Or == Orientation.Horizontal ? 30 + locx : Width - 1),
                    (Or == Orientation.Vertical ? 30 + locx : Height - 1)), Radius, 0):
                    HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recPro, Ra, 0))
                {
                    GetAppResources.GetControlGraphicsEffect(g);
                    g.FillPath(LB, GP);
                    if (PV != 0) g.FillPath(LB1, GPV);
                    if (BT != 0)
                    {
                        using (Pen pen = new Pen(new SolidBrush(BC), BT))
                        {
                            pen.Alignment = PenAlignment.Inset;
                            g.DrawPath(pen, HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(recf, Radius, BorderWidth));
                        }
                    }
                    e.Graphics.FillPath(new TextureBrush(bitm), GP);
                }
            }

            base.OnPaint(e);
        }

        Orientation Or = Orientation.Horizontal;
        public Orientation Orientation
        {
            get { return Or; }
            set
            {
             
                Or = value; Invalidate();
            }
        }

        private LinearGradientMode Linear = LinearGradientMode.Horizontal;
        public LinearGradientMode GradientMode
        {
            get { return Linear; }
            set
            {
                Linear = value; Invalidate();
            }
        }

        int AnV = 0;
        public int ProgressValue
        {
            get { return PV; }
            set
            {
                if (value > MAV)
                {
                    PV = MAV;
                }
                if (value < MV)
                {
                    PV = MV;
                }
                if (value >= MV || value <= MAV) PV = value;
                if(AnimationMode== Enums.ProgressAnimationMode.Value && IsHandleCreated) tmrIndi.Start();
                Invalidate();
            }
        }

        private Enums.ProgressAnimationMode animationMode = Enums.ProgressAnimationMode.Value;
        public Enums.ProgressAnimationMode AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value;
                locx = 0;
                if (animationMode != Enums.ProgressAnimationMode.None)
                {
                    if (IsHandleCreated)
                        //if(!DesignMode)
                        tmrIndi.Start();
                }
                Invalidate();

            }
        }

        private CornerRadius Ra = new CornerRadius(2);
        private int BT = 1;

        private int MAV = 100;
        private int MV = 0;
        private int PV = 0;
        private Color BC = Global.PrimaryColors.BorderProgressBarColor1;
        private Color BPC2 = Global.PrimaryColors.BaseProgressBarColor1;
        private Color PC2 = Global.PrimaryColors.ProgressBarColor1;

        public Color ProgressColor2
        {
            get { return PC2; }
            set
            {
                PC2 = value; Invalidate();
            }
        }

        public Color BaseProgressColor2
        {
            get { return BPC2; }
            set
            {
                BPC2 = value; Invalidate();
            }
        }

        private Color BPC1 = Global.PrimaryColors.BaseProgressBarColor1;
        private Color PC1 = Global.PrimaryColors.ProgressBarColor1;

        public Color ProgressColor1
        {
            get { return PC1; }
            set
            {
                PC1 = value; Invalidate();
            }
        }

        public Color BaseProgressColor1
        {
            get { return BPC1; }
            set
            {
                BPC1 = value; Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return BC; }
            set
            {
                BC = value; Invalidate();
            }
        }

        /// <summary>
        /// Get or set radius of progress bar
        /// </summary>
        [Localizable(true)]
        public CornerRadius Radius
        {
            get { return Ra; }
            set
            {
                Ra = value; Invalidate();
            }
        }

        public int BorderWidth
        {
            get { return BT; }
            set
            {
                BT = value; Invalidate();
            }
        }

        public int MinimumValue
        {
            get { return MV; }
            set
            {
                if (value < 0) MV = 0;
                else MV = value; Invalidate();
            }
        }

        public int MaximumValue
        {
            get { return MAV; }
            set
            {
                if (value < PV) MAV = PV;
                else MAV = value; Invalidate();
            }
        }
    }
}
