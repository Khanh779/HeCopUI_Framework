using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class hColorPicker : UserControl
    {
        public hColorPicker()
        {
            InitializeComponent();

            hhTrackBar11.ValueChanged += HColorPicker_ValueChanged;
            hhTrackBar12.ValueChanged += HColorPicker_ValueChanged;
            hhTrackBar13.ValueChanged += HColorPicker_ValueChanged;
            Size = MaximumSize = MinimumSize = FixedSize;
            hTextBox1.Text = hhTrackBar11.Value.ToString();
            hTextBox2.Text = hhTrackBar12.Value.ToString();
            hTextBox3.Text = hhTrackBar13.Value.ToString();
        }

        Size FixedSize = new Size(327, 325);

        protected override void OnPaint(PaintEventArgs e)
        {
            GetAppResources.GetControlGraphicsEffect(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1), ClientRectangle);
            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            Size = MaximumSize = MinimumSize = FixedSize;
            base.OnSizeChanged(e);
        }

        private void HColorPicker_ValueChanged(object sender, EventArgs e)
        {

            hTextBox1.Text = hhTrackBar11.Value.ToString();
            hTextBox2.Text = hhTrackBar12.Value.ToString();
            hTextBox3.Text = hhTrackBar13.Value.ToString();
            HPanel4.PanelColor1 = HPanel4.PanelColor2 = Color.FromArgb(255, hhTrackBar11.Value, hhTrackBar12.Value, hhTrackBar13.Value);
            TB_HtmlCode.Text = ColorTranslator.ToHtml(HPanel4.PanelColor1);
        }


    }
}
