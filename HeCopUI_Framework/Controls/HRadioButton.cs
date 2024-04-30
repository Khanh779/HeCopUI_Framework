using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public class HRadioButton : Control
    {
        #region Variables


        Color enabledCheckedColor = HeCopUI_Framework.Global.PrimaryColors.BackNormalColor1;
        Color enabledUnCheckedColor = ColorTranslator.FromHtml("#9c9ea1");

        Color disabledColor = ColorTranslator.FromHtml("#c4c6ca");
        Color enabledTextColor = ColorTranslator.FromHtml("#929292");
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

        Timer AlphaAnimationTimer = new Timer { Interval = 16 };
        Timer SizeAnimationTimer = new Timer { Interval = 35 };


        int SizeAnimationNum = 0;
        int PointAnimationNum = 9;
        int Alpha = 0;

        #endregion

        #region Events

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            AlphaAnimationTimer.Start();
            SizeAnimationTimer.Start();
        }


        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        #endregion
        public HRadioButton()
        {
            SetStyle(HeCopUI_Framework.GetAppResources.SetControlStyles(), true);
            AlphaAnimationTimer.Tick += new EventHandler(AlphaAnimationTick);
            SizeAnimationTimer.Tick += new EventHandler(SizeAnimationTick);
            RippleAnimation = new Timer() { Interval = 8 };
            RippleAnimation.Tick += RippleAnimation_Tick;
        }

        protected override void OnCreateControl()
        {
            Init();
            base.OnCreateControl();
        }

        void Init()
        {


            //if (DesignMode == true)
            //{
            //    SizeAnimationTimer.Stop(); AlphaAnimationTimer.Stop(); RippleAnimation.Stop();
            //}
        }

        int rippleCenter = 28;
        int rippleWidth = 0;

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Size.Height <= 28) Size = new Size(Width, 28);
            if (Size.Width <= 28)
                Size = new Size(28, Height);
            base.OnSizeChanged(e);
        }

        private void RippleAnimation_Tick(object sender, EventArgs e)
        {
            if (Hover == true)
            {
                if (rippleWidth < 28)
                {
                    rippleWidth += 2;
                }
                else RippleAnimation.Stop();
            }
            else
            {
                if (rippleWidth > 0)
                {
                    rippleWidth -= 2;
                }
                else RippleAnimation.Stop();
            }
            Invalidate();
        }

        Timer RippleAnimation;

        private void UpdateState()
        {
            if (!IsHandleCreated || !Checked)
                return;
            foreach (Control c in Parent.Controls)
            {
                if (!ReferenceEquals(c, this) && c is HRadioButton)
                {
                    ((HRadioButton)c).Checked = false;
                }
            }
        }

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
                UpdateState();
                CheckedChanged?.Invoke(this, null);
                Invalidate();
            }
        }


        public bool AlwayCheckedInstance { get; set; } = false;

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (AlwayCheckedInstance == true)
                    Checked = true;
                else
                    Checked = !Checked;
            }
            base.OnMouseClick(e);
        }

        bool Hover = false;

        protected override void OnMouseEnter(EventArgs e)
        {
            Hover = true;
            RippleAnimation.Start();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hover = false; RippleAnimation.Start();
            base.OnMouseLeave(e);
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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.TextRenderingHint = TextRenderHint;
            Rectangle BGEllipse = new Rectangle(6, 6, 16, 16);
            using (SolidBrush BG = new SolidBrush(Enabled ? Checked ? EnabledCheckedColor : EnabledUnCheckedColor : DisabledColor))
            using (var pen= new Pen(new SolidBrush(BG.Color), 2))
            {
                g.DrawEllipse(pen, BGEllipse);
                StringFormat SF = new StringFormat();
                SF.Alignment = SF.LineAlignment = StringAlignment.Near;
                SF.Trimming = ST;
                //Draw Ripple when mouse horver.
                g.FillEllipse(new SolidBrush(Color.FromArgb(RippleAlpha, RippleColor)),
                       new RectangleF((rippleCenter / 2 - rippleWidth / 2), (rippleCenter / 2 - rippleWidth / 2), rippleWidth, rippleWidth));

                // Draw Check Mark
                if (Checked)
                    g.FillEllipse(BG, new RectangleF(5 + PointAnimationNum, 5 + PointAnimationNum, SizeAnimationNum, SizeAnimationNum));

                //RadioButton Text
                g.DrawString(Text, Font, new SolidBrush(Enabled ? EnabledTextColor : DisabledTextColor),
                    new RectangleF(28, 30 / 2 - g.MeasureString(Text, Font).Height / 2, Width - 28, Height - 6), SF);
                if (DesignMode == false && foc==true)
                {
                    g.SmoothingMode = SmoothingMode.None; g.PixelOffsetMode = PixelOffsetMode.Default;
                    var a = new Pen(new SolidBrush(fbc), 1f) { Alignment = PenAlignment.Inset, DashStyle = dashStyle };
                    g.DrawRectangle(a, new Rectangle(
                      0, 0, Width - 1, Height - 1));

                }
            }
            base.OnPaint(pevent);
        }

        bool foc = false;
        protected override void OnGotFocus(EventArgs e)
        {
            foc = true; Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            foc = false; Invalidate();
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

        public int RippleAlpha { get; set; } = 60;
        public Color RippleColor { get; set; } = HeCopUI_Framework.Global.PrimaryColors.BackHoverColor1;

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }


        public event EventHandler CheckedChanged;


        private void AlphaAnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (Alpha < 250)
                {
                    Alpha += 25;
                    this.Invalidate();
                }
            }
            else if (Alpha > 0)
            {
                Alpha -= 25;
                this.Invalidate();
            }
        }
        private void SizeAnimationTick(object sender, EventArgs e)
        {
            if (Checked)
            {
                if (SizeAnimationNum < 8)
                {
                    SizeAnimationNum += 2;
                    this.Invalidate();

                    if (PointAnimationNum > 5)
                    {
                        PointAnimationNum -= 1;
                        this.Invalidate();
                    }
                }
            }
            else if (SizeAnimationNum > 0)
            {
                SizeAnimationNum -= 2;
                this.Invalidate();

                if (PointAnimationNum < 9)
                {
                    PointAnimationNum += 1;
                    this.Invalidate();
                }
            }
        }
    }
}