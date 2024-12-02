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
            location = new Point(0, 0);
            this.radius = radius;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            grPath = new GraphicsPath();
            if (radius <= 0f)
            {
                grPath.AddRectangle(new RectangleF(x, y, width, height));
            }
            else
            {
                RectangleF ef = new RectangleF(x, y, 2f * radius, 2f * radius);
                RectangleF ef2 = new RectangleF((width - (2f * radius)) - 1f, x, 2f * radius, 2f * radius);
                RectangleF ef3 = new RectangleF(x, (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);
                RectangleF ef4 = new RectangleF((width - (2f * radius)) - 1f,
                    (height - (2f * radius)) - 1f, 2f * radius, 2f * radius);

                grPath.AddArc(ef, 180f, 90f);
                grPath.AddArc(ef2, 270f, 90f);
                grPath.AddArc(ef4, 0f, 90f);
                grPath.AddArc(ef3, 90f, 90f);
                grPath.CloseAllFigures();
            }
        }

        public GraphicsPath Path =>
            grPath;

        public RectangleF Rect =>
            new RectangleF(x, y, width, height);

        public float Radius
        {
            get =>
                radius;
            set
            {
                radius = value; Invalidate();
            }
        }

        public HToggleButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);

            artis = 4f;


            diameter = 30f;

            DoubleBuffered = true;



            MyRectangle(2f * diameter, diameter + 2f, diameter / 2f, 1f, 1f);
            circle = new RectangleF(1f, 1f, diameter, diameter);

            painTicker = new Timer();
            painTicker.Tick += new EventHandler(paintTicker_Tick);
            painTicker.Interval = 10;



        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            painTicker.Start();
            base.OnInvalidated(e);
        }



        protected override void OnCreateControl()
        {
            painTicker.Start();
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
            Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
            e.Graphics.TextRenderingHint = TextRenderHint;
            Pen pen;
            using (SolidBrush brush = new SolidBrush(isON ? OnCol : OffCol))
            {
                e.Graphics.FillPath(brush, Path);
            }
            using (pen = new Pen(borderColor, 2f))
            {
                e.Graphics.DrawPath(pen, Path);
            }
            if (textEnabled)
            {
                using (Font font = new Font(Font.Name, (8.2f * diameter) / 30f))
                {
                    SolidBrush b = new SolidBrush(statusColor);
                    int height = TextRenderer.MeasureText(OnTex, font).Height;
                    float num2 = (diameter - height) / 2f;
                    e.Graphics.DrawString(OnTex, font, b, 5f, num2 + 1f);
                    height = TextRenderer.MeasureText(OffTex, font).Height;
                    num2 = (diameter - height) / 2f;
                    e.Graphics.DrawString(OffTex, font, b, diameter + 2f, num2 + 1f);
                }
                using (SolidBrush brush2 = new SolidBrush(LC))
                {
                    e.Graphics.FillEllipse(brush2, circle);
                }
                using (pen = new Pen(Color.LightGray, 1.2f))
                {
                    e.Graphics.DrawEllipse(pen, circle);
                }
            }
            else
            {
                using (SolidBrush brush3 = new SolidBrush(isON ? OnCol : OffCol))
                {
                    using (SolidBrush brush4 = new SolidBrush(LC))
                    {
                        e.Graphics.FillPath(brush3, Path);
                        e.Graphics.FillEllipse(brush4, circle);
                        e.Graphics.DrawEllipse(Pens.DarkGray, circle);
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
            diameter = base.Width / 2;
            artis = (4f * diameter) * 30f;
            MyRectangle(2f * diameter, diameter + 2f, diameter / 2f, 1f, 1f);
            circle = new RectangleF(!isON ? 1f : ((base.Width - diameter) - 1f), 1f, diameter, diameter);
            Invalidate();
            base.OnResize(e);
        }

        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = circle.X;
            if (isON)
            {
                if ((x + artis) <= ((base.Width - diameter) - 1f))
                {
                    x += artis;
                    circle = new RectangleF(x, 1f, diameter, diameter);
                    Invalidate();
                }
                else
                {
                    x = (base.Width - diameter) - 1f;
                    circle = new RectangleF(x, 1f, diameter, diameter);
                    Invalidate();
                    painTicker.Stop();
                }
            }
            else if ((x - artis) >= 1f)
            {
                x -= artis;
                circle = new RectangleF(x, 1f, diameter, diameter); Invalidate();
            }
            else
            {
                x = 1f;
                circle = new RectangleF(x, 1f, diameter, diameter);
                Invalidate();
                painTicker.Stop();
            }
            Invalidate();
        }

        public bool TextEnabled
        {
            get =>
                textEnabled;
            set
            {
                textEnabled = value;
                base.Invalidate();
            }
        }

        public bool IsOn
        {
            get =>
                isON;
            set
            {
                painTicker.Stop();
                isON = value;
                painTicker.Start();
                if (SliderValueChanged != null)
                {
                    SliderValueChanged(this, EventArgs.Empty);
                }

                Invalidate();
            }
        }

        public Color BorderColor
        {
            get =>
                borderColor;
            set
            {
                borderColor = value;
                base.Invalidate();
            }
        }

        protected override Size DefaultSize
            => new Size(60, 35);
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);


        public string OnText
        {
            get =>
                OnTex;
            set
            {
                OnTex = value;
                base.Invalidate();
            }
        }
        public string OffText
        {
            get =>
                OffTex;
            set
            {
                OffTex = value;
                base.Invalidate();
            }
        }

        public Color OnColor
        {
            get =>
                OnCol;
            set
            {
                OnCol = value;
                base.Invalidate();
            }
        }

        public Color OffColor
        {
            get =>
                OffCol;
            set
            {
                OffCol = value;
                base.Invalidate();
            }
        }
    }
}
