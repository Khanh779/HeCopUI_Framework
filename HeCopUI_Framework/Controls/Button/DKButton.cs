
using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Enums;
using HeCopUI_Framework.Global;
using HeCopUI_Framework.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Buttons
{
    [ToolboxBitmap(typeof(System.Windows.Forms.Button))]
    public class DKButton : Control
    {
        // Các thuộc tính màu sắc
        private Color _normalColor1 = PrimaryColors.BackNormalColor1;
        private Color _normalColor2 = PrimaryColors.BackNormalColor2;
        private Color _hoverColor1 = PrimaryColors.BackHoverColor1;
        private Color _hoverColor2 = PrimaryColors.BackHoverColor2;
        private Color _pressColor1 = PrimaryColors.BackPressColor1;
        private Color _pressColor2 = PrimaryColors.BackPressColor2;

        private Color _textNormalColor = PrimaryColors.ForeNormalColor1;
        private Color _textHoverColor = PrimaryColors.ForeHoverColor1;
        private Color _textPressColor = PrimaryColors.ForePressColor1;

        private Color _borderColor = Color.FromArgb(34, 139, 34);



        private int _borderThickness = 1;

        // Biến trạng thái
        private bool _isHovering = false;
        private bool _isPressed = false;

        ShapeType shapeType = ShapeType.RoundedRectangle;
        public ShapeType ShapeType
        {
            get => shapeType;
            set
            {
                shapeType = value;
                Invalidate();
            }
        }

        int radius = 3;
        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                Invalidate();
            }
        }

        ContentAlignment contentAlignment = ContentAlignment.MiddleCenter;
        public ContentAlignment ContentAlignment
        {
            get => contentAlignment;
            set
            {
                contentAlignment = value;
                Invalidate();
            }
        }

        StringTrimming stringTrimming = StringTrimming.EllipsisCharacter;
        public StringTrimming StringTrimming
        {
            get => stringTrimming;
            set
            {
                stringTrimming = value;
                Invalidate();
            }
        }

        TextRenderingHint textRenderingHint = TextRenderingHint.AntiAliasGridFit;
        public TextRenderingHint TextRenderingHint
        {
            get => textRenderingHint;
            set
            {
                textRenderingHint = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Get or set the text color
        /// </summary>
        [Description("Get or set the text color")]
        public new Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }

        public Color TextNormalColor
        {
            get => _textNormalColor;
            set { _textNormalColor = value; Invalidate(); }
        }

        public Color TextHoverColor
        {
            get => _textHoverColor;
            set { _textHoverColor = value; Invalidate(); }
        }

        public Color TextPressColor
        {
            get => _textPressColor;
            set { _textPressColor = value; Invalidate(); }
        }

        AnimationMode animationMode = AnimationMode.None;
        public AnimationMode AnimationMode
        {
            get => animationMode;
            set
            {
                animationMode = value;
                if (animationMode == AnimationMode.Ripple)
                    animationManager.Singular = false;
                else
                    animationManager.Singular = true;
                Invalidate();
            }
        }

        AnimationManager animationManager;

        public DKButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            animationManager = new AnimationManager(true)
            {
                Increment = 0.03,
                AnimationType = Animations.AnimationType.EaseOut
            };

            animationManager.OnAnimationProgress += AnimationManager_AnimationProgress;

            //animationManager.StopAll();
        }

        private void AnimationManager_AnimationProgress(object obj)
        {
            Invalidate();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _isHovering = true;
            if (animationMode == AnimationMode.ColorTransition)
            {
                animationManager.StartNewAnimation(AnimationDirection.In);
            }
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _isHovering = false;
            if (animationMode == AnimationMode.ColorTransition)
            {
                animationManager.StartNewAnimation(AnimationDirection.Out);
            }
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _isPressed = true;
            if (animationMode == AnimationMode.ColorTransition)
            {
                animationManager.StartNewAnimation(AnimationDirection.In, e.Location);
            }
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _isPressed = false;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (animationMode == AnimationMode.Ripple)
            {
                animationManager.StartNewAnimation(AnimationDirection.In, e.Location);
            }
        }

        LinearGradientMode gradientMode = LinearGradientMode.BackwardDiagonal;
        public LinearGradientMode GradientMode
        {
            get => gradientMode;
            set
            {
                gradientMode = value;
                Invalidate();
            }
        }

        TextImageRelation imageRelation = TextImageRelation.ImageBeforeText;
        public TextImageRelation ImageRelation
        {
            get => imageRelation;
            set
            {
                imageRelation = value;
                Invalidate();
            }
        }

        Image image;
        public Image Image
        {
            get => image;
            set
            {
                image = value;
                Invalidate();
            }
        }

        Size _imageSize = new Size(20, 20);
        public Size ImageSize
        {
            get => _imageSize;
            set
            {
                _imageSize = value;
                Invalidate();
            }
        }

        int imageOffsetX = 0;
        public int ImageOffsetX
        {
            get => imageOffsetX;
            set
            {
                imageOffsetX = value;
                Invalidate();
            }
        }

        int imageOffsetY = 0;
        public int ImageOffsetY
        {
            get => imageOffsetY;
            set
            {
                imageOffsetY = value;
                Invalidate();
            }
        }



        int shadowAlpha = 120;
        public int ShadowAlpha
        {
            get => shadowAlpha;
            set
            {
                shadowAlpha = value;
                Invalidate();
            }
        }

        Color shadowColor = Color.Black;
        public Color ShadowColor
        {
            get => shadowColor;
            set
            {
                shadowColor = value;
                Invalidate();
            }
        }

        Padding shadowPadding = new Padding(0);
        public Padding ShadowPadding
        {
            get => shadowPadding;
            set
            {
                shadowPadding = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = TextRenderingHint;

            // Tạo shadow cho control
            using (GraphicsPath sgp = GraphicsHelper.GetRoundPath(ClientRectangle, Radius))
            using (var shadowBitmap = GraphicsHelper.DrawBitmapShadow(ClientRectangle, Color.FromArgb(ShadowAlpha, ShadowColor), Radius))
            using (var shadowBrush = new TextureBrush(shadowBitmap))
            {
                e.Graphics.FillPath(shadowBrush, sgp);
            }

            var contentRectangle = new RectangleF(
              shadowPadding.Left,
              shadowPadding.Top,
              Width - shadowPadding.Horizontal, // Tính cả padding trái và phải
              Height - shadowPadding.Vertical    // Tính cả padding trên và dưới
            );

            using (GraphicsPath contentPath = GraphicsHelper.GetRoundPath(contentRectangle, Radius))
            using (Bitmap bmp = new Bitmap((int)contentRectangle.Right, (int)contentRectangle.Bottom))
            {
                bmp.MakeTransparent();

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.TextRenderingHint = TextRenderingHint;

                    Color color1 = animationMode == AnimationMode.ColorTransition
                        ? (_isPressed
                            ? ColorHelper.BlendColor(_hoverColor1, _pressColor1, animationManager.GetProgress() * 255)
                            : _isHovering
                                ? ColorHelper.BlendColor(_normalColor1, _hoverColor1, animationManager.GetProgress() * 255)
                                : ColorHelper.BlendColor(_normalColor1, _hoverColor1, animationManager.GetProgress() * 255))
                        : animationMode == AnimationMode.Ripple
                            ? (_isHovering ? _hoverColor1 : _normalColor1)

                            : (_isPressed ? _pressColor1 : _isHovering ? _hoverColor1 : _normalColor1);

                    Color color2 = animationMode == AnimationMode.ColorTransition
                        ? (_isPressed
                            ? ColorHelper.BlendColor(_hoverColor2, _pressColor2, animationManager.GetProgress() * 255)
                            : _isHovering
                                ? ColorHelper.BlendColor(_normalColor2, _hoverColor2, animationManager.GetProgress() * 255)
                                : ColorHelper.BlendColor(_normalColor2, _hoverColor2, animationManager.GetProgress() * 255))
                        : animationMode == AnimationMode.Ripple
                            ? (_isHovering ? _hoverColor2 : _normalColor2)

                            : (_isPressed ? _pressColor2 : _isHovering ? _hoverColor2 : _normalColor2);



                    // Vẽ nội dung chính
                    using (var brush = new LinearGradientBrush(contentRectangle, color1, color2, gradientMode))
                    using (GraphicsPath path = GraphicsHelper.GetRoundPath(contentRectangle, Radius))
                    using (GraphicsPath borderPath = GraphicsHelper.GetRoundPath(contentRectangle, Radius, BorderThickness))
                    {
                        g.FillPath(brush, path);

                        // Kích thước và vị trí của văn bản
                        RectangleF textBound = new RectangleF(
                             BorderThickness + textPadding.Left,
                             BorderThickness + textPadding.Top,
                            bmp.Width + shadowPadding.Right - BorderThickness * 2 - textPadding.Right,
                            bmp.Height + shadowPadding.Bottom - BorderThickness * 2 - textPadding.Bottom
                        );


                        // Kích thước và vị trí của hình ảnh
                        RectangleF imageBound = new RectangleF(0, 0, 0, 0);

                        if (Image != null)
                        {
                            switch (ImageRelation)
                            {
                                case TextImageRelation.TextBeforeImage:
                                    // Văn bản ở trước hình ảnh
                                    textBound = new RectangleF(
                                        BorderThickness + textPadding.Left + imageOffsetX,
                                        BorderThickness + textPadding.Top,
                                        bmp.Width + shadowPadding.Right - BorderThickness * 2 - textPadding.Right - _imageSize.Width - imageOffsetX,
                                        bmp.Height + shadowPadding.Bottom - BorderThickness * 2 - textPadding.Bottom
                                    );
                                    imageBound = new RectangleF(
                                        textBound.Width + imageOffsetX,
                                        contentRectangle.Top + (bmp.Height - _imageSize.Height) / 2,
                                        _imageSize.Width,
                                        _imageSize.Height
                                    );
                                    break;

                                case TextImageRelation.ImageBeforeText:
                                    // Hình ảnh ở trước văn bản
                                    imageBound = new RectangleF(
                                        BorderThickness + 1 + imageOffsetX,
                                        contentRectangle.Top + (bmp.Height - _imageSize.Height) / 2,
                                        _imageSize.Width,
                                        _imageSize.Height
                                    );
                                    textBound = new RectangleF(
                                        imageBound.Right + textPadding.Left + imageOffsetX,
                                        BorderThickness + textPadding.Top,
                                        bmp.Width + shadowPadding.Right - BorderThickness * 2 - textPadding.Right - _imageSize.Width - imageOffsetX,
                                        bmp.Height + shadowPadding.Bottom - BorderThickness * 2 - textPadding.Bottom
                                    );
                                    break;

                                case TextImageRelation.ImageAboveText:
                                    // Hình ảnh ở trên văn bản
                                    imageBound = new RectangleF(
                                        contentRectangle.Left + (bmp.Width - _imageSize.Width) / 2,
                                        shadowPadding.Top + BorderThickness + textPadding.Top + imageOffsetY,
                                        _imageSize.Width,
                                        _imageSize.Height
                                    );
                                    textBound = new RectangleF(
                                        BorderThickness + textPadding.Left,
                                        imageBound.Bottom + textPadding.Top + 2,
                                        bmp.Width + shadowPadding.Right - BorderThickness * 2 - textPadding.Right,
                                        bmp.Height + shadowPadding.Bottom - BorderThickness * 2 - textPadding.Bottom - _imageSize.Height - imageOffsetY
                                    );
                                    break;

                                case TextImageRelation.TextAboveImage:
                                    // Văn bản ở trên hình ảnh
                                    textBound = new RectangleF(
                                        BorderThickness + textPadding.Left,
                                        BorderThickness + textPadding.Top,
                                        bmp.Width + shadowPadding.Right - BorderThickness * 2 - textPadding.Right,
                                        bmp.Height + shadowPadding.Bottom - BorderThickness * 2 - textPadding.Bottom - _imageSize.Height - imageOffsetY
                                    );
                                    imageBound = new RectangleF(
                                        contentRectangle.Left + (bmp.Width - _imageSize.Width) / 2,
                                        textBound.Bottom + imageOffsetY,
                                        _imageSize.Width,
                                        _imageSize.Height
                                    );
                                    break;
                            }

                            g.DrawImage(Image, imageBound);
                        }

                        StringFormat sf = new StringFormat();
                        TextHelper.SetStringAlign(sf, contentAlignment);

                        using (var textBrush = new SolidBrush(_isPressed ? _textPressColor : _isHovering ? _textHoverColor : _textNormalColor))
                            g.DrawString(Text, Font, textBrush, textBound, sf);

                        if (BorderThickness > 0)
                        {
                            using (var pen = new Pen(_borderColor, BorderThickness))
                                g.DrawPath(pen, borderPath);
                        }
                    }

                    // Hiệu ứng ripple (nếu có)
                    if (AnimationMode == AnimationMode.Ripple && animationManager.IsAnimating())
                        for (var i = 0; i < animationManager.GetAnimationCount(); i++)
                        {
                            var animationValue = animationManager.GetProgress(i);
                            var animationSource = animationManager.GetSource(i);
                            using (Brush rippleBrush = new SolidBrush(Color.FromArgb((int)(101 - (animationValue * 100)), rippleColor)))
                            {
                                var rippleSize = (int)(animationValue * (Math.Max(Width, Height)) * 3);
                                g.FillEllipse(rippleBrush, new RectangleF(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                            }
                        }

                    // Vẽ kết quả lên control
                    using (TextureBrush tb = new TextureBrush(bmp))
                    {
                        e.Graphics.FillPath(tb, contentPath);
                    }
                }
            }

        }

        Color rippleColor = Color.FromArgb(0, 0, 0);
        public Color RippleColor
        {
            get => rippleColor;
            set
            {
                rippleColor = value;
                Invalidate();
            }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color NormalColor1
        {
            get => _normalColor1;
            set { _normalColor1 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color NormalColor2
        {
            get => _normalColor2;
            set { _normalColor2 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color HoverColor1
        {
            get => _hoverColor1;
            set { _hoverColor1 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color HoverColor2
        {
            get => _hoverColor2;
            set { _hoverColor2 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color PressColor1
        {
            get => _pressColor1;
            set { _pressColor1 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color PressColor2
        {
            get => _pressColor2;
            set { _pressColor2 = value; Invalidate(); }
        }

        [Editor(typeof(ColorEditor), typeof(UITypeEditor))]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        public int BorderThickness
        {
            get => _borderThickness;
            set { _borderThickness = value; Invalidate(); }
        }

        Padding textPadding = new Padding(0);
        public Padding TextPadding
        {
            get => textPadding;
            set
            {
                textPadding = value;
                Invalidate();
            }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        [Category("Misc")]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                Invalidate();
            }
        }
        [Category("Misc")]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                Invalidate();
            }
        }


    }
}
