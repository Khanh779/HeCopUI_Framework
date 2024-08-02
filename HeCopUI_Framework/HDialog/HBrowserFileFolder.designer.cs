using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Controls.Button;
using HeCopUI_Framework.Enums;

namespace HeCopUI_Framework.HDialog
{
    partial class HBrowserFileFolder
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
            this.components = new System.ComponentModel.Container();
            this.Btn_Scan = new HeCopUI_Framework.Controls.Button.HButton();
            this.LB_Info = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new HeCopUI_Framework.Controls.HWTreeView();
            this.Btn_Cancel = new HeCopUI_Framework.Controls.Button.HButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Scan
            // 
            this.Btn_Scan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Scan.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.Btn_Scan.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Scan.BorderColor = System.Drawing.Color.DarkGray;
            this.Btn_Scan.BorderDownColor = System.Drawing.Color.DarkGray;
            this.Btn_Scan.BorderHoverColor = System.Drawing.Color.DarkGray;
            this.Btn_Scan.BorderThickness = 1;
            this.Btn_Scan.ButtonColor1 = System.Drawing.Color.White;
            this.Btn_Scan.ButtonColor2 = System.Drawing.Color.White;
            this.Btn_Scan.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_Scan.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_Scan.BackHoverColor1 = System.Drawing.Color.WhiteSmoke;
            this.Btn_Scan.BackHoverColor2 = System.Drawing.Color.WhiteSmoke;
            this.Btn_Scan.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Scan.ClipRegion = true;
            this.Btn_Scan.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Btn_Scan.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_Scan.FocusBorderColor = System.Drawing.Color.White;
            this.Btn_Scan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Btn_Scan.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Btn_Scan.Image = null;
            this.Btn_Scan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Scan.ImagePadding = new System.Windows.Forms.Padding(0);
            this.Btn_Scan.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_Scan.IsAutoSize = false;
            this.Btn_Scan.Location = new System.Drawing.Point(332, 5);
            this.Btn_Scan.Name = "Btn_Scan";
            this.Btn_Scan.Radius = new Struct.CornerRadius(5);
            this.Btn_Scan.RippleColor = System.Drawing.Color.Black;
            this.Btn_Scan.ShadowColor = System.Drawing.Color.LightGray;
            this.Btn_Scan.ShadowPadding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Btn_Scan.ShadowRadius = 5;
            this.Btn_Scan.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.Btn_Scan.Size = new System.Drawing.Size(44, 28);
            this.Btn_Scan.SupportImageGif = false;
            this.Btn_Scan.TabIndex = 2;
            this.Btn_Scan.Text = "OK";
            this.Btn_Scan.TextDownColor = System.Drawing.Color.DimGray;
            this.Btn_Scan.TextHoverColor = System.Drawing.Color.DimGray;
            this.Btn_Scan.TextNormalColor = System.Drawing.Color.DimGray;
            this.Btn_Scan.TextPadding = new System.Windows.Forms.Padding(5);
            this.Btn_Scan.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Btn_Scan.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // LB_Info
            // 
            this.LB_Info.AutoEllipsis = true;
            this.LB_Info.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Info.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LB_Info.ForeColor = System.Drawing.Color.DimGray;
            this.LB_Info.Location = new System.Drawing.Point(0, 0);
            this.LB_Info.Name = "LB_Info";
            this.LB_Info.Size = new System.Drawing.Size(431, 42);
            this.LB_Info.TabIndex = 0;
            this.LB_Info.Text = "Mô Tả";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(18, 18);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.LB_Info);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.panel1.Location = new System.Drawing.Point(15, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 239);
            this.panel1.TabIndex = 8;
            // 
            // treeView1
            // 
            this.treeView1.BackCheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.treeView1.CheckBoxes = true;
            this.treeView1.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.ItemHeight = 28;
            this.treeView1.Location = new System.Drawing.Point(0, 42);
            this.treeView1.Name = "treeView1";
            this.treeView1.NodeBackgroundColor = System.Drawing.Color.Transparent;
            this.treeView1.NodeForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(62)))));
            this.treeView1.NodeSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.treeView1.NodeSelectedForeColor = System.Drawing.Color.White;
            this.treeView1.NodeSplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowGridLines = true;
            this.treeView1.ShowLines = false;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(431, 197);
            this.treeView1.StateImageList = this.imageList1;
            this.treeView1.TabIndex = 1;
            this.treeView1.TipFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Cancel.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.Btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Cancel.BorderColor = System.Drawing.Color.DarkGray;
            this.Btn_Cancel.BorderDownColor = System.Drawing.Color.DarkGray;
            this.Btn_Cancel.BorderHoverColor = System.Drawing.Color.DarkGray;
            this.Btn_Cancel.BorderThickness = 1;
            this.Btn_Cancel.ButtonColor1 = System.Drawing.Color.White;
            this.Btn_Cancel.ButtonColor2 = System.Drawing.Color.White;
            this.Btn_Cancel.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_Cancel.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.Btn_Cancel.BackHoverColor1 = System.Drawing.Color.WhiteSmoke;
            this.Btn_Cancel.BackHoverColor2 = System.Drawing.Color.WhiteSmoke;
            this.Btn_Cancel.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Cancel.ClipRegion = true;
            this.Btn_Cancel.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.Btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Btn_Cancel.FocusBorderColor = System.Drawing.Color.White;
            this.Btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Btn_Cancel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Btn_Cancel.Image = null;
            this.Btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_Cancel.ImagePadding = new System.Windows.Forms.Padding(0);
            this.Btn_Cancel.ImageSize = new System.Drawing.Size(20, 20);
            this.Btn_Cancel.IsAutoSize = false;
            this.Btn_Cancel.Location = new System.Drawing.Point(382, 5);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Radius =  new Struct.CornerRadius(5);
            this.Btn_Cancel.RippleColor = System.Drawing.Color.Black;
            this.Btn_Cancel.ShadowColor = System.Drawing.Color.LightGray;
            this.Btn_Cancel.ShadowPadding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.Btn_Cancel.ShadowRadius = 5;
            this.Btn_Cancel.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.Btn_Cancel.Size = new System.Drawing.Size(69, 28);
            this.Btn_Cancel.SupportImageGif = false;
            this.Btn_Cancel.TabIndex = 9;
            this.Btn_Cancel.Text = "Cancel";
            this.Btn_Cancel.TextDownColor = System.Drawing.Color.DimGray;
            this.Btn_Cancel.TextHoverColor = System.Drawing.Color.DimGray;
            this.Btn_Cancel.TextNormalColor = System.Drawing.Color.DimGray;
            this.Btn_Cancel.TextPadding = new System.Windows.Forms.Padding(5);
            this.Btn_Cancel.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.Btn_Cancel.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Btn_Cancel);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Scan);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 300);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 2, 5, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(459, 38);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // HBrowserFileFolder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(463, 340);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormControlBox.CloseBoxColor = System.Drawing.Color.White;
            this.FormControlBox.CloseBoxHoverColor = System.Drawing.Color.Red;
            this.FormControlBox.HoverColorShape = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.FormControlBox.IconCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.FormControlBox.IconCloseHoverColor = System.Drawing.Color.WhiteSmoke;
            this.FormControlBox.IconMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.FormControlBox.IconMaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FormControlBox.IconMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.FormControlBox.IconMinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FormControlBox.MaximizeBoxColor = System.Drawing.Color.White;
            this.FormControlBox.MaximizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormControlBox.MinimizeBoxColor = System.Drawing.Color.White;
            this.FormControlBox.MinimizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HBrowserFileFolder";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TitleFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load += new System.EventHandler(this.BrowserFileFolder_Load);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label LB_Info;
        private HButton Btn_Scan;
        private System.Windows.Forms.Panel panel1;
        private HButton Btn_Cancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private HWTreeView treeView1;
    }
}