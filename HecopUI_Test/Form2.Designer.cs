using HeCopUI_Framework.Controls.TextControl;

namespace HecopUI_Test
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hCheckBox1 = new HeCopUI_Framework.Controls.Button.HCheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.hTextBox1 = new HecopUI_Test.CControls.HTextBox();
            this.SuspendLayout();
            // 
            // hCheckBox1
            // 
            this.hCheckBox1.BorderBox = System.Drawing.Color.Transparent;
            this.hCheckBox1.CheckBoxColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.CheckBoxColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox1.CheckBoxGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hCheckBox1.CheckColor = System.Drawing.Color.White;
            this.hCheckBox1.Checked = false;
            this.hCheckBox1.CheckedBoxColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.CheckedBoxColor2 = System.Drawing.Color.DodgerBlue;
            this.hCheckBox1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox1.DisabledCheckBoxColor = System.Drawing.Color.Gray;
            this.hCheckBox1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox1.EnabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.hCheckBox1.FocusBorderColor = System.Drawing.Color.Gray;
            this.hCheckBox1.Location = new System.Drawing.Point(0, 95);
            this.hCheckBox1.Name = "hCheckBox1";
            this.hCheckBox1.RippleAlpha = 60;
            this.hCheckBox1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.Size = new System.Drawing.Size(75, 28);
            this.hCheckBox1.TabIndex = 0;
            this.hCheckBox1.Text = "hCheckBox1";
            this.hCheckBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox1.UnCheckedBoxColor = System.Drawing.Color.DimGray;
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "dsadasd",
            "sadsad",
            "ádasd"});
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.textBox1.Location = new System.Drawing.Point(281, 137);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Tuyết Nhi Dễ Thương";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(58, 165);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(507, 150);
            this.maskedTextBox1.Mask = ".";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 64);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(23, 4, 2, 5);
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // hTextBox1
            // 
            this.hTextBox1.AcceptReturn = false;
            this.hTextBox1.AcceptTab = false;
            this.hTextBox1.BorderColor = System.Drawing.Color.Gray;
            this.hTextBox1.BorderWidth = 1;
            this.hTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox1.ForeColor = System.Drawing.Color.DimGray;
            this.hTextBox1.HideSelection = true;
            this.hTextBox1.Lines = new string[0];
            this.hTextBox1.Location = new System.Drawing.Point(288, 307);
            this.hTextBox1.MaxLength = 32767;
            this.hTextBox1.Name = "hTextBox1";
            this.hTextBox1.PasswordChar = '\0';
            this.hTextBox1.ReadOnly = false;
            this.hTextBox1.ShortCutKeysEnabled = true;
            this.hTextBox1.Size = new System.Drawing.Size(213, 35);
            this.hTextBox1.TabIndex = 9;
            this.hTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.hTextBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            this.hTextBox1.UnderlineStyle = true;
            this.hTextBox1.WartermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox1.Watermark = "Type watermark text here.";
            this.hTextBox1.WatermarkForeColor = System.Drawing.Color.Gray;
            this.hTextBox1.WordWrap = true;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.BorderLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.BorderPadding = new System.Windows.Forms.Padding(1);
            this.ClientSize = new System.Drawing.Size(649, 408);
            this.ControlBoxSize = 35;
            this.Controls.Add(this.hTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.hCheckBox1);
            this.Name = "Form2";
            this.NonClientAreaPadding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TitleBarHeight = 40;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HeCopUI_Framework.Controls.Button.HCheckBox hCheckBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Button button1;
        private CControls.HTextBox hTextBox1;
    }
}