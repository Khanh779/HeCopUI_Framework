
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HRichTextBox), "Bitmaps.RitchTextBox.bmp")]
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    [ComVisible(true)]
    public partial class HRichTextBox : Control
    {
        RichTextBox richTextBox;

        private System.Drawing.Text.TextRenderingHint textRenderHint = GetAppResources.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }

        Animations.AnimationManager _animationManager;

        public HRichTextBox()
        {

            SetStyle(GetAppResources.SetControlStyles(), true);
            richTextBox = new RichTextBox();
            _animationManager = new Animations.AnimationManager()
            {
                Increment = 0.08
            };
            //Inti();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            Inti();
            UpdateR();
            base.OnInvalidated(e);
        }

        protected override void OnCreateControl()
        {
            Inti();
            richTextBox.BackColor = RichTextBoxColor;

            _animationManager.OnAnimationProgress += delegate
            {
                Invalidate();
            };
            #region Event Mouse

            richTextBox.Leave += delegate
            {
             
                _animationManager.StartNewAnimation(Animations.AnimationDirection.Out);
            };

            richTextBox.Enter += (sender, e) =>
            {

                if (richTextBox.IsHandleCreated && richTextBox.Created)
                    _animationManager.StartNewAnimation(Animations.AnimationDirection.In);
                Invalidate();
            };

            richTextBox.MouseLeave += delegate
            {
                Hover = false;
                if (richTextBox.IsHandleCreated && richTextBox.Created)
                {
                    richTextBox.BackColor = RichTextBoxColor;
                    _animationManager.StartNewAnimation(Animations.AnimationDirection.Out);
                }
                Invalidate();
            };

            richTextBox.MouseEnter += delegate
            {
                Hover = true;
                if (richTextBox.IsHandleCreated && richTextBox.Created)
                    richTextBox.BackColor = RichTextBoxHoverColor;
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In);
                Invalidate();
            };

            #endregion

            richTextBox.MultilineChanged += (sender, e) =>
            {
                if (richTextBox.IsHandleCreated && richTextBox.Created)
                    MultilineChanged?.Invoke(richTextBox, e);
            };

            Controls.Add(richTextBox);
        
            UpdateR();
            base.OnCreateControl();
        }

        void Inti()
        {
          
            richTextBox.SelectionRightIndent = SelectionRightIndent;
            richTextBox.AcceptsTab = AcceptsTab;
            richTextBox.HideSelection = HideSelection;
            richTextBox.RightToLeft = RightToLeft;

            richTextBox.ShowSelectionMargin = ShowSelectionMargin;
            richTextBox.ShortcutsEnabled = ShorcutEnabled;
            richTextBox.BulletIndent = BulletIndent;
            richTextBox.AutoScrollOffset = AutoScrollOffset;
            richTextBox.AutoWordSelection = AutoWordSelection;
            richTextBox.ScrollBars = RichTextBoxScrollBars;
            richTextBox.EnableAutoDragDrop = EnableAutoDragDrop;
            richTextBox.Multiline = MultiLine;
            richTextBox.DetectUrls = DetectUrls;
            richTextBox.MaxLength = MaxLength;
            // richTextBox.ZoomFactor = ZoomFactor;
            richTextBox.BorderStyle = BorderStyle.None;
            richTextBox.TextChanged += (ob, send) =>
            {
                base.Text = richTextBox.Text;
            };
        }

        public Color TextColor
        {
            get { return richTextBox.ForeColor; }
            set
            {
                richTextBox.ForeColor = value;
                Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                richTextBox.Focus();
            }
            base.OnMouseClick(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            richTextBox.Focus();
            base.OnEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Hover = false;
            if (richTextBox.IsHandleCreated)
            {
                _animationManager.StartNewAnimation(Animations.AnimationDirection.Out);
                if (richTextBox.IsHandleCreated)
                    richTextBox.BackColor = RichTextBoxColor;
            }
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            Hover = true;
            if (richTextBox.IsHandleCreated)
            {
                _animationManager.StartNewAnimation(Animations.AnimationDirection.In);
                if (richTextBox.Created)
                    richTextBox.BackColor = RichTextBoxHoverColor;
            }
            Invalidate();
            base.OnMouseEnter(e);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.FillPath(new SolidBrush(Hover ? RichTextBoxHoverColor : richTextBox.BackColor),
                HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, Radius, BorderThickness));
            if (BorderThickness != 0)
                g.DrawPath(new Pen(new SolidBrush(richTextBox.Focused ?
                    HeCopUI_Framework.Helper.DrawHelper.BlendColor(BorderHoverColor, BorderFocusColor, _animationManager.GetProgress() * 255) :
                    Hover ? HeCopUI_Framework.Helper.DrawHelper.BlendColor(bc, BorderHoverColor, _animationManager.GetProgress() * 255) :
                    HeCopUI_Framework.Helper.DrawHelper.BlendColor(BorderColor, BorderHoverColor, _animationManager.GetProgress() * 255)),
                    BorderThickness),
                    HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, Radius, BorderThickness));

            base.OnPaint(e);
        }

        int ra = 1;
        public int Radius
        {
            get { return ra; }
            set
            {
                ra = value; Invalidate();
            }

        }

        int bt = 1;
        public int BorderThickness
        {
            get { return bt; }
            set
            {
                bt = value; Invalidate();
            }

        }

        
        private int sel = 0;
        public int SelectionRightIndent
        {
            get { return sel; }
            set
            {
                sel = value; Invalidate();

            }
        }



        private bool hideSelection = false;
        public bool HideSelection
        {
            get { return hideSelection; }
            set
            {
                hideSelection = value; Invalidate();
            }
        }

        private bool showSelectionMargin = false;
        public bool ShowSelectionMargin
        {
            get { return showSelectionMargin; }
            set
            {
                showSelectionMargin = value; Invalidate();

            }
        }

        private bool shortcutsEnabled = false;
        public bool ShorcutEnabled
        {
            get
            {
                return shortcutsEnabled;
            }
            set
            {
                shortcutsEnabled = value; Invalidate();
            }
        }

        private int bulletIndent = 0;

        public int BulletIndent
        {
            get { return bulletIndent; }
            set
            {
                bulletIndent = value; Invalidate();
            }
        }

        public event EventMultilineChanged MultilineChanged;

        public delegate void EventMultilineChanged(object sender, EventArgs e);

        private bool autoWordSelection = false;
        public bool AutoWordSelection
        {
            get { return autoWordSelection; }
            set
            {
                autoWordSelection = value; Invalidate();
            }
        }

        private bool enableAutoDragDrop = false;

        public bool EnableAutoDragDrop
        {
            get { return enableAutoDragDrop; }
            set
            {
                enableAutoDragDrop = value; Invalidate();
            }

        }

        public bool MultiLine
        {
            get {
                bool a = false;
                if (richTextBox == null && !richTextBox.IsHandleCreated) richTextBox = new RichTextBox();
                else a= richTextBox.Multiline;
                return a; }
            set
            {
               
                richTextBox.Multiline = value;
                Invalidate();

            }
        }

        public bool WordWrap
        {
            get
            {
                bool a = false;
                if (richTextBox == null && !richTextBox.IsHandleCreated) richTextBox = new RichTextBox();
                else a = richTextBox.WordWrap;
                return a;
            }
            set {   richTextBox.WordWrap = value; Invalidate(); }
        }

        private Point autoScrollOffset = new Point(0, 0);

        public new Point AutoScrollOffset
        {
            get { return autoScrollOffset; }
            set
            {
                autoScrollOffset = value; Invalidate();
            }
        }

        int maxLength = new RichTextBox().MaxLength;
        public int MaxLength
        {
            get { return maxLength; }
            set
            {
                maxLength = value; Invalidate();
            }
        }

        bool acceptsTab = false;

        public bool AcceptsTab
        {
            get { return acceptsTab; }
            set
            {
                acceptsTab = value; Invalidate();
            }
        }

        private bool detectUrls = true;
        public bool DetectUrls
        {
            get { return detectUrls; }
            set
            {
                detectUrls = value; Invalidate();
            }
        }

        RightToLeft rightToLeft = new RichTextBox().RightToLeft;

        public new RightToLeft RightToLeft
        {
            get { return rightToLeft; }
            set
            {
                rightToLeft = value; Invalidate();
            }
        }

        RichTextBoxScrollBars richTextBoxScrollBars = new RichTextBox().ScrollBars;


        public RichTextBoxScrollBars RichTextBoxScrollBars
        {
            get { return richTextBoxScrollBars; }
            set
            {
                richTextBoxScrollBars = value; Invalidate();
            }
        }

        bool Hover = false;

        void UpdateR()
        {
            if (IsHandleCreated && richTextBox.IsHandleCreated)
            {
                richTextBox.Location = new Point(BorderThickness + 2 + Radius / 2, BorderThickness + 2 + Radius / 2);
                richTextBox.Size = new Size(Width - BorderThickness * 2 - 2 - Radius, Height - BorderThickness * 2 - 2 - Radius);
                if (Size.Height <= 6 + BorderThickness * 2)
                {
                    Size = new Size(Width, 6 + BorderThickness * 2);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            UpdateR();
            base.OnResize(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            UpdateR();
            base.OnSizeChanged(e);
        }


        public string[] Lines
        {
            get {

                string[] a = { };
                if (richTextBox == null && !richTextBox.IsHandleCreated) richTextBox = new RichTextBox();
                else a = richTextBox.Lines;
                return a; 
               
            }
            set
            {
                richTextBox.Lines = value; Invalidate();
            }
        }

    
       
        public bool ReadOnly
        {
            get
            {
                bool a = false;
                if (richTextBox == null && !richTextBox.IsHandleCreated) richTextBox = new RichTextBox();
                else a = richTextBox.ReadOnly;
                return a;
            }
            set
            {
                richTextBox.ReadOnly = value; Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (richTextBox.IsHandleCreated)
                richTextBox.Focus();
            base.OnGotFocus(e);
        }

       
        private Color bc = Global.PrimaryColors.BorderNormalColor1;
        public Color BorderColor
        {
            get { return bc; }
            set
            {
                bc = value; Invalidate();
            }
        }

        
        private Color bhc = Global.PrimaryColors.BackHoverColor1;
        public Color BorderHoverColor
        {
            get { return bhc; }
            set
            {
                bhc = value; Invalidate();
            }
        }

        private Color tbc = Color.White;
        public Color RichTextBoxColor
        {
            get { return tbc; }
            set
            {
                if (value.A == 0)
                {
                    if (richTextBox. IsHandleCreated)
                        richTextBox.BackColor = Color.White;
                }
                else
                    tbc = value;
                if (richTextBox.IsHandleCreated)
                    richTextBox.BackColor = tbc;
                Invalidate();
            }
        }

        private Color tbhc = Color.White;
        public Color RichTextBoxHoverColor
        {
            get { return tbhc; }
            set
            {
                if (value.A == 255)
                    tbhc = value;
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
                base.Text = value;
                richTextBox.Text = value;
                Invalidate();
            }
        }

        public Color BorderFocusColor { get; set; } = HeCopUI_Framework.Global.PrimaryColors.BorderNormalColor1;
    }
}