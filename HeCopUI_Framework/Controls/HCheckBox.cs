using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [DefaultEvent("CheckedChanged")]
    public partial class HCheckBox : Control
    {
        #region Variables

        static Point[] CHECKMARK_LINE = { new Point(3, 8), new Point(7, 12), new Point(14, 5) };


        Color enabledCheckedColor = HeCopUI_Framework.Global.PrimaryColors.BackNormalColor1;
        Color enabledUnCheckedColor = ColorTranslator.FromHtml("#9c9ea1");
        Color disabledColor = Color.Gray;
        Color enabledTextColor = ColorTranslator.FromHtml("#999999");
        Color disabledTextColor = ColorTranslator.FromHtml("#babbbd");

        public Color DisabledColor
        {
            get { return disabledColor; }
            set
            {
                disabledColor = value; Invalidate();
            }
        }

        public Color EnabledTextColor
        {
            get { return enabledTextColor; }
            set
            {
                enabledTextColor = value; Invalidate();
            }
        }

        public Color DisabledTextColor
        {
            get { return disabledTextColor; }
            set
            {
                disabledTextColor = value; Invalidate();
            }
        }

        public Color EnabledCheckedColor
        {
            get { return enabledCheckedColor; }
            set
            {
                enabledCheckedColor = value; Invalidate();
            }
        }

        public Color EnabledUnCheckedColor
        {
            get { return enabledUnCheckedColor; }
            set
            {
                enabledUnCheckedColor = value; Invalidate();
            }
        }


        Timer AnimationTimer = new Timer { Interval = 17 };


        int SizeAnimationNum = 14;
        int PointAnimationNum = 3;
        int Alpha = 0;

        #endregion

      
        public HCheckBox()
        {
            SetStyle(HeCopUI_Framework.GetAppResources.SetControlStyles(), true);
            AnimationTimer = new Timer() { Interval = 10 };
            AnimationTimer.Tick += new EventHandler(AnimationTick);
            RippleAnimate = new Timer() { Interval = 5 };

            RippleAnimate.Tick += RippleAnimate_Tick;
        }



        protected override void OnMouseEnter(EventArgs e)
        {
            Hover = true;
            RippleAnimate.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hover = false;
            RippleAnimate.Start();
            base.OnMouseLeave(e);
        }


        int rippleCenter = 30;
        int rippleWidth = 0;
        private void RippleAnimate_Tick(object sender, EventArgs e)
        {
            if (Hover == true)
            {
                if (rippleWidth < 28)
                {
                    rippleWidth += 2;
                }
                else RippleAnimate.Stop();
            }
            else
            {
                if (rippleWidth > 0)
                {
                    rippleWidth -= 2;
                }
                else RippleAnimate.Stop();
            }
            Invalidate();
        }

        Timer RippleAnimate;

        bool Hover = false;

        private bool _checked = false;
        ///<summary>
        ///  Gets or sets a value indicating whether the control is checked.
        ///</summary>
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                //if(IsHandleCreated)
                AnimationTimer.Start();
                CheckedChanged?.Invoke(this, null);
                Invalidate();
            }

        }

        public event EventHandler CheckedChanged;

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Size.Height <= 28) Size = new Size(Width, 28);
            if (Size.Width <= 28)
                Size = new Size(28, Height);

            base.OnSizeChanged(e);
        }


        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value; Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Checked = !Checked;
            }
            base.OnMouseClick(e);
        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = GetAppResources.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }

        Color checkboxc1 = Global.PrimaryColors.BackNormalColor1;
        public Color CheckBoxColor1
        {
            get { return checkboxc1; }
            set
            {
                checkboxc1 = value; Invalidate();
            }
        }

        Color checkboxc2 = Global.PrimaryColors.BackNormalColor2;
        public Color CheckBoxColor2
        {
            get { return checkboxc2; }
            set
            {
                checkboxc2 = value; Invalidate();
            }
        }

        LinearGradientMode linear = LinearGradientMode.Vertical;

        ///<summary>
        /// Gets or sets the direction of the gradient.
        //</summary>
        public LinearGradientMode CheckBoxGradientMode
        {
            get { return linear; }
            set
            {
                linear = value; Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {

            using (var checkmarkPath = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(6f, 6, 15, 15), 0))
            using (SolidBrush BG = new SolidBrush(Enabled ? Checked ? EnabledCheckedColor : EnabledUnCheckedColor : DisabledColor))
            using (Pen Pen = new Pen(BG.Color, 1) { Alignment = PenAlignment.Inset })
            using (var checkb = new LinearGradientBrush(new Rectangle(0, 0, checkBoxSize, checkBoxSize), checkboxc1, checkboxc2, linear))
            using (var ripplebac = new SolidBrush(Color.FromArgb(RippleAlpha, RippleColor)))
            using (var penfoc = new Pen(new SolidBrush(fbc), 1f) { Alignment = PenAlignment.Inset, DashStyle = dashStyle })
            {
                var g = pevent.Graphics;
                StringFormat SF = new StringFormat();
                GetAppResources.GetControlGraphicsEffect(g);
                g.TextRenderingHint = TextRenderHint;
                g.FillPath(BG, checkmarkPath);
                g.DrawPath(Pen, checkmarkPath);
                g.FillRectangle(checkb, 3.5f + PointAnimationNum, 3.5f + PointAnimationNum, SizeAnimationNum, SizeAnimationNum);
                //CheckBox Text
                SF.Alignment = SF.LineAlignment = StringAlignment.Near;
                SF.Trimming = ST;
                g.DrawString(Text, Font, new SolidBrush(Enabled ? EnabledTextColor : DisabledTextColor),
                    new RectangleF(28, 30 / 2 - g.MeasureString(Text, Font).Height / 2, Width - 30, Height - 6), SF);
                //Draw Ripple when mouse horver.
                g.FillEllipse(ripplebac,
                       new RectangleF((rippleCenter - rippleWidth) / 2 - 1.25f, (rippleCenter - rippleWidth) / 2 - 1.25f, rippleWidth, rippleWidth));
                //CheckMark
                g.DrawImage(CheckMarkBitmap(), 5f, 5);
                if (DesignMode == false)
                    if (Focused)
                    {
                        g.SmoothingMode = SmoothingMode.None;
                        g.PixelOffsetMode = PixelOffsetMode.Default;
                        g.DrawRectangle(penfoc, new Rectangle(
                          0, 0, Width - 1, Height - 1));
                    }
            }

            base.OnPaint(pevent);
        }



        protected override void OnGotFocus(EventArgs e)
        {
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            Invalidate();
            base.OnLostFocus(e);
        }

        Color fbc = Global.PrimaryColors.BorderNormalColor1;
        public Color FocusBorderColor
        {
            get { return fbc; }
            set { fbc = value; Invalidate(); }
        }

        private DashStyle dashStyle = DashStyle.Dot;
        public DashStyle DashStyle
        {
            get
            {
                return dashStyle;
            }
            set
            {
                dashStyle = value; Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor { get; set; }

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }


        public int RippleAlpha { get; set; } = 60;
        public Color RippleColor { get; set; } = Color.FromArgb(0, 168, 148);

        void AnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (Alpha < 250)
                {
                    Alpha += 25;
                    this.Invalidate();

                    if (SizeAnimationNum > 0)
                    {
                        SizeAnimationNum -= 2;
                        this.Invalidate();
                    }

                    if (PointAnimationNum < 10)
                    {
                        PointAnimationNum += 1;
                        this.Invalidate();
                    }
                }
                else if (Alpha > 250) AnimationTimer.Stop();
            }
            else if (Alpha > 0)
            {
                Alpha -= 25;
                this.Invalidate();

                if (SizeAnimationNum < 14)
                {
                    SizeAnimationNum += 2;
                    this.Invalidate();
                }


                if (PointAnimationNum > 3)
                {
                    PointAnimationNum -= 1;
                    this.Invalidate();
                }
            }
            else if (Alpha < -250) AnimationTimer.Stop();
        }

        private Color checkColor = Color.White;
        public Color CheckColor
        {
            get { return checkColor; }
            set
            {
                checkColor = value; Invalidate();
            }
        }

        int checkBoxSize = 16;

        private Bitmap CheckMarkBitmap()
        {
            var checkMark = new Bitmap(checkBoxSize, checkBoxSize);
            checkMark.MakeTransparent();
            var g = Graphics.FromImage(checkMark);
            g.SmoothingMode = SmoothingMode.HighQuality;
            using (var pen = new Pen(new SolidBrush(Color.FromArgb(Alpha, checkColor)), 2))
                g.DrawLines(pen, CHECKMARK_LINE);
            return checkMark;
        }
    }
}