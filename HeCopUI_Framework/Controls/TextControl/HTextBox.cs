using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Drawing.Text;
using System.Security.Cryptography;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace HecopUI_Test.CControls
{
    [DefaultEvent("TextChanged")]
    public class HTextBox : Control
    {
        private bool _underlineStyle = true;
        private TextBox innerTextBox;
        warterMark wm = new warterMark();
        Color watermarkForeColor = Color.Gray;
        Color borderColor = Color.Gray;

        public HTextBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            Cursor = Cursors.IBeam;
            base.ForeColor = Color.DimGray;

            innerTextBox = new TextBox();
            Text = innerTextBox.Text;
            innerTextBox.BorderStyle = BorderStyle.None;
            innerTextBox.TextChanged += InnerTextBox_TextChanged; ;

            wm.Click += Wm_Click;


            UpdateInnerTextBoxPosition();


        }

        private void InnerTextBox_TextChanged(object sender, EventArgs e)
        {
            Text = innerTextBox.Text;
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
                innerTextBox.Text = Text;
            Invalidate();
        }

        #region Properties for innerTextBox

        [Browsable(true)]
        [Category("Misc")]
        [Description("The font used by the text box.")]
        public new Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Misc")]
        [Description("The background color of the text box.")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Misc")]
        [Description("The foreground color of the text box.")]
        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Misc")]
        [Description("The foreground color of wartermark text.")]
        public Color WatermarkForeColor
        {
            get { return watermarkForeColor; }
            set
            {
                watermarkForeColor = value;
                Invalidate();
            }
        }

        bool _multiline = false;
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether the text box is multiline.")]
        public bool Multiline
        {
            get { return _multiline; }
            set
            {
                _multiline = value;
                Invalidate();
            }
        }

        bool _readOnly = false;
        [Browsable(true)]
        [DefaultValue(true)]
        [Description("Indicates whether the text box is read-only.")]
        public bool ReadOnly
        {
            get { return _readOnly; }
            set
            {
                _readOnly = value;
                Invalidate();
            }
        }

        bool _useSystemPasswordChar = false;
        [Browsable(true)]
        [DefaultValue(false)]
        [Description("Indicates whether the text box uses the password character.")]
        public bool UseSystemPasswordChar
        {
            get { return _useSystemPasswordChar; }
            set
            {
                _useSystemPasswordChar = value;
                Invalidate();
            }
        }

        HorizontalAlignment _textAlign = HorizontalAlignment.Left;
        [Browsable(true)]
        [Description("The text alignment within the text box.")]
        public HorizontalAlignment TextAlign
        {
            get { return _textAlign; }
            set
            {
                _textAlign = value;
                Invalidate();
            }
        }

        #endregion

        #region Properties for CustomTextBox

        int _borderWidth = 1;
        /// <summary>
        /// Gets or sets the border width of the TextBox control.
        /// </summary>
        [Description("The border width of the TextBox control.")]
        public int BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;

                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border color of the TextBox control.
        /// </summary>
        [Description("The border color of the TextBox control.")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        string _wartermark = "Type watermark text here.";
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        /// <summary>
        /// Gets or sets the watermark text of the TextBox control.
        /// </summary>
        [Description("The watermark text of the TextBox control.")]
        public string Watermark
        {
            get { return _wartermark; }
            set
            {
                _wartermark = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the underline style of the TextBox control.
        /// </summary>
        [Description("The underline style of the TextBox control.")]
        public bool UnderlineStyle
        {
            get { return _underlineStyle; }
            set
            {
                _underlineStyle = value;
                Invalidate();
            }
        }

        TextRenderingHint textRenderingHint = HeCopUI_Framework.GetAppResources.SetTextRender();
        /// <summary>
        /// Gets or sets the text rendering hint of the text in the TextBox control.
        /// </summary>
        [Description("The text rendering hint of the text in the TextBox control.")]
        public TextRenderingHint TextRenderHint
        {
            get { return textRenderingHint; }
            set
            {
                textRenderingHint = value;
                Invalidate();
            }
        }

        Font wartermarkFont = Control.DefaultFont;
        /// <summary>
        /// Gets or sets the font of the watermark text in the TextBox control.
        /// </summary>
        [Description("The font of the watermark text in the TextBox control.")]
        public Font WartermarkFont
        {
            get { return wartermarkFont; }
            set
            {
                wartermarkFont = value;
                Invalidate();
            }
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        [Category("Misc")]
        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Description("The text associated with this control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                if (innerTextBox != null && innerTextBox.IsHandleCreated)
                    innerTextBox.Text = value;
                Invalidate();
            }
        }

        CharacterCasing characterCasing = CharacterCasing.Normal;

        /// <summary>
        /// Gets or sets the character casing of the text in the TextBox control.
        /// </summary>
        /// <param name="e"></param>
        [Description("The character casing of the text in the TextBox control.")]
        public CharacterCasing CharacterCasing
        {
            get { return characterCasing; }
            set
            {
                characterCasing = value;
                Invalidate();
            }
        }

        int maxLength = 32767;
        /// <summary>
        /// Gets or sets the maximum number of characters the user can type or paste into the text box control.
        /// </summary>
        [Description("The maximum number of characters the user can type or paste into the text box control.")]
        public int MaxLength
        {
            get { return maxLength; }
            set
            {
                maxLength = value;
                Invalidate();
            }
        }

        char passwordChar = '\0';
        /// <summary>
        /// Gets or sets the character used to mask characters of a password in a single-line TextBox control.
        /// </summary>
        [Description("The character used to mask characters of a password in a single-line TextBox control.")]
        public char PasswordChar
        {
            get { return passwordChar; }
            set
            {
                passwordChar = value;
                Invalidate();
            }
        }

        bool shortCutKeysEnabled = true;
        /// <summary>
        /// Gets or sets a value indicating whether the defined shortcuts are enabled.
        /// </summary>
        [Description("A value indicating whether the defined shortcuts are enabled.")]
        public bool ShortCutKeysEnabled
        {
            get { return shortCutKeysEnabled; }
            set
            {
                shortCutKeysEnabled = value;
                Invalidate();
            }
        }

        bool hideSelection = true;
        /// <summary>
        /// Gets or sets a value indicating whether the selected text in the text box control remains highlighted when the control loses focus.
        /// </summary>
        public bool HideSelection
        {
            get { return hideSelection; }
            set
            {
                hideSelection = value;
                Invalidate();
            }
        }

        bool acceptReturn = false;
        /// <summary>
        /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.
        /// </summary>
        public bool AcceptReturn
        {
            get { return acceptReturn; }
            set
            {
                acceptReturn = value;
                Invalidate();
            }
        }

        bool acceptTab = false;
        /// <summary>
        /// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.
        /// </summary>
        public bool AcceptTab
        {
            get { return acceptTab; }
            set
            {
                acceptTab = value;
                Invalidate();
            }
        }

        bool wordWrap = true;
        /// <summary>
        /// Gets or sets a value indicating whether text in the text box control is displayed using multiple lines.
        /// </summary>
        public bool WordWrap
        {
            get { return wordWrap; }
            set
            {
                wordWrap = value;
                Invalidate();
            }
        }

        AutoCompleteStringCollection autoCompleteCustomSource = new AutoCompleteStringCollection();
        /// <summary>
        /// Gets or sets the custom source for auto-complete strings.
        /// </summary>
        ///   [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Localizable(true)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("Misc_AutoComplete")]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return autoCompleteCustomSource; }
            set
            {
                autoCompleteCustomSource = value;
                Invalidate();
            }
        }

        AutoCompleteMode autoCompleteMode = AutoCompleteMode.None;
        /// <summary>
        /// Gets or sets an option that controls how automatic completion works for the TextBox.
        /// </summary>
        [Category("Misc_AutoComplete")]
        [DefaultValue(AutoCompleteMode.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return autoCompleteMode; }
            set
            {
                autoCompleteMode = value;
                Invalidate();
            }
        }

        AutoCompleteSource autoCompleteSource = AutoCompleteSource.None;
        /// <summary>
        /// Gets or sets a value specifying the source of complete strings used for automatic completion.
        /// </summary>
        [Category("Misc_AutoComplete")]
        [DefaultValue(AutoCompleteSource.None)]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return autoCompleteSource; }
            set
            {
                autoCompleteSource = value;
                Invalidate();
            }
        }


        string[] lines = new string[] { };
        /// <summary>
        /// Gets the lines of text in a multiline TextBox control.
        /// </summary>
        public string[] Lines
        {
            get { return lines; }
            set
            {
                lines = value;
                Invalidate();
            }
        }

        RightToLeft rightToLeft = RightToLeft.No;
        /// <summary>
        /// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
        /// </summary>
        [Localizable(true)]
        [Category("Misc")]
        //[AmbientValue(RightToLeft.Inherit)]
        public override RightToLeft RightToLeft
        {
            get { return rightToLeft; }
            set
            {
                rightToLeft = value;
                Invalidate();
            }
        }



        #endregion

        #region Events and methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            using (var pen = new Pen(BorderColor, _borderWidth))
            {
                if (_underlineStyle)
                {
                    g.DrawLine(pen, 0, Height - 1, Width, Height - 1);
                }
                else
                {
                    g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
                }
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateInnerTextBoxSize();
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
                innerTextBox.Focus();
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
                innerTextBox.Focus();
            Invalidate();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            innerTextBox.Text = Text;
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
                innerTextBox.Focus();
        }

        private void Wm_Click(object sender, EventArgs e)
        {
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
                innerTextBox.Focus();
            Invalidate();
        }


        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateTextAndWarter();
            UpdateInnerTextBoxPosition();

        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            UpdateInnerTextBoxPosition();
            base.OnInvalidated(e);
        }

        void UpdateTextAndWarter()
        {
            if (innerTextBox != null && !Controls.Contains(innerTextBox))
                Controls.Add(innerTextBox);

            if (wm != null && !Controls.Contains(wm))
            {
                Controls.Add(wm);
                wm.BringToFront();
            }
            Invalidate();
        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
            {
                innerTextBox.Cursor = Cursor;
            }
            if (wm != null && wm.IsHandleCreated)
            {
                wm.Cursor = Cursor;

            }
            Invalidate();
        }

        void UpdateInnerTextBoxPosition()
        {
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
            {
                innerTextBox.Location = new Point(2 + BorderWidth, (Height - innerTextBox.Height) / 2);

                if (wm != null && wm.IsHandleCreated)
                {
                    wm.Size = new Size(Width - 3 - BorderWidth * 2, innerTextBox.Height);
                    wm.Location = new Point(innerTextBox.Location.X + (TextAlign == HorizontalAlignment.Left ? 1 : TextAlign == HorizontalAlignment.Right ? -1 : 0),
                        innerTextBox.Location.Y);

                    wm.Text = _wartermark;
                    wm.Font = WartermarkFont;
                    wm.ForeColor = WatermarkForeColor;
                    wm.TextRenderHint = TextRenderHint;
                    wm.TextAlign = TextAlign;

                }
                if (innerTextBox != null && innerTextBox.IsHandleCreated)
                {
                    if (wm != null && wm.IsHandleCreated)
                        wm.Visible = string.IsNullOrEmpty(innerTextBox.Text) && !Multiline && TextAlign != HorizontalAlignment.Center;

                    innerTextBox.Font = Font;
                    innerTextBox.BackColor = BackColor;
                    innerTextBox.ForeColor = ForeColor;
                    innerTextBox.Multiline = Multiline;
                    innerTextBox.ReadOnly = ReadOnly;
                    innerTextBox.UseSystemPasswordChar = UseSystemPasswordChar;
                    innerTextBox.TextAlign = TextAlign;
                    innerTextBox.CharacterCasing = CharacterCasing;
                    innerTextBox.MaxLength = MaxLength;
                    innerTextBox.PasswordChar = PasswordChar;
                    innerTextBox.ShortcutsEnabled = ShortCutKeysEnabled;
                    innerTextBox.HideSelection = HideSelection;
                    innerTextBox.AcceptsReturn = AcceptReturn;
                    innerTextBox.AcceptsTab = AcceptTab;
                    innerTextBox.WordWrap = WordWrap;

                    innerTextBox.RightToLeft = RightToLeft;

                    //innerTextBox.AutoCompleteCustomSource = AutoCompleteCustomSource;
                    //if (innerTextBox.Created && innerTextBox.IsHandleCreated)
                    //{
                    //    innerTextBox.AutoCompleteMode = AutoCompleteMode;
                    //}
                    //innerTextBox.AutoCompleteSource = AutoCompleteSource;

                    if (Lines.Length > 0)
                        innerTextBox.Lines = Lines;
                }


                UpdateInnerTextBoxSize();
            }
        }

        void UpdateInnerTextBoxSize()
        {
            if (innerTextBox != null && innerTextBox.IsHandleCreated)
            {
                innerTextBox.Width = Width - 4 - BorderWidth * 2;


                if (Height <= (Multiline ? 40 : innerTextBox.Height + BorderWidth * 2 + 4))
                {
                    Height = Multiline ? 40 : innerTextBox.Height + BorderWidth * 2 + 4;

                }
                if (Multiline)
                    innerTextBox.Height = Height - 2 - BorderWidth * 2;

                if (Width < 100)
                {
                    Width = innerTextBox.Width + BorderWidth * 2 + 4;
                }

            }
        }

        #endregion

        private class warterMark : Control
        {
            public warterMark()
            {
                SetStyle(ControlStyles.OptimizedDoubleBuffer |
                         ControlStyles.SupportsTransparentBackColor, true);
            }

            TextRenderingHint trd = HeCopUI_Framework.GetAppResources.SetTextRender();
            /// <summary>
            /// Gets or sets the text rendering hint of the text in the TextBox control.
            /// </summary>
            public TextRenderingHint TextRenderHint
            {
                get
                {
                    return trd;
                }
                set
                {
                    trd = value;
                    Invalidate();
                }
            }

            HorizontalAlignment _textAlign = HorizontalAlignment.Left;
            /// <summary>
            /// Gets or sets the text alignment within the text box.
            /// </summary>
            public HorizontalAlignment TextAlign
            {
                get
                {
                    return _textAlign;
                }
                set
                {
                    _textAlign = value;
                    Invalidate();
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                Bitmap bmp = new Bitmap(Width, Height);
                bmp.MakeTransparent();

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    g.TextRenderingHint = trd;

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    switch (_textAlign)
                    {
                        case HorizontalAlignment.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;
                        case HorizontalAlignment.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;
                        case HorizontalAlignment.Right:
                            sf.Alignment = StringAlignment.Far;
                            break;
                    }
                    sf.Trimming = StringTrimming.EllipsisCharacter;

                    using (var bru = new SolidBrush(ForeColor))
                        g.DrawString(Text, Font, bru, new RectangleF(0, 0, Width, Height), sf);


                    sf.Dispose();

                }
                e.Graphics.DrawImage(bmp, 0, 0);


            }
        }
    }
}
