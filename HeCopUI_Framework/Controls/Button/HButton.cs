using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Helper;
using HeCopUI_Framework.Struct;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Media;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using DashStyle = System.Drawing.Drawing2D.DashStyle;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(HButton), "Bitmaps.Button.bmp")]
    public partial class HButton : Control
    {
        #region Thành phần tối thiết
        protected override void OnTextChanged(EventArgs e)
        {
            SetAutoSize();
            Invalidate();
            base.OnTextChanged(e);
        }

        private int GetMaxPad(int num1, int num2, int num3, int num4)
        {
            int[] re = { num1, num2, num3, num4 };

            return re.Max();

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetAutoSize();
            base.OnSizeChanged(e);
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
      
        private bool autosize = false;
        public bool IsAutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value; Invalidate();
            }
        }
        #endregion

        private int BT { get; set; } = 0;
        private Color BC { get; set; } = Color.DarkGray;
        private Color BTC { get; set; } = Global.PrimaryColors.BackNormalColor1;
        //Global.PrimaryColors.BackNormalColor1
        public Color BackHoverColor1 { get; set; } = Global.PrimaryColors.BackHoverColor1;
        //Global.PrimaryColors.BackHoverColor1
        public Color BackPressColor1 { get; set; } = Global.PrimaryColors.BackPressColor1;
        //Global.PrimaryColors.BackPressColor1
        public Color BackHoverColor2 { get; set; } = Global.PrimaryColors.BackHoverColor2;
        public Color BackPressColor2 { get; set; } = Global.PrimaryColors.BackPressColor2;
        bool ButDo;
        bool ButHo;

        public Color TextHoverColor { get; set; } = Color.White;
        public Color TextDownColor { get; set; } = Color.White;
        private Color textNormalColor = Color.WhiteSmoke;
        public Color TextNormalColor
        {
            get { return textNormalColor; }
            set
            {
                textNormalColor = value; Invalidate();
            }
        }

        private Color buttonColor2 = Global.PrimaryColors.BackNormalColor2;
        public Color ButtonColor2
        {
            get
            {
                return buttonColor2;
            }
            set
            {
                buttonColor2 = value;
                Invalidate();
            }
        }

        public int BorderThickness
        {
            get { return BT; }
            set
            {
                BT = value; Invalidate();
            }
        }

        private DialogResult DR = DialogResult.None;
        public DialogResult DialogResult
        {
            get { return DR; }
            set
            {
                DR = value; Invalidate();
            }
        }

        public Color ButtonColor1
        {
            get
            {
                return BTC;
            }
            set
            {
                BTC = value;
                Invalidate();

            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Color ForeColor { get; set; }

        public Color BorderColor
        {
            get { return BC; }
            set
            {
                BC = value; Invalidate();
            }
        }
        public Color BorderDownColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        public Color BorderHoverColor { get; set; } = Global.PrimaryColors.BackNormalColor1;
        private LinearGradientMode LB = LinearGradientMode.Vertical;
        public LinearGradientMode GradientMode
        {
            get { return LB; }
            set
            {
                LB = value; 
                Invalidate();
            }
        }

        /// <summary>
        /// Sets or gets a value that indicates whether the control resizes based on its contents.
        /// </summary>
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public override bool AutoSize
        {
            get { return autosize; }
            set
            {
                autosize = value;
                SetAutoSize();
                Invalidate();
            }
        }


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


        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Padding Padding { get; set; } = new Padding(0);

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
                if (value.Bottom < 0) shadowPadding.Bottom = 0;
                SetAutoSize();
                Invalidate();
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

        GraphicsPath CircularGraphicsPath(RectangleF rect)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(rect);
            return graphicsPath;
        }

        CornerRadius radius = new Struct.CornerRadius(5);

        /// <summary>
        /// Gets or sets radius of HButton.
        /// </summary>
     
        public CornerRadius Radius
        {
            get { return radius; }
            set
            {
                radius = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float b = 0f;
            base.OnPaint(e);
            RectangleF RF = new RectangleF(shadowPadding.Left + 2 + textPadding.Left, shadowPadding.Top + 2 + textPadding.Top, Width - 2 - textPadding.Right - textPadding.Left - shadowPadding.Left - shadowPadding.Right, Height - 2 - textPadding.Bottom - textPadding.Top - shadowPadding.Top - shadowPadding.Bottom);
            GetAppResources.MakeTransparent(this, e.Graphics);
            using (GraphicsPath SGP = (ST == ShapeType.Rectangle) ? HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b, b, Width - b, Height - b), new CornerRadius(radius, 0.5f)) : CircularGraphicsPath(new RectangleF(b, b, Width - b, Height - b)))
            using (GraphicsPath GP = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), (Width - shadowPadding.Left) - (shadowPadding.Right), (Height - shadowPadding.Top) - (shadowPadding.Bottom)), Radius, BorderThickness))
            
            using (LinearGradientBrush AHB = 
                (AnimationMode == AnimationMode.ColorTransition) ? new LinearGradientBrush(ClientRectangle, ButDo ? BackPressColor1 : ButHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor1, BackHoverColor1, 255 * _animationManager.GetProgress()), 
                 ButDo ? BackPressColor2 : ButHo ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(ButtonColor2, BackHoverColor2, 255 * _animationManager.GetProgress()), LB) :
                (AnimationMode == AnimationMode.Ripple) ? new LinearGradientBrush(ClientRectangle, ButHo ? BackHoverColor1 : ButtonColor1, ButHo ? BackHoverColor2 : ButtonColor2, LB) :
                 new LinearGradientBrush(ClientRectangle, ButDo ? BackPressColor1 : ButHo ? BackHoverColor1 : ButtonColor1, ButDo ? BackPressColor2 : ButHo ? BackHoverColor2 : ButtonColor2, LB))
            
            using (SolidBrush sbText = new SolidBrush(ButDo ? TextDownColor : ButHo ? TextHoverColor : TextNormalColor))
            using (StringFormat SF = new StringFormat())
            using (Bitmap bitmap = HeCopUI_Framework.Ultils.DropShadow.Create(SGP, ShadowColor, shadowRad))
            {
                bitmap.MakeTransparent();
                Graphics g = Graphics.FromImage(bitmap);
                g.TextRenderingHint = textRenderHint;
                if (ST == ShapeType.Circular)
                {
                    GetAppResources.GetControlGraphicsEffect(g); GetAppResources.GetControlGraphicsEffect(e.Graphics);
                }
                if (ST == ShapeType.Rectangle)
                {
                    if (Radius.All != 0)
                    {
                        GetAppResources.GetControlGraphicsEffect(g);
                        GetAppResources.GetControlGraphicsEffect(e.Graphics);
                    }
                    else
                    {
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    }
                }
                if (Radius.All == 0) g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                GetAppResources.GetStringAlign(SF, CA);
                SF.Trimming = STA;    
                if (ClipRegion == true && DesignMode == false)
                {
                    if (ST == ShapeType.Rectangle) Region = new Region(HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(0, 0, Width, Height), new CornerRadius(radius, 2.5f)));
                    if (ST == ShapeType.Circular)
                    {
                        GraphicsPath a = new GraphicsPath(); a.AddEllipse(0, 0, Width, Height);
                        Region = new Region(a);
                    }
                }
               
                g.FillPath(AHB, GP);

                if (image != null)
                {
                    if (supportImageGif == true)
                    {
                        try
                        {
                            AnimateImage();
                            //Get the next frame ready for rendering.
                            ImageAnimator.UpdateFrames();
                        }
                        catch { }
                    }

                    RectangleF drawRectangle = RectangleF.Empty;

                    switch (textImageRelation)
                    {
                        case ContentAlignment.MiddleLeft:
                            drawRectangle = new RectangleF(imagePadding.Left + radius.TopLeft + 8, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.MiddleRight:
                            drawRectangle = new RectangleF(Width - 8 - imagePadding.Right - imgSize.Width - radius.TopRight, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.MiddleCenter:
                            drawRectangle = new RectangleF(Width / 2 - imgSize.Width / 2, Height / 2 - imgSize.Height / 2, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.TopLeft:
                            drawRectangle = new RectangleF(imagePadding.Left + radius.TopLeft + 8, imagePadding.Top + 8, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.TopCenter:
                            drawRectangle = new RectangleF(Width / 2 - imgSize.Width / 2, imagePadding.Top + 8, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.TopRight:
                            drawRectangle = new RectangleF(Width - radius.TopRight - imagePadding.Right - imgSize.Width - 8, imagePadding.Top + 8, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.BottomLeft:
                            drawRectangle = new RectangleF(imagePadding.Left + radius.BottomLeft + 8, Height - 8 - imagePadding.Bottom - imgSize.Height, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.BottomCenter:
                            drawRectangle = new RectangleF(Width / 2 - imgSize.Width / 2, Height - imagePadding.Bottom - 8 - imgSize.Height, imgSize.Width, imgSize.Height);
                            break;
                        case ContentAlignment.BottomRight:
                            drawRectangle = new RectangleF(Width - imagePadding.Right - imgSize.Width - 8 - radius.BottomRight, Height - imagePadding.Bottom - 8 - imgSize.Height, imgSize.Width, imgSize.Height);
                            break;
                        default:
                            drawRectangle = RectangleF.Empty;
                            break;
                    }

                    // Chỉ vẽ hình ảnh nếu hình chữ nhật vẽ đã được xác định
                    if (drawRectangle != RectangleF.Empty)
                        g.DrawImage(image, drawRectangle, new RectangleF(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
                }

                g.DrawString(Text, Font, sbText, RF, SF);
                Pen pen = new Pen(new SolidBrush(ButDo ? BorderDownColor : ButHo ? BorderHoverColor : BorderColor), BT);
                pen.Alignment = PenAlignment.Inset;
                if (Radius.All == 0) g.SmoothingMode = SmoothingMode.Default;
                if (BT != 0) g.DrawPath(pen, GP);
                g.SmoothingMode = SmoothingMode.HighQuality;
                if (AnimationMode == AnimationMode.Ripple && _animationManager.IsAnimating())
                    for (var i = 0; i < _animationManager.GetAnimationCount(); i++)
                    {
                        var animationValue = _animationManager.GetProgress(i);
                        var animationSource = _animationManager.GetSource(i);
                        using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), RippleColor)))
                        {
                            var rippleSize = (int)(animationValue * (Math.Max(Width, Height)) * 3);
                            g.FillEllipse(rippleBrush, new RectangleF(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                        }
                    }

                //Draw focus border
                if (DesignMode == false && Focused)
                {
                    g.SmoothingMode= SmoothingMode.None;
                    using (GraphicsPath gpf = HeCopUI_Framework.Helper.DrawHelper.SetRoundedCornerRectangle(new RectangleF(b + (shadowPadding.Left), b + (shadowPadding.Top), (Width - shadowPadding.Left) - (shadowPadding.Right), (Height - shadowPadding.Top) - (shadowPadding.Bottom)), radius, BorderThickness * 2+3))
                    using (var p = new Pen(new SolidBrush(fbc), 1) { Alignment = PenAlignment.Inset, DashStyle = dashStyle })
                        g.DrawPath(p, gpf);
                   
                }
                Brush brr = new TextureBrush(bitmap);
                    e.Graphics.FillPath(brr, SGP);
            }

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

        private Padding textPadding = new Padding(0, 0, 0, 0);
        public Padding TextPadding
        {
            get { return textPadding; }
            set
            {
                textPadding = value;
                if (value.Left < 0) textPadding.Left = 0;
                if (value.Top < 0) textPadding.Top = 0;
                if (value.Right < 0) textPadding.Right = 0;
                if (value.Bottom < 0) textPadding.Bottom = 0;
                SetAutoSize();
                Invalidate();
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            SetAutoSize();
            base.OnInvalidated(e);
        }

        void SetAutoSize()
        {
            if (AutoSize == true)
            {
                int Pad = Math.Abs(GetMaxPad(textPadding.Left + shadowPadding.Left, textPadding.Top + shadowPadding.Top, textPadding.Right + shadowPadding.Right, textPadding.Bottom + shadowPadding.Bottom));
                Size n = TextRenderer.MeasureText(Text, Font);
                Regex regex = new Regex("\n");
                int i = regex.Matches(Text).Count;
                int a = 0;
                if (i == 0) a = n.Height;
                else a += n.Height;
                int imax = 0; int imay = 0;
                if (image != null)
                {
                    imax = imgSize.Width; imay = imgSize.Height;
                }
                Size = new Size(imax + n.Width + 8 + Pad, a + 8 + Pad + imay);
            }
        }

        bool currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {
            this.Invalidate();
        }

        private void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(image, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private bool supportImageGif = false;
        public bool SupportImageGif
        {
            get { return supportImageGif; }
            set
            {
                supportImageGif = value; Invalidate();
            }
        }

        private Padding imagePadding = new Padding(0, 0, 0, 0);
        public Padding ImagePadding
        {
            get { return imagePadding; }
            set
            {
                imagePadding = value; Invalidate();
            }
        }

        private Size imgSize = new Size(20, 20);
        public Size ImageSize
        {
            get { return imgSize; }
            set
            {
                imgSize = value; Invalidate();
            }
        }

        private Image image = null;
        public Image Image
        {
            get { return image; }
            set
            {
                image = value; Invalidate();
            }
        }

        private ContentAlignment textImageRelation = ContentAlignment.MiddleLeft;
        public ContentAlignment ImageAlign
        {
            get { return textImageRelation; }
            set
            {
                textImageRelation = value; Invalidate();
            }
        }

       
        AnimationMode animationMode = AnimationMode.None;
        public AnimationMode AnimationMode
        {
            get { return animationMode; }
            set
            {
                animationMode = value; 
                switch (animationMode)
                {
                    case AnimationMode.None:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.03;
                        break;
                    case AnimationMode.Ripple:
                        _animationManager.Singular = false;
                        _animationManager.Increment = 0.03;
                        break;
                    case AnimationMode.ColorTransition:
                        _animationManager.Singular = true;
                        _animationManager.Increment = 0.05;
                        break;
                }
                Invalidate();
            }
        }

        public HButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            _animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };
            //_animationManager.SetProgress(0);
            object[] b = new object[] { new Point(0, 0) };
            _animationManager.StartNewAnimation(AnimationDirection.Out) ;
            _animationManager.SetData(b);
         
           
            ForeColor = Color.White;
            if (IsAutoSize == true)
            {
                SizeF n = TextRenderer.MeasureText(Text, Font);
                Size = new Size((int)n.Width + (int)Padding.All, (int)n.Height + Padding.All);
            }
           
            _animationManager.OnAnimationProgress += _animationManager_OnAnimationProgress;
            _animationManager.OnAnimationFinished += _animationManager_OnAnimationFinished;
        
          
        }

        private void _animationManager_OnAnimationProgress(object sender)
        {
            Invalidate();
        }

        private void _animationManager_OnAnimationFinished(object sender)
        {
            _animationManager.Dispose();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ButDo = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            ButHo = true;
           if(animationMode== AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(AnimationDirection.In);

            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            ButHo = false;
            if (AnimationMode == AnimationMode.ColorTransition)
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            Invalidate();
            base.OnMouseLeave(e);
        }

        private Animations.AnimationManager _animationManager;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            ButDo = true;
            if (AnimationMode == AnimationMode.Ripple)
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In, e.Location);
            Invalidate();
            base.OnMouseDown(e);
        }

       
        public Color RippleColor { get; set; } = Color.Black;
        protected override void OnMouseClick(MouseEventArgs e)
        {
            var a = FindForm();
            if (a != null) a.DialogResult = DR;
            base.OnMouseClick(e);
        }

        private System.Drawing.Text.TextRenderingHint textRenderHint = GetAppResources.SetTextRender();
        /// <summary>
        /// Gets or sets TextRenderingHint for text button.
        /// </summary>
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }


        private StringTrimming STA = StringTrimming.EllipsisCharacter;
        public StringTrimming TextTrim
        {
            get { return STA; }
            set
            {
                STA = value; Invalidate();
            }
        }

        private ContentAlignment CA = ContentAlignment.MiddleCenter;
        public ContentAlignment ButtonTextAlign
        {
            get { return CA; }
            set
            {
                CA = value; Invalidate();
            }
        }

        private ShapeType ST = ShapeType.Rectangle;

        public ShapeType ShapeButtonType
        {
            get { return ST; }
            set
            {
                ST = value; Invalidate();
            }
        }

      
    }
}
