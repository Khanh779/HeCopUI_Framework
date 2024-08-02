using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(HTitleSubButton), "Bitmaps.Button.bmp")]
    public partial class HTitleSubButton : Control
    {
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; }

        /// <summary>
        ///   Gets or sets the text associated with this control.
        /// </summary>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value; Invalidate();
            }
        }

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

        protected override void OnCreateControl()
        {
            Invalidate();
            base.OnCreateControl();
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }
        public HTitleSubButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            _animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };

            object[] b = new object[] { new Point(0, 0) };
            _animationManager.StartNewAnimation(AnimationDirection.Out);
            _animationManager.SetData(b);

            Size = new Size(111, 123);
            BackColor = Color.Transparent;
           
            _animationManager.OnAnimationProgress += delegate { Invalidate(); };
           
            ForeColor = Color.White;
        
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            butDo = true;
            if(AnimationMode== Enums.AnimationMode.Ripple)
            _animationManager.StartNewAnimation(Animations.AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            butDo = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            butHo = true;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In);
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            butHo = false;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.Out);
            Invalidate();
            base.OnMouseLeave(e);
        }

        public Color BackHoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color BackPressColor2 { get; set; } = Global.PrimaryColors.BackPressColor1;
        private Color buttonColor2 = Global.PrimaryColors.BackNormalColor1;
        public Color ButtonColor2
        {
            get { return buttonColor2; }
            set
            {
                buttonColor2 = value;
            
                Invalidate();
            }
        }

    

        private Animations.AnimationManager _animationManager;

        Enums.AnimationMode animationMode= Enums.AnimationMode.None;
        public Enums.AnimationMode AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value;
                switch (animationMode)
                {
                    case Enums.AnimationMode.None:
                        _animationManager.Singular = true;
                        break;
                    case Enums.AnimationMode.Ripple:
                        _animationManager.Singular = false;
                        _animationManager.Increment = 0.03;
                        break;
                    case Enums.AnimationMode.ColorTransition:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.05;
                        break;
                }
                Invalidate();
            }
        }
  

        private int interval = 200;
        /// <summary>
        /// Set speed animation with value type milisecond to show animate
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set { interval = value; Invalidate(); }
        }

    
        public Color RippleColor { get; set; } = Color.Black;



        bool butHo;
        bool butDo;

        private CornerRadius Ra = new CornerRadius(0);
        [Localizable(true)]
        public CornerRadius Radius
        {
            get { return Ra; }
            set
            {
                Ra = value; Invalidate();
            }
        }

        private int BT = 0;
        public int BorderThickness
        {
            get { return BT; }
            set
            {
                BT = value; Invalidate();
            }
        }

        private Color BC = Global.PrimaryColors.BackNormalColor1;
        public Color BackHoverColor1 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color BackPressColor1 { get; set; } = Global.PrimaryColors.BackPressColor1;
        public Color ButtonColor1
        {
            get { return BC; }
            set
            {
                BC = value;
             
                Invalidate();
            }
        }

        private Color BDC = Color.Transparent;
        public Color BorderColor
        {
            get { return BDC; }
            set
            {
                BDC = value; Invalidate();
            }
        }

        #region Ess
        private Image BI;
        public Image ButtonImage
        {
            get { return BI; }
            set
            {
                BI = value; Invalidate();
            }
        }



        private int IS = 5;
        public int ImageOffsetY
        {
            get { return IS; }
            set
            {
                IS = value; Invalidate();
            }
        }

        private Size ISi = new Size(50, 50);
        public Size ImageSize
        {
            get { return ISi; }
            set
            {
                ISi = value; Invalidate();
            }
        }

        private float TOY = 1;
        public float TextOffsetY
        {
            get { return TOY; }
            set
            {
                TOY = value; Invalidate();
            }
        }

        bool currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {

            this.Invalidate();
        }
        public void AnimateImage()
        {

            if (!currentlyAnimating)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(BI, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }



        #endregion

        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value; Invalidate();
            }
        }

        public Color BorderHoverColor { get; set; } = Color.Transparent;
        public Color BorderDownColor { get; set; } = Color.Transparent;



        private Padding shadowPadding = new Padding(0, 0, 0, 0);
        public Padding ShadowPadding
        {
            get { return shadowPadding; }
            set
            {
                shadowPadding = value;
                if (value.Left < 0) shadowPadding.Left = 0;
                if (value.Top < 0) shadowPadding.Top = 0;
                if (value.Right < 0) shadowPadding.Right = 0;
                if (value.Bottom < 0) shadowPadding.Bottom = 0; Invalidate();
            }
        }

        private Color shadowColor = Color.FromArgb(60, 0, 0, 0);
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value; Invalidate();
            }
        }

        private int shadowRad = 5;
        public int ShadowRadius
        {
            get { return shadowRad; }
            set
            {
                shadowRad = value; Invalidate();
            }
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

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
           
            using (GraphicsPath SGP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width, Height), Radius))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), (Width - shadowPadding.Left) - (shadowPadding.Right), (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness))

            using (Bitmap bitmap = HeCopUI_Framework.Ultils.DropShadow.Create(SGP, ShadowColor, shadowRad))
            using (Graphics g = Graphics.FromImage(bitmap))
            using (Pen pen = new Pen(new SolidBrush(butDo ? BorderDownColor : butHo ? BorderHoverColor : BDC), BT))
            using (LinearGradientBrush LA = (AnimationMode == Enums.AnimationMode.ColorTransition) ? new LinearGradientBrush(ClientRectangle, butDo ? BackPressColor1 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()),
                butDo ? BackPressColor2 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()), gradientMode) :
               (AnimationMode == Enums.AnimationMode.Ripple) ? new LinearGradientBrush(ClientRectangle, butHo ? BackHoverColor1 : ButtonColor1, butHo ? BackHoverColor2 : ButtonColor2, gradientMode) :
                new LinearGradientBrush(ClientRectangle, butDo ? BackPressColor1 : butHo ? BackHoverColor1 : ButtonColor1, butDo ? BackPressColor2 : butHo ? BackHoverColor2 : ButtonColor2, gradientMode))

            {
                bitmap.MakeTransparent();
                if (ClipRegion == true && DesignMode == false&& Ra.All!=0)
                {
                    GetAppResources.MakeTransparent(this, g);
                    Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new CornerRadius(Radius, 2.5f)));
                }
                g.TextRenderingHint = TextRenderHint;
                if (Ra.All != 0)
                {
                    GetAppResources.GetControlGraphicsEffect(g);
                    GetAppResources.GetControlGraphicsEffect(e.Graphics);
                }
                if (Ra.All == 0)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode= PixelOffsetMode.HighQuality;
                }

                pen.Alignment = PenAlignment.Inset;

                g.FillPath(LA, GP);
                try
                {
                    AnimateImage();
                    //Get the next frame ready for rendering.
                    ImageAnimator.UpdateFrames();
                    //Draw the next frame in the animation.
                    g.DrawImage(BI, new RectangleF(Width / 2 - ISi.Width / 2, IS, ISi.Width, ISi.Height));

                }
                catch { }
                StringFormat SF = new StringFormat();
                SF.Trimming = ST;
                GetAppResources.GetStringAlign(SF, TCA);
                StringFormat SAF = new StringFormat();
                SAF.Trimming = ST;
                GetAppResources.GetStringAlign(SAF, ITCA);
                SizeF sd = g.MeasureString(Text, Font);
                g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(2 + TPadd.Left, Font.Height + (IS + ISi.Height + TOY) + TPadd.Top, Width - 2 - TPadd.Right, TeY + Font.Height - TPadd.Bottom), SF);
                g.DrawString(SubText, TeIF, new SolidBrush(textColor), new RectangleF(2 + ITPadd.Left, TeY + Font.Height * 2 + ITPadd.Top + 4 + (IS + ISi.Height + TOY) + TexInffoOffsetY, Width - 2 - ITPadd.Right, (Height - TexInffoOffsetY - TeIF.Height - IS - ISi.Height - TOY - TeY) - ITPadd.Bottom), SAF);

                
                if (BT != 0) g.DrawPath(pen, GP);
               
                if (AnimationMode == Enums.AnimationMode.Ripple && _animationManager.IsAnimating())
                {
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    for (var i = 0; i < _animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = _animationManager.GetProgress(i);
                        var animationSource = _animationManager.GetSource(i);
                        using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), RippleColor)))
                        {
                            var rippleSize = (int)(animationValue * (Math.Max(Width, Height)) * 3);
                            g.FillEllipse(rippleBrush, new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                        }
                    }
                }
                // Constrain the button to the region.
                if (DesignMode == false && Focused)
                {
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top),
                        (Width - shadowPadding.Left) - (shadowPadding.Right),
                        (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness * 2 + 5))
                        g.DrawPath(new Pen(new SolidBrush(fbc), 1) { Alignment = PenAlignment.Inset, DashStyle = dashStyle }, gpf);
                }
                TextureBrush tb = new TextureBrush(bitmap);
                e.Graphics.FillPath(tb, SGP);
            }

            base.OnPaint(e);
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

        Color fbc = Color.White;
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

        public bool ClipRegion { get; set; } = false;

        #region End
        private Padding ITPadd = new Padding(0, 0, 0, 0);
        public Padding TextTextPadding
        {
            get { return ITPadd; }
            set
            {
                ITPadd = value; Invalidate();
            }
        }

        private Padding TPadd = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get { return TPadd; }
            set
            {
                TPadd = value; Invalidate();
            }
        }

        private ContentAlignment ITCA = ContentAlignment.TopCenter;
        public ContentAlignment SubTextAlign
        {
            get { return ITCA; }
            set
            {
                ITCA = value; Invalidate();
            }
        }

        private ContentAlignment TCA = ContentAlignment.TopCenter;
        public ContentAlignment TextAlign
        {
            get { return TCA; }
            set
            {
                TCA = value; Invalidate();
            }
        }

        private int TexInffoOffsetY = 0;
        public int SubTextOffSetY
        {
            get { return TexInffoOffsetY; }
            set
            {
                TexInffoOffsetY = value; Invalidate();
            }
        }

        private int TeY = 10;
        public int TextY
        {
            get { return TeY; }
            set
            {
                TeY = value; Invalidate();
            }
        }

        private Font TeIF = new Font(DefaultFont, FontStyle.Regular);
        public Font SubTextFont
        {
            get { return TeIF; }
            set
            {
                TeIF = value; Invalidate();
            }
        }

        private Color textColor = Color.Silver;
        public Color SubTextColor
        {
            get { return textColor; }
            set
            {
                textColor = value; Invalidate();
            }
        }

        private string subText = "Enter Sub Text Here";
        public string SubText
        {
            get { return subText; }
            set
            {
                subText = value; Invalidate();
            }
        }

        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }

        #endregion
    }
}
