using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing.Text;

namespace HeCopUI_Framework.Controls.Bubble
{
    public class HWaterDropControl : Control
    {
        private Timer timer;
        private float waveOffset = 0;

        public HWaterDropControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            timer = new Timer();
            timer.Interval = 30; // Update interval
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            waveOffset += (clockWise ? -1 : 1) * WaveOffset;
            switch (clockWise)
            {
                case true:
                    if (waveOffset < Math.PI * 2) waveOffset = 360;
                    break;
                case false:
                    if (waveOffset > Math.PI * 2) waveOffset = 0;
                    break;
            }
            this.Invalidate();
        }

        /// <summary>
        /// Gets or sets wave offset.
        /// </summary>
        public float WaveOffset { get; set; } = 0.05f;

        bool clockWise = true;
        /// <summary>
        /// Gets or sets clock wise.
        /// </summary>
        public bool ClockWise
        {
            get { return clockWise; }
            set
            {
                clockWise = value;
                this.Invalidate();
            }
        }

        Color borderColor1 = Color.FromArgb(50, Color.DodgerBlue);
        /// <summary>
        /// Gets or sets border color 1.
        /// </summary>
        public Color BorderColor1
        {
            get { return borderColor1; }
            set
            {
                borderColor1 = value;
                this.Invalidate();
            }
        }

        Color borderColor2 = Color.FromArgb(0, 168, 148);
        /// <summary>
        /// Gets or sets border color 2.
        /// </summary>
        public Color BorderColor2
        {
            get { return borderColor2; }
            set
            {
                borderColor2 = value;
                this.Invalidate();
            }
        }

        Color bubbleColor1 = Color.FromArgb(80, Color.DodgerBlue);
        /// <summary>
        /// Gets or sets bubble color 1.
        /// </summary>
        public Color BubbleColor1
        {
            get { return bubbleColor1; }
            set
            {
                bubbleColor1 = value;
                this.Invalidate();
            }
        }

        Color bubbleColor2 = Color.FromArgb(40, 0, 168, 148);
        /// <summary>
        /// Gets or sets bubble color 2.
        /// </summary>
        public Color BubbleColor2
        {
            get { return bubbleColor2; }
            set
            {
                bubbleColor2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets wave count.
        /// </summary>
        public int WaveCount { get; set; } = 4;

        /// <summary>
        /// Gets or sets wave rate.
        /// </summary>
        public int WaveRate { get; set; } = 3;

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        public Color TextColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets text font.
        /// </summary>
        public Font TextFont { get; set; } = new Font("Arial", 20);

        /// <summary>
        /// Gets or sets progress value type.
        /// </summary>
        public Enums.ProgressValueType ProgressValueType { get; set; } = Enums.ProgressValueType.Percentage;

        private TextRenderingHint textRenderHint { get; set; } = TextRenderingHint.AntiAlias;
        /// <summary>
        /// Gets or sets text render hint.
        /// </summary>
        public TextRenderingHint TextRenderHint
        {
            get { return textRenderHint; }
            set
            {
                textRenderHint = value;
                this.Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets border thickness.
        /// </summary>
        public int BorderThickness { get; set; } = 1;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderHint;


            float centerX = this.Width / 2;
            float centerY = this.Height / 2;
            float radius = Math.Min(this.Width, this.Height) / 2 - 10;

            PointF[] points = new PointF[100];
            for (int i = 0; i < points.Length; i++)
            {
                float angle = i * (360f / points.Length) * (float)Math.PI / 180f;
                // Điều chỉnh sóng mượt hơn và biên độ nhỏ lại
                float wave = (float)Math.Sin(angle * WaveCount + waveOffset) * WaveRate; // Tần số và biên độ giảm
                points[i] = new PointF(
                    centerX + (float)Math.Cos(angle) * (radius + wave),
                    centerY + (float)Math.Sin(angle) * (radius + wave)
                );
            }



            PathGradientBrush brush = new PathGradientBrush(points);
            //brush.CenterColor = Color.Transparent;
            //brush.SurroundColors = new Color[] { Color.FromArgb(60, bubbleColor1), Color.FromArgb(60, bubbleColor2)};
            brush.InterpolationColors = new ColorBlend(3)
            {
                Colors = new Color[] { bubbleColor1, bubbleColor2, Color.Transparent },
                Positions = new float[] { 0, 0.5f, 1 }
            };

            g.FillPolygon(brush, points);
            brush.Dispose();

            using (LinearGradientBrush linearBrush = new LinearGradientBrush(ClientRectangle, borderColor1, borderColor2, LinearGradientMode.Horizontal))
            using (Pen pen = new Pen(linearBrush, BorderThickness))
            {
                g.DrawPolygon(pen, points);
            }


            // Draw text
            if (ProgressValueType != Enums.ProgressValueType.None)
            {
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                sf.Trimming = StringTrimming.EllipsisCharacter;
                using (var brushText = new SolidBrush(TextColor))
                {
                    switch (ProgressValueType)
                    {
                        case Enums.ProgressValueType.TextAndValue:
                            g.DrawString(Text + " " + Value, TextFont, brushText, ClientRectangle, sf);
                            break;
                        case Enums.ProgressValueType.TextAndPercentage:
                            g.DrawString(Text + " " + Value + "%", TextFont, brushText, ClientRectangle, sf);
                            break;
                        case Enums.ProgressValueType.Text:
                            g.DrawString(Text, TextFont, brushText, ClientRectangle, sf);
                            break;
                        case Enums.ProgressValueType.Value:
                            g.DrawString(Value.ToString(), TextFont, brushText, ClientRectangle, sf);
                            break;
                        case Enums.ProgressValueType.Percentage:
                            g.DrawString(Value + "%", TextFont, brushText, ClientRectangle, sf);
                            break;
                        case Enums.ProgressValueType.None:
                            break;

                    }
                }
            }


        }


        private int value = 0;
        /// <summary>
        /// Gets or sets value.
        /// </summary>

        public int Value
        {
            get { return value; }
            set
            {
                this.value = value;
                this.Invalidate();
            }
        }
    }

}
