

using HeCopUI_Framework.Animations;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [DefaultEvent("TextChanged")]
    public partial class HTextBox : Control
    {
        #region Fields


        private TextBox tbCtrl = new TextBox();
        private Color borderColor = Global.PrimaryColors.BackNormalColor1;

        #endregion
        #region Properties

        private Image _Image;
        public Image Image
        {
            get { return _Image; }
            set
            {
                _Image = value;
                //ImageSize = value == null ? Size.Empty : value.Size;
                //tbCtrl.Location = new Point(24, 14);

                Invalidate();
            }
        }


        private int _MaxLength = 32767;
        public int MaxLength
        {
            get { return _MaxLength; }
            set
            {
                _MaxLength = value;

                Invalidate();
            }
        }

        private bool _Multiline;
        public bool Multiline
        {
            get { return _Multiline; }
            set
            {
                _Multiline = value;
                Invalidate();
            }
        }

        private bool _ReadOnly;
        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set
            {
                _ReadOnly = value;
                if (tbCtrl.IsHandleCreated)
                    tbCtrl.ReadOnly = value;
            }
        }


        bool shortcutsEnabled = false;
        public bool ShortcutsEnabled
        {
            get { return shortcutsEnabled; }
            set
            {
                shortcutsEnabled = value; Invalidate();
            }
        }


        private bool _ShowBottomBorder = true;
        public bool ShowBottomBorder
        {
            get { return _ShowBottomBorder; }
            set
            {
                _ShowBottomBorder = value;
                Invalidate();
            }
        }

        private bool _ShowTopBorder = true;

        public bool ShowTopBorder
        {
            get { return _ShowTopBorder; }
            set
            {
                _ShowTopBorder = value;
                Invalidate();
            }
        }

        private HorizontalAlignment _TextAlignment;

        public HorizontalAlignment TextAlignment
        {
            get { return _TextAlignment; }
            set
            {
                _TextAlignment = value;
                if(tbCtrl.IsHandleCreated)
                tbCtrl.TextAlign = _TextAlignment;
                Invalidate();
            }
        }

        bool useSystemPasswordChar = false;
        public bool UseSystemPasswordChar
        {
            get { return useSystemPasswordChar; }
            set
            {

                useSystemPasswordChar = value;
                Invalidate();
            }
        }

        private string _Watermark = "Enter watermark";
        public string WatermarkText
        {
            get { return _Watermark; }
            set
            {
                _Watermark = value;

                Invalidate();
            }
        }

        private Color _WatermarkColor = ColorTranslator.FromHtml("#747881");

        public Color WatermarkColor
        {
            get { return _WatermarkColor; }
            set
            {
                _WatermarkColor = value;
                Invalidate();
            }
        }

        #endregion
        #region EventArgs



        Color textColor = Color.FromArgb(64, 64, 64);
        public Color TextColor
        {
            get { return textColor; }
            set
            {
                textColor = value; Invalidate();
            }
        }




        public void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (tbCtrl.IsHandleCreated)
                Text = tbCtrl.Text;
            UpdateTextBoxLocation(); Invalidate();
        }

        CharacterCasing characterCasing = CharacterCasing.Normal;
        public CharacterCasing CharacterCasing
        {
            get { return characterCasing; }
            set
            {
                characterCasing = value; Invalidate();
            }
        }

        AutoCompleteMode autoCompleteMode = AutoCompleteMode.None;
        public AutoCompleteMode AutoCompleteMode { get { return autoCompleteMode; } set { autoCompleteMode = value; Invalidate(); } }

        AutoCompleteSource autoCompleteSource = AutoCompleteSource.None;
        public AutoCompleteSource AutoCompleteSource { get { return autoCompleteSource; } set { autoCompleteSource = value; Invalidate(); } }

        ScrollBars scrollBars = ScrollBars.Both;
        public ScrollBars ScrollBars
        {
            get { return scrollBars; }
            set
            {
                scrollBars = value; Invalidate();
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            if (tbCtrl.IsHandleCreated)
                tbCtrl.Font = Font;
        }

        public System.Drawing.Text.TextRenderingHint WatermarkRendering { get; set; } = GetAppResources.SetTextRender();

        protected override void OnForeColorChanged(EventArgs e)
        {
            base.OnForeColorChanged(e);
            if (tbCtrl.IsHandleCreated)
                tbCtrl.ForeColor = ForeColor;
            Invalidate();
        }

        protected override void OnGotFocus(EventArgs e)
        {

            base.OnGotFocus(e);
            UpdateTextBoxLocation();
            if (tbCtrl.IsHandleCreated)
                tbCtrl.Focus();
        }

        protected override void OnEnter(EventArgs e)
        {
            if (tbCtrl.IsHandleCreated)
                tbCtrl.Focus();
            UpdateTextBoxLocation();
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            //UpdateTextBoxLocation();
            if (tbCtrl.IsHandleCreated)
            {
                if (!_animationManager.IsAnimating())
                    _animationManager.StartNewAnimation(AnimationDirection.Out);
                if (tbCtrl.Text == " ") tbCtrl.Text = String.Empty;
            }
            Invalidate();
            base.OnLeave(e);
        }



        protected override void OnLostFocus(EventArgs e)
        {
            UpdateTextBoxLocation();
            base.OnLostFocus(e);
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateTextBoxLocation();
            base.OnResize(e);



        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateTextBoxLocation();
            base.OnSizeChanged(e);
        }





        #endregion

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Color ForeColor { get; set; } = Color.Transparent;

        /// <summary>
        ///   Gets or sets the text associated with this control.
        /// </summary>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public new string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;

                UpdateTextBoxLocation();

                Invalidate();
            }
        }

        public HTextBox()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);

            tbCtrl = new TextBox();
            _animationManager = new AnimationManager
            {
                Increment = 0.08,
                AnimationType = AnimationType.EaseInOut,
                InterruptAnimation = false
            };

            //Init();

         
        }

        private AnimationManager _animationManager;

        protected override void OnCreateControl()
        {
            Init();
            _animationManager.OnAnimationProgress += sender =>
            {

                Invalidate();
            };
            Cursor = Cursors.IBeam;
            AddTextBox();
            Controls.Add(tbCtrl);

            SetPlaceholder(tbCtrl, WatermarkText, WatermarkFont);
            UpdateTextBoxLocation();
            base.OnCreateControl();
        }

        Font _warFont = DefaultFont;
        public Font WatermarkFont
        {
            get { return _warFont; }
            set
            {
                _warFont = value;

                Invalidate();
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (tbCtrl.IsHandleCreated)
            {

                Init();
                UpdateTextBoxLocation();
            }
            base.OnInvalidated(e);
        }

        private a SetPlaceholder(Control control, string text, Font font)
        {
            var placeholder = new a();
            placeholder.v = WatermarkRendering;
            placeholder.Text = text;
            placeholder.Font = font;
            placeholder.ForeColor = WatermarkColor;
            placeholder.BackColor = Color.Transparent;
            placeholder.Cursor = Cursors.IBeam;
            placeholder.Margin = Padding.Empty;

            //get rid of the left margin that all labels have
            //FlatStyle = FlatStyle.Flat,
            placeholder.AutoSize = false;

            //Leave 1px on the left so we can see the blinking cursor
            placeholder.Size = new Size(control.Size.Width - 4, control.Size.Height);
            placeholder.Location = new Point(control.Location.X + 1, control.Location.Y);

            //disappear when the user starts typing
            control.TextChanged += (sender, args) =>
            {
                placeholder.Visible = string.IsNullOrEmpty(control.Text);
            };
            placeholder.Visible = string.IsNullOrEmpty(control.Text);
            //stay the same size/location as the control
            EventHandler updateSize = (sender, args) =>
            {
                placeholder.Location = new Point( control.Location.X+1, control.Location.Y);
                placeholder.Size = new Size(control.Size.Width - 1, control.Size.Height);
            };

            placeholder.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    control.Focus();
                }
            };
            placeholder.MouseEnter += (sender, e) =>
            {
                butHover = true;
                control.BackColor = TextBoxHoverColor;
                if (style != TextBoxStyle.Style2)
                    _animationManager.StartNewAnimation(AnimationDirection.In);
            };

            placeholder.MouseLeave += (sender, e) =>
            {
                butHover = false;
                control.BackColor = TextBoxColor;
                if (style != TextBoxStyle.Style2)
                    _animationManager.StartNewAnimation(AnimationDirection.Out);
            };
            control.SizeChanged += updateSize;
            control.LocationChanged += updateSize;
            if (!control.Parent.Contains(placeholder))
                //if(Style!= TextBoxStyle.Style3)
                control.Parent.Controls.Add(placeholder);

            placeholder.BringToFront();
            placeholder.Invalidate();
            return placeholder;
        }

        private bool acceptsTab = false;
        bool acceptReturn;

        public bool AcceptsReturn
        {
            get { return acceptReturn; }
            set
            {
                acceptReturn = value;
                if (tbCtrl.IsHandleCreated) tbCtrl.AcceptsReturn = acceptReturn;
                Invalidate();
            }
        }

        public bool AcceptsTab
        {
            get { return acceptsTab; }
            set
            {
                acceptsTab = value;
                if (tbCtrl.IsHandleCreated) tbCtrl.AcceptsTab = acceptsTab;
                Invalidate();
            }
        }

        void Init()
        {

            tbCtrl.Font = Font;
            tbCtrl.ForeColor = textColor;
            tbCtrl.BackColor = butHover? TextBoxHoverColor: TextBoxColor;
            tbCtrl.ShortcutsEnabled = ShortcutsEnabled;
            tbCtrl.TextAlign = TextAlignment;
            tbCtrl.CharacterCasing = CharacterCasing;
            tbCtrl.UseSystemPasswordChar = UseSystemPasswordChar;
            tbCtrl.Multiline = Multiline;
            tbCtrl.MaxLength = MaxLength;
            tbCtrl.ReadOnly = ReadOnly;
            tbCtrl.AutoCompleteMode = AutoCompleteMode;
            tbCtrl.AutoCompleteSource = AutoCompleteSource;
            tbCtrl.ScrollBars = ScrollBars;
            tbCtrl.AcceptsTab = AcceptsTab;
            tbCtrl.AcceptsReturn = AcceptsReturn;
        
                tbCtrl.TextAlign = TextAlignment;

            #region Sự kiện cần thiết

            DoubleBuffered = true;

            //tbCtrl = new TextBox();
            tbCtrl.BorderStyle = BorderStyle.None;

         
            #endregion
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            butHover = false;
            Invalidate();
            tbCtrl.BackColor = TextBoxColor;
            if (style != TextBoxStyle.Style2)
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            butHover = true;
            Invalidate();
            tbCtrl.BackColor = TextBoxHoverColor;
            if (style != TextBoxStyle.Style2)
                _animationManager.StartNewAnimation(AnimationDirection.In);
           
            base.OnMouseEnter(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                tbCtrl.Focus();
            }
            base.OnMouseClick(e);
        }

        class a : Control
        {
            public bool IsInstance
            {
                get
                {
                    bool c = false;
                    if (_in != null) c = true;
                    return c;
                }
            }

            static a _in = null;
            public static a Instance
            {
                get
                {
                    if (_in == null || _in.IsDisposed) _in = new a();
                    return _in;
                }
            }

            public a()
            {
                SetStyle(GetAppResources.SetControlStyles(), true);
                DoubleBuffered = true;
                _in = this;
                BackColor = Color.Transparent;
            }

            public TextRenderingHint v = TextRenderingHint.ClearTypeGridFit;

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.TextRenderingHint = v;
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), new RectangleF(0, 0, Width, Height), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center }); ;
                base.OnPaint(e);
            }
        }

        bool butHover = false;

        private Color textBoxColor = Color.White;
        private Color textBoxHoverColor = Color.FromArgb(250, 250, 250);
        public Color TextBoxColor
        {
            get { return textBoxColor; }
            set
            {
                if (value.A == 0)
                    textBoxColor = Color.White;
                else
                    textBoxColor = value;

                Invalidate();
            }
        }

        public Color TextBoxHoverColor
        {
            get => textBoxHoverColor;
            set
            {
                if (value.A == 0) textBoxHoverColor = Color.FromArgb(250, 250, 250);
                else
                    textBoxHoverColor = value;
                Invalidate();
            }
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (tbCtrl.IsHandleCreated)
            {
                _animationManager.StartNewAnimation(AnimationDirection.In);
            }
            UpdateTextBoxLocation();
            Invalidate();
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (tbCtrl.IsHandleCreated)
            {
                _animationManager.StartNewAnimation(AnimationDirection.Out);
            }
            UpdateTextBoxLocation();

            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            tbCtrl.Text = Text;
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Adds an actual <see cref="TextBox"/> control to this control.
        /// </summary>
        private void AddTextBox()
        {
            tbCtrl.Size = new Size(Width - 15 - BorderThickness, 49);
            tbCtrl.Location = new Point(24, Height / 2 - tbCtrl.Height / 2);
            tbCtrl.BorderStyle = BorderStyle.None;
            tbCtrl.TextAlign = TextAlignment;
            tbCtrl.Multiline = Multiline;
            tbCtrl.TextChanged += TextBox_TextChanged;
            tbCtrl.Enter += TextBox_Enter;
            tbCtrl.Leave += TextBox_Leave;
            tbCtrl.MouseEnter += delegate
            {
                butHover = true; tbCtrl.BackColor = TextBoxHoverColor;
                UpdateTextBoxLocation();
                if (style != TextBoxStyle.Style2)
                    _animationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            };
            tbCtrl.MouseLeave += delegate
            {
                butHover = false;
                tbCtrl.BackColor = TextBoxColor;
                if (style != TextBoxStyle.Style2)
                    _animationManager.StartNewAnimation(AnimationDirection.Out);
                UpdateTextBoxLocation();
                Invalidate();
            };

            tbCtrl.GotFocus += (sender, e) =>
            {
                if (tbCtrl.IsHandleCreated)
                {
                    _animationManager.StartNewAnimation(AnimationDirection.In);
                }
                Invalidate();
            };

            tbCtrl.LostFocus += (sender, e) =>
            {
                if (tbCtrl.IsHandleCreated)
                {
                    _animationManager.StartNewAnimation(AnimationDirection.Out);
                }
                Invalidate();
            };
          
        }

        void UpdateTextBoxLocation()
        {
            if (tbCtrl.IsHandleCreated && IsHandleCreated)
            {
                if (_Multiline)
                {
                    tbCtrl.Location = new Point((Image != null ? ImageSize.Width + imageX : 0) + BorderThickness + rad / 2 + tbX, BorderThickness + rad);
                }
                else
                {
                    tbCtrl.Location = new Point((Image != null ? ImageSize.Width + imageX + 2 : 2) + BorderThickness + tbX + rad / 2, (Height / 2
                         - tbCtrl.Height / 2) - ((style == TextBoxStyle.Style2) ? BorderThickness + 1 : 0));
                }

                tbCtrl.Width = Width - ((Image != null ? ImageSize.Width + imageX : 0) + BorderThickness * 2 +4 + rad / 2) - 2 - tbX;
                if (this.Size.Height <= tbCtrl.Height + b + BorderThickness * 2 + Radius * 2)
                    Size = new Size(Width, tbCtrl.Height + b + BorderThickness * 2 + rad * 2);

            }

        }

        int b = 4;

        /// <summary>
        /// If the <see cref="Image"/> property value is specified, the image
        /// will be drawn.
        /// /// </summary>
        /// 
        /// <param name="g">Reference to the Graphics class.</param>
        private void DrawImage(Graphics g)
        {
            if (_Image != null)
            {
                g.DrawImage(_Image, 2 + imageX + Radius / 2 + BorderThickness, (Height / 2 - ImageSize.Height / 2) - (Style== TextBoxStyle.Style2? BorderThickness:0)
                   , ImageSize.Width, ImageSize.Height);
            }
        }



        int tbX = 2;

        public int TexOffsetX
        {
            get { return tbX; }
            set
            {
                tbX = value; Invalidate();
            }
        }

        int imageX = 2;

        public int ImageOffsetX
        {
            get { return imageX; }
            set
            {
                imageX = value; Invalidate();
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;

                Invalidate();
            }
        }
        private int rad = 0;
        public int Radius
        {
            get { return rad; }
            set
            {
                rad = value; Invalidate();
            }
        }
        private int borderThickness = 1;
        public int BorderThickness
        {
            get { return borderThickness; }
            set
            {
                borderThickness = value; UpdateTextBoxLocation(); Invalidate();
            }
        }

        public Color BorderHoverColor
        {
            get => borderHoverColor; set
            {
                borderHoverColor = value;

                Invalidate();
            }
        }
        public Color BorderFocusColor
        {
            get => borderFocusColor;
            set
            {
                borderFocusColor = value; Invalidate();
            }
        }

        private Color borderHoverColor = Global.PrimaryColors.BackHoverColor1;
        private Color borderFocusColor = Global.PrimaryColors.BackPressColor1;

        private Size imageSize = new Size(10, 10);
        public Size ImageSize
        {
            get { return imageSize; }
            set
            {
                imageSize = value; Invalidate();
            }
        }

        public enum TextBoxStyle { Style1, Style2 }
        TextBoxStyle style = TextBoxStyle.Style1;
        public TextBoxStyle Style
        {
            get { return style; }
            set
            {
                style = value;

                Invalidate();
            }
        }

        public bool UseAnimation { get; set; } = false;
        SizeF te;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            int s = 10;

            te = g.MeasureString(WatermarkText,
                   new Font(WatermarkFont.Name, s));
            GetAppResources.GetControlGraphicsEffect(g);
            var lineY = Height - BorderThickness - 2;

            if (Radius == 0)
            {
                g.SmoothingMode = SmoothingMode.Default;
            }
            GraphicsPath Gp = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(0, 0,
                 Width, Height - BorderThickness), Radius, BorderThickness);

            g.FillPath(new SolidBrush(butHover ? textBoxHoverColor : textBoxColor), Gp);

            //DrawWatermark();
           
            double fade = (UseAnimation ? 255 * _animationManager.GetProgress() : (Focused || butHover || !_animationManager.IsAnimating() ? 255 * 1 : 0));

            Pen pen = new Pen(new SolidBrush(tbCtrl.Focused ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(BorderHoverColor, borderFocusColor, fade) : butHover ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(BorderColor, BorderHoverColor, fade) : HeCopUI_Framework.Helper.DrawHelper.BlendColor(BorderColor, BorderHoverColor, fade)), borderThickness)
            { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset };
            switch (style)
            {
                case TextBoxStyle.Style1:
                    g.FillPath(new SolidBrush( tbCtrl.BackColor), HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(0, 0, Width, Height), Radius, BorderThickness));
                    if (BorderThickness >= 0)
                        g.DrawPath(pen, HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(0, 0, Width, Height), Radius, BorderThickness));
                    break;

                case TextBoxStyle.Style2:
                    if (UseAnimation == false || !_animationManager.IsAnimating())
                    {
                        //No animation
                        g.FillRectangle(new SolidBrush(tbCtrl.Focused ? borderFocusColor : borderColor), 0, lineY, Width, tbCtrl.Focused ? BorderThickness * 2 + 1 : BorderThickness * 2);
                    }
                    else
                    {
                        //Animate
                        int animationWidth = (int)(Width * _animationManager.GetProgress());
                        int halfAnimationWidth = animationWidth / 2;
                        int animationStart = 0 + Width / 2;
                        //Unfocused background
                        g.FillRectangle(new SolidBrush(BorderColor), 0, lineY, Width, BorderThickness);
                        //Animated focus transition
                        g.FillRectangle(new SolidBrush(BorderColor), animationStart - halfAnimationWidth, lineY, animationWidth, BorderThickness + 1);
                    }
                    break;

            }
            DrawImage(g);

        }
    }

}