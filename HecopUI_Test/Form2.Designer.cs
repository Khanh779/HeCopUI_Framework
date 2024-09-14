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
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.BorderLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.BorderPadding = new System.Windows.Forms.Padding(1);
            this.ClientSize = new System.Drawing.Size(315, 227);
            this.ControlBoxSize = 35;
            this.Controls.Add(this.hCheckBox1);
            this.Name = "Form2";
            this.NonClientAreaPadding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.TitleBarHeight = 40;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HeCopUI_Framework.Controls.Button.HCheckBox hCheckBox1;
    }
}