using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using LinearGradientBrush = System.Drawing.Drawing2D.LinearGradientBrush;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HPieChart : Control
    {
        public HPieChart()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            animationManager = new AnimationManager(true);
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        AnimationManager animationManager;

        private LegendType legendType = LegendType.None;
        public LegendType LegendChart
        {
            get { return legendType; }
            set
            {
                legendType = value; Invalidate();
            }
        }

        private int startangle = 0;
        public int StartAngle
        {
            get { return startangle; }
            set
            {
                startangle = value; Invalidate();
            }

        }

        protected override void OnCreateControl()
        {
            if (DesignMode)
            {
                // Ví dụ biểu đồ 
                Dictionary<object, float> item1 = new Dictionary<object, float>
                {
                    { "A", 10 },
                    { "B", 20 },
                    { "C", 30 },
                    { "D", 40 }
                };
                AddItems("Example 1", item1, Color.MediumVioletRed);

                Dictionary<object, float> item2 = new Dictionary<object, float>
                {
                    { "A", 50 },
                    { "B", 60 },
                    { "L", 70 },
                    { "43", 80 }
                };
                AddItems("Example 2", item2, Color.DodgerBlue);

                Dictionary<object, float> item3 = new Dictionary<object, float>
                {
                    { "A", 90 },
                    { "B", 105 },
                    { "1", 80 },
                    { "4", 12 }
                };
                AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));

            }
            base.OnCreateControl();
        }

        private int innerRad = 0;
        public int CircularWidth
        {
            get { return innerRad; }
            set
            {
                innerRad = value; Invalidate();
            }
        }

        private Color cirvuColo = Color.Salmon;
        public Color CircularColor
        {
            get { return cirvuColo; }
            set
            {
                cirvuColo = value; Invalidate();
            }
        }

        private Color legenColor = Color.FromArgb(170, 170, 170);
        public Color LegendTextColor
        {
            get { return legenColor; }
            set
            {
                legenColor = value; Invalidate();
            }
        }

        public bool ShowValuesTip { get; set; } = true;
        bool hover = false;

        Color valueColor = Color.White;
        public Color ValueColor
        {
            get { return valueColor; }
            set
            {
                valueColor = value; Invalidate();
            }
        }

        Font legendFont = Control.DefaultFont;
        public Font LegendFont
        {
            get { return legendFont; }
            set
            {
                legendFont = value; Invalidate();
            }
        }

        Font serFont = Control.DefaultFont;
        public Font SeriesValueFont
        {
            get { return serFont; }
            set
            {
                serFont = value; Invalidate();
            }
        }

        int pieSize = 150;
        public int PieCharSize
        {
            get { return pieSize; }
            set
            {
                pieSize = value; Invalidate();
            }
        }

        System.Drawing.Text.TextRenderingHint textRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        public System.Drawing.Text.TextRenderingHint TextRenderHint
        {
            get { return textRenderingHint; }
            set
            {
                textRenderingHint = value; Invalidate();
            }
        }

        private bool visibleLegend = true;
        public bool VisibleLegend
        {
            get { return visibleLegend; }
            set
            {
                visibleLegend = value; Invalidate();
            }
        }

        int al = 255;

        HeCopUI_Framework.Controls.Chart.Model.DataItems dataItem = new DataItems();

        public void AddItems(string legendText, Dictionary<object, float> items, System.Drawing.Color color)
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            dataItem.Add(legendText, items, color);


        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.TextRenderingHint = TextRenderHint;

                if (dataItem.Items.Count > 0)
                {
                    Rectangle rect = new Rectangle(Width / 2 - pieSize / 2, Height / 2 - pieSize / 2, pieSize, pieSize);
                    float sum = 0;
                    float fDegValue = 0;
                    float fDegSum = startangle;
                    RectangleF recta = new RectangleF(0, 0, pieSize, pieSize);
                    g.TextRenderingHint = TextRenderHint;
                    float locy = (Height / 2 - ((dataItem.Items.Count + 1) * legendFont.Size));
                    GraphicsPath path = new GraphicsPath();
                    Brush brush;
                    dataItem.Items.ForEach(item => sum += item.Data.Values.Sum());

                    foreach (var item in dataItem.Items)
                    {
                        fDegValue = item.Data.Values.Sum() * 360 / sum;
                        brush = new SolidBrush(Color.FromArgb(al, item.Color));

                        switch (legendType)
                        {
                            case LegendType.None:
                                recta = new RectangleF(Width / 2 - pieSize / 2, Height / 2 - pieSize / 2, pieSize, pieSize);
                                g.FillPie(brush, rect, Convert.ToSingle(fDegSum * animationManager.GetProgress()), Convert.ToSingle(fDegValue * animationManager.GetProgress()));
                                g.FillEllipse(new SolidBrush(cirvuColo), new RectangleF(Width / 2 - innerRad / 2, Height / 2 - innerRad / 2, innerRad, innerRad));
                                break;
                            case LegendType.Right:
                                rect = new Rectangle(Width / 2 - pieSize, Height / 2 - pieSize / 2, pieSize, pieSize);
                                g.FillPie(brush, rect, Convert.ToSingle(fDegSum * animationManager.GetProgress()), Convert.ToSingle(fDegValue * animationManager.GetProgress()));
                                g.FillEllipse(new SolidBrush(cirvuColo), new RectangleF(Width / 2 - pieSize / 2 - innerRad / 2, Height / 2 - innerRad / 2, innerRad, innerRad));
                                Pen pen = new Pen(new SolidBrush(Color.Gray), 1) { Alignment = PenAlignment.Center };
                                g.DrawLine(pen, Width / 2 + 8, Height / 2 - pieSize / 2, Width / 2 + 8, Height / 2 - pieSize / 2 + pieSize);
                                recta = new RectangleF(Width / 2 - pieSize, Height / 2 - pieSize / 2, pieSize, pieSize);
                                break;
                        }

                        if (ShowValuesTip)
                            path.AddPie(Rectangle.Round(recta), fDegSum, fDegValue);

                        if (visibleLegend)
                            DrawLabeledPieChart(g, recta, StartAngle, item.Data.Values.Sum(), sum, "0.0", serFont, new SolidBrush(valueColor));

                        fDegSum += fDegValue;
                    }

                    if (legendType == LegendType.Right)
                    {
                        dataItem.Items.ForEach(item =>
                        {
                            locy += legendFont.Height + 2;
                            g.SmoothingMode = SmoothingMode.Default;
                            g.FillRectangle(new SolidBrush(item.Color), new RectangleF(Width / 2 + 20, locy, 12, 12));
                            g.DrawString(item.LegendText, legendFont, new SolidBrush(legenColor), new PointF(Width / 2 + 34, locy + 6 - legendFont.Height / 2));
                        });
                    }

                    // Hiện tooltip
                    if (!DesignMode && ShowValuesTip && hover)
                    {
                        Point mousePosition = PointToClient(MousePosition);
                        if (path.IsVisible(mousePosition))
                        {
                            float angle = (float)(Math.Atan2(mousePosition.Y - Height / 2, (mousePosition.X) - (Width - (legendType == LegendType.Right ? pieSize : 0)) / 2) * 180 / Math.PI);
                            if (angle < 0) angle += 360;
                            float value = 0;
                            string te = "";
                            float startAngle = startangle;
                            float endAngle = startangle;

                            foreach (var item in dataItem.Items)
                            {
                                endAngle += item.Data.Values.Sum() / sum * 360;
                                float midAngle = (startAngle + endAngle) / 2;

                                if (angle >= startAngle && angle <= endAngle)
                                {
                                    value = item.Data.Values.Sum();
                                    te = item.LegendText + ": " + value + " (total)\n";
                                    // Hiển thị giá trị của từng key
                                    item.Data.ToList().ForEach(x => te += $"{x.Key}: {x.Value}\n");
                                    break;
                                }

                                startAngle = endAngle;
                            }

                            string tooltip = $" {te}";
                            SizeF size = g.MeasureString(tooltip, serFont);
                            PointF ttlo = new PointF(Width - mousePosition.X > size.Width + 4 ? mousePosition.X + 20 : mousePosition.X - size.Width - 4,
                                Height - mousePosition.Y > size.Height + 4 ? mousePosition.Y : mousePosition.Y - size.Height - 4);

                            g.FillRectangle(new SolidBrush(Color.White), ttlo.X, ttlo.Y + 10, size.Width + 4, size.Height + 4);
                            g.DrawRectangle(new Pen(Color.DimGray), ttlo.X, ttlo.Y + 10, size.Width + 4, size.Height + 4);
                            g.DrawString(tooltip, serFont, new SolidBrush(Color.DimGray), ttlo.X + 2, ttlo.Y + 12);
                        }
                    }
                }
                else
                {
                    StringFormat SF = new StringFormat();
                    SF.Alignment = SF.LineAlignment = StringAlignment.Center;
                    SF.Trimming = StringTrimming.EllipsisWord;
                    LinearGradientBrush LB = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, Width, Height), Color.FromArgb(230, Color.DodgerBlue), Color.FromArgb(99, 58, 175), LinearGradientMode.ForwardDiagonal);
                    g.FillRectangle(LB, ClientRectangle);
                    g.DrawString("No data to show graph chart!", Font, new SolidBrush(Color.White), new RectangleF(3, 3, Width - 4, Height - 4), SF);
                }
            }

            base.OnPaint(e);
        }


        protected override void OnMouseHover(EventArgs e)
        {
            hover = true; Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {

            Invalidate();
            base.OnMouseMove(e);
        }



        private void DrawLabeledPieChart(Graphics gr, RectangleF rect, float initial_angle, float values, float total, string label_format, Font label_font, Brush label_brush)
        {
            using (StringFormat string_format = new StringFormat())
            {
                // Center text.
                string_format.Alignment = StringAlignment.Center;
                string_format.LineAlignment = StringAlignment.Center;

                // Find the center of the rectangle.
                float cx = (rect.Left + rect.Right) / 2f;
                float cy = (rect.Top + rect.Bottom) / 2f;

                // Place the label about 2/3 of the way out to the edge.
                float radius = (rect.Width + rect.Height) / 2f * 0.33f;

                float start_angle = initial_angle;

                foreach (var item in dataItem.Items)
                {
                    float sweep_angle = item.Data.Values.Sum() * 360f / total;

                    // Label the slice.
                    double label_angle = Math.PI * (start_angle + sweep_angle / 2f) / 180f;
                    float x = cx + (float)(radius * Math.Cos(label_angle));
                    float y = cy + (float)(radius * Math.Sin(label_angle));

                    gr.DrawString(item.Data.Values.Sum().ToString(label_format), label_font, label_brush, x, y, string_format);

                    start_angle += sweep_angle;
                }
            }
        }


    }


}

