using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_ThuVienB
{
    public class cuiChartLine : UserControl
    {
        private float[] privateDataPoints = new float[7] { 100f, 90f, 80f, 75f, 70f, 65f, 60f };

        private bool usePercent = true;

        private float privateMaxValue = 100f;

        private int chartPadding = 40;

        private bool showPopup;

        private PointF popupLocation;

        private string popupText;

        private bool privateGradientBackground = true;

        private Color privatePointColor = Color.FromArgb(255, 106, 0);

        private Color privateAxisColor = Color.Gray;

        private string[] xLabelsLong = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private string[] xLabelsShort = new string[7] { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

        private string[] privateCustomXAxis = new string[0];

        private Color privateChartLineColor = Color.FromArgb(255, 106, 0);

        private Color privateDayColor = Color.DarkGray;

        private bool privateShortDates = true;

        private bool privateAutoMaxValue = true;

        private bool privateUseBezier;

        private IContainer components;

        [Browsable(true)]
        [Category("CuoreUI Chart Colors")]
        [Description("Whether the background under the lines should be a gradient.")]
        public bool GradientBackground
        {
            get
            {
                return privateGradientBackground;
            }
            set
            {
                if (privateGradientBackground != value)
                {
                    privateGradientBackground = value;
                    Refresh();
                }
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Colors")]
        [Description("Color of the circular points.")]
        public Color PointColor
        {
            get
            {
                return privatePointColor;
            }
            set
            {
                if (privatePointColor != value)
                {
                    privatePointColor = value;
                    Refresh();
                }
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Colors")]
        [Description("Color of the axis (x and y lines).")]
        public Color AxisColor
        {
            get
            {
                return privateAxisColor;
            }
            set
            {
                privateAxisColor = value;
                Refresh();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Data")]
        [Description("The data points that will be plotted on the line chart.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public float[] DataPoints
        {
            get
            {
                return privateDataPoints;
            }
            set
            {
                privateDataPoints = value;
                if (privateAutoMaxValue)
                {
                    privateMaxValue = privateDataPoints.Max();
                }
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Data")]
        [Description("The X axis values, if you don't want to use the weekdays.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public string[] CustomXAxis
        {
            get
            {
                return privateCustomXAxis;
            }
            set
            {
                privateCustomXAxis = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Layout")]
        [Description("The padding around the chart area.")]
        public int ChartPadding
        {
            get
            {
                return chartPadding;
            }
            set
            {
                chartPadding = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Layout")]
        [Description("If true, the Y-axis will show percentages. If false, it will show absolute values.")]
        public bool UsePercent
        {
            get
            {
                return usePercent;
            }
            set
            {
                usePercent = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Layout")]
        [Description("The maximum value for the Y-axis.")]
        public float MaxValue
        {
            get
            {
                return privateMaxValue;
            }
            set
            {
                AutoMaxValue = false;
                privateMaxValue = value;
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Colors")]
        [Description("Color of the line that connects points.")]
        public Color ChartLineColor
        {
            get
            {
                return privateChartLineColor;
            }
            set
            {
                privateChartLineColor = value;
                Refresh();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Colors")]
        [Description("Color of the day label.")]
        public Color DayColor
        {
            get
            {
                return privateDayColor;
            }
            set
            {
                privateDayColor = value;
                Refresh();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Data")]
        [Description("Whether the dates should be minified.")]
        public bool ShortDates
        {
            get
            {
                return privateShortDates;
            }
            set
            {
                privateShortDates = value;
                Refresh();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Layout")]
        [Description("Whether the MaxValue should update automatically to fit chart data.")]
        public bool AutoMaxValue
        {
            get
            {
                return privateAutoMaxValue;
            }
            set
            {
                privateAutoMaxValue = value;
                if (value)
                {
                    privateMaxValue = privateDataPoints.Max();
                }
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("CuoreUI Chart Layout")]
        [Description("Smoothens the lines by using Bezier curves instead.")]
        public bool UseBezier
        {
            get
            {
                return privateUseBezier;
            }
            set
            {
                privateUseBezier = value;
                Invalidate();
            }
        }

        private Color PopupBackground
        {
            get
            {
                if (BackColor.R + BackColor.G + BackColor.B > 128)
                {
                    return Color.FromArgb(64, Color.Black);
                }
                return Color.FromArgb(64, Color.White);
            }
        }

        private Color PopupText
        {
            get
            {
                if (BackColor.R + BackColor.G + BackColor.B > 128)
                {
                    return Color.White;
                }
                return Color.Black;
            }
        }

        public cuiChartLine()
        {
            InitializeComponent();
            base.MouseMove += OnMouseMove;
            DoubleBuffered = true;
            Font = new Font("Microsoft Yahei UI", 8.25f);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Refresh();
        }

        public bool hasDuplicate(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums[i - 1])
                {
                    return true;
                }
            }
            return false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            int num = base.Width - chartPadding * 2;
            int num2 = base.Height - chartPadding * 2;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            Pen pen = new Pen(AxisColor, 1f);
            Pen pen2 = new Pen(Color.FromArgb(64, AxisColor), 1f)
            {
                DashStyle = DashStyle.Dash
            };
            Pen pen3 = new Pen(ChartLineColor, 2f);
            graphics.DrawLine(pen, chartPadding, chartPadding, chartPadding, num2 + chartPadding);
            graphics.DrawLine(pen, chartPadding, num2 + chartPadding, num + chartPadding, num2 + chartPadding);
            for (int i = 1; i <= 5; i++)
            {
                float num3 = chartPadding + num2 - i * num2 / 5;
                graphics.DrawLine(pen2, chartPadding, num3, num + chartPadding, num3);
            }
            float num4 = 100f / privateMaxValue;
            if (privateDataPoints.Length > 1)
            {
                GraphicsPath graphicsPath = new GraphicsPath();
                float num5 = chartPadding;
                float y = chartPadding + num2 - privateDataPoints[0] * num4 / 100f * num2;
                graphicsPath.StartFigure();
                graphicsPath.AddLine(num5, num2 + chartPadding, num5, y);
                for (int j = 0; j < privateDataPoints.Length - 1; j++)
                {
                    float num6 = chartPadding + j * num / (privateDataPoints.Length - 1);
                    float num7 = chartPadding + num2 - privateDataPoints[j] * num4 / 100f * num2;
                    float num8 = chartPadding + (j + 1) * num / (privateDataPoints.Length - 1);
                    float num9 = chartPadding + num2 - privateDataPoints[j + 1] * num4 / 100f * num2;
                    if (privateUseBezier)
                    {
                        float x = num6 + (num8 - num6) / 3f;
                        float y2 = num7;
                        float x2 = num8 - (num8 - num6) / 3f;
                        float y3 = num9;
                        graphics.DrawBezier(pen3, num6, num7, x, y2, x2, y3, num8, num9);
                        graphicsPath.AddBezier(num6, num7, x, y2, x2, y3, num8, num9);
                    }
                    else
                    {
                        graphics.DrawLine(pen3, num6, num7, num8, num9);
                        graphicsPath.AddLine(num6, num7, num8, num9);
                    }
                }
                float num10 = chartPadding + num;
                float y4 = chartPadding + num2 - privateDataPoints[privateDataPoints.Length - 1] * num4 / 100f * num2;
                graphicsPath.AddLine(num10, y4, num10, num2 + chartPadding);
                graphicsPath.CloseFigure();
                if (GradientBackground)
                {
                    if (ChartLineColor.A == byte.MaxValue)
                    {
                        using (LinearGradientBrush brush = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(64, ChartLineColor), Color.Transparent))
                            graphics.FillPath(brush, graphicsPath);
                    }
                    else
                    {
                        int alpha = (64 + ChartLineColor.A) / 2;
                        using (LinearGradientBrush brush2 = new LinearGradientBrush(new Point(0, 0), new Point(0, base.Height), Color.FromArgb(alpha, ChartLineColor), Color.Transparent))
                            graphics.FillPath(brush2, graphicsPath);
                    }
                }
                else
                {
                    using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(32, ChartLineColor)))
                        graphics.FillPath(brush3, graphicsPath);
                }
                using (SolidBrush brush4 = new SolidBrush(PointColor))
                {
                    float[] array = privateDataPoints;
                    foreach (float num11 in array)
                    {
                        float num12 = chartPadding + Array.IndexOf(privateDataPoints, num11) * num / (privateDataPoints.Length - 1);
                        float num13 = chartPadding + num2 - num11 * num4 / 100f * num2;
                        graphics.FillEllipse(brush4, num12 - 4f, num13 - 4f, 8f, 8f);
                    }
                }
                if (showPopup)
                {
                    SizeF sizeF = graphics.MeasureString(popupText, Font);
                    RectangleF rectangle = new RectangleF(popupLocation.X - sizeF.Width / 2f, popupLocation.Y - sizeF.Height - 10f, sizeF.Width, sizeF.Height);
                    using (GraphicsPath path = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(rectangle, (int)(rectangle.Height / 4f)))
                    using (SolidBrush brush5 = new SolidBrush(PopupBackground))
                    {
                        graphics.FillPath(brush5, path);
                    }
                    graphics.DrawString(popupText, Font, new SolidBrush(PopupText), rectangle.X + 1.5f, rectangle.Y + 1f);
                }
            }
            pen.Dispose();
            pen2.Dispose();
            pen3.Dispose();
            DrawLabels(graphics, chartPadding, num, num2);
        }

        private void DrawLabels(Graphics g, int padding, int width, int height)
        {
            Brush brush = new SolidBrush(DayColor);
            if (usePercent)
            {
                for (int i = 0; i <= 5; i++)
                {
                    float num = padding + height - i * height / 5;
                    g.DrawString($"{Math.Round(i * 20 * privateMaxValue / 100f, 2)}%", Font, brush, padding - 35, num - 7f);
                }
            }
            else
            {
                for (int j = 0; j <= 5; j++)
                {
                    float num2 = padding + height - j * height / 5;
                    float num3 = j * privateMaxValue / 5f;
                    g.DrawString($"{Math.Round(num3, 2)}", Font, brush, padding - 35, num2 - 7f);
                }
            }
            if (privateCustomXAxis.Length != 0)
            {
                for (int k = 0; k < privateCustomXAxis.Length; k++)
                {
                    float num4 = padding + k * width / (privateCustomXAxis.Length - 1);
                    g.DrawString(privateCustomXAxis[k], Font, brush, num4 - 20f, padding + height + 5);
                }
                return;
            }
            for (int l = 0; l < xLabelsLong.Length; l++)
            {
                float num5 = padding + l * width / (xLabelsLong.Length - 1);
                if (ShortDates)
                {
                    g.DrawString(xLabelsShort[l], Font, brush, num5 - 20f, padding + height + 5);
                }
                else
                {
                    g.DrawString(xLabelsLong[l], Font, brush, num5 - 20f, padding + height + 5);
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            int num = base.Width - chartPadding * 2;
            int num2 = base.Height - chartPadding * 2;
            float num3 = 100f / privateMaxValue;
            bool flag = false;
            for (int i = 0; i < privateDataPoints.Length; i++)
            {
                float num4 = chartPadding + i * num / (privateDataPoints.Length - 1);
                float num5 = chartPadding + num2 - privateDataPoints[i] * num3 / 100f * num2;
                if (Math.Abs(e.X - num4) < 10f && Math.Abs(e.Y - num5) < 10f)
                {
                    showPopup = true;
                    if (!popupLocation.Equals(new PointF(num4, num5)))
                    {
                        popupLocation = new PointF(num4, num5);
                        popupText = $"{privateDataPoints[i]}";
                        if (usePercent)
                        {
                            popupText += "%";
                        }
                        InvalidatePopupRegion();
                    }
                    flag = true;
                    return;
                }
                InvalidatePopupRegion();
                showPopup = false;
            }
            if (!flag && showPopup)
            {
                showPopup = false;
            }
        }

        private void InvalidatePopupRegion()
        {
            SizeF sizeF = CreateGraphics().MeasureString(popupText, Font);
            RectangleF rectangle = new RectangleF(popupLocation.X - sizeF.Width / 2f, popupLocation.Y - sizeF.Height - 10f, sizeF.Width, sizeF.Height + 1f);
            GraphicsPath path = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(rectangle, (int)(rectangle.Height / 4f));
            Region region = new Region(path);
            Invalidate(region);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.Name = "cuiLineChart";
            base.Size = new System.Drawing.Size(495, 295);
            base.ResumeLayout(false);
        }
    }
}
