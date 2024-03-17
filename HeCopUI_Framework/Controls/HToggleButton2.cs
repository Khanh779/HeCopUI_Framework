using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class HToggleButton2 : Control
    {
        public HToggleButton2()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            MinimumSize = new Size(47, 22);
            Padding = new Padding(5);
            BackColor = Color.Transparent;
            Paint += HToggleButton2_Paint;
            AutoSize = false;
            MouseClick += HToggleButton2_MouseClick;
        }

        private void HToggleButton2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Checked == true)
                {
                    ValueChecked = false;
                }
                else ValueChecked = true;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetStandardSize();
            base.OnSizeChanged(e);
        }
        protected override void OnCreateControl()
        {
            Invalidate();
            base.OnCreateControl();
        }

        private void SetStandardSize()
        {
            Size = new Size(Width, Width / 2);
        }

        private void HToggleButton2_Paint(object sender, PaintEventArgs e)
        {
            this.OnPaintBackground(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (var path = new GraphicsPath())
            {
                var d = Padding.All;
                var r = this.Height - 2 * d;
                path.AddArc(d, d, r, r, 90, 180);
                path.AddArc(this.Width - r - d, d, r, r, -90, 180);
                path.CloseFigure();
                e.Graphics.FillPath(Checked ? new SolidBrush(onColor) : new SolidBrush(offColor), path);
                Pen pens = new Pen(new SolidBrush(LeverCo), SlBor);
                e.Graphics.DrawPath(pens, path);
                r = Height - 1;
                var rect = Checked ? new Rectangle(Width - r - 1, 0, r, r)
                                   : new Rectangle(0, 0, r, r);
                e.Graphics.FillEllipse(Checked ? new SolidBrush(onSlieColor) : new SolidBrush(offSlieColor), rect);
                Pen pen = new Pen(LeverCo, Bo);
                e.Graphics.DrawEllipse(pen, rect);
            }
        }

        private bool Checked = true;
        public bool ValueChecked
        {
            get { return Checked; }
            set
            {
                Checked = value; Invalidate();
            }
        }

        private float SlBor = 1;
        public float SliderWidth
        {
            get { return SlBor; }
            set
            {
                SlBor = value; Invalidate();
            }
        }

        private float Bo = 1;
        public float BorderWidth
        {
            get { return Bo; }
            set
            {
                Bo = value; Invalidate();
            }
        }

        private Color LeverCo = Color.Gray;
        public Color BorderColor
        {
            get { return LeverCo; }
            set
            {
                LeverCo = value; Invalidate();
            }

        }

        private Color onSlieColor = Color.LightGray;
        public Color OnLeverColor
        {
            get { return onSlieColor; }
            set
            {
                onSlieColor = value; Invalidate();
            }

        }
        private Color offSlieColor = Color.LightGray;
        public Color OffLeverColor
        {
            get { return offSlieColor; }
            set
            {
                offSlieColor = value; Invalidate();
            }

        }

        private Color onColor = HeCopUI_Framework.Global.PrimaryColors.OnToggleButtonColor;
        public Color OnColor
        {
            get { return onColor; }
            set
            {
                onColor = value; Invalidate();
            }

        }

        private Color offColor = HeCopUI_Framework.Global.PrimaryColors.OffToggleButtonColor;
        public Color OffColor
        {
            get { return offColor; }
            set
            {
                offColor = value; Invalidate();
            }

        }

    }
}
