using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(HTitleButton), "Bitmaps.Button.bmp")]
    public partial class HTitleButton : Control
    {

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

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
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

       


        public HTitleButton()
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

            _animationManager.OnAnimationProgress += _animationManager_OnAnimationProgress;
            _animationManager.OnAnimationFinished += _animationManager_OnAnimationFinished;
            Size = new Size(111, 123);

            DoubleBuffered = true;
            ForeColor = Color.White;

        }

        private void _animationManager_OnAnimationFinished(object sender)
        {
            _animationManager.Dispose();
        }

        private void _animationManager_OnAnimationProgress(object sender)
        {
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            butDo = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            butDo = true;
            if (BackPressColor1 == Color.Empty)
            {
                BackPressColor1 = Color.FromArgb(ButtonColor1.R - 5, ButtonColor1.G - 5, ButtonColor1.B - 5);
            }
            if (AnimationMode == Enums.AnimationMode.Ripple)
                _animationManager.StartNewAnimation(AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            butHo = true;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
            {
                _animationManager.StartNewAnimation(AnimationDirection.In);
            }
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            butHo = false;
            if (AnimationMode == Enums.AnimationMode.ColorTransition)
            {
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            }

            Invalidate();
            base.OnMouseLeave(e);
        }


        private Enums.AnimationMode animationMode =Enums.AnimationMode.None;
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


        bool butHo;
        bool butDo;

        private Shapes.Circular.CornerRadius Ra = new Shapes.Circular.CornerRadius(5);
        public Shapes.Circular.CornerRadius Radius
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
        public Color BackHoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        public Color BackPressColor2 { get; set; } = Global.PrimaryColors.BackPressColor1;

        public Color ButtonColor1
        {
            get { return BC; }
            set
            {
                BC = value;
              
                Invalidate();
            }
        }

        private Color btn2 = Global.PrimaryColors.BackNormalColor1;

        public Color ButtonColor2
        {
            get { return btn2; }
            set
            {
                btn2 = value;
               
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

        private Image BI;
        public Image ButtonImage
        {
            get { return BI; }
            set
            {
                BI = value; Invalidate();

            }
        }



        private float IS = 5;
        public float ImageOffsetY
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


        StringFormat SF = new StringFormat();
        Pen pen;

        private int interval = 200;
        /// <summary>
        /// Set speed animation with value type milisecond to show animate
        /// </summary>
        public int Interval
        {
            get { return interval; }
            set
            {
                interval = value; Invalidate();
            }
        }


        public Color RippleColor { get; set; } = Color.Black;


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }

        private Padding textPadding = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get
            {
                return textPadding;
            }
            set
            {
                textPadding = value;
                if (value.Left < 0) textPadding.Left = 0;
                if (value.Top < 0) textPadding.Top = 0;
                if (value.Right < 0) textPadding.Right = 0;
                if (value.Bottom < 0) textPadding.Bottom = 0; Invalidate();
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

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
            using (LinearGradientBrush LB1 =
               (AnimationMode == Enums.AnimationMode.ColorTransition) ? new LinearGradientBrush(ClientRectangle, butDo ? BackPressColor1 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()),
                butDo ? BackPressColor2 : butHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()), LB) :
               (AnimationMode == Enums.AnimationMode.Ripple) ? new LinearGradientBrush(ClientRectangle, butHo ? BackHoverColor1 : ButtonColor1, butHo ? BackHoverColor2 : ButtonColor2, LB) :
                new LinearGradientBrush(ClientRectangle, butDo ? BackPressColor1 : butHo ? BackHoverColor1 : ButtonColor1, butDo ? BackPressColor2 : butHo ? BackHoverColor2 : ButtonColor2, LB))

            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), 
                (Width - shadowPadding.Left) - (shadowPadding.Right), (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius,BT))

            using (GraphicsPath SGP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width-b, Height-b), Radius))
            using (Bitmap bitmap = HeCopUI_Framework.Ultils.DropShadow.Create(SGP, ShadowColor, shadowRad))
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                bitmap.MakeTransparent();
                if (ClipRegion == true && DesignMode == false && Ra.All!=0)
                {
                    GetAppResources.MakeTransparent(this, g);
                    Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new Shapes.Circular.CornerRadius(Radius, 2.5f)));
                }
                g.TextRenderingHint = TextRenderHint;
                if (Radius.All != 0)
                {
                    GetAppResources.GetControlGraphicsEffect(g);
                    GetAppResources.GetControlGraphicsEffect(e.Graphics);
                }
                if (Ra.All == 0)
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                }
                SF.Trimming = ST;
                SF.Alignment = StringAlignment.Center;
                SF.LineAlignment = StringAlignment.Near;
                pen = new Pen(new SolidBrush(butDo ? BorderDownColor : butHo ? BorderHoverColor : BDC), BT);
                pen.Alignment = PenAlignment.Inset;

                g.FillPath(LB1, GP);
               
                if (BT != 0) g.DrawPath(pen, GP);

                try
                {
                    AnimateImage();
                    ImageAnimator.UpdateFrames();
                    g.DrawImage(BI, new RectangleF(Width / 2 - ISi.Width / 2, IS, ISi.Width, ISi.Height));
                }
                catch { }
                if (Text != String.Empty)
                    g.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(2 + textPadding.Left, textPadding.Top + (IS + ISi.Height + TOY), Width - 2 - textPadding.Right - textPadding.Left, (this.Height) - (IS + ISi.Height + TOY) - textPadding.Bottom - textPadding.Top), SF);

                if (_animationManager.IsAnimating() && animationMode== Enums.AnimationMode.Ripple)
                {
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
                if (Focused)
                {
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top),
                    (Width - shadowPadding.Left) - (shadowPadding.Right),
                    (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness * 2 + 5))
                        g.DrawPath(new Pen(new SolidBrush(fbc), 1) { Alignment = PenAlignment.Inset, DashStyle = dashStyle }, gpf);
                }
                Brush br = new TextureBrush(bitmap);
                e.Graphics.FillPath(br, SGP);
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

        private readonly AnimationManager _animationManager;

        private LinearGradientMode LB = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return LB; }
            set
            {
                LB = value; Invalidate();
            }
        }

        public int AlphaAnimated { get; set; } = 180;




        private StringTrimming ST = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }


    }
}
