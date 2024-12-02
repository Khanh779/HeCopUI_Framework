using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HLineAreaChart : Control
    {
        private AnimationManager animationManager;

        private Color _titleColor = Color.Black;
        private Font _titleFont = new Font("Arial", 12, FontStyle.Bold);
        private TitleChartAlign _titleChartAlign = TitleChartAlign.TopLeft;
        private LegendType _legendType = LegendType.Right;
        private Color _numbericChartColor = Color.DimGray;
        private int _maximumValue = 100;
        private bool showTitle = true;
        private string title = "Line Chart";
        private int visibleNumberOy = 10;
        private int spaceBetweenPoints = 10;
        Color axisColor = Color.Gray;
        Font _numbericChartFont = new Font("Arial", 8, FontStyle.Regular);
        Font _legendFont = new Font("Arial", 8, FontStyle.Regular);


        private DataItems dataItems = new DataItems();

        public Color TitleColor { get => _titleColor; set { _titleColor = value; Invalidate(); } }
        public Font TitleFont { get => _titleFont; set { _titleFont = value; Invalidate(); } }
        public TitleChartAlign TitleChartAlign { get => _titleChartAlign; set { _titleChartAlign = value; Invalidate(); } }
        public LegendType LegendType { get => _legendType; set { _legendType = value; Invalidate(); } }
        public Color NumbericChartColor { get => _numbericChartColor; set { _numbericChartColor = value; Invalidate(); } }
        public bool ShowTitle { get => showTitle; set { showTitle = value; Invalidate(); } }
        public string TitleText { get => title; set { title = value; Invalidate(); } }
        public int VisibleNumberOy { get => visibleNumberOy; set { visibleNumberOy = value; Invalidate(); } }
        public int SpaceBetweenPoints { get => spaceBetweenPoints; set { spaceBetweenPoints = value; Invalidate(); } }
        public Color AxisColor { get => axisColor; set { axisColor = value; Invalidate(); } }

        public Font NumbericChartFont { get => _numbericChartFont; set { _numbericChartFont = value; Invalidate(); } }
        public Font LegendFont { get => _legendFont; set { _legendFont = value; Invalidate(); } }


        public HLineAreaChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            animationManager = new AnimationManager();
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        protected override void OnCreateControl()
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            if (DesignMode)
            {
                // Ví dụ mẫu đi
                Dictionary<object, float> item1 = new Dictionary<object, float>
                {
                    { "A", 10 },
                    { "B", 20 },
                    { "C", 30 }
                };

                AddItems("Example 1", item1, Color.MediumVioletRed);

                Dictionary<object, float> item2 = new Dictionary<object, float>
                {
                    { "A", 30 },
                    { "B", 70 },
                    { "C", 20 }
                };
                AddItems("Example 2", item2, Color.DodgerBlue);

                Dictionary<object, float> item3 = new Dictionary<object, float>
                {
                    { "A", 50 },
                    { "B", 20 },
                    { "C", 10 }
                };
                AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));
            }

            base.OnCreateControl();
        }

        public void AddItems(string legendText, Dictionary<object, float> items, Color color)
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            dataItems.Add(legendText, items, color);
        }

        private float CalculateRoundedMaxValue()
        {
            float maxValue = 0;
            foreach (var dataset in dataItems.Items)
            {
                foreach (var value in dataset.Data.Values)
                {
                    if (value > maxValue)
                        maxValue = value;
                }
            }
            return (float)Math.Ceiling(maxValue / 10) * 10 + 10;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            _maximumValue = (int)CalculateRoundedMaxValue();

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;


            try
            {
                float offsetY = _titleFont.Height + 20;
                float chartHeight = Height - offsetY - 20;
                float chartWidth = Width - Width / 3; // Dành khoảng trống cho legend

                List<object> xAxisLabels = dataItems.Items
                    .SelectMany(item => item.Data.Keys)
                    .Distinct()
                    .ToList();

                //xAxisLabels.Sort();
                //if (sortMode == SortMode.Ascending)
                //    strOX.Sort();
                //else if (sortMode == SortMode.Descending)
                //    strOX.Sort((x, y) => y.ToString().CompareTo(x.ToString()));

                float pointSpacing = chartWidth / (xAxisLabels.Count - 1);

                // Vẽ trục tọa độ
                using (Pen axisPen = new Pen(AxisColor, 1))
                {
                    g.DrawLine(axisPen, 40, offsetY, 40, Height - 20); // Oy
                    g.DrawLine(axisPen, 40, Height - 20, chartWidth, Height - 20); // Ox

                    // Hiển thị chỉ số trên Oy
                    using (Brush textBrush = new SolidBrush(_numbericChartColor))
                    {
                        float step = _maximumValue / visibleNumberOy;
                        for (int i = 0; i <= visibleNumberOy; i++)
                        {
                            float value = i * step;
                            float y = Height - 20 - (value / _maximumValue * chartHeight);
                            g.DrawString(value.ToString(), NumbericChartFont, textBrush, 10, y - 10 + NumbericChartFont.Size / 2);
                            g.DrawLine(axisPen, 35, y, 40, y);
                        }
                    }
                }

                Helper.GraphicsHelper.SetHightGraphics(g);

                // Vẽ các đường
                foreach (var dataset in dataItems.Items)
                {
                    List<PointF> points = new List<PointF>();
                    foreach (var label in xAxisLabels)
                    {
                        int index = xAxisLabels.IndexOf(label);
                        float x = index * pointSpacing + (index == 0 ? 40 : 0);
                        float y = Height - 20;

                        if (dataset.Data.TryGetValue(label, out float value))
                        {
                            y -= (value / _maximumValue) * chartHeight;
                        }

                        using (Brush pointBrush = new SolidBrush(dataset.Color))
                        {
                            g.FillEllipse(pointBrush, x - 3, y - 3, 6, 6);
                        }

                        points.Add(new PointF(x, y));
                    }

                    using (Pen linePen = new Pen(dataset.Color, 1))
                    {
                        g.DrawLines(linePen, points.ToArray());
                    }
                }


                // Vẽ tiêu đề
                if (showTitle)
                {
                    using (Brush titleBrush = new SolidBrush(_titleColor))
                    {
                        g.DrawString(title, _titleFont, titleBrush, Width / 2 - g.MeasureString(title, _titleFont).Width / 2, 10);
                    }
                }

                if (LegendType != LegendType.None)
                {
                    float legendX = chartWidth + 20;
                    float legendY = 10;
                    float legendWidth = Width - legendX - 10;
                    float legendHeight = Height - 20;
                    float y = legendY + 10;
                    foreach (var dataset in dataItems.Items)
                    {
                        g.FillRectangle(new SolidBrush(dataset.Color), legendX + 10, y, 10, 10);
                        g.DrawString(dataset.LegendText, LegendFont, new SolidBrush(NumbericChartColor), legendX + 40, y - LegendFont.Size / 2);
                        y += LegendFont.Height + 5;
                    }
                }
            }
            catch (Exception ex)
            {
                g.DrawString($"Error: {ex.Message}", _titleFont, Brushes.Red, 10, 10);
            }

            base.OnPaint(e);
        }
    }
}
