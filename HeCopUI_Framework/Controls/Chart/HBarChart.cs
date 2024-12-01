using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Brush = System.Drawing.Brush;
using Color = System.Drawing.Color;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HBarChart : Control
    {
        public HBarChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            animationManager = new AnimationManager();
            animationManager.OnAnimationProgress += sender => Invalidate();
        }

        AnimationManager animationManager;

        // Tạo các biến private và public (get và set từ biến private và invalidate), biến _titleColor, _titleText, _titleFont, _titleChartAlign, _legendType, _numbericChartColor, _maximumValue, _minimumValue,... Tạo những biến có liên quan tới chart á, cụ thể là chart bar
        private Color _titleColor = Color.Black;
        private Font _titleFont = new Font("Arial", 12, FontStyle.Bold);
        private TitleChartAlign _titleChartAlign = TitleChartAlign.TopLeft;
        private LegendType _legendType = LegendType.Right;
        private Color _numbericChartColor = Color.DimGray;
        private int _maximumValue = 100;
        Color lineChart = Color.FromArgb(50, 50, 50);
        Color itemsColor = Color.FromArgb(50, 50, 50);
        bool showTitle = true;
        string title = "HBar Chart";
        int visibleNumberOy = 10;
        int spaceBetweenItems = 10;


        // Tạo các bins public để set và get từ các biến private, và không dùng [Category(...)]
        public Color TitleColor { get => _titleColor; set { _titleColor = value; Invalidate(); } }

        public Font TitleFont { get => _titleFont; set { _titleFont = value; Invalidate(); } }
        public TitleChartAlign TitleChartAlign { get => _titleChartAlign; set { _titleChartAlign = value; Invalidate(); } }

        public LegendType LegendType { get => _legendType; set { _legendType = value; Invalidate(); } }
        public Color NumbericChartColor { get => _numbericChartColor; set { _numbericChartColor = value; Invalidate(); } }

        public Color LineChart { get => lineChart; set { lineChart = value; Invalidate(); } }
        public Color ItemsTextColor { get => itemsColor; set { itemsColor = value; Invalidate(); } }
        public bool ShowTitle { get => showTitle; set { showTitle = value; Invalidate(); } }
        public string TitleText { get => title; set { title = value; Invalidate(); } }
        public int VisibleNumberOy { get => visibleNumberOy; set { visibleNumberOy = value; Invalidate(); } }
        public int SpaceBetweenItems { get => spaceBetweenItems; set { spaceBetweenItems = value; Invalidate(); } }


        protected override void OnCreateControl()
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            if (DesignMode)
            {
                // Ví dụ mẫu đi
                Dictionary<object, int> item1 = new Dictionary<object, int>
                {
                    { "A", 10 },
                    { "B", 20 },
                    { "C", 30 }
                };

                AddItems("Example 1", item1, Color.MediumVioletRed);

                Dictionary<object, int> item2 = new Dictionary<object, int>
                {
                    { "A", 30 },
                    { "B", 70 },
                    { "C", 20 }
                };
                AddItems("Example 2", item2, Color.DodgerBlue);

                Dictionary<object, int> item3 = new Dictionary<object, int>
                {
                    { "A", 50 },
                    { "B", 20 },
                    { "C", 10 }
                };
                AddItems("Example 3", item3, Color.FromArgb(0, 168, 138));
            }

            base.OnCreateControl();
        }

        bool borderItems = true;
        public bool BorderItems { get => borderItems; set { borderItems = value; animationManager.StartNewAnimation(AnimationDirection.In); Invalidate(); } }
        SortMode sortMode = SortMode.None;
        public SortMode SortMode { get => sortMode; set { sortMode = value; animationManager.StartNewAnimation(AnimationDirection.Out); animationManager.StartNewAnimation(AnimationDirection.In); Invalidate(); } }

        Font legendFont = new Font("Arial", 10, FontStyle.Regular);
        public Font LegendFont { get => legendFont; set { legendFont = value; Invalidate(); } }

        Color legenColor = Color.DimGray;
        public Color LegendColor { get => legenColor; set { legenColor = value; Invalidate(); } }

        HeCopUI_Framework.Controls.Chart.Model.DataItems dataItem = new DataItems();

        public void AddItems(string legendText, Dictionary<object, int> items, System.Drawing.Color color)
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            dataItem.Add(legendText, items, color);


        }

        private float CalculateRoundedMaxValue()
        {
            float maxValue = 0;
            List<object> strOX = new List<object>();
            dataItem.Items.ForEach(x =>
            {
                for (int i = 0; i < x.Data.Keys.Count; i++)
                    if (!strOX.Contains(x.Data.ElementAt(i).Key))
                        strOX.Add(x.Data.ElementAt(i).Key.ToString());
            });
            for (int strX = 0; strX < strOX.Count; strX++)
            {
                float a = 0;
                for (int item = 0; item < dataItem.Items.Count; item++)
                {
                    if (dataItem.Items[item].Data.ContainsKey(strOX[strX]))
                        a += dataItem.Items[item].Data[strOX[strX]];
                }
                if (a > maxValue)
                    maxValue = a;
            }
            // Làm tròn lên đến số chia hết cho 10
            maxValue = Convert.ToSingle(Math.Ceiling(maxValue / 10) * 10 + 10);

            return maxValue;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Tạo các biến để vẽ chart
            Graphics g = e.Graphics;
            _maximumValue = (int)CalculateRoundedMaxValue();
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            try
            {
                float locy = Height / 2 - ((dataItem.Items.Count + 1) * legendFont.Size);
                string tooltipText = "";
                int maxCount = 0;
                int off_X_and_Y = 5;
                float offY = _titleFont.Height + 20;
                using (Pen pen = new Pen(lineChart, 1))
                using (Pen penOY = new Pen(new SolidBrush(LineChart), 1))
                using (Brush brush = new SolidBrush(itemsColor))
                using (Brush brushTitle = new SolidBrush(TitleColor))
                using (Font oyf = new Font(_titleFont.Name, 10f))
                using (Brush brushOy = new SolidBrush(NumbericChartColor))
                {
                    float offyh = 20;
                    float offx = 11 * _maximumValue.ToString().Length;
                    float offcw = Width / 3;
                    List<object> strOX = new List<object>();

                    // Vẽ trục ngang Ox và trục dọc Oy của chart
                    g.DrawLine(pen, offx, Height - offyh, Width - offcw, Height - offyh); //Ox
                    g.DrawLine(pen, offx, Height - offyh, offx, offY);

                    dataItem.Items.ForEach(x =>
                    {
                        for (int i = 0; i < x.Data.Keys.Count; i++)
                            if (!strOX.Contains(x.Data.ElementAt(i).Key))
                                strOX.Add(x.Data.ElementAt(i).Key.ToString());
                    });

                    if (sortMode == SortMode.Ascending)
                        strOX.Sort();
                    else if (sortMode == SortMode.Descending)
                        strOX.Sort((x, y) => y.ToString().CompareTo(x.ToString()));
                    //else if(sortMode == SortMode.None)


                    maxCount = strOX.Count;

                    // Hiển thị chỉ số trên trục OY
                    float tickSpacing = _maximumValue / (visibleNumberOy);
                    for (int i = 0; i <= visibleNumberOy; i++)
                    {
                        float tickValue = i * tickSpacing;
                        float tickY = (Height - offyh) - ((tickValue / _maximumValue) * (Height - offY - offyh));
                        PointF tickPos = new PointF(offx - e.Graphics.MeasureString(((tickValue)).ToString(), oyf).Width - 5, tickY - _titleFont.Height / 2);

                        // Vẽ các chỉ số trên trục Oy
                        g.DrawString(((float)(tickValue)).ToString(), oyf, brushOy, tickPos);
                        g.DrawLine(penOY, offx - 6, tickY, offx, tickY);
                    }


                    PointF ttp = PointToClient(MousePosition);
                    // Tính toán độ rộng của các cột dựa trên số lượng items và khoảng cách tùy chỉnh
                    float totalSpacing = (dataItem.Items.Count - 1) * SpaceBetweenItems;
                    float barWidth = (Width - offcw - offx - off_X_and_Y * 2 - 10 * 2 - totalSpacing) / maxCount;
                    for (int i = 0; i < strOX.Count; i++)
                    {
                        //float tickX = (offx + 10) + ((i * (Width - Width / 3 - 2 - offx - 8*2 - off_X_and_Y*2)) / strOX.Count);
                        float tickX = (offx + 5) + i * (barWidth + SpaceBetweenItems) + off_X_and_Y;
                        PointF tickPos = new PointF(tickX - e.Graphics.MeasureString(strOX[i].ToString(), oyf).Width / 2, Height - offyh + 5);
                        g.DrawString(strOX[i].ToString(), oyf, brushOy, tickPos);
                    }
                    for (int strX = 0; strX < strOX.Count; strX++)
                    {
                        float x = (offx) + strX * (barWidth + SpaceBetweenItems) + off_X_and_Y;
                        float totalHeight = 0;
                        float yt = 0;
                        float dataValue = 0;
                        for (int item = 0; item < dataItem.Items.Count; item++)
                        {
                            if (dataItem.Items.ElementAt(item).Data.ContainsKey(strOX[strX]))
                            {
                                dataValue += dataItem.Items[item].Data[strOX[strX]];
                                float vl = dataItem.Items[item].Data[strOX[strX]];
                                // Chỉnh sửa phần tính toán y và height tùy theo yêu cầu cụ thể của bạn
                                float y = (float)((Height - offyh - totalHeight) - (vl / _maximumValue) * (Height - offyh - offY) * animationManager.GetProgress());
                                float height = (float)((vl / _maximumValue) * (Height - offyh - offY) * animationManager.GetProgress());
                                g.FillRectangle(new SolidBrush(dataItem.Items[item].Color), x, y, barWidth, height);
                                g.DrawString(dataValue.ToString(), oyf, brush, x, y - oyf.Height);
                                totalHeight += height;

                            }
                            yt = (float)((Height - offyh - totalHeight) * animationManager.GetProgress());
                        }

                        if (ttp.X >= x && ttp.X <= x + barWidth && ttp.Y >= yt && ttp.Y <= yt + totalHeight)
                        {
                            tooltipText = strOX[strX].ToString() + ": " + dataValue.ToString() + " (total)\n";
                            for (int item = 0; item < dataItem.Items.Count; item++)
                            {
                                if (dataItem.Items.ElementAt(item).Data.ContainsKey(strOX[strX]))
                                {
                                    tooltipText += dataItem.Items[item].LegendText + ": " + dataItem.Items[item].Data[strOX[strX]].ToString() + "\n";
                                }
                            }
                            continue;
                        }

                    }

                    if (showTitle)
                    {
                        // Vẽ tiêu đề
                        float tx = (TitleChartAlign == TitleChartAlign.TopLeft || TitleChartAlign == TitleChartAlign.BottomLeft) ? 0 : (TitleChartAlign == TitleChartAlign.TopCenter || TitleChartAlign == TitleChartAlign.BottomCenter) ? Width / 2 - g.MeasureString(title, _titleFont).Width / 2 :
                                  (TitleChartAlign == TitleChartAlign.TopRight || TitleChartAlign == TitleChartAlign.BottomRight) ? Width - g.MeasureString(title, _titleFont).Width : 0;

                        // Tạo float ty để vẽ tiêu đề theo chiều dọc, gồm 3 trường hợp: Top, Center, Bottom
                        float ty = TitleChartAlign == TitleChartAlign.TopLeft ? 0 : TitleChartAlign == TitleChartAlign.TopCenter ? 0 : TitleChartAlign == TitleChartAlign.TopRight ? 0 :
                                  (TitleChartAlign == TitleChartAlign.BottomLeft || TitleChartAlign == TitleChartAlign.BottomRight || TitleChartAlign == TitleChartAlign.BottomCenter) ? Height - g.MeasureString(title, _titleFont).Height : 0;

                        g.DrawString(title, _titleFont, brushTitle, tx, ty);
                    }

                    g.DrawLine(new Pen(LineChart, 1), Width - offcw + 4, Height / 3f, Width - offcw + 4, Height - Height / 3f);

                    for (int i = 0; i < dataItem.Items.Count; i++)
                    {
                        locy += legendFont.Height;
                        g.FillRectangle(new SolidBrush(dataItem.Items[i].Color), new RectangleF(Width - offcw + 12, locy, 12, 12));
                        g.DrawString(dataItem.Items[i].LegendText, legendFont, new SolidBrush(legenColor), new PointF(Width - offcw + 26, locy + 6 - legendFont.Height / 2));
                    }

                    if (hover && tooltipText != "")
                    {
                        var ttsi = g.MeasureString(tooltipText, toolTipFont);
                        int offbh = 2;
                        g.FillRectangle(new SolidBrush(Color.White), ttp.X - ttsi.Width / 2, ttp.Y - ttsi.Height - 5 - offbh, ttsi.Width + 4, ttsi.Height + 4);
                        g.DrawRectangle(new Pen(Color.DimGray, 1), ttp.X - ttsi.Width / 2, ttp.Y - ttsi.Height - 5 - offbh, ttsi.Width + 4, ttsi.Height + 4);
                        g.DrawString(tooltipText, toolTipFont, new SolidBrush(Color.DimGray), ttp.X - (ttsi.Width - 3) / 2, ttp.Y - (ttsi.Height + 3) - offbh);
                    }
                }
            }
            catch
            {
                // Fill Rectangle màu Xám đậm và màu chữ trắng khi không có dữ liệu
                g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, Height);
                g.DrawString("No Data", _titleFont, new SolidBrush(Color.White), Width / 2 - g.MeasureString("No Data", _titleFont).Width / 2, Height / 2 - g.MeasureString("No Data", _titleFont).Height / 2);
            }

            base.OnPaint(e);
        }


        bool isMouseHovered(float x, float y, float barWidth, float height)
        {
            PointF ttp = PointToClient(MousePosition);
            return ttp.X >= x && ttp.X <= x + barWidth && ttp.Y >= y && ttp.Y <= y + height;
        }


        Font toolTipFont = DefaultFont;
        public Font ToolTipFont { get => toolTipFont; set { toolTipFont = value; Invalidate(); } }

        bool hover = false;
        protected override void OnMouseEnter(EventArgs e)
        {
            hover = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseMove(e);
        }

    }


}
