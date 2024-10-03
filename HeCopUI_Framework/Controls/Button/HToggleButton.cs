using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class HToggleButton : Control
    {
        private float diameter = 0;
        private RectangleF circle = new RectangleF(0, 0, 0, 0);
        private bool isON = false;
        private float artis = 0;
        private Color borderColor = Color.LightGray;
        private bool textEnabled = true;
        private string OnTex = "On";
        private string OffTex = "Off";
        private Color OnCol = HeCopUI_Framework.Global.PrimaryColors.OnToggleButtonColor;
        private Color OffCol = HeCopUI_Framework.Global.PrimaryColors.OffToggleButtonColor;
        private Timer painTicker = new Timer();
        public event SliderChangedEventHandler SliderValueChanged;
        private Point location = new Point(0, 0);
        private float radius = 20;
        private GraphicsPath grPath = new GraphicsPath();
        private float x = 0;
        private float y = 0;
        private float width = 0;
        private float height = 0;
        private Color LC = HeCopUI_Framework.Global.PrimaryColors.LeverToggleButtonColor;



        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            Invalidate();
            base.OnFontChanged(e);
        }

        protected override void OnForeColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnForeColorChanged(e);
        }
        public void MyRectangle(float width, float height, float radius, float x = 0f, float y = 0f)
        {
            this.location = new Point(0, 0);
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.grPath = new GraphicsPath();
            if (radius <= 0f)
            {
                this.grPath.AddRectangle(new RectangleF(x, y, width, height));
            }
            else
            {
                RectangleF ef = new RectangleF(x, y, 2f * radius, 2f * radius);
                RectangleF ef2 = new RectangleF((width - (2f * radius)) - 1f, x, 2f * radius, 2f * radius);
                RectangleF ef3 = new RectangleF(x, (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);
                RectangleF ef4 = new RectangleF((width - (2f * radius)) - 1f,
                    (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);

                this.grPath.AddArc(ef, 180f, 90f);
                this.grPath.AddArc(ef2, 270f, 90f);
                this.grPath.AddArc(ef4, 0f, 90f);
                this.grPath.AddArc(ef3, 90f, 90f);
                this.grPath.CloseAllFigures();
            }
        }

        public GraphicsPath Path =>
            this.grPath;

        public RectangleF Rect =>
            new RectangleF(this.x, this.y, this.width, this.height);

        public float Radius
        {
            get =>
                this.radius;
            set
            {
                this.radius = value; Invalidate();
            }
        }

        public HToggleButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);

            this.artis = 4f;


            this.diameter = 30f;

            this.DoubleBuffered = true;



            MyRectangle(2f * this.diameter, this.diameter + 2f, this.diameter / 2f, 1f, 1f);
            this.circle = new RectangleF(1f, 1f, this.diameter, this.diameter);

            painTicker = new Timer();
            this.painTicker.Tick += new EventHandler(this.paintTicker_Tick);
            this.painTicker.Interval = 10;



        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            this.painTicker.Start();
            base.OnInvalidated(e);
        }



        protected override void OnCreateControl()
        {
            this.painTicker.Start();
            base.OnCreateControl();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }

        Color statusColor = Color.White;
        public Color StatusColor
        {
            get { return statusColor; }
            set
            {
                statusColor = value; Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                IsOn = !IsOn;
                // IsOn = isON;
                //base.OnMouseClick(e);
            }

            base.OnMouseClick(e);
            Invalidate();
        }


        private System.Drawing.Text.TextRenderingHint textRenderHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value; Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GetAppResources.GetControlGraphicsEffect(e.Graphics);
            e.Graphics.TextRenderingHint = TextRenderHint;
            Pen pen;
            using (SolidBrush brush = new SolidBrush(this.isON ? this.OnCol : this.OffCol))
            {
                e.Graphics.FillPath((Brush)brush, Path);
            }
            using (pen = new Pen(this.borderColor, 2f))
            {
                e.Graphics.DrawPath(pen, this.Path);
            }
            if (this.textEnabled)
            {
                using (Font font = new Font(Font.Name, (8.2f * this.diameter) / 30f))
                {
                    SolidBrush b = new SolidBrush(statusColor);
                    int height = TextRenderer.MeasureText(this.OnTex, font).Height;
                    float num2 = (this.diameter - height) / 2f;
                    e.Graphics.DrawString(this.OnTex, font, b, 5f, num2 + 1f);
                    height = TextRenderer.MeasureText(this.OffTex, font).Height;
                    num2 = (this.diameter - height) / 2f;
                    e.Graphics.DrawString(this.OffTex, font, b, this.diameter + 2f, num2 + 1f);
                }
                using (SolidBrush brush2 = new SolidBrush(LC))
                {
                    e.Graphics.FillEllipse((Brush)brush2, this.circle);
                }
                using (pen = new Pen(Color.LightGray, 1.2f))
                {
                    e.Graphics.DrawEllipse(pen, this.circle);
                }
            }
            else
            {
                using (SolidBrush brush3 = new SolidBrush(this.isON ? this.OnCol : this.OffCol))
                {
                    using (SolidBrush brush4 = new SolidBrush(LC))
                    {
                        e.Graphics.FillPath((Brush)brush3, Path);
                        e.Graphics.FillEllipse((Brush)brush4, this.circle);
                        e.Graphics.DrawEllipse(Pens.DarkGray, this.circle);
                    }
                }
            }
            base.OnPaint(e);
        }


        private Color BordLC = Color.DarkGray;
        public Color BorderLeverColor
        {
            get { return BordLC; }
            set
            {
                BordLC = value; Invalidate();
            }
        }

        public Color LeverColor
        {
            get { return LC; }
            set
            {
                LC = value; Invalidate();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.Width = (base.Height - 2) * 2;
            this.diameter = base.Width / 2;
            this.artis = (4f * this.diameter) * 30f;
            MyRectangle(2f * this.diameter, this.diameter + 2f, this.diameter / 2f, 1f, 1f);
            this.circle = new RectangleF(!this.isON ? 1f : ((base.Width - this.diameter) - 1f), 1f, this.diameter, this.diameter);
            Invalidate();
            base.OnResize(e);
        }

        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = this.circle.X;
            if (this.isON)
            {
                if ((x + this.artis) <= ((base.Width - this.diameter) - 1f))
                {
                    x += this.artis;
                    this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                    Invalidate();
                }
                else
                {
                    x = (base.Width - this.diameter) - 1f;
                    this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                    Invalidate();
                    this.painTicker.Stop();
                }
            }
            else if ((x - this.artis) >= 1f)
            {
                x -= this.artis;
                this.circle = new RectangleF(x, 1f, this.diameter, this.diameter); Invalidate();
            }
            else
            {
                x = 1f;
                this.circle = new RectangleF(x, 1f, this.diameter, this.diameter);
                Invalidate();
                this.painTicker.Stop();
            }
            Invalidate();
        }

        public bool TextEnabled
        {
            get =>
                this.textEnabled;
            set
            {
                this.textEnabled = value;
                base.Invalidate();
            }
        }

        public bool IsOn
        {
            get =>
                this.isON;
            set
            {
                this.painTicker.Stop();
                this.isON = value;
                this.painTicker.Start();
                if (this.SliderValueChanged != null)
                {
                    this.SliderValueChanged(this, EventArgs.Empty);
                }

                Invalidate();
            }
        }

        public Color BorderColor
        {
            get =>
                this.borderColor;
            set
            {
                this.borderColor = value;
                base.Invalidate();
            }
        }

        protected override Size DefaultSize
            => new Size(60, 35);
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);


        public string OnText
        {
            get =>
                this.OnTex;
            set
            {
                this.OnTex = value;
                base.Invalidate();
            }
        }
        public string OffText
        {
            get =>
                this.OffTex;
            set
            {
                this.OffTex = value;
                base.Invalidate();
            }
        }

        public Color OnColor
        {
            get =>
                this.OnCol;
            set
            {
                this.OnCol = value;
                base.Invalidate();
            }
        }

        public Color OffColor
        {
            get =>
                this.OffCol;
            set
            {
                this.OffCol = value;
                base.Invalidate();
            }
        }
    }
}
