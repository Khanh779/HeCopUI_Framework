
using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HeCopUI_Framework.Forms
{
    [ToolboxItem(false)]
    public partial class HMessageBox : Form
    {
        private static HMessageBox _MsgBox;
        private List<HButton> _buttonCollection = new List<HButton>();
        private static DialogResult _buttonResult = new DialogResult();
        private HDropShadowForm hDropShadowForm1;
        private HFormControlBox hFormControlBox11;
        private static Timer _timer;

        [DllImport("Msg.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);

        public enum MessageBoxStyle
        {
            /// <summary>
            /// Gets or sets user interface with Light Style.
            /// </summary>
            Light,
            /// <summary>
            /// Gets or sets user interface with Dark Style.
            /// </summary>
            Dark,
            /// <summary>
            /// Gets or sets user interface with Custom Style.\nThis Style will be set by user.
            /// </summary>
            Custom
        }
        private HMessageBox.MessageBoxStyle messageBoxStyle = HMessageBox.MessageBoxStyle.Custom;
        public HMessageBox.MessageBoxStyle Style
        {
            get { return messageBoxStyle; }
            set
            {
                messageBoxStyle = value; Invalidate();
            }
        }

        #region FormDesignMess
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LB_Product = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.hFormControlBox11 = new HeCopUI_Framework.Controls.HFormControlBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.hDragControl1 = new HeCopUI_Framework.Controls.HDragControl();
            this.hDragControl2 = new HeCopUI_Framework.Controls.HDragControl();
            this.hDragControl3 = new HeCopUI_Framework.Controls.HDragControl();
            this.hDragControl4 = new HeCopUI_Framework.Controls.HDragControl();
            this.hDropShadowForm1 = new HeCopUI_Framework.Controls.HDropShadowForm();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.LB_Product);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 38);
            this.panel1.TabIndex = 1;
            // 
            // LB_Product
            // 
            this.LB_Product.AutoEllipsis = true;
            this.LB_Product.CausesValidation = false;
            this.LB_Product.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Product.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LB_Product.Location = new System.Drawing.Point(30, 10);
            this.LB_Product.Name = "LB_Product";
            this.LB_Product.Size = new System.Drawing.Size(215, 20);
            this.LB_Product.TabIndex = 2;
            this.LB_Product.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.hFormControlBox11);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(278, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(42, 38);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // hFormControlBox11
            // 
            this.hFormControlBox11.ForeColor = System.Drawing.Color.Gray;
            this.hFormControlBox11.HoverColorType = ShapeType.Circular;
            this.hFormControlBox11.IconButtonType = HeCopUI_Framework.Controls.HFormControlBox.IconType.Close;
            this.hFormControlBox11.Location = new System.Drawing.Point(3, 5);
            this.hFormControlBox11.MaximizeToFullScreen = false;
            this.hFormControlBox11.Name = "hFormControlBox11";
            this.hFormControlBox11.Radius = 0;
            this.hFormControlBox11.Size = new System.Drawing.Size(32, 28);
            this.hFormControlBox11.TabIndex = 0;

            this.hFormControlBox11.Text = "hFormControlBox11";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(52, 93);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(15, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(52, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 93);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.CausesValidation = false;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(6, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(268, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Message Text Here!\r\n=>This is example about Message Box!";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(10, 2, 0, 0);
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(268, 51);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // hDragControl1
            // 
            this.hDragControl1.GetControl = this.panel1;
            this.hDragControl1.TargetControl = this;
            // 
            // hDragControl2
            // 
            this.hDragControl2.GetControl = this.pictureBox1;
            this.hDragControl2.TargetControl = this;
            // 
            // hDragControl3
            // 
            this.hDragControl3.GetControl = this.LB_Product;
            this.hDragControl3.TargetControl = this;
            // 
            // hDragControl4
            // 
            this.hDragControl4.GetControl = this.flowLayoutPanel1;
            this.hDragControl4.TargetControl = this;
            // 
            // hDropShadowForm1
            // 
            this.hDropShadowForm1.AlphaColor = 150;
            this.hDropShadowForm1.HideResizeShadow = false;
            this.hDropShadowForm1.ShadowBlur = 10;
            this.hDropShadowForm1.ShadowColor = System.Drawing.Color.Black;
            this.hDropShadowForm1.ShadowSpread = 0;
            this.hDropShadowForm1.ShadowVisible = true;
            this.hDropShadowForm1.TargetForm = this;
            // 
            // HMessageBox
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(320, 131);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LB_Product;
        private HDragControl hDragControl1;
        private HDragControl hDragControl2;
        private HDragControl hDragControl3;
        private HDragControl hDragControl4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        #endregion

        public HMessageBox()
        {
            InitializeComponent();
            SetStyle(GetAppResources.SetControlStyles(), true);
            Paint += HMessageBox_Paint;
            //_MsgBox.Paint += HMessageBox_Paint;
            Text = LB_Product.Text;
            Load += Form1_Load;
            _MsgBox = this;
            ApplyTheme();
        }

        void ApplyTheme()
        {
            switch (messageBoxStyle)
            {
                case MessageBoxStyle.Light:
                    BackColor = Color.White;
                    label1.ForeColor = LB_Product.ForeColor = Color.DimGray;
                    break;
                case MessageBoxStyle.Dark:
                    BackColor = Color.FromArgb(30, 30, 30);
                    label1.ForeColor = LB_Product.ForeColor = Color.White;
                    break;
            }
        }

        public Color BorderColor { get; set; } = Color.Silver;
        public int BorderThickness { get; set; } = 4;

        private void HMessageBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            Rectangle RF = new Rectangle(0, 0, Width - 1, Height - 1);
            g.DrawRectangle(new Pen(new SolidBrush(BorderColor), BorderThickness), RF);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _MsgBox = this;
            SizeChanged += (Sender, E) =>
            {
                Invalidate();
            };
            Resize += (Sender, E) =>
            {
                Invalidate();
            };
        }
        public static DialogResult Show(string message)
        {
            _MsgBox = new HMessageBox();
            _MsgBox.label1.Text = message;
            _MsgBox.pictureBox2 = null;
            InitButtons(Buttons.OK);
            InitOKButton();
            _MsgBox.Size = HMessageBox.MessageSize(message);
            _MsgBox.panel2.Hide();
            _MsgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title)
        {
            _MsgBox = new HMessageBox();
            _MsgBox.label1.Text = message;
            _MsgBox.pictureBox2 = null;
            _MsgBox.LB_Product.Text = title;
            _MsgBox.Size = HMessageBox.MessageSize(message);
            _MsgBox.panel2.Hide();
            InitButtons(Buttons.OK);
            InitOKButton();
            _MsgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons)
        {
            _MsgBox = new HMessageBox();
            _MsgBox.label1.Text = message;
            _MsgBox.LB_Product.Text = title;
            _MsgBox.panel2.Hide();
            HMessageBox.InitButtons(buttons);

            _MsgBox.Size = HMessageBox.MessageSize(message);
            _MsgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, HIcon icon)
        {
            _MsgBox = new HMessageBox();
            _MsgBox.label1.Text = message;
            _MsgBox.LB_Product.Text = title;

            HMessageBox.InitButtons(buttons);
            HMessageBox.InitIcon(icon);

            _MsgBox.Size = HMessageBox.MessageSize(message);
            _MsgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }

        public static DialogResult Show(string message, string title, Buttons buttons, HIcon icon, AnimateStyle style)
        {
            _MsgBox = new HMessageBox();
            _MsgBox.label1.Text = message;
            _MsgBox.LB_Product.Text = title;
            _MsgBox.Height = 0;
            HMessageBox.InitButtons(buttons);
            HMessageBox.InitIcon(icon);
            _timer = new Timer();
            Size formSize = HMessageBox.MessageSize(message);

            switch (style)
            {
                case HMessageBox.AnimateStyle.SlideDown:
                    _MsgBox.Size = new Size(formSize.Width, 0);
                    _timer.Interval = 1;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case HMessageBox.AnimateStyle.FadeIn:
                    _MsgBox.Size = formSize;
                    _MsgBox.Opacity = 0;
                    _timer.Interval = 20;
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    break;

                case HMessageBox.AnimateStyle.ZoomIn:
                    _MsgBox.Size = new Size(formSize.Width + 100, formSize.Height + 100);
                    _timer.Tag = new AnimateMsgBox(formSize, style);
                    _timer.Interval = 1;
                    break;
            }

            _timer.Tick += timer_Tick;
            _timer.Start();
            _MsgBox.ShowDialog();
            MessageBeep(0);
            return _buttonResult;
        }
        static void timer_Tick(object sender, EventArgs e)
        {
            Timer timer = (Timer)sender;
            AnimateMsgBox animate = (AnimateMsgBox)timer.Tag;
            switch (animate.Style)
            {
                case HMessageBox.AnimateStyle.SlideDown:
                    if (_MsgBox.Height < animate.FormSize.Height)
                    {
                        _MsgBox.Height += 17;
                        _MsgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;

                case HMessageBox.AnimateStyle.FadeIn:
                    if (_MsgBox.Opacity < 1)
                    {
                        _MsgBox.Opacity += 0.1;
                        _MsgBox.Invalidate();
                    }
                    else
                    {
                        _timer.Stop();
                        _timer.Dispose();
                    }
                    break;

                case HMessageBox.AnimateStyle.ZoomIn:
                    if (_MsgBox.Width > animate.FormSize.Width)
                    {
                        _MsgBox.Width -= 17;
                        _MsgBox.Invalidate();
                    }
                    if (_MsgBox.Height > animate.FormSize.Height)
                    {
                        _MsgBox.Height -= 17;
                        _MsgBox.Invalidate();
                    }
                    break;
            }
        }

        private static void InitButtons(Buttons buttons)
        {
            switch (buttons)
            {
                case HMessageBox.Buttons.AbortRetryIgnore:
                    InitAbortRetryIgnoreButtons();
                    break;

                case HMessageBox.Buttons.OK:
                    InitOKButton();
                    break;

                case HMessageBox.Buttons.OKCancel:
                    InitOKCancelButtons();
                    break;

                case HMessageBox.Buttons.RetryCancel:
                    _MsgBox.InitRetryCancelButtons();
                    break;

                case HMessageBox.Buttons.YesNo:
                    HMessageBox.InitYesNoButtons();
                    break;

                case HMessageBox.Buttons.YesNoCancel:
                    InitYesNoCancelButtons();
                    break;
            }

            foreach (HButton btn in _MsgBox._buttonCollection)
            {
                btn.Height = 30;
                btn.Width = 80;
                btn.Font = Font;
                btn.TextTrim = StringTrimming.EllipsisCharacter;
                SizeF me = TextRenderer.MeasureText(btn.Text, btn.Font);
                btn.Size = new Size((int)me.Width + 10, btn.Height);
                btn.AutoSize = true;
                btn.ShapeButtonType = ShapeType.Rectangle;
                _MsgBox.flowLayoutPanel2.Controls.Add(btn);
            }
        }

        /// <summary>
        /// Gets or sets font text, message text, title text, button text,...
        /// </summary>
        public static new Font Font
        { get; set; } = new Font("Arial", 10);

        private static void InitIcon(HIcon icon)
        {
            switch (icon)
            {
                case HMessageBox.HIcon.Application:
                    _MsgBox.pictureBox2.Image = SystemIcons.Application.ToBitmap();
                    break;

                case HMessageBox.HIcon.Exclamation:
                    _MsgBox.pictureBox2.Image = SystemIcons.Exclamation.ToBitmap();
                    break;

                case HMessageBox.HIcon.Error:
                    _MsgBox.pictureBox2.Image = SystemIcons.Error.ToBitmap();
                    break;

                case HMessageBox.HIcon.Info:
                    _MsgBox.pictureBox2.Image = SystemIcons.Information.ToBitmap();
                    break;

                case HMessageBox.HIcon.Question:
                    _MsgBox.pictureBox2.Image = SystemIcons.Question.ToBitmap();
                    break;

                case HMessageBox.HIcon.Shield:
                    _MsgBox.pictureBox2.Image = SystemIcons.Shield.ToBitmap();
                    break;

                case HMessageBox.HIcon.Warning:
                    _MsgBox.pictureBox2.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        private static void InitAbortRetryIgnoreButtons()
        {
            HButton btnAbort = new HButton();
            if (btnAbortT == String.Empty) btnAbort.Text = "Abort";
            else btnAbort.Text = btnAbortT;
            btnAbort.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Abort;
                _MsgBox.Dispose();
            };

            HButton btnRetry = new HButton();
            if (btnRetryT == String.Empty) btnRetry.Text = "Retry";
            else
                btnRetry.Text = btnRetryT;
            btnRetry.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Retry;
                _MsgBox.Dispose();
            };

            HButton btnIgnore = new HButton();
            if (btnIgnoreT == String.Empty) btnIgnore.Text = "Ignore";
            else
                btnIgnore.Text = btnIgnoreT;
            btnIgnore.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Ignore;
                _MsgBox.Dispose();
            };

            _MsgBox._buttonCollection.Add(btnAbort);
            _MsgBox._buttonCollection.Add(btnRetry);
            _MsgBox._buttonCollection.Add(btnIgnore);
        }

        private static void InitOKButton()
        {
            HButton btnOK = new HButton();
            if (btnOKT == String.Empty) btnOK.Text = "OK";
            else btnOK.Text = btnOKT;
            btnOK.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.OK;
                _MsgBox.Dispose();
            };

            _MsgBox._buttonCollection.Add(btnOK);
        }

        private static void InitOKCancelButtons()
        {
            HButton btnOK = new HButton();
            if (btnOKT == String.Empty) btnOK.Text = "OK";
            else btnOK.Text = btnOKT;
            btnOK.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.OK;
                _MsgBox.Dispose();
            };

            HButton btnCancel = new HButton();
            if (btnRetryT == String.Empty) btnCancel.Text = "Cancel";
            else
                btnCancel.Text = btnCancelT;
            btnCancel.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Cancel;
                _MsgBox.Dispose();
            };

            _MsgBox._buttonCollection.Add(btnOK);
            _MsgBox._buttonCollection.Add(btnCancel);
        }

        public static void SetLanguage(string BtnOK, string BtnRetry, string BtnCancel, string BtnAbort, string BtnIgnore, string BtnYes, string BtnNo)
        {
            btnOKT = BtnOK; btnAbortT = BtnAbort; btnCancelT = BtnCancel; btnRetryT = BtnRetry; btnYesT = BtnYes; btnNoT = BtnNo;
        }

        static string btnOKT = "";
        static string btnRetryT = "";
        static string btnAbortT = "";
        static string btnCancelT = "";
        static string btnIgnoreT = "";
        static string btnYesT = "";
        static string btnNoT = "";

        private void InitRetryCancelButtons()
        {
            HButton btnRetry = new HButton();
            if (btnRetryT == String.Empty) btnRetry.Text = "Retry";
            else btnRetry.Text = btnRetryT;
            btnRetry.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Retry;
                _MsgBox.Dispose();
            };
            HButton btnCancel = new HButton();
            if (btnRetryT == String.Empty) btnCancel.Text = "Cancel";
            else btnCancel.Text = btnCancelT;
            btnCancel.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Cancel;
                _MsgBox.Dispose();
            };
            this._buttonCollection.Add(btnCancel);
            this._buttonCollection.Add(btnRetry);
        }

        private static void InitYesNoButtons()
        {
            HButton btnYes = new HButton();
            if (btnYesT == "") btnYes.Text = "Yes";
            else btnYes.Text = btnYesT;
            btnYes.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Yes;
                _MsgBox.Dispose();
            };
            HButton btnNo = new HButton();
            if (btnNoT == String.Empty) btnNo.Text = "No";
            else btnNo.Text = btnNoT;
            btnNo.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.No;
                _MsgBox.Dispose();
            };
            _MsgBox._buttonCollection.Add(btnNo);
            _MsgBox._buttonCollection.Add(btnYes);
        }

        private static void InitYesNoCancelButtons()
        {
            HButton btnYes = new HButton();
            if (btnYesT == String.Empty) btnYes.Text = "Yes";
            else btnYes.Text = btnYesT;
            btnYes.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Yes;
                _MsgBox.Dispose();
            };
            HButton btnNo = new HButton();
            if (btnNoT == String.Empty) btnNo.Text = "No";
            else btnNo.Text = btnNoT;
            btnNo.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.No;
                _MsgBox.Dispose();
            };
            HButton btnCancel = new HButton();
            if (btnCancelT == String.Empty) btnCancel.Text = "Cancel";
            else
              if (btnNoT == String.Empty) btnNo.Text = "No";
            else btnNo.Text = btnNoT;
            btnCancel.Click += (sender, e) =>
            {
                _buttonResult = DialogResult.Cancel;
                _MsgBox.Dispose();
            };
            _MsgBox._buttonCollection.Add(btnYes);
            _MsgBox._buttonCollection.Add(btnNo);
            _MsgBox._buttonCollection.Add(btnCancel);
        }

        private static Size MessageSize(string message)
        {
            Graphics g = _MsgBox.CreateGraphics();
            int width = 350;
            int height = 200;

            SizeF size = g.MeasureString(message, Font);

            if (message.Length < 180)
            {
                if ((int)size.Width > 230)
                {
                    width = (int)size.Width;
                }
            }
            else
            {
                string[] groups = (from Match m in Regex.Matches(message, ".{1,180}") select m.Value).ToArray();
                int lines = groups.Length + 1;
                width = 500;
                height += (int)(size.Height + 10) * lines;
            }
            return new Size(width, height);
        }

        public enum Buttons
        {
            AbortRetryIgnore = 1,
            OK = 2,
            OKCancel = 3,
            RetryCancel = 4,
            YesNo = 5,
            YesNoCancel = 6
        }

        public enum HIcon
        {
            Application = 1,
            Exclamation = 2,
            Error = 3,
            Warning = 4,
            Info = 5,
            Question = 6,
            Shield = 7,
            Search = 8
        }

        public enum AnimateStyle
        {
            SlideDown = 1,
            FadeIn = 2,
            ZoomIn = 3
        }

    }

    class AnimateMsgBox
    {
        public Size FormSize;
        public HMessageBox.AnimateStyle Style;
        public AnimateMsgBox(Size formSize, HMessageBox.AnimateStyle style)
        {
            this.FormSize = formSize;
            this.Style = style;
        }
    }
}
