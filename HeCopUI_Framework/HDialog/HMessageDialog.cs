using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Controls.Button;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace HeCopUI_Framework.HDialog
{
    public partial class HMessageDialog : UserControl
    {
        #region Components
        private Controls.HPanel HPanel1;
        private FlowLayoutPanel PN_BtnCollection;
        private Controls.HLabel hLabel1;
        private Controls.HLabel hLabel2;
        private Panel panel1;
        private HImage hImage1;
        private Panel PN_Ico;
        private FlowLayoutPanel flowLayoutPanel1;
        #endregion

        #region Initialize Component Form

        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.HPanel1 = new HeCopUI_Framework.Controls.HPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hLabel2 = new HeCopUI_Framework.Controls.HLabel();
            this.PN_Ico = new System.Windows.Forms.Panel();
            this.hImage1 = new HeCopUI_Framework.Controls.HImage();
            this.PN_BtnCollection = new System.Windows.Forms.FlowLayoutPanel();
            this.hLabel1 = new HeCopUI_Framework.Controls.HLabel();
            this.HPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PN_Ico.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 179);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(493, 41);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // HPanel1
            // 
            this.HPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HPanel1.BackColor = System.Drawing.Color.Transparent;
            this.HPanel1.BorderColor = System.Drawing.Color.DodgerBlue;
            this.HPanel1.BorderThickness = 4F;
            this.HPanel1.Controls.Add(this.panel1);
            this.HPanel1.Controls.Add(this.PN_BtnCollection);
            this.HPanel1.Controls.Add(this.hLabel1);
            this.HPanel1.Location = new System.Drawing.Point(25, 50);
            this.HPanel1.Name = "HPanel1";
            this.HPanel1.PanelColor1 = System.Drawing.Color.White;
            this.HPanel1.Radius = new Struct.CornerRadius(10);
            this.HPanel1.RoundBottomLeft = true;
            this.HPanel1.RoundBottomRight = true;
            this.HPanel1.RoundTopLeft = true;
            this.HPanel1.RoundTopRight = true;
            this.HPanel1.Size = new System.Drawing.Size(475, 215);
            this.HPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hLabel2);
            this.panel1.Controls.Add(this.PN_Ico);
            this.panel1.Location = new System.Drawing.Point(19, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 89);
            this.panel1.TabIndex = 3;
            // 
            // hLabel2
            // 
            this.hLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.hLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hLabel2.Location = new System.Drawing.Point(54, 0);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(380, 89);
            this.hLabel2.TabIndex = 2;
            this.hLabel2.Text = "Văn bản thông báo";
            this.hLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // PN_Ico
            // 
            this.PN_Ico.Controls.Add(this.hImage1);
            this.PN_Ico.Dock = System.Windows.Forms.DockStyle.Left;
            this.PN_Ico.Location = new System.Drawing.Point(0, 0);
            this.PN_Ico.Name = "PN_Ico";
            this.PN_Ico.Size = new System.Drawing.Size(54, 89);
            this.PN_Ico.TabIndex = 4;
            // 
            // hImage1
            // 
            this.hImage1.Dock = System.Windows.Forms.DockStyle.Top;

            this.hImage1.Image = null;
            this.hImage1.ImageSize = new System.Drawing.Size(150, 150);
            this.hImage1.Location = new System.Drawing.Point(0, 0);
            this.hImage1.Name = "hImage1";
            this.hImage1.SetImageSizeMode = HeCopUI_Framework.Controls.HImage.ImageSizeMode.Zoom;
            this.hImage1.Size = new System.Drawing.Size(54, 47);
            this.hImage1.TabIndex = 3;
            this.hImage1.Text = "hImage1";
            // 
            // PN_BtnCollection
            // 
            this.PN_BtnCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PN_BtnCollection.CausesValidation = false;
            this.PN_BtnCollection.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.PN_BtnCollection.Location = new System.Drawing.Point(19, 165);
            this.PN_BtnCollection.Name = "PN_BtnCollection";
            this.PN_BtnCollection.Size = new System.Drawing.Size(437, 42);
            this.PN_BtnCollection.TabIndex = 0;
            // 
            // hLabel1
            // 
            this.hLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hLabel1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.hLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.hLabel1.Location = new System.Drawing.Point(19, 15);
            this.hLabel1.Name = "hLabel1";
            this.hLabel1.Size = new System.Drawing.Size(434, 41);
            this.hLabel1.TabIndex = 1;
            this.hLabel1.Text = "Tiêu đề thông báo";
            this.hLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // HMessageDialog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.HPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "HMessageDialog";
            this.Size = new System.Drawing.Size(525, 325);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HMessageDialog_Paint);
            this.HPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.PN_Ico.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        public HMessageDialog()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Load += HMessageDialog_Load;
        }

        public Padding OverlayFormPadding { get; set; } = new Padding(0, 0, 0, 0);
        public string Title { get; set; } = "Message Dialog";
        public string MessageText { get; set; } = "This is example.";

        public string OKButton { get; set; } = "OK";
        public string CancelButton { get; set; } = "Cancel";
        public string YesButton { get; set; } = "Yes";
        public string NoButton { get; set; } = "No";
        public string AbortButton { get; set; } = "Abort";
        public string RetryButton { get; set; } = "Retry";
        public string IgnoreButton { get; set; } = "Ignore";

        public MessageBoxButtons MessageBoxButton { get; set; } = MessageBoxButtons.OK;

        public MessageBoxIcon MessageBoxIcon { get; set; } = MessageBoxIcon.None;

        public void ShowMessageOverlay(Control owner)
        {
            ow = owner;
            owner.Controls.Add(this);
            Show();
            this.BringToFront();
            Location = new Point(2 + OverlayFormPadding.Left, 2 + OverlayFormPadding.Top);
            Size = new Size(owner.Width - OverlayFormPadding.Left - 4 - OverlayFormPadding.Right,
               owner.Height - OverlayFormPadding.Top - OverlayFormPadding.Bottom - 4);
            owner.SizeChanged += Owner_SizeChanged;
            Focus();

        }

        Control ow;

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Space)
            {
                Parent.Controls.Remove(this);
            }
            return base.ProcessDialogKey(keyData);
        }



        private void Owner_SizeChanged(object sender, EventArgs e)
        {
            Control owner = ow;
            Size = new Size(owner.Width - OverlayFormPadding.Left - 4 - OverlayFormPadding.Right,
              owner.Height - OverlayFormPadding.Top - OverlayFormPadding.Bottom - 4);
        }

        private void HMessageDialog_Load(object sender, EventArgs e)
        {
            PN_BtnCollection.Controls.Clear();
            hLabel1.Text = Title; hLabel2.Text = MessageText;
            LoadMessageDialogType();
            PN_Ico.Visible = true;
            HPanel1.Location = new Point((Width - HPanel1.Width) / 2, (Height - HPanel1.Height) / 2);
            foreach (HButton sd in PN_BtnCollection.Controls)
            {
                sd.AutoSize = true; sd.TextPadding = new Padding(4, 4, 4, 4);
                sd.AnimationMode = Enums.AnimationMode.ColorTransition;
                sd.Font = new Font("Arial", 13f, FontStyle.Bold);
                sd.ButtonColor1 = sd.ButtonColor2 = ButtonColor;
                sd.BackPressColor1 = sd.BackPressColor2 = BackPressColor;
                sd.BackHoverColor1 = sd.BackHoverColor2 = BackHoverColor;
                sd.TextHoverColor = TextHoverColor;
                sd.TextNormalColor = TextNormalColor;
                sd.TextDownColor = TextDownColor;
                sd.Radius = new Struct.CornerRadius(5);
            }

            switch (MessageBoxIcon)
            {
                case MessageBoxIcon.None:
                    PN_Ico.Visible = false;
                    break;
                case MessageBoxIcon.Warning:
                    hImage1.Image = SystemIcons.Warning.ToBitmap();
                    break;
                case MessageBoxIcon.Question:
                    hImage1.Image = SystemIcons.Question.ToBitmap();
                    break;
                case MessageBoxIcon.Information:
                    hImage1.Image = SystemIcons.Information.ToBitmap();
                    break;
                case MessageBoxIcon.Error:
                    hImage1.Image = SystemIcons.Error.ToBitmap();
                    break;


            }
        }


        public Color BackHoverColor { get; set; } = Color.FromArgb(235, 235, 235);
        public Color TextHoverColor { get; set; } = Color.FromArgb(0, 188, 168);
        public Color TextNormalColor { get; set; } = Color.FromArgb(0, 168, 148);
        public Color ButtonColor { get; set; } = Color.White;
        public Color BackPressColor { get; set; } = Color.FromArgb(225, 225, 225);
        public Color TextDownColor { get; set; } = Color.FromArgb(0, 148, 128);

        private void HMessageDialog_Paint(object sender, PaintEventArgs e)
        {
            GetAppResources.MakeTransparent(this, e.Graphics);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(160, Color.Black)), ClientRectangle);
        }

        public DialogResult DialogResult = DialogResult.None;

        void LoadMessageDialogType()
        {
            switch (MessageBoxButton)
            {
                case MessageBoxButtons.OK:
                    OK();
                    break;
                case MessageBoxButtons.YesNo:
                    YesNo();
                    break;
                case MessageBoxButtons.OKCancel:
                    OKCancel();
                    break;
            }

        }


        void OK()
        {
            HButton Yes = new HButton();
            Yes.Text = OKButton;
            Yes.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DialogResult = DialogResult.OK;
                    Parent.Controls.Remove(this);
                }
            };
            PN_BtnCollection.Controls.Add(Yes);
        }

        void YesNo()
        {
            HButton Yes = new HButton();
            Yes.Text = YesButton;
            Yes.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DialogResult = DialogResult.Yes;
                    Parent.Controls.Remove(this);
                }
            };
            HButton No = new HButton();
            No.Text = NoButton;
            No.MouseClick += (sender, e) =>
              {
                  if (e.Button == MouseButtons.Left)
                  {
                      DialogResult = DialogResult.No; Parent.Controls.Remove(this);
                  }
              };
            PN_BtnCollection.Controls.Add(No);
            PN_BtnCollection.Controls.Add(Yes);
        }

        void OKCancel()
        {
            HButton Yes = new HButton();
            Yes.Text = OKButton;
            Yes.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DialogResult = DialogResult.OK; Parent.Controls.Remove(this);
                }
            };
            HButton No = new HButton();
            No.Text = CancelButton;
            No.MouseClick += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    DialogResult = DialogResult.Cancel; Parent.Controls.Remove(this);
                }
            };
            PN_BtnCollection.Controls.Add(No);
            PN_BtnCollection.Controls.Add(Yes);
        }

    }
}
