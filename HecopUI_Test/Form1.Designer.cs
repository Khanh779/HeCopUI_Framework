using HeCopUI_Framework.Controls;
using HeCopUI_Framework.Controls.Progress;
using HeCopUI_Framework.Enums;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static HeCopUI_Framework.GetAppResources;
using HScrollBar = HeCopUI_Framework.Controls.HScrollBar;

namespace HecopUI_Test
{
    partial class Form1
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
            HeCopUI_Framework.Controls.Charts.Series series2 = new HeCopUI_Framework.Controls.Charts.Series();
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item 1",
            "Subitem 1",
            "Subitem 2"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Item 2",
            "Subitem 1",
            "Subitem 2"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "Ittem 3",
            "dsa",
            "2sa"}, -1);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.hTabControl1 = new HeCopUI_Framework.Controls.HTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.hLabel10 = new HeCopUI_Framework.Controls.HLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.hLabel9 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel8 = new HeCopUI_Framework.Controls.HLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hLabel7 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel6 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel5 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel4 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel3 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel2 = new HeCopUI_Framework.Controls.HLabel();
            this.hLabel1 = new HeCopUI_Framework.Controls.HLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hTitleSubButton7 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton8 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton9 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton4 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton5 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton6 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton3 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleSubButton2 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleButton7 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton8 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton9 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton4 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton5 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton6 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton3 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hTitleButton2 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hButton7 = new HeCopUI_Framework.Controls.HButton();
            this.hButton8 = new HeCopUI_Framework.Controls.HButton();
            this.hButton9 = new HeCopUI_Framework.Controls.HButton();
            this.hTitleSubButton1 = new HeCopUI_Framework.Controls.HTitleSubButton();
            this.hTitleButton1 = new HeCopUI_Framework.Controls.HTitleButton();
            this.hButton4 = new HeCopUI_Framework.Controls.HButton();
            this.hButton5 = new HeCopUI_Framework.Controls.HButton();
            this.hButton6 = new HeCopUI_Framework.Controls.HButton();
            this.hButton3 = new HeCopUI_Framework.Controls.HButton();
            this.hButton2 = new HeCopUI_Framework.Controls.HButton();
            this.hButton1 = new HeCopUI_Framework.Controls.HButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.hEffectImage1 = new HeCopUI_Framework.Controls.Effect.HEffectImage();
            this.hImage1 = new HeCopUI_Framework.Controls.HImage();
            this.tabPage21 = new System.Windows.Forms.TabPage();
            this.hRichTextBox2 = new HeCopUI_Framework.Controls.HRichTextBox();
            this.hTextBox2 = new HeCopUI_Framework.Controls.HTextBox();
            this.hTextBox1 = new HeCopUI_Framework.Controls.HTextBox();
            this.hRichTextBox1 = new HeCopUI_Framework.Controls.HRichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.hRadioButton3 = new HeCopUI_Framework.Controls.HRadioButton();
            this.hRadioButton2 = new HeCopUI_Framework.Controls.HRadioButton();
            this.hCheckBox3 = new HeCopUI_Framework.Controls.HCheckBox();
            this.hCheckBox2 = new HeCopUI_Framework.Controls.HCheckBox();
            this.hRadioButton1 = new HeCopUI_Framework.Controls.HRadioButton();
            this.hToggleButton21 = new HeCopUI_Framework.Controls.HToggleButton2();
            this.hToggleButton11 = new HeCopUI_Framework.Controls.HToggleButton1();
            this.hToggleButton1 = new HeCopUI_Framework.Controls.HToggleButton();
            this.hCheckBox1 = new HeCopUI_Framework.Controls.HCheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.hDotProgressRing7 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hProgressBar4 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar5 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar6 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hButton10 = new HeCopUI_Framework.Controls.HButton();
            this.hProgressBar3 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hProgressBar2 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hCircularProgressBar2 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar();
            this.hProgressBarWaterWave1 = new HeCopUI_Framework.Controls.Progress.HProgressBarWaterWave();
            this.waveProgressLoading1 = new HeCopUI_Framework.Controls.Progress.WaveProgressLoading();
            this.hProgressBar1 = new HeCopUI_Framework.Controls.Progress.HProgressBar();
            this.hCircularProgressBar21 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar2();
            this.hCircularProgressBar11 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar1();
            this.hCircularProgressBar1 = new HeCopUI_Framework.Controls.Progress.HCircularProgressBar();
            this.hDotProgressRing6 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing5 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing4 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing3 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing2 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.hDotProgressRing1 = new HeCopUI_Framework.Controls.Progress.HDotProgressRing();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.hScrollBar3 = new HeCopUI_Framework.Controls.HScrollBar();
            this.hScrollBar4 = new HeCopUI_Framework.Controls.HScrollBar();
            this.hScrollBar2 = new HeCopUI_Framework.Controls.HScrollBar();
            this.hScrollBar1 = new HeCopUI_Framework.Controls.HScrollBar();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.HPanel1 = new HeCopUI_Framework.Controls.HPanel();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.hTabControl3 = new HeCopUI_Framework.Controls.HTabControl();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.hTabControl2 = new HeCopUI_Framework.Controls.HTabControl();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.hTabControl4 = new HeCopUI_Framework.Controls.HTabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.hBarChart1 = new HeCopUI_Framework.Controls.Charts.HBarChart();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.hLineAreaChart1 = new HeCopUI_Framework.Controls.Charts.HLineAreaChart();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.hPieChart1 = new HeCopUI_Framework.Controls.Charts.HPieChart();
            this.tabPage18 = new System.Windows.Forms.TabPage();
            this.hRadarChart1 = new HeCopUI_Framework.Controls.Charts.HRadarChart();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.hTextBox3 = new HeCopUI_Framework.Controls.HTextBox();
            this.hCircleAnglePicker1 = new HeCopUI_Framework.Controls.HCircleAnglePicker();
            this.hRadialRangeSlider1 = new HeCopUI_Framework.Controls.HRadialRangeSlider();
            this.hSolidGauge1 = new HeCopUI_Framework.Controls.HSolidGauge();
            this.hDigitalGauge1 = new HeCopUI_Framework.Controls.HDigitalGauge();
            this.tabPage19 = new System.Windows.Forms.TabPage();
            this.hClockDigital1 = new HeCopUI_Framework.Controls.HClockDigital();
            this.hClockCircular1 = new HeCopUI_Framework.Controls.HClockCircular();
            this.tabPage22 = new System.Windows.Forms.TabPage();
            this.hListView1 = new HeCopUI_Framework.Controls.HListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage20 = new System.Windows.Forms.TabPage();
            this.hDotRing1 = new HeCopUI_Framework.Controls.Progress.HDotRing();
            this.hProgressRing1 = new HeCopUI_Framework.Controls.Progress.HProgressRing();
            this.linearParticleAnimation1 = new HeCopUI_Framework.Controls.Progress.LinearParticleAnimation();
            this.hTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage21.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.hTabControl3.SuspendLayout();
            this.hTabControl2.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.hTabControl4.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.tabPage18.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage19.SuspendLayout();
            this.tabPage22.SuspendLayout();
            this.tabPage20.SuspendLayout();
            this.SuspendLayout();
            // 
            // hTabControl1
            // 
            this.hTabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.hTabControl1.ApplyTabPagesColor = true;
            this.hTabControl1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTabControl1.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl1.BorderThickness = 1;
            this.hTabControl1.Controls.Add(this.tabPage1);
            this.hTabControl1.Controls.Add(this.tabPage2);
            this.hTabControl1.Controls.Add(this.tabPage5);
            this.hTabControl1.Controls.Add(this.tabPage21);
            this.hTabControl1.Controls.Add(this.tabPage3);
            this.hTabControl1.Controls.Add(this.tabPage4);
            this.hTabControl1.Controls.Add(this.tabPage7);
            this.hTabControl1.Controls.Add(this.tabPage8);
            this.hTabControl1.Controls.Add(this.tabPage9);
            this.hTabControl1.Controls.Add(this.tabPage14);
            this.hTabControl1.Controls.Add(this.tabPage6);
            this.hTabControl1.Controls.Add(this.tabPage19);
            this.hTabControl1.Controls.Add(this.tabPage22);
            this.hTabControl1.Controls.Add(this.tabPage20);
            this.hTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hTabControl1.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hTabControl1.ItemSize = new System.Drawing.Size(25, 135);
            this.hTabControl1.Location = new System.Drawing.Point(1, 42);
            this.hTabControl1.Multiline = true;
            this.hTabControl1.Name = "hTabControl1";
            this.hTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.hTabControl1.SelectedIndex = 0;
            this.hTabControl1.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hTabControl1.SelectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl1.Size = new System.Drawing.Size(900, 554);
            this.hTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.hTabControl1.TabIndex = 0;
            this.hTabControl1.TabsColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTabControl1.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl1.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl1.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl1.UnSelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTabControl1.UnselectedTextColor = System.Drawing.Color.WhiteSmoke;
            this.hTabControl1.UseAnimation = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage1.Controls.Add(this.hLabel10);
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.hLabel9);
            this.tabPage1.Controls.Add(this.hLabel8);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.hLabel2);
            this.tabPage1.Controls.Add(this.hLabel1);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 546);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Home";
            // 
            // hLabel10
            // 
            this.hLabel10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hLabel10.BackColor = System.Drawing.Color.Transparent;
            this.hLabel10.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel10.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel10.Location = new System.Drawing.Point(406, 165);
            this.hLabel10.Name = "hLabel10";
            this.hLabel10.Size = new System.Drawing.Size(56, 25);
            this.hLabel10.Symbol = "";
            this.hLabel10.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel10.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel10.SymbolVisible = false;
            this.hLabel10.TabIndex = 10;
            this.hLabel10.Text = "Github:";
            this.hLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hLabel10.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel10.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.DarkGray;
            this.linkLabel1.Location = new System.Drawing.Point(465, 165);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(269, 25);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/Khanh779";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            // 
            // hLabel9
            // 
            this.hLabel9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hLabel9.BackColor = System.Drawing.Color.Transparent;
            this.hLabel9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel9.Location = new System.Drawing.Point(406, 129);
            this.hLabel9.Name = "hLabel9";
            this.hLabel9.Size = new System.Drawing.Size(114, 23);
            this.hLabel9.Symbol = "";
            this.hLabel9.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel9.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel9.SymbolVisible = true;
            this.hLabel9.TabIndex = 8;
            this.hLabel9.Text = "About me:";
            this.hLabel9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel9.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel8
            // 
            this.hLabel8.BackColor = System.Drawing.Color.Transparent;
            this.hLabel8.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel8.Location = new System.Drawing.Point(22, 129);
            this.hLabel8.Name = "hLabel8";
            this.hLabel8.Size = new System.Drawing.Size(100, 23);
            this.hLabel8.Symbol = "";
            this.hLabel8.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel8.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel8.SymbolVisible = true;
            this.hLabel8.TabIndex = 7;
            this.hLabel8.Text = "Introduce:";
            this.hLabel8.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel8.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.hLabel7);
            this.panel1.Controls.Add(this.hLabel6);
            this.panel1.Controls.Add(this.hLabel5);
            this.panel1.Controls.Add(this.hLabel4);
            this.panel1.Controls.Add(this.hLabel3);
            this.panel1.Location = new System.Drawing.Point(22, 155);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 10, 2, 10);
            this.panel1.Size = new System.Drawing.Size(364, 334);
            this.panel1.TabIndex = 6;
            // 
            // hLabel7
            // 
            this.hLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hLabel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel7.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel7.Location = new System.Drawing.Point(2, 243);
            this.hLabel7.Name = "hLabel7";
            this.hLabel7.Size = new System.Drawing.Size(360, 53);
            this.hLabel7.Symbol = "✨";
            this.hLabel7.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel7.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel7.SymbolVisible = true;
            this.hLabel7.TabIndex = 10;
            this.hLabel7.Text = "Explore now - Hecop UI Framework, where power meets flexibility! :D";
            this.hLabel7.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel7.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel6
            // 
            this.hLabel6.BackColor = System.Drawing.Color.Transparent;
            this.hLabel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel6.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel6.Location = new System.Drawing.Point(2, 190);
            this.hLabel6.Name = "hLabel6";
            this.hLabel6.Size = new System.Drawing.Size(360, 53);
            this.hLabel6.Symbol = "📱 ";
            this.hLabel6.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel6.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel6.SymbolVisible = true;
            this.hLabel6.TabIndex = 9;
            this.hLabel6.Text = "Cross-Platform Support: Develop for both web and mobile effortlessly.";
            this.hLabel6.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel6.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel5
            // 
            this.hLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hLabel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel5.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel5.Location = new System.Drawing.Point(2, 137);
            this.hLabel5.Name = "hLabel5";
            this.hLabel5.Size = new System.Drawing.Size(360, 53);
            this.hLabel5.Symbol = "⚡ ";
            this.hLabel5.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel5.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel5.SymbolVisible = true;
            this.hLabel5.TabIndex = 8;
            this.hLabel5.Text = "Smooth Performance: A fluid and fast user experience across all devices.";
            this.hLabel5.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel5.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel4
            // 
            this.hLabel4.BackColor = System.Drawing.Color.Transparent;
            this.hLabel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel4.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel4.Location = new System.Drawing.Point(2, 83);
            this.hLabel4.Name = "hLabel4";
            this.hLabel4.Size = new System.Drawing.Size(360, 54);
            this.hLabel4.Symbol = "🎨 ";
            this.hLabel4.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel4.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel4.SymbolVisible = true;
            this.hLabel4.TabIndex = 7;
            this.hLabel4.Text = "Flexible Customization: Fine-tune with progress bars, tab controls, and versatile" +
    " features.";
            this.hLabel4.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel3
            // 
            this.hLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.hLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.hLabel3.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel3.Location = new System.Drawing.Point(2, 10);
            this.hLabel3.Name = "hLabel3";
            this.hLabel3.Size = new System.Drawing.Size(360, 73);
            this.hLabel3.Symbol = "🚀 ";
            this.hLabel3.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel3.SymbolFont = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.hLabel3.SymbolVisible = true;
            this.hLabel3.TabIndex = 6;
            this.hLabel3.Text = "Diverse UI Components: Charts, buttons, checkboxes, textboxes, and more, helping " +
    "you build interfaces swiftly.";
            this.hLabel3.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel2
            // 
            this.hLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hLabel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.hLabel2.ForeColor = System.Drawing.Color.DarkGray;
            this.hLabel2.Location = new System.Drawing.Point(22, 57);
            this.hLabel2.Name = "hLabel2";
            this.hLabel2.Size = new System.Drawing.Size(340, 45);
            this.hLabel2.Symbol = "";
            this.hLabel2.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel2.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel2.SymbolVisible = true;
            this.hLabel2.TabIndex = 1;
            this.hLabel2.Text = "Hecop UI Framework - Your ideal companion for seamless app development.";
            this.hLabel2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hLabel1
            // 
            this.hLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hLabel1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.hLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLabel1.Location = new System.Drawing.Point(22, 21);
            this.hLabel1.Name = "hLabel1";
            this.hLabel1.Size = new System.Drawing.Size(331, 30);
            this.hLabel1.Symbol = "";
            this.hLabel1.SymbolColor = System.Drawing.Color.Gray;
            this.hLabel1.SymbolFont = new System.Drawing.Font("Segoe UI Symbol", 10F);
            this.hLabel1.SymbolVisible = true;
            this.hLabel1.TabIndex = 0;
            this.hLabel1.Text = "Welcome to Hecop UI Framework!";
            this.hLabel1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.hLabel1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hLabel1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage2.Controls.Add(this.hTitleSubButton7);
            this.tabPage2.Controls.Add(this.hTitleSubButton8);
            this.tabPage2.Controls.Add(this.hTitleSubButton9);
            this.tabPage2.Controls.Add(this.hTitleSubButton4);
            this.tabPage2.Controls.Add(this.hTitleSubButton5);
            this.tabPage2.Controls.Add(this.hTitleSubButton6);
            this.tabPage2.Controls.Add(this.hTitleSubButton3);
            this.tabPage2.Controls.Add(this.hTitleSubButton2);
            this.tabPage2.Controls.Add(this.hTitleButton7);
            this.tabPage2.Controls.Add(this.hTitleButton8);
            this.tabPage2.Controls.Add(this.hTitleButton9);
            this.tabPage2.Controls.Add(this.hTitleButton4);
            this.tabPage2.Controls.Add(this.hTitleButton5);
            this.tabPage2.Controls.Add(this.hTitleButton6);
            this.tabPage2.Controls.Add(this.hTitleButton3);
            this.tabPage2.Controls.Add(this.hTitleButton2);
            this.tabPage2.Controls.Add(this.hButton7);
            this.tabPage2.Controls.Add(this.hButton8);
            this.tabPage2.Controls.Add(this.hButton9);
            this.tabPage2.Controls.Add(this.hTitleSubButton1);
            this.tabPage2.Controls.Add(this.hTitleButton1);
            this.tabPage2.Controls.Add(this.hButton4);
            this.tabPage2.Controls.Add(this.hButton5);
            this.tabPage2.Controls.Add(this.hButton6);
            this.tabPage2.Controls.Add(this.hButton3);
            this.tabPage2.Controls.Add(this.hButton2);
            this.tabPage2.Controls.Add(this.hButton1);
            this.tabPage2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage2.Location = new System.Drawing.Point(139, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 546);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Buttons";
            // 
            // hTitleSubButton7
            // 
            this.hTitleSubButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleSubButton7.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton7.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton7.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton7.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton7.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton7.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton7.BorderThickness = 0;
            this.hTitleSubButton7.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton7.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton7.ButtonImage = null;
            this.hTitleSubButton7.ClipRegion = false;
            this.hTitleSubButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton7.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton7.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton7.ImageOffsetY = 15;
            this.hTitleSubButton7.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton7.Interval = 200;
            this.hTitleSubButton7.Location = new System.Drawing.Point(625, 327);
            this.hTitleSubButton7.Name = "hTitleSubButton7";
            this.hTitleSubButton7.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton7.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleSubButton7.ShadowRadius = 5;
            this.hTitleSubButton7.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton7.TabIndex = 26;
            this.hTitleSubButton7.Text = "Color Transition";
            this.hTitleSubButton7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton7.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton7.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton7.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton7.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton7.TextInfoOffSetY = -10;
            this.hTitleSubButton7.TextOffsetY = -10F;
            this.hTitleSubButton7.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton7.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton7.TextY = 10;
            // 
            // hTitleSubButton8
            // 
            this.hTitleSubButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleSubButton8.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton8.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton8.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton8.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton8.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton8.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton8.BorderThickness = 0;
            this.hTitleSubButton8.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton8.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton8.ButtonImage = null;
            this.hTitleSubButton8.ClipRegion = false;
            this.hTitleSubButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton8.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton8.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton8.ImageOffsetY = 15;
            this.hTitleSubButton8.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton8.Interval = 200;
            this.hTitleSubButton8.Location = new System.Drawing.Point(625, 176);
            this.hTitleSubButton8.Name = "hTitleSubButton8";
            this.hTitleSubButton8.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton8.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton8.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleSubButton8.ShadowRadius = 5;
            this.hTitleSubButton8.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton8.TabIndex = 25;
            this.hTitleSubButton8.Text = "Ripple Effect";
            this.hTitleSubButton8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton8.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton8.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton8.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton8.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton8.TextInfoOffSetY = -10;
            this.hTitleSubButton8.TextOffsetY = -10F;
            this.hTitleSubButton8.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton8.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton8.TextY = 10;
            // 
            // hTitleSubButton9
            // 
            this.hTitleSubButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleSubButton9.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton9.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton9.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton9.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton9.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton9.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton9.BorderThickness = 0;
            this.hTitleSubButton9.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton9.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton9.ButtonImage = null;
            this.hTitleSubButton9.ClipRegion = false;
            this.hTitleSubButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton9.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton9.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton9.ImageOffsetY = 15;
            this.hTitleSubButton9.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton9.Interval = 200;
            this.hTitleSubButton9.Location = new System.Drawing.Point(625, 29);
            this.hTitleSubButton9.Name = "hTitleSubButton9";
            this.hTitleSubButton9.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton9.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton9.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleSubButton9.ShadowRadius = 5;
            this.hTitleSubButton9.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton9.TabIndex = 24;
            this.hTitleSubButton9.Text = "No animation";
            this.hTitleSubButton9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton9.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton9.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton9.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton9.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton9.TextInfoOffSetY = -10;
            this.hTitleSubButton9.TextOffsetY = -10F;
            this.hTitleSubButton9.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton9.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton9.TextY = 10;
            // 
            // hTitleSubButton4
            // 
            this.hTitleSubButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleSubButton4.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton4.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton4.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton4.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton4.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton4.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton4.BorderThickness = 0;
            this.hTitleSubButton4.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton4.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton4.ButtonImage = null;
            this.hTitleSubButton4.ClipRegion = false;
            this.hTitleSubButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton4.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton4.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton4.ImageOffsetY = 15;
            this.hTitleSubButton4.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton4.Interval = 200;
            this.hTitleSubButton4.Location = new System.Drawing.Point(498, 327);
            this.hTitleSubButton4.Name = "hTitleSubButton4";
            this.hTitleSubButton4.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton4.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton4.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton4.ShadowRadius = 5;
            this.hTitleSubButton4.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton4.TabIndex = 23;
            this.hTitleSubButton4.Text = "Color Transition";
            this.hTitleSubButton4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton4.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton4.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton4.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton4.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton4.TextInfoOffSetY = -10;
            this.hTitleSubButton4.TextOffsetY = -10F;
            this.hTitleSubButton4.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton4.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton4.TextY = 10;
            // 
            // hTitleSubButton5
            // 
            this.hTitleSubButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleSubButton5.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton5.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton5.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton5.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton5.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton5.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton5.BorderThickness = 0;
            this.hTitleSubButton5.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton5.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton5.ButtonImage = null;
            this.hTitleSubButton5.ClipRegion = false;
            this.hTitleSubButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton5.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton5.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton5.ImageOffsetY = 15;
            this.hTitleSubButton5.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton5.Interval = 200;
            this.hTitleSubButton5.Location = new System.Drawing.Point(498, 176);
            this.hTitleSubButton5.Name = "hTitleSubButton5";
            this.hTitleSubButton5.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton5.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton5.ShadowRadius = 5;
            this.hTitleSubButton5.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton5.TabIndex = 22;
            this.hTitleSubButton5.Text = "Ripple Effect";
            this.hTitleSubButton5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton5.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton5.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton5.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton5.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton5.TextInfoOffSetY = -10;
            this.hTitleSubButton5.TextOffsetY = -10F;
            this.hTitleSubButton5.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton5.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton5.TextY = 10;
            // 
            // hTitleSubButton6
            // 
            this.hTitleSubButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleSubButton6.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton6.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton6.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton6.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleSubButton6.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton6.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton6.BorderThickness = 0;
            this.hTitleSubButton6.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleSubButton6.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleSubButton6.ButtonImage = null;
            this.hTitleSubButton6.ClipRegion = false;
            this.hTitleSubButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton6.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton6.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton6.ImageOffsetY = 15;
            this.hTitleSubButton6.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton6.Interval = 200;
            this.hTitleSubButton6.Location = new System.Drawing.Point(498, 29);
            this.hTitleSubButton6.Name = "hTitleSubButton6";
            this.hTitleSubButton6.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton6.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton6.ShadowRadius = 5;
            this.hTitleSubButton6.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton6.TabIndex = 21;
            this.hTitleSubButton6.Text = "No animation";
            this.hTitleSubButton6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton6.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton6.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton6.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton6.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton6.TextInfoOffSetY = -10;
            this.hTitleSubButton6.TextOffsetY = -10F;
            this.hTitleSubButton6.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton6.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton6.TextY = 10;
            // 
            // hTitleSubButton3
            // 
            this.hTitleSubButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleSubButton3.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton3.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton3.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton3.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton3.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleSubButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton3.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton3.BorderThickness = 1;
            this.hTitleSubButton3.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton3.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton3.ButtonImage = null;
            this.hTitleSubButton3.ClipRegion = false;
            this.hTitleSubButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton3.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton3.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton3.ImageOffsetY = 15;
            this.hTitleSubButton3.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton3.Interval = 200;
            this.hTitleSubButton3.Location = new System.Drawing.Point(370, 327);
            this.hTitleSubButton3.Name = "hTitleSubButton3";
            this.hTitleSubButton3.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton3.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton3.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton3.ShadowRadius = 5;
            this.hTitleSubButton3.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton3.TabIndex = 20;
            this.hTitleSubButton3.Text = "Color Transition";
            this.hTitleSubButton3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton3.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton3.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton3.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton3.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton3.TextInfoOffSetY = -10;
            this.hTitleSubButton3.TextOffsetY = -10F;
            this.hTitleSubButton3.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton3.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton3.TextY = 10;
            // 
            // hTitleSubButton2
            // 
            this.hTitleSubButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleSubButton2.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton2.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton2.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton2.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton2.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleSubButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton2.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton2.BorderThickness = 1;
            this.hTitleSubButton2.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton2.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton2.ButtonImage = null;
            this.hTitleSubButton2.ClipRegion = false;
            this.hTitleSubButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton2.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton2.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton2.ImageOffsetY = 15;
            this.hTitleSubButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton2.Interval = 200;
            this.hTitleSubButton2.Location = new System.Drawing.Point(370, 176);
            this.hTitleSubButton2.Name = "hTitleSubButton2";
            this.hTitleSubButton2.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton2.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton2.ShadowRadius = 5;
            this.hTitleSubButton2.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton2.TabIndex = 19;
            this.hTitleSubButton2.Text = "Ripple Effect";
            this.hTitleSubButton2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton2.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton2.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton2.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton2.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton2.TextInfoOffSetY = -10;
            this.hTitleSubButton2.TextOffsetY = -10F;
            this.hTitleSubButton2.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton2.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton2.TextY = 10;
            // 
            // hTitleButton7
            // 
            this.hTitleButton7.AlphaAnimated = 180;
            this.hTitleButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleButton7.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton7.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton7.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton7.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton7.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton7.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton7.BorderThickness = 0;
            this.hTitleButton7.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton7.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton7.ButtonImage = null;
            this.hTitleButton7.ClipRegion = false;
            this.hTitleButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton7.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton7.ForeColor = System.Drawing.Color.White;
            this.hTitleButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton7.ImageOffsetY = 10F;
            this.hTitleButton7.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton7.Interval = 200;
            this.hTitleButton7.Location = new System.Drawing.Point(250, 362);
            this.hTitleButton7.Name = "hTitleButton7";
            this.hTitleButton7.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton7.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleButton7.ShadowRadius = 5;
            this.hTitleButton7.Size = new System.Drawing.Size(110, 82);
            this.hTitleButton7.TabIndex = 18;
            this.hTitleButton7.Text = "Color Transition";
            this.hTitleButton7.TextOffsetY = 1F;
            this.hTitleButton7.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton8
            // 
            this.hTitleButton8.AlphaAnimated = 180;
            this.hTitleButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleButton8.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton8.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton8.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton8.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton8.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton8.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton8.BorderThickness = 0;
            this.hTitleButton8.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton8.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton8.ButtonImage = null;
            this.hTitleButton8.ClipRegion = false;
            this.hTitleButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton8.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton8.ForeColor = System.Drawing.Color.White;
            this.hTitleButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton8.ImageOffsetY = 10F;
            this.hTitleButton8.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton8.Interval = 200;
            this.hTitleButton8.Location = new System.Drawing.Point(138, 362);
            this.hTitleButton8.Name = "hTitleButton8";
            this.hTitleButton8.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton8.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton8.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton8.ShadowRadius = 5;
            this.hTitleButton8.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton8.TabIndex = 17;
            this.hTitleButton8.Text = "Color Transition";
            this.hTitleButton8.TextOffsetY = 1F;
            this.hTitleButton8.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton9
            // 
            this.hTitleButton9.AlphaAnimated = 180;
            this.hTitleButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hTitleButton9.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton9.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton9.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton9.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton9.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton9.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton9.BorderThickness = 1;
            this.hTitleButton9.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton9.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton9.ButtonImage = null;
            this.hTitleButton9.ClipRegion = false;
            this.hTitleButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton9.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton9.ForeColor = System.Drawing.Color.White;
            this.hTitleButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton9.ImageOffsetY = 10F;
            this.hTitleButton9.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton9.Interval = 200;
            this.hTitleButton9.Location = new System.Drawing.Point(21, 362);
            this.hTitleButton9.Name = "hTitleButton9";
            this.hTitleButton9.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton9.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton9.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton9.ShadowRadius = 5;
            this.hTitleButton9.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton9.TabIndex = 16;
            this.hTitleButton9.Text = "Color Transition";
            this.hTitleButton9.TextOffsetY = 1F;
            this.hTitleButton9.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton4
            // 
            this.hTitleButton4.AlphaAnimated = 180;
            this.hTitleButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleButton4.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton4.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton4.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton4.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton4.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton4.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton4.BorderThickness = 0;
            this.hTitleButton4.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton4.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton4.ButtonImage = null;
            this.hTitleButton4.ClipRegion = false;
            this.hTitleButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton4.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton4.ForeColor = System.Drawing.Color.White;
            this.hTitleButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton4.ImageOffsetY = 10F;
            this.hTitleButton4.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton4.Interval = 200;
            this.hTitleButton4.Location = new System.Drawing.Point(250, 263);
            this.hTitleButton4.Name = "hTitleButton4";
            this.hTitleButton4.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton4.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton4.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleButton4.ShadowRadius = 5;
            this.hTitleButton4.Size = new System.Drawing.Size(110, 82);
            this.hTitleButton4.TabIndex = 15;
            this.hTitleButton4.Text = "Ripple Effect";
            this.hTitleButton4.TextOffsetY = 1F;
            this.hTitleButton4.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton5
            // 
            this.hTitleButton5.AlphaAnimated = 180;
            this.hTitleButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleButton5.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton5.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton5.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton5.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton5.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton5.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton5.BorderThickness = 0;
            this.hTitleButton5.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton5.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton5.ButtonImage = null;
            this.hTitleButton5.ClipRegion = false;
            this.hTitleButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton5.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton5.ForeColor = System.Drawing.Color.White;
            this.hTitleButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton5.ImageOffsetY = 10F;
            this.hTitleButton5.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton5.Interval = 200;
            this.hTitleButton5.Location = new System.Drawing.Point(138, 263);
            this.hTitleButton5.Name = "hTitleButton5";
            this.hTitleButton5.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton5.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton5.ShadowRadius = 5;
            this.hTitleButton5.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton5.TabIndex = 14;
            this.hTitleButton5.Text = "Ripple Effect";
            this.hTitleButton5.TextOffsetY = 1F;
            this.hTitleButton5.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton6
            // 
            this.hTitleButton6.AlphaAnimated = 180;
            this.hTitleButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hTitleButton6.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton6.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton6.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton6.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton6.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton6.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton6.BorderThickness = 1;
            this.hTitleButton6.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton6.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton6.ButtonImage = null;
            this.hTitleButton6.ClipRegion = false;
            this.hTitleButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton6.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton6.ForeColor = System.Drawing.Color.White;
            this.hTitleButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton6.ImageOffsetY = 10F;
            this.hTitleButton6.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton6.Interval = 200;
            this.hTitleButton6.Location = new System.Drawing.Point(21, 263);
            this.hTitleButton6.Name = "hTitleButton6";
            this.hTitleButton6.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton6.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton6.ShadowRadius = 5;
            this.hTitleButton6.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton6.TabIndex = 13;
            this.hTitleButton6.Text = "Ripple Effect";
            this.hTitleButton6.TextOffsetY = 1F;
            this.hTitleButton6.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton3
            // 
            this.hTitleButton3.AlphaAnimated = 180;
            this.hTitleButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleButton3.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton3.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton3.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton3.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton3.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton3.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton3.BorderThickness = 0;
            this.hTitleButton3.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton3.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton3.ButtonImage = null;
            this.hTitleButton3.ClipRegion = false;
            this.hTitleButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton3.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton3.ForeColor = System.Drawing.Color.White;
            this.hTitleButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton3.ImageOffsetY = 10F;
            this.hTitleButton3.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton3.Interval = 200;
            this.hTitleButton3.Location = new System.Drawing.Point(250, 166);
            this.hTitleButton3.Name = "hTitleButton3";
            this.hTitleButton3.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton3.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton3.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hTitleButton3.ShadowRadius = 5;
            this.hTitleButton3.Size = new System.Drawing.Size(110, 82);
            this.hTitleButton3.TabIndex = 12;
            this.hTitleButton3.Text = "No animation";
            this.hTitleButton3.TextOffsetY = 1F;
            this.hTitleButton3.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleButton2
            // 
            this.hTitleButton2.AlphaAnimated = 180;
            this.hTitleButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleButton2.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton2.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton2.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton2.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hTitleButton2.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton2.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton2.BorderThickness = 0;
            this.hTitleButton2.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hTitleButton2.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hTitleButton2.ButtonImage = null;
            this.hTitleButton2.ClipRegion = false;
            this.hTitleButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton2.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton2.ForeColor = System.Drawing.Color.White;
            this.hTitleButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton2.ImageOffsetY = 10F;
            this.hTitleButton2.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton2.Interval = 200;
            this.hTitleButton2.Location = new System.Drawing.Point(138, 166);
            this.hTitleButton2.Name = "hTitleButton2";
            this.hTitleButton2.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton2.RippleColor = System.Drawing.Color.Black;
            this.hTitleButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton2.ShadowRadius = 5;
            this.hTitleButton2.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton2.TabIndex = 11;
            this.hTitleButton2.Text = "No animation";
            this.hTitleButton2.TextOffsetY = 1F;
            this.hTitleButton2.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton7
            // 
            this.hButton7.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton7.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton7.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton7.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton7.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton7.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton7.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton7.BorderThickness = 0;
            this.hButton7.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton7.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton7.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton7.ClipRegion = false;
            this.hButton7.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton7.FocusBorderColor = System.Drawing.Color.White;
            this.hButton7.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton7.Image = null;
            this.hButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton7.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton7.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton7.IsAutoSize = false;
            this.hButton7.Location = new System.Drawing.Point(250, 117);
            this.hButton7.Name = "hButton7";
            this.hButton7.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton7.RippleColor = System.Drawing.Color.Black;
            this.hButton7.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton7.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton7.ShadowRadius = 5;
            this.hButton7.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton7.Size = new System.Drawing.Size(110, 34);
            this.hButton7.SupportImageGif = false;
            this.hButton7.TabIndex = 10;
            this.hButton7.Text = "Color Transition";
            this.hButton7.TextDownColor = System.Drawing.Color.White;
            this.hButton7.TextHoverColor = System.Drawing.Color.White;
            this.hButton7.TextNormalColor = System.Drawing.Color.White;
            this.hButton7.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton7.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton7.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton8
            // 
            this.hButton8.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton8.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton8.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton8.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton8.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton8.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton8.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton8.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton8.BorderThickness = 0;
            this.hButton8.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton8.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton8.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton8.ClipRegion = false;
            this.hButton8.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton8.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton8.FocusBorderColor = System.Drawing.Color.White;
            this.hButton8.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton8.Image = null;
            this.hButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton8.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton8.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton8.IsAutoSize = false;
            this.hButton8.Location = new System.Drawing.Point(138, 117);
            this.hButton8.Name = "hButton8";
            this.hButton8.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton8.RippleColor = System.Drawing.Color.Black;
            this.hButton8.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton8.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton8.ShadowRadius = 5;
            this.hButton8.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton8.Size = new System.Drawing.Size(105, 29);
            this.hButton8.SupportImageGif = false;
            this.hButton8.TabIndex = 9;
            this.hButton8.Text = "Color Transition";
            this.hButton8.TextDownColor = System.Drawing.Color.White;
            this.hButton8.TextHoverColor = System.Drawing.Color.White;
            this.hButton8.TextNormalColor = System.Drawing.Color.White;
            this.hButton8.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton8.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton8.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton9
            // 
            this.hButton9.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.ColorTransition;
            this.hButton9.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton9.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton9.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton9.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hButton9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton9.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton9.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton9.BorderThickness = 1;
            this.hButton9.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton9.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton9.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton9.ClipRegion = false;
            this.hButton9.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton9.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton9.FocusBorderColor = System.Drawing.Color.White;
            this.hButton9.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton9.Image = null;
            this.hButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton9.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton9.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton9.IsAutoSize = false;
            this.hButton9.Location = new System.Drawing.Point(21, 117);
            this.hButton9.Name = "hButton9";
            this.hButton9.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton9.RippleColor = System.Drawing.Color.Black;
            this.hButton9.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton9.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton9.ShadowRadius = 5;
            this.hButton9.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton9.Size = new System.Drawing.Size(105, 29);
            this.hButton9.SupportImageGif = false;
            this.hButton9.TabIndex = 8;
            this.hButton9.Text = "Color Transition";
            this.hButton9.TextDownColor = System.Drawing.Color.White;
            this.hButton9.TextHoverColor = System.Drawing.Color.White;
            this.hButton9.TextNormalColor = System.Drawing.Color.White;
            this.hButton9.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton9.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton9.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hTitleSubButton1
            // 
            this.hTitleSubButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleSubButton1.BackColor = System.Drawing.Color.Transparent;
            this.hTitleSubButton1.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton1.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton1.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton1.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleSubButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleSubButton1.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleSubButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleSubButton1.BorderThickness = 1;
            this.hTitleSubButton1.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleSubButton1.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleSubButton1.ButtonImage = null;
            this.hTitleSubButton1.ClipRegion = false;
            this.hTitleSubButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleSubButton1.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleSubButton1.ForeColor = System.Drawing.Color.White;
            this.hTitleSubButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleSubButton1.ImageOffsetY = 15;
            this.hTitleSubButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleSubButton1.Interval = 200;
            this.hTitleSubButton1.Location = new System.Drawing.Point(370, 29);
            this.hTitleSubButton1.Name = "hTitleSubButton1";
            this.hTitleSubButton1.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleSubButton1.RippleColor = System.Drawing.Color.Black;
            this.hTitleSubButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleSubButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton1.ShadowRadius = 5;
            this.hTitleSubButton1.Size = new System.Drawing.Size(115, 117);
            this.hTitleSubButton1.TabIndex = 7;
            this.hTitleSubButton1.Text = "No animation";
            this.hTitleSubButton1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton1.TextInfo = "Enter Text Info Here";
            this.hTitleSubButton1.TextInfoAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hTitleSubButton1.TextInfoColor = System.Drawing.Color.LightGray;
            this.hTitleSubButton1.TextInfoFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hTitleSubButton1.TextInfoOffSetY = -10;
            this.hTitleSubButton1.TextOffsetY = -10F;
            this.hTitleSubButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleSubButton1.TextTextPadding = new System.Windows.Forms.Padding(0);
            this.hTitleSubButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTitleSubButton1.TextY = 10;
            // 
            // hTitleButton1
            // 
            this.hTitleButton1.AlphaAnimated = 180;
            this.hTitleButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hTitleButton1.BackColor = System.Drawing.Color.Transparent;
            this.hTitleButton1.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton1.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton1.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton1.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hTitleButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hTitleButton1.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hTitleButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hTitleButton1.BorderThickness = 1;
            this.hTitleButton1.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTitleButton1.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hTitleButton1.ButtonImage = null;
            this.hTitleButton1.ClipRegion = false;
            this.hTitleButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hTitleButton1.FocusBorderColor = System.Drawing.Color.White;
            this.hTitleButton1.ForeColor = System.Drawing.Color.White;
            this.hTitleButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hTitleButton1.ImageOffsetY = 10F;
            this.hTitleButton1.ImageSize = new System.Drawing.Size(30, 30);
            this.hTitleButton1.Interval = 200;
            this.hTitleButton1.Location = new System.Drawing.Point(21, 166);
            this.hTitleButton1.Name = "hTitleButton1";
            this.hTitleButton1.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hTitleButton1.RippleColor = System.Drawing.Color.BlanchedAlmond;
            this.hTitleButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hTitleButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hTitleButton1.ShadowRadius = 5;
            this.hTitleButton1.Size = new System.Drawing.Size(105, 78);
            this.hTitleButton1.TabIndex = 6;
            this.hTitleButton1.Text = "No animation";
            this.hTitleButton1.TextOffsetY = 1F;
            this.hTitleButton1.TextPadding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.hTitleButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTitleButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton4
            // 
            this.hButton4.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton4.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton4.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton4.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton4.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton4.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton4.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton4.BorderThickness = 0;
            this.hButton4.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton4.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton4.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton4.ClipRegion = false;
            this.hButton4.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton4.FocusBorderColor = System.Drawing.Color.White;
            this.hButton4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton4.Image = null;
            this.hButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton4.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton4.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton4.IsAutoSize = false;
            this.hButton4.Location = new System.Drawing.Point(250, 73);
            this.hButton4.Name = "hButton4";
            this.hButton4.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton4.RippleColor = System.Drawing.Color.Black;
            this.hButton4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton4.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton4.ShadowRadius = 5;
            this.hButton4.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton4.Size = new System.Drawing.Size(110, 34);
            this.hButton4.SupportImageGif = false;
            this.hButton4.TabIndex = 5;
            this.hButton4.Text = "Ripple Effect";
            this.hButton4.TextDownColor = System.Drawing.Color.White;
            this.hButton4.TextHoverColor = System.Drawing.Color.White;
            this.hButton4.TextNormalColor = System.Drawing.Color.White;
            this.hButton4.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton5
            // 
            this.hButton5.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton5.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton5.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton5.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton5.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton5.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton5.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton5.BorderThickness = 0;
            this.hButton5.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton5.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton5.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton5.ClipRegion = false;
            this.hButton5.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton5.FocusBorderColor = System.Drawing.Color.White;
            this.hButton5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton5.Image = null;
            this.hButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton5.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton5.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton5.IsAutoSize = false;
            this.hButton5.Location = new System.Drawing.Point(138, 73);
            this.hButton5.Name = "hButton5";
            this.hButton5.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton5.RippleColor = System.Drawing.Color.Black;
            this.hButton5.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton5.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton5.ShadowRadius = 5;
            this.hButton5.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton5.Size = new System.Drawing.Size(105, 29);
            this.hButton5.SupportImageGif = false;
            this.hButton5.TabIndex = 4;
            this.hButton5.Text = "Ripple Effect";
            this.hButton5.TextDownColor = System.Drawing.Color.White;
            this.hButton5.TextHoverColor = System.Drawing.Color.White;
            this.hButton5.TextNormalColor = System.Drawing.Color.White;
            this.hButton5.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton5.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton5.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton6
            // 
            this.hButton6.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.Ripple;
            this.hButton6.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton6.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton6.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton6.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hButton6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton6.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton6.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton6.BorderThickness = 1;
            this.hButton6.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton6.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton6.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton6.ClipRegion = false;
            this.hButton6.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton6.FocusBorderColor = System.Drawing.Color.White;
            this.hButton6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton6.Image = null;
            this.hButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton6.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton6.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton6.IsAutoSize = false;
            this.hButton6.Location = new System.Drawing.Point(21, 73);
            this.hButton6.Name = "hButton6";
            this.hButton6.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton6.RippleColor = System.Drawing.Color.Black;
            this.hButton6.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton6.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton6.ShadowRadius = 5;
            this.hButton6.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton6.Size = new System.Drawing.Size(105, 29);
            this.hButton6.SupportImageGif = false;
            this.hButton6.TabIndex = 3;
            this.hButton6.Text = "Ripple Effect";
            this.hButton6.TextDownColor = System.Drawing.Color.White;
            this.hButton6.TextHoverColor = System.Drawing.Color.White;
            this.hButton6.TextNormalColor = System.Drawing.Color.White;
            this.hButton6.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton6.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton6.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton3
            // 
            this.hButton3.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton3.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton3.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton3.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton3.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton3.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton3.BorderThickness = 0;
            this.hButton3.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton3.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton3.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton3.ClipRegion = false;
            this.hButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton3.FocusBorderColor = System.Drawing.Color.White;
            this.hButton3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton3.Image = null;
            this.hButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton3.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton3.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton3.IsAutoSize = false;
            this.hButton3.Location = new System.Drawing.Point(250, 29);
            this.hButton3.Name = "hButton3";
            this.hButton3.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton3.RippleColor = System.Drawing.Color.Black;
            this.hButton3.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton3.ShadowPadding = new System.Windows.Forms.Padding(3, 1, 3, 4);
            this.hButton3.ShadowRadius = 5;
            this.hButton3.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton3.Size = new System.Drawing.Size(110, 34);
            this.hButton3.SupportImageGif = false;
            this.hButton3.TabIndex = 2;
            this.hButton3.Text = "No animation";
            this.hButton3.TextDownColor = System.Drawing.Color.White;
            this.hButton3.TextHoverColor = System.Drawing.Color.White;
            this.hButton3.TextNormalColor = System.Drawing.Color.White;
            this.hButton3.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton2
            // 
            this.hButton2.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton2.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton2.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton2.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(98)))), ((int)(((byte)(78)))));
            this.hButton2.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton2.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton2.BorderThickness = 0;
            this.hButton2.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(88)))));
            this.hButton2.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hButton2.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton2.ClipRegion = false;
            this.hButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton2.FocusBorderColor = System.Drawing.Color.White;
            this.hButton2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton2.Image = null;
            this.hButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton2.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton2.IsAutoSize = false;
            this.hButton2.Location = new System.Drawing.Point(138, 29);
            this.hButton2.Name = "hButton2";
            this.hButton2.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton2.RippleColor = System.Drawing.Color.Black;
            this.hButton2.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton2.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton2.ShadowRadius = 5;
            this.hButton2.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton2.Size = new System.Drawing.Size(105, 29);
            this.hButton2.SupportImageGif = false;
            this.hButton2.TabIndex = 1;
            this.hButton2.Text = "No animation";
            this.hButton2.TextDownColor = System.Drawing.Color.White;
            this.hButton2.TextHoverColor = System.Drawing.Color.White;
            this.hButton2.TextNormalColor = System.Drawing.Color.White;
            this.hButton2.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hButton1
            // 
            this.hButton1.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton1.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton1.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton1.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton1.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton1.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton1.BorderThickness = 1;
            this.hButton1.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton1.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton1.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton1.ClipRegion = false;
            this.hButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton1.FocusBorderColor = System.Drawing.Color.White;
            this.hButton1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton1.Image = null;
            this.hButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton1.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton1.IsAutoSize = false;
            this.hButton1.Location = new System.Drawing.Point(21, 29);
            this.hButton1.Name = "hButton1";
            this.hButton1.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hButton1.RippleColor = System.Drawing.Color.Black;
            this.hButton1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton1.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton1.ShadowRadius = 5;
            this.hButton1.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton1.Size = new System.Drawing.Size(105, 29);
            this.hButton1.SupportImageGif = false;
            this.hButton1.TabIndex = 0;
            this.hButton1.Text = "No animation";
            this.hButton1.TextDownColor = System.Drawing.Color.White;
            this.hButton1.TextHoverColor = System.Drawing.Color.White;
            this.hButton1.TextNormalColor = System.Drawing.Color.White;
            this.hButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage5.Controls.Add(this.hEffectImage1);
            this.tabPage5.Controls.Add(this.hImage1);
            this.tabPage5.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage5.Location = new System.Drawing.Point(139, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(757, 546);
            this.tabPage5.TabIndex = 15;
            this.tabPage5.Text = "Images";
            // 
            // hEffectImage1
            // 
            this.hEffectImage1.Image = global::HecopUI_Test.Properties.Resources.hTitleSubButton6_ButtonImage;
            this.hEffectImage1.ImageSize = new System.Drawing.Size(150, 150);
            this.hEffectImage1.Intensity = 1;
            this.hEffectImage1.Location = new System.Drawing.Point(433, 81);
            this.hEffectImage1.Name = "hEffectImage1";
            this.hEffectImage1.Size = new System.Drawing.Size(270, 211);
            this.hEffectImage1.TabIndex = 1;
            this.hEffectImage1.TargetColor = System.Drawing.Color.Green;
            this.hEffectImage1.Text = "hEffectImage1";
            // 
            // hImage1
            // 
            this.hImage1.BlurIntensity = 3;
            this.hImage1.HShapeType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hImage1.Image = global::HecopUI_Test.Properties.Resources.hEffectImage1_Image;
            this.hImage1.ImageSize = new System.Drawing.Size(150, 150);
            this.hImage1.KernelMode = HeCopUI_Framework.Enums.KernelMode.GaussianBlur;
            this.hImage1.Location = new System.Drawing.Point(53, 58);
            this.hImage1.Name = "hImage1";
            this.hImage1.SetImageSizeMode = HeCopUI_Framework.Controls.HImage.ImageSizeMode.Custom;
            this.hImage1.Size = new System.Drawing.Size(222, 215);
            this.hImage1.TabIndex = 0;
            this.hImage1.Text = "hImage1";
            // 
            // tabPage21
            // 
            this.tabPage21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage21.Controls.Add(this.hRichTextBox2);
            this.tabPage21.Controls.Add(this.hTextBox2);
            this.tabPage21.Controls.Add(this.hTextBox1);
            this.tabPage21.Controls.Add(this.hRichTextBox1);
            this.tabPage21.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage21.Location = new System.Drawing.Point(139, 4);
            this.tabPage21.Name = "tabPage21";
            this.tabPage21.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage21.Size = new System.Drawing.Size(757, 546);
            this.tabPage21.TabIndex = 13;
            this.tabPage21.Text = "TextBox & Labels";
            // 
            // hRichTextBox2
            // 
            this.hRichTextBox2.AcceptsTab = false;
            this.hRichTextBox2.AutoWordSelection = false;
            this.hRichTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRichTextBox2.BorderThickness = 1;
            this.hRichTextBox2.BulletIndent = 0;
            this.hRichTextBox2.DetectUrls = true;
            this.hRichTextBox2.EnableAutoDragDrop = false;
            this.hRichTextBox2.HideSelection = false;
            this.hRichTextBox2.Lines = new string[] {
        "hRichTextBox2"};
            this.hRichTextBox2.Location = new System.Drawing.Point(354, 157);
            this.hRichTextBox2.MaxLength = 2147483647;
            this.hRichTextBox2.MultiLine = true;
            this.hRichTextBox2.Name = "hRichTextBox2";
            this.hRichTextBox2.Radius = 1;
            this.hRichTextBox2.ReadOnly = false;
            this.hRichTextBox2.RichTextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hRichTextBox2.RichTextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hRichTextBox2.RichTextBoxScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.hRichTextBox2.SelectionRightIndent = 0;
            this.hRichTextBox2.ShorcutEnabled = false;
            this.hRichTextBox2.ShowSelectionMargin = false;
            this.hRichTextBox2.Size = new System.Drawing.Size(250, 268);
            this.hRichTextBox2.TabIndex = 3;
            this.hRichTextBox2.Text = "hRichTextBox2";
            this.hRichTextBox2.TextColor = System.Drawing.Color.Silver;
            this.hRichTextBox2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRichTextBox2.WordWrap = true;
            // 
            // hTextBox2
            // 
            this.hTextBox2.AcceptsReturn = true;
            this.hTextBox2.AcceptsTab = true;
            this.hTextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.hTextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.hTextBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTextBox2.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTextBox2.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hTextBox2.BorderThickness = 1;
            this.hTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox2.Image = null;
            this.hTextBox2.ImageOffsetX = 2;
            this.hTextBox2.ImageSize = new System.Drawing.Size(20, 20);
            this.hTextBox2.Location = new System.Drawing.Point(354, 53);
            this.hTextBox2.MaxLength = 32767;
            this.hTextBox2.Multiline = false;
            this.hTextBox2.Name = "hTextBox2";
            this.hTextBox2.Radius = 0;
            this.hTextBox2.ReadOnly = false;
            this.hTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hTextBox2.ShortcutsEnabled = false;
            this.hTextBox2.ShowBottomBorder = true;
            this.hTextBox2.ShowTopBorder = true;
            this.hTextBox2.Size = new System.Drawing.Size(250, 38);
            this.hTextBox2.Style = HeCopUI_Framework.Controls.HTextBox.TextBoxStyle.Style2;
            this.hTextBox2.TabIndex = 2;
            this.hTextBox2.TexOffsetX = 2;
            this.hTextBox2.Text = "hTextBox2";
            this.hTextBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.hTextBox2.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTextBox2.TextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hTextBox2.TextColor = System.Drawing.Color.Silver;
            this.hTextBox2.UseAnimation = false;
            this.hTextBox2.UseSystemPasswordChar = false;
            this.hTextBox2.WatermarkColor = System.Drawing.Color.DarkGray;
            this.hTextBox2.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox2.WatermarkRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTextBox2.WatermarkText = "Enter watermark";
            // 
            // hTextBox1
            // 
            this.hTextBox1.AcceptsReturn = true;
            this.hTextBox1.AcceptsTab = true;
            this.hTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.hTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.hTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTextBox1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hTextBox1.BorderThickness = 1;
            this.hTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox1.Image = null;
            this.hTextBox1.ImageOffsetX = 2;
            this.hTextBox1.ImageSize = new System.Drawing.Size(20, 20);
            this.hTextBox1.Location = new System.Drawing.Point(74, 53);
            this.hTextBox1.MaxLength = 32767;
            this.hTextBox1.Multiline = false;
            this.hTextBox1.Name = "hTextBox1";
            this.hTextBox1.Radius = 0;
            this.hTextBox1.ReadOnly = false;
            this.hTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hTextBox1.ShortcutsEnabled = false;
            this.hTextBox1.ShowBottomBorder = true;
            this.hTextBox1.ShowTopBorder = true;
            this.hTextBox1.Size = new System.Drawing.Size(250, 38);
            this.hTextBox1.Style = HeCopUI_Framework.Controls.HTextBox.TextBoxStyle.Style1;
            this.hTextBox1.TabIndex = 1;
            this.hTextBox1.TexOffsetX = 2;
            this.hTextBox1.Text = "hTextBox1";
            this.hTextBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.hTextBox1.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTextBox1.TextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hTextBox1.TextColor = System.Drawing.Color.Silver;
            this.hTextBox1.UseAnimation = false;
            this.hTextBox1.UseSystemPasswordChar = false;
            this.hTextBox1.WatermarkColor = System.Drawing.Color.DarkGray;
            this.hTextBox1.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox1.WatermarkRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTextBox1.WatermarkText = "Enter watermark";
            // 
            // hRichTextBox1
            // 
            this.hRichTextBox1.AcceptsTab = false;
            this.hRichTextBox1.AutoWordSelection = false;
            this.hRichTextBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox1.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRichTextBox1.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRichTextBox1.BorderThickness = 1;
            this.hRichTextBox1.BulletIndent = 0;
            this.hRichTextBox1.DetectUrls = true;
            this.hRichTextBox1.EnableAutoDragDrop = false;
            this.hRichTextBox1.HideSelection = false;
            this.hRichTextBox1.Lines = new string[] {
        "hRichTextBox1"};
            this.hRichTextBox1.Location = new System.Drawing.Point(74, 157);
            this.hRichTextBox1.MaxLength = 2147483647;
            this.hRichTextBox1.MultiLine = true;
            this.hRichTextBox1.Name = "hRichTextBox1";
            this.hRichTextBox1.Radius = 1;
            this.hRichTextBox1.ReadOnly = false;
            this.hRichTextBox1.RichTextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hRichTextBox1.RichTextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hRichTextBox1.RichTextBoxScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.hRichTextBox1.SelectionRightIndent = 0;
            this.hRichTextBox1.ShorcutEnabled = false;
            this.hRichTextBox1.ShowSelectionMargin = false;
            this.hRichTextBox1.Size = new System.Drawing.Size(250, 268);
            this.hRichTextBox1.TabIndex = 0;
            this.hRichTextBox1.Text = "hRichTextBox1";
            this.hRichTextBox1.TextColor = System.Drawing.Color.Silver;
            this.hRichTextBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRichTextBox1.WordWrap = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage3.Controls.Add(this.hRadioButton3);
            this.tabPage3.Controls.Add(this.hRadioButton2);
            this.tabPage3.Controls.Add(this.hCheckBox3);
            this.tabPage3.Controls.Add(this.hCheckBox2);
            this.tabPage3.Controls.Add(this.hRadioButton1);
            this.tabPage3.Controls.Add(this.hToggleButton21);
            this.tabPage3.Controls.Add(this.hToggleButton11);
            this.tabPage3.Controls.Add(this.hToggleButton1);
            this.tabPage3.Controls.Add(this.hCheckBox1);
            this.tabPage3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPage3.Location = new System.Drawing.Point(139, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(757, 546);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Switch/ Options";
            // 
            // hRadioButton3
            // 
            this.hRadioButton3.AlwayCheckedInstance = true;
            this.hRadioButton3.Checked = false;
            this.hRadioButton3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton3.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton3.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton3.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton3.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hRadioButton3.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton3.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton3.Location = new System.Drawing.Point(34, 221);
            this.hRadioButton3.Name = "hRadioButton3";
            this.hRadioButton3.RippleAlpha = 60;
            this.hRadioButton3.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton3.Size = new System.Drawing.Size(299, 28);
            this.hRadioButton3.TabIndex = 8;
            this.hRadioButton3.Text = "hRadioButton3";
            this.hRadioButton3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hRadioButton2
            // 
            this.hRadioButton2.AlwayCheckedInstance = true;
            this.hRadioButton2.Checked = false;
            this.hRadioButton2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton2.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton2.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton2.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hRadioButton2.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton2.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton2.Location = new System.Drawing.Point(34, 187);
            this.hRadioButton2.Name = "hRadioButton2";
            this.hRadioButton2.RippleAlpha = 60;
            this.hRadioButton2.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton2.Size = new System.Drawing.Size(299, 28);
            this.hRadioButton2.TabIndex = 7;
            this.hRadioButton2.Text = "hRadioButton2";
            this.hRadioButton2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hCheckBox3
            // 
            this.hCheckBox3.CheckColor = System.Drawing.Color.White;
            this.hCheckBox3.Checked = false;
            this.hCheckBox3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox3.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox3.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hCheckBox3.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox3.Location = new System.Drawing.Point(34, 101);
            this.hCheckBox3.Name = "hCheckBox3";
            this.hCheckBox3.RippleAlpha = 60;
            this.hCheckBox3.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox3.Size = new System.Drawing.Size(299, 28);
            this.hCheckBox3.TabIndex = 6;
            this.hCheckBox3.Text = "hCheckBox3";
            this.hCheckBox3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox3.CheckedChanged += new System.EventHandler(this.hCheckBox3_CheckedChanged);
            // 
            // hCheckBox2
            // 
            this.hCheckBox2.CheckColor = System.Drawing.Color.White;
            this.hCheckBox2.Checked = false;
            this.hCheckBox2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox2.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox2.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hCheckBox2.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox2.Location = new System.Drawing.Point(34, 67);
            this.hCheckBox2.Name = "hCheckBox2";
            this.hCheckBox2.RippleAlpha = 60;
            this.hCheckBox2.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox2.Size = new System.Drawing.Size(299, 28);
            this.hCheckBox2.TabIndex = 5;
            this.hCheckBox2.Text = "hCheckBox2";
            this.hCheckBox2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox2.CheckedChanged += new System.EventHandler(this.hCheckBox2_CheckedChanged);
            // 
            // hRadioButton1
            // 
            this.hRadioButton1.AlwayCheckedInstance = true;
            this.hRadioButton1.Checked = true;
            this.hRadioButton1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hRadioButton1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.hRadioButton1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hRadioButton1.EnabledCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hRadioButton1.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hRadioButton1.EnabledUnCheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(158)))), ((int)(((byte)(161)))));
            this.hRadioButton1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hRadioButton1.Location = new System.Drawing.Point(34, 153);
            this.hRadioButton1.Name = "hRadioButton1";
            this.hRadioButton1.RippleAlpha = 60;
            this.hRadioButton1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hRadioButton1.Size = new System.Drawing.Size(299, 28);
            this.hRadioButton1.TabIndex = 4;
            this.hRadioButton1.Text = "hRadioButton1";
            this.hRadioButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hRadioButton1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hToggleButton21
            // 
            this.hToggleButton21.BackColor = System.Drawing.Color.Transparent;
            this.hToggleButton21.BorderColor = System.Drawing.Color.Gray;
            this.hToggleButton21.BorderWidth = 1F;
            this.hToggleButton21.Location = new System.Drawing.Point(45, 359);
            this.hToggleButton21.MinimumSize = new System.Drawing.Size(47, 22);
            this.hToggleButton21.Name = "hToggleButton21";
            this.hToggleButton21.OffColor = System.Drawing.Color.DimGray;
            this.hToggleButton21.OffLeverColor = System.Drawing.Color.LightGray;
            this.hToggleButton21.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hToggleButton21.OnLeverColor = System.Drawing.Color.LightGray;
            this.hToggleButton21.Padding = new System.Windows.Forms.Padding(5);
            this.hToggleButton21.Size = new System.Drawing.Size(47, 23);
            this.hToggleButton21.SliderWidth = 1F;
            this.hToggleButton21.TabIndex = 3;
            this.hToggleButton21.Text = "hToggleButton21";
            this.hToggleButton21.ValueChecked = true;
            // 
            // hToggleButton11
            // 
            this.hToggleButton11.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hToggleButton11.ActiveText = "ON";
            this.hToggleButton11.BackColor = System.Drawing.Color.Transparent;
            this.hToggleButton11.ForeColor = System.Drawing.Color.White;
            this.hToggleButton11.InActiveColor = System.Drawing.Color.DimGray;
            this.hToggleButton11.InActiveText = "OFF";
            this.hToggleButton11.Location = new System.Drawing.Point(45, 313);
            this.hToggleButton11.MinimumSize = new System.Drawing.Size(56, 26);
            this.hToggleButton11.Name = "hToggleButton11";
            this.hToggleButton11.ShowStatusText = true;
            this.hToggleButton11.Size = new System.Drawing.Size(56, 26);
            this.hToggleButton11.SliderColor = System.Drawing.Color.DarkGray;
            this.hToggleButton11.TabIndex = 2;
            this.hToggleButton11.Text = "hToggleButton11";
            this.hToggleButton11.TextColor = System.Drawing.Color.White;
            this.hToggleButton11.TextRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hToggleButton11.ToggleState = HeCopUI_Framework.Controls.HToggleButton1.ToggleButtonState.OFF;
            // 
            // hToggleButton1
            // 
            this.hToggleButton1.BorderColor = System.Drawing.Color.LightGray;
            this.hToggleButton1.BorderLeverColor = System.Drawing.Color.DarkGray;
            this.hToggleButton1.IsOn = false;
            this.hToggleButton1.LeverColor = System.Drawing.Color.White;
            this.hToggleButton1.Location = new System.Drawing.Point(45, 268);
            this.hToggleButton1.Name = "hToggleButton1";
            this.hToggleButton1.OffColor = System.Drawing.Color.DimGray;
            this.hToggleButton1.OffText = "Off";
            this.hToggleButton1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hToggleButton1.OnText = "On";
            this.hToggleButton1.Radius = 13.5F;
            this.hToggleButton1.Size = new System.Drawing.Size(54, 29);
            this.hToggleButton1.StatusColor = System.Drawing.Color.White;
            this.hToggleButton1.TabIndex = 1;
            this.hToggleButton1.Text = "hToggleButton1";
            this.hToggleButton1.TextEnabled = true;
            this.hToggleButton1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // hCheckBox1
            // 
            this.hCheckBox1.CheckColor = System.Drawing.Color.White;
            this.hCheckBox1.Checked = true;
            this.hCheckBox1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hCheckBox1.DisabledTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(187)))), ((int)(((byte)(189)))));
            this.hCheckBox1.EnabledTextColor = System.Drawing.Color.LightGray;
            this.hCheckBox1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(118)))));
            this.hCheckBox1.Location = new System.Drawing.Point(34, 33);
            this.hCheckBox1.Name = "hCheckBox1";
            this.hCheckBox1.RippleAlpha = 60;
            this.hCheckBox1.RippleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hCheckBox1.Size = new System.Drawing.Size(299, 28);
            this.hCheckBox1.TabIndex = 0;
            this.hCheckBox1.Text = "hCheckBox1";
            this.hCheckBox1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hCheckBox1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hCheckBox1.CheckedChanged += new System.EventHandler(this.hCheckBox1_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage4.Controls.Add(this.hDotProgressRing7);
            this.tabPage4.Controls.Add(this.hProgressBar4);
            this.tabPage4.Controls.Add(this.hProgressBar5);
            this.tabPage4.Controls.Add(this.hProgressBar6);
            this.tabPage4.Controls.Add(this.hButton10);
            this.tabPage4.Controls.Add(this.hProgressBar3);
            this.tabPage4.Controls.Add(this.hProgressBar2);
            this.tabPage4.Controls.Add(this.hCircularProgressBar2);
            this.tabPage4.Controls.Add(this.hProgressBarWaterWave1);
            this.tabPage4.Controls.Add(this.waveProgressLoading1);
            this.tabPage4.Controls.Add(this.hProgressBar1);
            this.tabPage4.Controls.Add(this.hCircularProgressBar21);
            this.tabPage4.Controls.Add(this.hCircularProgressBar11);
            this.tabPage4.Controls.Add(this.hCircularProgressBar1);
            this.tabPage4.Controls.Add(this.hDotProgressRing6);
            this.tabPage4.Controls.Add(this.hDotProgressRing5);
            this.tabPage4.Controls.Add(this.hDotProgressRing4);
            this.tabPage4.Controls.Add(this.hDotProgressRing3);
            this.tabPage4.Controls.Add(this.hDotProgressRing2);
            this.tabPage4.Controls.Add(this.hDotProgressRing1);
            this.tabPage4.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(757, 546);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Progress Bar";
            // 
            // hDotProgressRing7
            // 
            this.hDotProgressRing7.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing7.DotCount = 10;
            this.hDotProgressRing7.Interval = 50;
            this.hDotProgressRing7.Location = new System.Drawing.Point(385, 18);
            this.hDotProgressRing7.Name = "hDotProgressRing7";
            this.hDotProgressRing7.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style5;
            this.hDotProgressRing7.Radius = 5;
            this.hDotProgressRing7.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing7.StartAnimation = true;
            this.hDotProgressRing7.SupportTransparent = true;
            this.hDotProgressRing7.TabIndex = 19;
            this.hDotProgressRing7.Text = "hDotProgressRing7";
            // 
            // hProgressBar4
            // 
            this.hProgressBar4.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.None;
            this.hProgressBar4.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar4.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar4.BorderWidth = 1;
            this.hProgressBar4.ForeColor = System.Drawing.Color.White;
            this.hProgressBar4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar4.Location = new System.Drawing.Point(522, 256);
            this.hProgressBar4.MaximumValue = 100;
            this.hProgressBar4.MinimumValue = 0;
            this.hProgressBar4.Name = "hProgressBar4";
            this.hProgressBar4.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar4.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar4.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar4.ProgressValue = 32;
            this.hProgressBar4.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar4.Size = new System.Drawing.Size(15, 260);
            this.hProgressBar4.TabIndex = 18;
            this.hProgressBar4.Text = "hProgressBar4";
            // 
            // hProgressBar5
            // 
            this.hProgressBar5.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Value;
            this.hProgressBar5.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar5.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar5.BorderWidth = 1;
            this.hProgressBar5.ForeColor = System.Drawing.Color.White;
            this.hProgressBar5.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar5.Location = new System.Drawing.Point(483, 256);
            this.hProgressBar5.MaximumValue = 100;
            this.hProgressBar5.MinimumValue = 0;
            this.hProgressBar5.Name = "hProgressBar5";
            this.hProgressBar5.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar5.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar5.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar5.ProgressValue = 32;
            this.hProgressBar5.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar5.Size = new System.Drawing.Size(15, 260);
            this.hProgressBar5.TabIndex = 17;
            this.hProgressBar5.Text = "hProgressBar5";
            // 
            // hProgressBar6
            // 
            this.hProgressBar6.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Indeterminate;
            this.hProgressBar6.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar6.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar6.BorderWidth = 1;
            this.hProgressBar6.ForeColor = System.Drawing.Color.White;
            this.hProgressBar6.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar6.Location = new System.Drawing.Point(444, 256);
            this.hProgressBar6.MaximumValue = 100;
            this.hProgressBar6.MinimumValue = 0;
            this.hProgressBar6.Name = "hProgressBar6";
            this.hProgressBar6.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.hProgressBar6.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar6.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar6.ProgressValue = 32;
            this.hProgressBar6.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar6.Size = new System.Drawing.Size(15, 260);
            this.hProgressBar6.TabIndex = 16;
            this.hProgressBar6.Text = "hProgressBar6";
            // 
            // hButton10
            // 
            this.hButton10.AnimationMode = HeCopUI_Framework.Enums.AnimationMode.None;
            this.hButton10.BackHoverColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton10.BackHoverColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton10.BackPressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton10.BackPressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.hButton10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hButton10.BorderDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(108)))));
            this.hButton10.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hButton10.BorderThickness = 1;
            this.hButton10.ButtonColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hButton10.ButtonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hButton10.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hButton10.ClipRegion = false;
            this.hButton10.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            this.hButton10.DialogResult = System.Windows.Forms.DialogResult.None;
            this.hButton10.FocusBorderColor = System.Drawing.Color.White;
            this.hButton10.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.hButton10.Image = null;
            this.hButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hButton10.ImagePadding = new System.Windows.Forms.Padding(0);
            this.hButton10.ImageSize = new System.Drawing.Size(20, 20);
            this.hButton10.IsAutoSize = false;
            this.hButton10.Location = new System.Drawing.Point(654, 293);
            this.hButton10.Name = "hButton10";
            this.hButton10.Radius = new HeCopUI_Framework.Struct.CornerRadius(0F);
            this.hButton10.RippleColor = System.Drawing.Color.Black;
            this.hButton10.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hButton10.ShadowPadding = new System.Windows.Forms.Padding(0);
            this.hButton10.ShadowRadius = 5;
            this.hButton10.ShapeButtonType = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.hButton10.Size = new System.Drawing.Size(75, 29);
            this.hButton10.SupportImageGif = false;
            this.hButton10.TabIndex = 15;
            this.hButton10.Text = "Random";
            this.hButton10.TextDownColor = System.Drawing.Color.White;
            this.hButton10.TextHoverColor = System.Drawing.Color.White;
            this.hButton10.TextNormalColor = System.Drawing.Color.White;
            this.hButton10.TextPadding = new System.Windows.Forms.Padding(0);
            this.hButton10.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hButton10.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hButton10.MouseClick += new System.Windows.Forms.MouseEventHandler(this.hButton10_MouseClick);
            // 
            // hProgressBar3
            // 
            this.hProgressBar3.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.None;
            this.hProgressBar3.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar3.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar3.BorderWidth = 1;
            this.hProgressBar3.ForeColor = System.Drawing.Color.White;
            this.hProgressBar3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar3.Location = new System.Drawing.Point(20, 469);
            this.hProgressBar3.MaximumValue = 100;
            this.hProgressBar3.MinimumValue = 0;
            this.hProgressBar3.Name = "hProgressBar3";
            this.hProgressBar3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar3.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar3.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar3.ProgressValue = 32;
            this.hProgressBar3.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar3.Size = new System.Drawing.Size(323, 15);
            this.hProgressBar3.TabIndex = 14;
            this.hProgressBar3.Text = "hProgressBar3";
            // 
            // hProgressBar2
            // 
            this.hProgressBar2.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Value;
            this.hProgressBar2.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar2.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar2.BorderWidth = 1;
            this.hProgressBar2.ForeColor = System.Drawing.Color.White;
            this.hProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar2.Location = new System.Drawing.Point(20, 445);
            this.hProgressBar2.MaximumValue = 100;
            this.hProgressBar2.MinimumValue = 0;
            this.hProgressBar2.Name = "hProgressBar2";
            this.hProgressBar2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar2.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar2.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar2.ProgressValue = 32;
            this.hProgressBar2.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar2.Size = new System.Drawing.Size(323, 15);
            this.hProgressBar2.TabIndex = 13;
            this.hProgressBar2.Text = "hProgressBar2";
            // 
            // hCircularProgressBar2
            // 
            this.hCircularProgressBar2.AnimationMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.AnimationType.Indicator;
            this.hCircularProgressBar2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar2.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hCircularProgressBar2.InnerMargin = 2;
            this.hCircularProgressBar2.InnerWidth = -1;
            this.hCircularProgressBar2.Interval = 50;
            this.hCircularProgressBar2.Location = new System.Drawing.Point(20, 256);
            this.hCircularProgressBar2.Maximum = 100;
            this.hCircularProgressBar2.Minimum = 0;
            this.hCircularProgressBar2.Name = "hCircularProgressBar2";
            this.hCircularProgressBar2.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hCircularProgressBar2.OuterMargin = -10;
            this.hCircularProgressBar2.OuterWidth = 10;
            this.hCircularProgressBar2.ProgressBarValue = 40;
            this.hCircularProgressBar2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar2.ProgressTextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.TextMode.Percentage;
            this.hCircularProgressBar2.ProgressWidth = 10;
            this.hCircularProgressBar2.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar2.TabIndex = 12;
            this.hCircularProgressBar2.Text = "hCircularProgressBar2";
            this.hCircularProgressBar2.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.hCircularProgressBar2.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hProgressBarWaterWave1
            // 
            this.hProgressBarWaterWave1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBarWaterWave1.BorderThickness = 5;
            this.hProgressBarWaterWave1.Location = new System.Drawing.Point(177, 256);
            this.hProgressBarWaterWave1.Maximum = 100;
            this.hProgressBarWaterWave1.Minimum = 0;
            this.hProgressBarWaterWave1.Name = "hProgressBarWaterWave1";
            this.hProgressBarWaterWave1.ProgressShape = HeCopUI_Framework.Controls.Progress.HProgressBarWaterWave.ProgressShapeType.Circular;
            this.hProgressBarWaterWave1.Radius = 0;
            this.hProgressBarWaterWave1.Size = new System.Drawing.Size(108, 111);
            this.hProgressBarWaterWave1.TabIndex = 11;
            this.hProgressBarWaterWave1.Text = "hProgressBarWaterWave1";
            this.hProgressBarWaterWave1.Value = 50;
            this.hProgressBarWaterWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBarWaterWave1.WaveHeight = 30;
            this.hProgressBarWaterWave1.WaveSleep = 50;
            this.hProgressBarWaterWave1.WaveWidth = 200;
            // 
            // waveProgressLoading1
            // 
            this.waveProgressLoading1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.waveProgressLoading1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.waveProgressLoading1.Location = new System.Drawing.Point(444, 76);
            this.waveProgressLoading1.MaxHeight = 60;
            this.waveProgressLoading1.Name = "waveProgressLoading1";
            this.waveProgressLoading1.Size = new System.Drawing.Size(270, 127);
            this.waveProgressLoading1.SpaceBetweenWave = 20;
            this.waveProgressLoading1.TabIndex = 10;
            this.waveProgressLoading1.Text = "waveProgressLoading1";
            this.waveProgressLoading1.WaveAnimationStyle = HeCopUI_Framework.Controls.Progress.WaveProgressLoading.AnimationStyle.Ascending;
            this.waveProgressLoading1.WaveCount = 5;
            this.waveProgressLoading1.WaveWidth = 10;
            // 
            // hProgressBar1
            // 
            this.hProgressBar1.AnimationMode = HeCopUI_Framework.Enums.ProgressAnimationMode.Indeterminate;
            this.hProgressBar1.BaseProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hProgressBar1.BaseProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hProgressBar1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hProgressBar1.BorderWidth = 1;
            this.hProgressBar1.ForeColor = System.Drawing.Color.White;
            this.hProgressBar1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hProgressBar1.Location = new System.Drawing.Point(20, 421);
            this.hProgressBar1.MaximumValue = 100;
            this.hProgressBar1.MinimumValue = 0;
            this.hProgressBar1.Name = "hProgressBar1";
            this.hProgressBar1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.hProgressBar1.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hProgressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hProgressBar1.ProgressValue = 32;
            this.hProgressBar1.Radius = new HeCopUI_Framework.Struct.CornerRadius(5F);
            this.hProgressBar1.Size = new System.Drawing.Size(323, 15);
            this.hProgressBar1.TabIndex = 9;
            this.hProgressBar1.Text = "hProgressBar1";
            // 
            // hCircularProgressBar21
            // 
            this.hCircularProgressBar21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hCircularProgressBar21.BarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar21.BarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar21.BarWidth = 6F;
            this.hCircularProgressBar21.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.hCircularProgressBar21.ForeColor = System.Drawing.Color.DimGray;
            this.hCircularProgressBar21.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.hCircularProgressBar21.LineColor = System.Drawing.Color.DimGray;
            this.hCircularProgressBar21.LineWidth = 1;
            this.hCircularProgressBar21.Location = new System.Drawing.Point(250, 127);
            this.hCircularProgressBar21.Maximum = ((long)(100));
            this.hCircularProgressBar21.MinimumSize = new System.Drawing.Size(100, 100);
            this.hCircularProgressBar21.Name = "hCircularProgressBar21";
            this.hCircularProgressBar21.ProgressShape = HeCopUI_Framework.Controls.Progress.HCircularProgressBar2.ProgressShapeType.Flat;
            this.hCircularProgressBar21.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar21.TabIndex = 8;
            this.hCircularProgressBar21.Text = "57%";
            this.hCircularProgressBar21.TextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar2.TextModeVisible.Percentage;
            this.hCircularProgressBar21.Value = ((long)(57));
            // 
            // hCircularProgressBar11
            // 
            this.hCircularProgressBar11.BackColor = System.Drawing.Color.Transparent;
            this.hCircularProgressBar11.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hCircularProgressBar11.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hCircularProgressBar11.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.hCircularProgressBar11.ForeColor = System.Drawing.Color.Gray;
            this.hCircularProgressBar11.Location = new System.Drawing.Point(135, 127);
            this.hCircularProgressBar11.Maximum = ((long)(100));
            this.hCircularProgressBar11.MinimumSize = new System.Drawing.Size(100, 100);
            this.hCircularProgressBar11.Name = "hCircularProgressBar11";
            this.hCircularProgressBar11.ProgressColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar11.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar11.ProgressShape = HeCopUI_Framework.Controls.Progress.HCircularProgressBar1._ProgressShape.Round;
            this.hCircularProgressBar11.ProgressThickness = 8F;
            this.hCircularProgressBar11.ProgresTextType = HeCopUI_Framework.Controls.Progress.HCircularProgressBar1.TextType.Percentage;
            this.hCircularProgressBar11.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar11.TabIndex = 7;
            this.hCircularProgressBar11.Text = "hCircularProgressBar11";
            this.hCircularProgressBar11.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar11.Value = ((long)(21));
            // 
            // hCircularProgressBar1
            // 
            this.hCircularProgressBar1.AnimationMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.AnimationType.None;
            this.hCircularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.hCircularProgressBar1.InnerMargin = 2;
            this.hCircularProgressBar1.InnerWidth = -1;
            this.hCircularProgressBar1.Interval = 50;
            this.hCircularProgressBar1.Location = new System.Drawing.Point(20, 127);
            this.hCircularProgressBar1.Maximum = 100;
            this.hCircularProgressBar1.Minimum = 0;
            this.hCircularProgressBar1.Name = "hCircularProgressBar1";
            this.hCircularProgressBar1.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hCircularProgressBar1.OuterMargin = -10;
            this.hCircularProgressBar1.OuterWidth = 10;
            this.hCircularProgressBar1.ProgressBarValue = 10;
            this.hCircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hCircularProgressBar1.ProgressTextMode = HeCopUI_Framework.Controls.Progress.HCircularProgressBar.TextMode.Percentage;
            this.hCircularProgressBar1.ProgressWidth = 10;
            this.hCircularProgressBar1.Size = new System.Drawing.Size(109, 109);
            this.hCircularProgressBar1.TabIndex = 6;
            this.hCircularProgressBar1.Text = "hCircularProgressBar1";
            this.hCircularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.hCircularProgressBar1.TextRenderHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.hCircularProgressBar1.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            // 
            // hDotProgressRing6
            // 
            this.hDotProgressRing6.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing6.DotCount = 8;
            this.hDotProgressRing6.Interval = 50;
            this.hDotProgressRing6.Location = new System.Drawing.Point(472, 18);
            this.hDotProgressRing6.Name = "hDotProgressRing6";
            this.hDotProgressRing6.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style6;
            this.hDotProgressRing6.Radius = 5;
            this.hDotProgressRing6.Size = new System.Drawing.Size(267, 31);
            this.hDotProgressRing6.StartAnimation = true;
            this.hDotProgressRing6.SupportTransparent = true;
            this.hDotProgressRing6.TabIndex = 5;
            this.hDotProgressRing6.Text = "hDotProgressRing6";
            // 
            // hDotProgressRing5
            // 
            this.hDotProgressRing5.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing5.DotCount = 10;
            this.hDotProgressRing5.Interval = 50;
            this.hDotProgressRing5.Location = new System.Drawing.Point(312, 18);
            this.hDotProgressRing5.Name = "hDotProgressRing5";
            this.hDotProgressRing5.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style7;
            this.hDotProgressRing5.Radius = 5;
            this.hDotProgressRing5.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing5.StartAnimation = true;
            this.hDotProgressRing5.SupportTransparent = true;
            this.hDotProgressRing5.TabIndex = 4;
            this.hDotProgressRing5.Text = "hDotProgressRing5";
            // 
            // hDotProgressRing4
            // 
            this.hDotProgressRing4.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing4.DotCount = 8;
            this.hDotProgressRing4.Interval = 50;
            this.hDotProgressRing4.Location = new System.Drawing.Point(239, 18);
            this.hDotProgressRing4.Name = "hDotProgressRing4";
            this.hDotProgressRing4.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style4;
            this.hDotProgressRing4.Radius = 5;
            this.hDotProgressRing4.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing4.StartAnimation = true;
            this.hDotProgressRing4.SupportTransparent = true;
            this.hDotProgressRing4.TabIndex = 3;
            this.hDotProgressRing4.Text = "hDotProgressRing4";
            // 
            // hDotProgressRing3
            // 
            this.hDotProgressRing3.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing3.DotCount = 8;
            this.hDotProgressRing3.Interval = 50;
            this.hDotProgressRing3.Location = new System.Drawing.Point(166, 18);
            this.hDotProgressRing3.Name = "hDotProgressRing3";
            this.hDotProgressRing3.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style3;
            this.hDotProgressRing3.Radius = 2;
            this.hDotProgressRing3.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing3.StartAnimation = true;
            this.hDotProgressRing3.SupportTransparent = true;
            this.hDotProgressRing3.TabIndex = 2;
            this.hDotProgressRing3.Text = "hDotProgressRing3";
            // 
            // hDotProgressRing2
            // 
            this.hDotProgressRing2.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing2.DotCount = 8;
            this.hDotProgressRing2.Interval = 50;
            this.hDotProgressRing2.Location = new System.Drawing.Point(93, 18);
            this.hDotProgressRing2.Name = "hDotProgressRing2";
            this.hDotProgressRing2.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style2;
            this.hDotProgressRing2.Radius = 5;
            this.hDotProgressRing2.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing2.StartAnimation = true;
            this.hDotProgressRing2.SupportTransparent = true;
            this.hDotProgressRing2.TabIndex = 1;
            this.hDotProgressRing2.Text = "hDotProgressRing2";
            // 
            // hDotProgressRing1
            // 
            this.hDotProgressRing1.DotColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(102)))));
            this.hDotProgressRing1.DotCount = 8;
            this.hDotProgressRing1.Interval = 50;
            this.hDotProgressRing1.Location = new System.Drawing.Point(20, 18);
            this.hDotProgressRing1.Name = "hDotProgressRing1";
            this.hDotProgressRing1.ProgressStyle = HeCopUI_Framework.Controls.Progress.HDotProgressRing.Style.Style1;
            this.hDotProgressRing1.Radius = 5;
            this.hDotProgressRing1.Size = new System.Drawing.Size(67, 67);
            this.hDotProgressRing1.StartAnimation = true;
            this.hDotProgressRing1.SupportTransparent = true;
            this.hDotProgressRing1.TabIndex = 0;
            this.hDotProgressRing1.Text = "hDotProgressRing1";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage7.Controls.Add(this.hScrollBar3);
            this.tabPage7.Controls.Add(this.hScrollBar4);
            this.tabPage7.Controls.Add(this.hScrollBar2);
            this.tabPage7.Controls.Add(this.hScrollBar1);
            this.tabPage7.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage7.Location = new System.Drawing.Point(139, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(757, 546);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Scroll Bars";
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hScrollBar3.BarRadius = 0;
            this.hScrollBar3.HighlightOnWheel = true;
            this.hScrollBar3.HoverThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(142)))));
            this.hScrollBar3.Location = new System.Drawing.Point(481, 158);
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.hScrollBar3.Size = new System.Drawing.Size(200, 10);
            this.hScrollBar3.TabIndex = 4;
            this.hScrollBar3.Text = "hScrollBar3";
            this.hScrollBar3.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar3.ThumbRadius = 0;
            this.hScrollBar3.UseBarColor = true;
            // 
            // hScrollBar4
            // 
            this.hScrollBar4.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hScrollBar4.BarRadius = 0;
            this.hScrollBar4.HighlightOnWheel = true;
            this.hScrollBar4.HoverThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(142)))));
            this.hScrollBar4.Location = new System.Drawing.Point(416, 56);
            this.hScrollBar4.Maximum = 50;
            this.hScrollBar4.Name = "hScrollBar4";
            this.hScrollBar4.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.hScrollBar4.Size = new System.Drawing.Size(10, 200);
            this.hScrollBar4.TabIndex = 3;
            this.hScrollBar4.Text = "hScrollBar4";
            this.hScrollBar4.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar4.ThumbRadius = 0;
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hScrollBar2.BarRadius = 0;
            this.hScrollBar2.HoverThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(142)))));
            this.hScrollBar2.Location = new System.Drawing.Point(152, 158);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Orientation = System.Windows.Forms.ScrollOrientation.HorizontalScroll;
            this.hScrollBar2.Size = new System.Drawing.Size(200, 10);
            this.hScrollBar2.TabIndex = 2;
            this.hScrollBar2.Text = "hScrollBar2";
            this.hScrollBar2.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar2.ThumbRadius = 0;
            this.hScrollBar2.UseBarColor = true;
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.BarColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hScrollBar1.BarRadius = 0;
            this.hScrollBar1.HoverThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(142)))));
            this.hScrollBar1.Location = new System.Drawing.Point(87, 56);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Orientation = System.Windows.Forms.ScrollOrientation.VerticalScroll;
            this.hScrollBar1.Size = new System.Drawing.Size(10, 200);
            this.hScrollBar1.TabIndex = 1;
            this.hScrollBar1.Text = "hScrollBar1";
            this.hScrollBar1.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(122)))));
            this.hScrollBar1.ThumbRadius = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage8.Controls.Add(this.HPanel1);
            this.tabPage8.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage8.Location = new System.Drawing.Point(139, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(757, 546);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "Container controls";
            // 
            // HPanel1
            // 
            this.HPanel1.BackColor = System.Drawing.Color.Transparent;
            this.HPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.HPanel1.BorderThickness = 1F;
            this.HPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.HPanel1.Location = new System.Drawing.Point(87, 48);
            this.HPanel1.Name = "HPanel1";
            this.HPanel1.PanelColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(48)))));
            this.HPanel1.PanelColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(48)))));
            this.HPanel1.Radius = new HeCopUI_Framework.Struct.CornerRadius(20F);
            this.HPanel1.RoundBottomLeft = true;
            this.HPanel1.RoundBottomRight = true;
            this.HPanel1.RoundTopLeft = true;
            this.HPanel1.RoundTopRight = true;
            this.HPanel1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.HPanel1.ShadowPadding = new System.Windows.Forms.Padding(5, 4, 5, 8);
            this.HPanel1.ShadowRadius = 5;
            this.HPanel1.Size = new System.Drawing.Size(572, 424);
            this.HPanel1.TabIndex = 0;
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage9.Controls.Add(this.hTabControl3);
            this.tabPage9.Controls.Add(this.hTabControl2);
            this.tabPage9.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage9.Location = new System.Drawing.Point(139, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(757, 546);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Tab Control";
            // 
            // hTabControl3
            // 
            this.hTabControl3.ApplyTabPagesColor = true;
            this.hTabControl3.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl3.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl3.BorderThickness = 1;
            this.hTabControl3.Controls.Add(this.tabPage12);
            this.hTabControl3.Controls.Add(this.tabPage13);
            this.hTabControl3.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl3.Location = new System.Drawing.Point(381, 45);
            this.hTabControl3.Name = "hTabControl3";
            this.hTabControl3.SelectedIndex = 0;
            this.hTabControl3.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl3.SelectedTextColor = System.Drawing.Color.White;
            this.hTabControl3.Size = new System.Drawing.Size(340, 444);
            this.hTabControl3.TabIndex = 1;
            this.hTabControl3.TabsColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTabControl3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl3.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl3.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl3.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl3.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl3.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl3.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl3.UnselectedTextColor = System.Drawing.Color.Silver;
            this.hTabControl3.UseAnimation = false;
            // 
            // tabPage12
            // 
            this.tabPage12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage12.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage12.Location = new System.Drawing.Point(4, 25);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(332, 415);
            this.tabPage12.TabIndex = 0;
            this.tabPage12.Text = "Tab 1";
            // 
            // tabPage13
            // 
            this.tabPage13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage13.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage13.Location = new System.Drawing.Point(4, 25);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(332, 415);
            this.tabPage13.TabIndex = 1;
            this.tabPage13.Text = "Tab 2";
            // 
            // hTabControl2
            // 
            this.hTabControl2.ApplyTabPagesColor = true;
            this.hTabControl2.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl2.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl2.BorderThickness = 1;
            this.hTabControl2.Controls.Add(this.tabPage10);
            this.hTabControl2.Controls.Add(this.tabPage11);
            this.hTabControl2.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl2.Location = new System.Drawing.Point(22, 45);
            this.hTabControl2.Name = "hTabControl2";
            this.hTabControl2.SelectedIndex = 0;
            this.hTabControl2.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTabControl2.SelectedTextColor = System.Drawing.Color.White;
            this.hTabControl2.Size = new System.Drawing.Size(340, 444);
            this.hTabControl2.TabIndex = 0;
            this.hTabControl2.TabsColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTabControl2.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl2.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl2.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl2.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl2.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl2.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl2.UnselectedTextColor = System.Drawing.Color.Silver;
            this.hTabControl2.UseAnimation = false;
            // 
            // tabPage10
            // 
            this.tabPage10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage10.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage10.Location = new System.Drawing.Point(4, 25);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(332, 415);
            this.tabPage10.TabIndex = 0;
            this.tabPage10.Text = "Tab 1";
            // 
            // tabPage11
            // 
            this.tabPage11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage11.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage11.Location = new System.Drawing.Point(4, 25);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(332, 415);
            this.tabPage11.TabIndex = 1;
            this.tabPage11.Text = "Tab 2";
            // 
            // tabPage14
            // 
            this.tabPage14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage14.Controls.Add(this.hTabControl4);
            this.tabPage14.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage14.Location = new System.Drawing.Point(139, 4);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(757, 546);
            this.tabPage14.TabIndex = 9;
            this.tabPage14.Text = "Charts";
            // 
            // hTabControl4
            // 
            this.hTabControl4.ApplyTabPagesColor = true;
            this.hTabControl4.BackgroundColor = System.Drawing.Color.Transparent;
            this.hTabControl4.BorderTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTabControl4.BorderThickness = 1;
            this.hTabControl4.Controls.Add(this.tabPage15);
            this.hTabControl4.Controls.Add(this.tabPage16);
            this.hTabControl4.Controls.Add(this.tabPage17);
            this.hTabControl4.Controls.Add(this.tabPage18);
            this.hTabControl4.CursorTabPages = System.Windows.Forms.Cursors.Default;
            this.hTabControl4.ItemSize = new System.Drawing.Size(54, 28);
            this.hTabControl4.Location = new System.Drawing.Point(34, 31);
            this.hTabControl4.Multiline = true;
            this.hTabControl4.Name = "hTabControl4";
            this.hTabControl4.SelectedIndex = 0;
            this.hTabControl4.SelectedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTabControl4.SelectedTextColor = System.Drawing.Color.White;
            this.hTabControl4.Size = new System.Drawing.Size(684, 464);
            this.hTabControl4.TabIndex = 1;
            this.hTabControl4.TabsColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTabControl4.TabStyle = HeCopUI_Framework.Enums.TabStyle.Style2;
            this.hTabControl4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.hTabControl4.TextPadding = new System.Windows.Forms.Padding(0);
            this.hTabControl4.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl4.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTabControl4.TextTrim = System.Drawing.StringTrimming.EllipsisCharacter;
            this.hTabControl4.UnSelectedBorderTabColor = System.Drawing.Color.Silver;
            this.hTabControl4.UnSelectedTabColor = System.Drawing.Color.Transparent;
            this.hTabControl4.UnselectedTextColor = System.Drawing.Color.Silver;
            this.hTabControl4.UseAnimation = false;
            // 
            // tabPage15
            // 
            this.tabPage15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage15.Controls.Add(this.hBarChart1);
            this.tabPage15.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage15.Location = new System.Drawing.Point(4, 32);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(676, 428);
            this.tabPage15.TabIndex = 0;
            this.tabPage15.Text = "Bar";
            // 
            // hBarChart1
            // 
            this.hBarChart1.BorderItems = true;
            this.hBarChart1.ItemsTextColor = System.Drawing.Color.DarkGray;
            this.hBarChart1.LegendColor = System.Drawing.Color.DarkGray;
            this.hBarChart1.LegendFont = new System.Drawing.Font("Arial", 10F);
            this.hBarChart1.LegendType = HeCopUI_Framework.Enums.LegendType.Right;
            this.hBarChart1.LineChart = System.Drawing.Color.Gray;
            this.hBarChart1.Location = new System.Drawing.Point(32, 33);
            this.hBarChart1.Name = "hBarChart1";
            this.hBarChart1.NumbericChartColor = System.Drawing.Color.DarkGray;
            this.hBarChart1.ShowTitle = true;
            this.hBarChart1.Size = new System.Drawing.Size(599, 371);
            this.hBarChart1.SortMode = HeCopUI_Framework.Enums.SortMode.None;
            this.hBarChart1.SpaceBetweenItems = 50;
            this.hBarChart1.TabIndex = 0;
            this.hBarChart1.Text = "hBarChart1";
            this.hBarChart1.TitleChartAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hBarChart1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hBarChart1.TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.hBarChart1.TitleText = "HBar Chart";
            this.hBarChart1.ToolTipFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hBarChart1.VisibleNumberOy = 10;
            // 
            // tabPage16
            // 
            this.tabPage16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage16.Controls.Add(this.hLineAreaChart1);
            this.tabPage16.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage16.Location = new System.Drawing.Point(4, 32);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(676, 428);
            this.tabPage16.TabIndex = 1;
            this.tabPage16.Text = "Line";
            // 
            // hLineAreaChart1
            // 
            this.hLineAreaChart1.ChartColor = System.Drawing.Color.Gray;
            this.hLineAreaChart1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hLineAreaChart1.GraphStyle = HeCopUI_Framework.Controls.Charts.HLineAreaChart.Style.Flat;
            this.hLineAreaChart1.GridColor = System.Drawing.Color.DimGray;
            this.hLineAreaChart1.Location = new System.Drawing.Point(32, 33);
            this.hLineAreaChart1.Name = "hLineAreaChart1";
            this.hLineAreaChart1.NumbericOfOxy = System.Drawing.Color.DarkGray;
            this.hLineAreaChart1.NumberOfOyVisible = 10;
            this.hLineAreaChart1.PointSize = 8;
            this.hLineAreaChart1.ShowAreas = true;
            this.hLineAreaChart1.ShowPoints = true;
            this.hLineAreaChart1.Size = new System.Drawing.Size(599, 371);
            this.hLineAreaChart1.SortMode = HeCopUI_Framework.Enums.SortMode.None;
            this.hLineAreaChart1.TabIndex = 0;
            this.hLineAreaChart1.Text = "hLineAreaChart1";
            this.hLineAreaChart1.TitleAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hLineAreaChart1.TitleFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            // 
            // tabPage17
            // 
            this.tabPage17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage17.Controls.Add(this.hPieChart1);
            this.tabPage17.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage17.Location = new System.Drawing.Point(4, 32);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage17.Size = new System.Drawing.Size(676, 428);
            this.tabPage17.TabIndex = 2;
            this.tabPage17.Text = "Pie";
            // 
            // hPieChart1
            // 
            this.hPieChart1.CircularColor = System.Drawing.Color.Salmon;
            this.hPieChart1.CircularWidth = 0;
            this.hPieChart1.LegendChart = HeCopUI_Framework.Enums.LegendType.Right;
            this.hPieChart1.LegendFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hPieChart1.LegendTextColor = System.Drawing.Color.DarkGray;
            this.hPieChart1.Location = new System.Drawing.Point(32, 33);
            this.hPieChart1.Name = "hPieChart1";
            this.hPieChart1.PieCharSize = 200;
            this.hPieChart1.SeriesValueFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hPieChart1.ShowValuesTip = true;
            this.hPieChart1.Size = new System.Drawing.Size(599, 371);
            this.hPieChart1.StartAngle = 0;
            this.hPieChart1.TabIndex = 0;
            this.hPieChart1.Text = "hPieChart1";
            this.hPieChart1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hPieChart1.ValueColor = System.Drawing.Color.White;
            this.hPieChart1.VisibleLegend = true;
            // 
            // tabPage18
            // 
            this.tabPage18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tabPage18.Controls.Add(this.hRadarChart1);
            this.tabPage18.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage18.Location = new System.Drawing.Point(4, 32);
            this.tabPage18.Name = "tabPage18";
            this.tabPage18.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage18.Size = new System.Drawing.Size(676, 428);
            this.tabPage18.TabIndex = 3;
            this.tabPage18.Text = "Radar";
            // 
            // hRadarChart1
            // 
            this.hRadarChart1.LegendColor = System.Drawing.Color.DarkGray;
            this.hRadarChart1.LegendFont = new System.Drawing.Font("Segoe UI", 10F);
            this.hRadarChart1.LegendType = HeCopUI_Framework.Enums.LegendType.Right;
            this.hRadarChart1.Location = new System.Drawing.Point(32, 33);
            this.hRadarChart1.MaxValue = 100;
            this.hRadarChart1.Name = "hRadarChart1";
            this.hRadarChart1.NumberVisible = true;
            this.hRadarChart1.PointSize = 8;
            this.hRadarChart1.RadarColor = System.Drawing.Color.Gray;
            series2.Color = System.Drawing.Color.OrangeRed;
            series2.Text = "serieName1";
            series2.Values = new float[] {
        90F,
        50F,
        70F,
        40F,
        60F};
            this.hRadarChart1.Series = new HeCopUI_Framework.Controls.Charts.Series[] {
        series2};
            this.hRadarChart1.ShowTitle = true;
            this.hRadarChart1.ShowValuesTip = false;
            this.hRadarChart1.Size = new System.Drawing.Size(599, 371);
            this.hRadarChart1.Step = 20;
            this.hRadarChart1.TabIndex = 0;
            this.hRadarChart1.Text = "hRadarChart1";
            this.hRadarChart1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.hRadarChart1.Title = "Radar Chart";
            this.hRadarChart1.TitleChartAlign = HeCopUI_Framework.Enums.TitleChartAlign.TopLeft;
            this.hRadarChart1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hRadarChart1.TitleFont = new System.Drawing.Font("Segoe UI", 12F);
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage6.Controls.Add(this.hTextBox3);
            this.tabPage6.Controls.Add(this.hCircleAnglePicker1);
            this.tabPage6.Controls.Add(this.hRadialRangeSlider1);
            this.tabPage6.Controls.Add(this.hSolidGauge1);
            this.tabPage6.Controls.Add(this.hDigitalGauge1);
            this.tabPage6.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage6.Location = new System.Drawing.Point(139, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(757, 546);
            this.tabPage6.TabIndex = 10;
            this.tabPage6.Text = "Gauge & Pickers";
            // 
            // hTextBox3
            // 
            this.hTextBox3.AcceptsReturn = true;
            this.hTextBox3.AcceptsTab = true;
            this.hTextBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.hTextBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.hTextBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hTextBox3.BorderFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(122)))));
            this.hTextBox3.BorderHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(162)))));
            this.hTextBox3.BorderThickness = 1;
            this.hTextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.hTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.hTextBox3.Image = null;
            this.hTextBox3.ImageOffsetX = 2;
            this.hTextBox3.ImageSize = new System.Drawing.Size(20, 20);
            this.hTextBox3.Location = new System.Drawing.Point(311, 175);
            this.hTextBox3.MaxLength = 32767;
            this.hTextBox3.Multiline = false;
            this.hTextBox3.Name = "hTextBox3";
            this.hTextBox3.Radius = 0;
            this.hTextBox3.ReadOnly = false;
            this.hTextBox3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.hTextBox3.ShortcutsEnabled = false;
            this.hTextBox3.ShowBottomBorder = true;
            this.hTextBox3.ShowTopBorder = true;
            this.hTextBox3.Size = new System.Drawing.Size(80, 28);
            this.hTextBox3.Style = HeCopUI_Framework.Controls.HTextBox.TextBoxStyle.Style2;
            this.hTextBox3.TabIndex = 5;
            this.hTextBox3.TexOffsetX = 2;
            this.hTextBox3.Text = "0";
            this.hTextBox3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.hTextBox3.TextBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hTextBox3.TextBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hTextBox3.TextColor = System.Drawing.Color.Silver;
            this.hTextBox3.UseAnimation = false;
            this.hTextBox3.UseSystemPasswordChar = false;
            this.hTextBox3.WatermarkColor = System.Drawing.Color.DarkGray;
            this.hTextBox3.WatermarkFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hTextBox3.WatermarkRendering = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hTextBox3.WatermarkText = "";
            // 
            // hCircleAnglePicker1
            // 
            this.hCircleAnglePicker1.AutoScroll = false;
            this.hCircleAnglePicker1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.hCircleAnglePicker1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.hCircleAnglePicker1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hCircleAnglePicker1.CircleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.hCircleAnglePicker1.CircleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hCircleAnglePicker1.CoreColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.hCircleAnglePicker1.CoreType = HeCopUI_Framework.Enums.CircleAnglePickerType.Ellipse;
            this.hCircleAnglePicker1.CoreWidth = 20;
            this.hCircleAnglePicker1.InnerCircle = true;
            this.hCircleAnglePicker1.InnerCircleColor = System.Drawing.Color.Gray;
            this.hCircleAnglePicker1.LineCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            this.hCircleAnglePicker1.LineColor = System.Drawing.Color.Gray;
            this.hCircleAnglePicker1.LineCut = 12;
            this.hCircleAnglePicker1.LineWidth = 2;
            this.hCircleAnglePicker1.Location = new System.Drawing.Point(287, 23);
            this.hCircleAnglePicker1.Name = "hCircleAnglePicker1";
            this.hCircleAnglePicker1.Size = new System.Drawing.Size(127, 127);
            this.hCircleAnglePicker1.TabIndex = 4;
            this.hCircleAnglePicker1.Text = "hCircleAnglePicker1";
            this.hCircleAnglePicker1.ValueChanged += new System.EventHandler(this.hCircleAnglePicker1_ValueChanged);
            // 
            // hRadialRangeSlider1
            // 
            this.hRadialRangeSlider1.BarColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.hRadialRangeSlider1.BarColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(68)))), ((int)(((byte)(48)))));
            this.hRadialRangeSlider1.BarThickness = 2;
            this.hRadialRangeSlider1.EndAngle = 265;
            this.hRadialRangeSlider1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hRadialRangeSlider1.Location = new System.Drawing.Point(43, 290);
            this.hRadialRangeSlider1.MaxValue = 100;
            this.hRadialRangeSlider1.MinValue = 0;
            this.hRadialRangeSlider1.Name = "hRadialRangeSlider1";
            this.hRadialRangeSlider1.Size = new System.Drawing.Size(136, 139);
            this.hRadialRangeSlider1.SlideColor1 = System.Drawing.Color.DarkSlateGray;
            this.hRadialRangeSlider1.SlideColor2 = System.Drawing.Color.SeaGreen;
            this.hRadialRangeSlider1.SliderScale = 90;
            this.hRadialRangeSlider1.SlideThickness = 4;
            this.hRadialRangeSlider1.StartAngle = 137;
            this.hRadialRangeSlider1.TabIndex = 2;
            this.hRadialRangeSlider1.Text = "hRadialRangeSlider1";
            this.hRadialRangeSlider1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.hRadialRangeSlider1.TextMode = HeCopUI_Framework.Controls.TextMode.FromValue1ToValue2;
            this.hRadialRangeSlider1.ThumbEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hRadialRangeSlider1.ThumbStartColor = System.Drawing.Color.Gray;
            this.hRadialRangeSlider1.Value1 = 30;
            this.hRadialRangeSlider1.Value2 = 80;
            // 
            // hSolidGauge1
            // 
            this.hSolidGauge1.BackColor = System.Drawing.Color.Transparent;
            this.hSolidGauge1.BaseGauge = System.Drawing.Color.Gainsboro;
            this.hSolidGauge1.CircularDiskColor = System.Drawing.Color.DimGray;
            this.hSolidGauge1.CircularDiskSizeType = HeCopUI_Framework.Controls.HSolidGauge.DiskSizeMode.Auto;
            this.hSolidGauge1.CircularSize = 20;
            this.hSolidGauge1.GaugeColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge1.GaugeColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge1.GaugeMode = HeCopUI_Framework.Controls.HSolidGauge.GaugeType.Gradient;
            this.hSolidGauge1.GaugeTextType = HeCopUI_Framework.Controls.HSolidGauge.TextType.Percentage;
            this.hSolidGauge1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.hSolidGauge1.Interval = 10;
            this.hSolidGauge1.Location = new System.Drawing.Point(28, 95);
            this.hSolidGauge1.MaximumValue = 100;
            this.hSolidGauge1.Name = "hSolidGauge1";
            this.hSolidGauge1.NeedleColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hSolidGauge1.NeedleHeight = HeCopUI_Framework.Controls.HSolidGauge.NeedleLongType.Auto;
            this.hSolidGauge1.NeedleLong = 50;
            this.hSolidGauge1.NeedleThickness = 2;
            this.hSolidGauge1.NeedleType = System.Drawing.Drawing2D.LineCap.Flat;
            this.hSolidGauge1.NumberOfOYVissible = 10;
            this.hSolidGauge1.ShapeType = System.Drawing.Drawing2D.LineCap.Round;
            this.hSolidGauge1.ShowMajor = true;
            this.hSolidGauge1.Size = new System.Drawing.Size(165, 165);
            this.hSolidGauge1.SolidGaugeWidth = 12;
            this.hSolidGauge1.TabIndex = 1;
            this.hSolidGauge1.Text = "hSolidGauge1";
            this.hSolidGauge1.TextRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hSolidGauge1.UseAnimation = false;
            this.hSolidGauge1.Value = 0;
            this.hSolidGauge1.ValueTextColor = System.Drawing.Color.White;
            // 
            // hDigitalGauge1
            // 
            this.hDigitalGauge1.BackColor = System.Drawing.Color.Transparent;
            this.hDigitalGauge1.BorderColor = System.Drawing.Color.DarkGray;
            this.hDigitalGauge1.BorderThickness = 2;
            this.hDigitalGauge1.GaugeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.hDigitalGauge1.Location = new System.Drawing.Point(43, 23);
            this.hDigitalGauge1.MaximumValue = 1000;
            this.hDigitalGauge1.MinimumValue = 0;
            this.hDigitalGauge1.Name = "hDigitalGauge1";
            this.hDigitalGauge1.NumberBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(30)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hDigitalGauge1.NumberColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hDigitalGauge1.NumberHeight = 20F;
            this.hDigitalGauge1.Radius = 5;
            this.hDigitalGauge1.Size = new System.Drawing.Size(119, 34);
            this.hDigitalGauge1.TabIndex = 0;
            this.hDigitalGauge1.Text = "hDigitalGauge1";
            this.hDigitalGauge1.Value = 0;
            // 
            // tabPage19
            // 
            this.tabPage19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage19.Controls.Add(this.hClockDigital1);
            this.tabPage19.Controls.Add(this.hClockCircular1);
            this.tabPage19.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage19.Location = new System.Drawing.Point(139, 4);
            this.tabPage19.Name = "tabPage19";
            this.tabPage19.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage19.Size = new System.Drawing.Size(757, 546);
            this.tabPage19.TabIndex = 11;
            this.tabPage19.Text = "Clock";
            // 
            // hClockDigital1
            // 
            this.hClockDigital1.BackColor = System.Drawing.Color.Transparent;
            this.hClockDigital1.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.hClockDigital1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hClockDigital1.Interval = 1000;
            this.hClockDigital1.Location = new System.Drawing.Point(235, 256);
            this.hClockDigital1.Name = "hClockDigital1";
            this.hClockDigital1.ShowMillisecond = false;
            this.hClockDigital1.Size = new System.Drawing.Size(263, 107);
            this.hClockDigital1.TabIndex = 1;
            this.hClockDigital1.Text = "hClockDigital1";
            this.hClockDigital1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // hClockCircular1
            // 
            this.hClockCircular1.Draw1MinuteTicks = true;
            this.hClockCircular1.Draw5MinuteTicks = true;
            this.hClockCircular1.HourHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hClockCircular1.Interval = 1000;
            this.hClockCircular1.Location = new System.Drawing.Point(263, 57);
            this.hClockCircular1.MinuteHandColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(86)))), ((int)(((byte)(189)))));
            this.hClockCircular1.Name = "hClockCircular1";
            this.hClockCircular1.SecondHandColor = System.Drawing.Color.RoyalBlue;
            this.hClockCircular1.Size = new System.Drawing.Size(193, 193);
            this.hClockCircular1.TabIndex = 0;
            this.hClockCircular1.TicksColor = System.Drawing.Color.Gray;
            // 
            // tabPage22
            // 
            this.tabPage22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage22.Controls.Add(this.hListView1);
            this.tabPage22.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage22.Location = new System.Drawing.Point(139, 4);
            this.tabPage22.Name = "tabPage22";
            this.tabPage22.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage22.Size = new System.Drawing.Size(757, 546);
            this.tabPage22.TabIndex = 14;
            this.tabPage22.Text = "ListView & TreeView";
            // 
            // hListView1
            // 
            this.hListView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.hListView1.AllowColumnReorder = true;
            this.hListView1.AutoSizeTable = false;
            this.hListView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hListView1.BorderBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hListView1.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hListView1.CheckBoxes = true;
            this.hListView1.CheckMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.hListView1.Depth = 0;
            this.hListView1.DividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(142)))));
            this.hListView1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hListView1.HeaderFont = new System.Drawing.Font("Segoe UI", 12F);
            this.hListView1.HeaderTextColor = System.Drawing.Color.Silver;
            this.hListView1.HideSelection = false;
            this.hListView1.ItemColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.hListView1.ItemFont = new System.Drawing.Font("Segoe UI", 12F);
            this.hListView1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            listViewItem4.StateImageIndex = 0;
            listViewItem5.StateImageIndex = 0;
            listViewItem6.StateImageIndex = 0;
            this.hListView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.hListView1.ItemSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hListView1.ItemTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(128)))));
            this.hListView1.ItemTextHoverColor = System.Drawing.Color.WhiteSmoke;
            this.hListView1.ItemTextSelectedColor = System.Drawing.Color.White;
            this.hListView1.Location = new System.Drawing.Point(21, 51);
            this.hListView1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.hListView1.Name = "hListView1";
            this.hListView1.OwnerDraw = true;
            this.hListView1.Size = new System.Drawing.Size(720, 138);
            this.hListView1.TabIndex = 0;
            this.hListView1.UseCompatibleStateImageBehavior = false;
            this.hListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Column Header 1";
            this.columnHeader1.Width = 222;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Column Header 2";
            this.columnHeader2.Width = 231;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Column Header 3";
            this.columnHeader3.Width = 264;
            // 
            // tabPage20
            // 
            this.tabPage20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tabPage20.Controls.Add(this.hDotRing1);
            this.tabPage20.Controls.Add(this.hProgressRing1);
            this.tabPage20.Controls.Add(this.linearParticleAnimation1);
            this.tabPage20.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabPage20.Location = new System.Drawing.Point(139, 4);
            this.tabPage20.Name = "tabPage20";
            this.tabPage20.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage20.Size = new System.Drawing.Size(757, 546);
            this.tabPage20.TabIndex = 16;
            this.tabPage20.Text = "Loading";
            // 
            // hDotRing1
            // 
            this.hDotRing1.Location = new System.Drawing.Point(166, 336);
            this.hDotRing1.Name = "hDotRing1";
            this.hDotRing1.Size = new System.Drawing.Size(172, 145);
            this.hDotRing1.TabIndex = 4;
            this.hDotRing1.Text = "hDotRing1";
            // 
            // hProgressRing1
            // 
            this.hProgressRing1.Angle = -90;
            this.hProgressRing1.Duration = 50;
            this.hProgressRing1.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.hProgressRing1.ForegroundColor1 = System.Drawing.Color.DarkSlateBlue;
            this.hProgressRing1.ForegroundColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(168)))), ((int)(((byte)(148)))));
            this.hProgressRing1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.hProgressRing1.Location = new System.Drawing.Point(440, 284);
            this.hProgressRing1.Name = "hProgressRing1";
            this.hProgressRing1.ScaleFactory = 100;
            this.hProgressRing1.Size = new System.Drawing.Size(177, 166);
            this.hProgressRing1.Speed = 1.5D;
            this.hProgressRing1.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.hProgressRing1.StepIncrement = 10;
            this.hProgressRing1.TabIndex = 3;
            this.hProgressRing1.Text = "hProgressRing1";
            this.hProgressRing1.Thickness = 5;
            // 
            // linearParticleAnimation1
            // 
            this.linearParticleAnimation1.Location = new System.Drawing.Point(66, 30);
            this.linearParticleAnimation1.Name = "linearParticleAnimation1";
            this.linearParticleAnimation1.Size = new System.Drawing.Size(353, 204);
            this.linearParticleAnimation1.TabIndex = 2;
            this.linearParticleAnimation1.Text = "linearParticleAnimation1";
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(902, 597);
            this.Controls.Add(this.hTabControl1);
            this.ForeColor = System.Drawing.Color.Coral;
            this.FormControlBox.CloseBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.CloseBoxHoverColor = System.Drawing.Color.Red;
            this.FormControlBox.HoverColorShape = HeCopUI_Framework.Enums.ShapeType.Rectangle;
            this.FormControlBox.IconCloseColor = System.Drawing.Color.WhiteSmoke;
            this.FormControlBox.IconCloseHoverColor = System.Drawing.Color.White;
            this.FormControlBox.IconMaximizeColor = System.Drawing.Color.WhiteSmoke;
            this.FormControlBox.IconMaximizeHoverColor = System.Drawing.Color.White;
            this.FormControlBox.IconMinimizeColor = System.Drawing.Color.WhiteSmoke;
            this.FormControlBox.IconMinimizeHoverColor = System.Drawing.Color.White;
            this.FormControlBox.MaximizeBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.MaximizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FormControlBox.MinimizeBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.FormControlBox.MinimizeBoxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1, 42, 1, 1);
            this.Resizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hecop UI Framework";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.TitleTextColor = System.Drawing.Color.DarkGray;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.hTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage21.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.hTabControl3.ResumeLayout(false);
            this.hTabControl2.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.hTabControl4.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.tabPage16.ResumeLayout(false);
            this.tabPage17.ResumeLayout(false);
            this.tabPage18.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage19.ResumeLayout(false);
            this.tabPage22.ResumeLayout(false);
            this.tabPage20.ResumeLayout(false);
            this.ResumeLayout(false);

        }








        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.ToolTip toolTip1;
        private HTabControl hTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private HLabel hLabel1;
        private HLabel hLabel2;
        private System.Windows.Forms.Panel panel1;
        private HLabel hLabel6;
        private HLabel hLabel5;
        private HLabel hLabel4;
        private HLabel hLabel3;
        private HLabel hLabel7;
        private HLabel hLabel8;
        private HLabel hLabel9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private HLabel hLabel10;
        private HButton hButton1;
        private HButton hButton2;
        private HButton hButton3;
        private HButton hButton4;
        private HButton hButton5;
        private HButton hButton6;
        private HTitleSubButton hTitleSubButton1;
        private HTitleButton hTitleButton1;
        private HButton hButton7;
        private HButton hButton8;
        private HButton hButton9;
        private HTitleButton hTitleButton2;
        private HTitleButton hTitleButton3;
        private HTitleButton hTitleButton4;
        private HTitleButton hTitleButton5;
        private HTitleButton hTitleButton6;
        private HTitleButton hTitleButton7;
        private HTitleButton hTitleButton8;
        private HTitleButton hTitleButton9;
        private HTitleSubButton hTitleSubButton3;
        private HTitleSubButton hTitleSubButton2;
        private HTitleSubButton hTitleSubButton4;
        private HTitleSubButton hTitleSubButton5;
        private HTitleSubButton hTitleSubButton6;
        private HTitleSubButton hTitleSubButton7;
        private HTitleSubButton hTitleSubButton8;
        private HTitleSubButton hTitleSubButton9;
        private HCheckBox hCheckBox1;
        private HToggleButton2 hToggleButton21;
        private HToggleButton1 hToggleButton11;
        private HToggleButton hToggleButton1;
        private HRadioButton hRadioButton1;
        private HCheckBox hCheckBox3;
        private HCheckBox hCheckBox2;
        private HRadioButton hRadioButton3;
        private HRadioButton hRadioButton2;
        private HDotProgressRing hDotProgressRing1;
        private HDotProgressRing hDotProgressRing6;
        private HDotProgressRing hDotProgressRing5;
        private HDotProgressRing hDotProgressRing4;
        private HDotProgressRing hDotProgressRing3;
        private HDotProgressRing hDotProgressRing2;
        private System.Windows.Forms.TabPage tabPage7;
        private HScrollBar hScrollBar1;
        private HScrollBar hScrollBar3;
        private HScrollBar hScrollBar4;
        private HScrollBar hScrollBar2;
        private HProgressBarWaterWave hProgressBarWaterWave1;
        private WaveProgressLoading waveProgressLoading1;
        private HProgressBar hProgressBar1;
        private HCircularProgressBar2 hCircularProgressBar21;
        private HCircularProgressBar1 hCircularProgressBar11;
        private HCircularProgressBar hCircularProgressBar1;
        private HCircularProgressBar hCircularProgressBar2;
        private HProgressBar hProgressBar3;
        private HProgressBar hProgressBar2;
        private HButton hButton10;
        private HProgressBar hProgressBar4;
        private HProgressBar hProgressBar5;
        private HProgressBar hProgressBar6;
        private System.Windows.Forms.TabPage tabPage8;
        private HPanel HPanel1;
        private TabPage tabPage9;
        private HTabControl hTabControl2;
        private TabPage tabPage10;
        private TabPage tabPage11;
        private HTabControl hTabControl3;
        private TabPage tabPage12;
        private TabPage tabPage13;
        private TabPage tabPage14;
        private HTabControl hTabControl4;
        private TabPage tabPage15;
        private TabPage tabPage16;
        private HeCopUI_Framework.Controls.Charts.HBarChart hBarChart1;
        private HeCopUI_Framework.Controls.Charts.HLineAreaChart hLineAreaChart1;
        private TabPage tabPage17;
        private HeCopUI_Framework.Controls.Charts.HPieChart hPieChart1;
        private TabPage tabPage18;
        private HeCopUI_Framework.Controls.Charts.HRadarChart hRadarChart1;
        private TabPage tabPage6;
        private HSolidGauge hSolidGauge1;
        private HDigitalGauge hDigitalGauge1;
        private TabPage tabPage19;
        private HClockDigital hClockDigital1;
        private HClockCircular hClockCircular1;
        private TabPage tabPage21;
        private HTextBox hTextBox1;
        private HRichTextBox hRichTextBox1;
        private HTextBox hTextBox2;
        private HRichTextBox hRichTextBox2;
        private TabPage tabPage22;
        private HListView hListView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private HRadialRangeSlider hRadialRangeSlider1;
        private HTextBox hTextBox3;
        private HCircleAnglePicker hCircleAnglePicker1;
        private TabPage tabPage5;
        private HDotProgressRing hDotProgressRing7;
        private HImage hImage1;
        private HeCopUI_Framework.Controls.Effect.HEffectImage hEffectImage1;
        private TabPage tabPage20;
        private HeCopUI_Framework.Controls. Progress.LinearParticleAnimation linearParticleAnimation1;
        private HeCopUI_Framework.Controls.Progress.HProgressRing hProgressRing1;
        private HeCopUI_Framework.Controls.Progress.HDotRing hDotRing1;
    }
}

