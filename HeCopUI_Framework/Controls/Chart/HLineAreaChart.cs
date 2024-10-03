using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Controls.Chart.Model;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Media;
using static System.Windows.Forms.AxHost;
using Color = System.Drawing.Color;
using Pen = System.Drawing.Pen;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HLineAreaChart : Control
    {
        #region Properties
#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable CS0414 // The field 'HLineAreaChart.hover' is assigned but its value is never used
        bool hover = false;
#pragma warning restore CS0414 // The field 'HLineAreaChart.hover' is assigned but its value is never used
#pragma warning restore IDE0052 // Remove unread private members
                               // Tạo các hàm, biến để hỗ trợ cho việc tạo các thuộc tính cho LineAreaChart
        int numberVisible = 10;
        public int NumberOfOyVisible
        {
            get { return numberVisible; }
            set { numberVisible = value; Invalidate(); }
        }

        int max = 100;
       
        Color gridColor = Color.Gainsboro;
        public Color GridColor
        {
            get { return gridColor; }
            set { gridColor = value; Invalidate(); }
        }

        bool showPoints = true;
        public bool ShowPoints
        {
            get { return showPoints; }
            set { showPoints = value; Invalidate(); }
        }

        int pointSize = 8;
        public int PointSize
        {
            get { return pointSize; }
            set { pointSize = value; Invalidate(); }
        }

        public enum Style { Curved, Flat }
        Style graphStyle = Style.Flat;
        public Style GraphStyle
        {
            get { return graphStyle; }
            set
            {
                graphStyle = value; Refresh();
            }
        }

        Font _titleFont = new Font("Segoe UI", 12, FontStyle.Bold);
        public Font TitleFont
        {
            get { return _titleFont; }
            set { _titleFont = value; Invalidate(); }
        }

        TitleChartAlign chartAlign = TitleChartAlign.TopLeft;
        public TitleChartAlign TitleAlign
        {
            get { return chartAlign; }
            set { chartAlign = value; Invalidate(); }
        }

        bool showArea = true;
        public bool ShowAreas
        {
            get { return showArea; }
            set { showArea = value; Invalidate(); }
        }

        SortMode sortMode = SortMode.None;
        public SortMode SortMode
        {
            get { return sortMode; }
            set { sortMode = value; Invalidate(); }
        }

        #endregion


        public HLineAreaChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
            dataItem = new Model.DataItems();
            animationManager = new AnimationManager();
            animationManager.OnAnimationProgress += sender => Invalidate();
           
        }

        protected override void OnCreateControl()
        {
            animationManager.StartNewAnimation(AnimationDirection.In);
            if (DesignMode)
            {
                // Thêm dữ liệu mẫu cho design mode
                Dictionary<object, int> item1 = new Dictionary<object, int>();
                item1.Add("A", 10);
                item1.Add("B", 20);
                item1.Add("C", 30);
                item1.Add("D", 40);
                dataItem.Add("Example 1", item1, Color.Red);

                Dictionary<object, int> item2 = new Dictionary<object, int>();
                item2.Add("A", 50);
                item2.Add("B", 60);
                item2.Add("C", 70);
                item2.Add("E", 20);
                dataItem.Add("Example 2", item2, Color.Blue);
            }
            base.OnCreateControl();
        }

        protected override void OnMouseHover(EventArgs e)
        {
            hover = true; Invalidate();
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            hover = false; Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            hover = true; Invalidate();
            base.OnMouseMove(e);
        }

        AnimationManager animationManager;

        HeCopUI_Framework.Controls.Chart.Model.DataItems dataItem = new DataItems();

        public void AddItems(string legendText, Dictionary<object, int> items, System.Drawing.Color color)
        {
            dataItem.Add(legendText, items, color);

          
        }


        public void ReLoadData()
        {
            Refresh();
            animationManager.StartNewAnimation(AnimationDirection.In);
            Invalidate();
        }

        KeyValuePair<object, int> getValueFromY(object key, int index)
        {
            KeyValuePair<object, int> y = new KeyValuePair<object, int>();

            // Kiểm tra null cho dataItem.Items và dataItem.Items[index]
            if (dataItem.Items != null && index >= 0 && index < dataItem.Items.Count && dataItem.Items[index].Data != null)
            {
                foreach (var kvp in dataItem.Items[index].Data)
                {
                    if (kvp.Key == key)
                    {
                        y = kvp;
                        break;
                    }
                }
            }

            return y;
        }


        bool isExists(object key, int index)
        {
            bool isExists = false;
            foreach (var kvp in dataItem.Items[index].Data)
            {
                if (kvp.Key == key)
                {
                    isExists = true;
                    break;
                }

            }
            return isExists;
        }

        private float CalculateRoundedMaxValue()
        {
            float maxValue = float.MinValue;

            foreach (var dataIte in dataItem.Items)
            {
                foreach (var value in dataIte.Data.Values)
                {
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }
            }

            // Làm tròn lên đến số chia hết cho 10
            maxValue = (float)Math.Ceiling(maxValue / 10) * 10+10;

            return maxValue;
        }

        Color numbericOfOxy= Color.Black;
        public Color NumbericOfOxy
        {
            get { return numbericOfOxy; }
            set { numbericOfOxy = value; Invalidate(); }
        }

        Color chartColor= Color.Black;
        public Color ChartColor
        {
            get { return chartColor; }
            set { chartColor = value; Invalidate(); }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            try
            {
                if(dataItem.Items.Count>0)
                {
                    if (!DesignMode)
                        max = (int)CalculateRoundedMaxValue();

                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    var oxf = DefaultFont;
                    var legendFont = DefaultFont;
                    float offX = 10;
                    float offY = 20;
                    float offcw = Width / 3f;
                    //string tooltipText = "";
                    float offxlegend = Width - offcw + 20;
                    float offylegend = _titleFont.Height + 20;
                    //PointF ttp = new PointF();
                    //SizeF ttsi = new SizeF();
                    float offch = 25;
                    float maxCount = 0;
                    // Vẽ tiêu đề, vị trí của tiêu đề dựa trên TitleAlign
                    SizeF si = g.MeasureString(Text, _titleFont);
                    using (var BrForeColor = new SolidBrush(ForeColor))
                    using (var BrOyNumber = new SolidBrush(numbericOfOxy))
                    using (var BrGrid = new SolidBrush(gridColor))
                    {
                        switch (TitleAlign)
                        {
                            case TitleChartAlign.TopLeft:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF(0, 0));
                                offY = (_titleFont.Height + 10);
                                break;
                            case TitleChartAlign.TopCenter:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF((Width - si.Width) / 2, 0));
                                offY = (_titleFont.Height + 10);
                                break;
                            case TitleChartAlign.TopRight:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF(Width - si.Width, 0));
                                offY = (_titleFont.Height + 10);
                                break;
                            case TitleChartAlign.BottomLeft:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF(0, Height - si.Height));
                                offch += si.Height + 5;
                                break;
                            case TitleChartAlign.BottomCenter:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF((Width - si.Width) / 2, Height - si.Height));
                                offch += si.Height + 5;
                                break;
                            case TitleChartAlign.BottomRight:
                                g.DrawString(Text, _titleFont, BrForeColor, new PointF(Width - si.Width, Height - si.Height));
                                offch += si.Height + 5;
                                break;
                        }
                        SizeF s = g.MeasureString(max.ToString(), oxf);
                        offX += s.Width;
                        // Vẽ các chỉ số cho trục Oy từ 0 đến max, dựa trên numberVisible và chiều cao của control
                        for (int i = 0; i <= numberVisible; i++)
                        {
                            SizeF v = g.MeasureString((max / numberVisible * i).ToString(), oxf);
                            float yPos = (Height - offch - ((Height - offY - offch) / numberVisible * i)) - v.Height / 2;
                            g.DrawString((max / numberVisible * i).ToString(), oxf, BrOyNumber, new PointF(offX - v.Width - 8, yPos));
                        }

                        // Vẽ legend
                        dataItem.Items.ForEach(dataItema =>
                        {
                            SizeF sif = e.Graphics.MeasureString(dataItema.LegendText.ToString(), legendFont);
                            offylegend = _titleFont.Height + (legendFont.Height * dataItem.Items.IndexOf(dataItema));
                            g.DrawLine(new Pen(new SolidBrush(dataItema.Color), 2), offxlegend, offylegend + sif.Height / 2, offxlegend + 16, offylegend + sif.Height / 2);
                            g.DrawString(dataItema.LegendText, legendFont, new SolidBrush(dataItema.Color), offxlegend + 20, offylegend);
                        });

                        List<object> strOX = new List<object>();

                        // Sử dụng số lượng phần tử trong danh sách duy nhất để xác định maxCount
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

                        maxCount = strOX.Count;
                        float step = (float)(Width - offcw - offX) / (maxCount);

                        // Tính toán khoảng cách giữa các điểm dựa trên số lượng dữ liệu
                        for (int i = 0; i <= numberVisible; i++)
                        {
                            // Vẽ thêm đường lưới trục Oy
                            g.DrawLine(new Pen(BrGrid, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot }, new PointF(offX, Height - offch - (Height - offY - offch) / numberVisible * i), new PointF(Width - offcw + 8, Height - offch - (Height - offY - offch) / numberVisible * i));
                        }

                        for (int i = 0; i < maxCount; i++)
                        {
                            float x = offX + step * i;
                            g.DrawLine(new Pen(BrGrid, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot }, new PointF(x, offY - 5), new PointF(x, Height - offch));
                            var item = strOX[i];
                            g.DrawString(item.ToString(), oxf, BrOyNumber, new PointF(x - 5, Height - offch + 8));
                        }
                        // Vẽ đường theo trục Ox và Oy
                        g.DrawLine(new Pen(new SolidBrush(chartColor), 1), new PointF(offX - 5, Height - offch), new PointF(Width - offcw + 8, Height - offch)); // Oy
                        g.DrawLine(new Pen(new SolidBrush(chartColor), 1), new PointF(offX, offY - 5), new PointF(offX, Height - offch + 5)); //Ox

                        // Vẽ các đường đồ thị(Lines) dựa trên dataItems
                        for (int item = 0; item < dataItem.Items.Count; item++)
                        {
                            var dataIte = dataItem.Items[item];
                            if (dataIte != null)
                            {
                                List<PointF> points = new List<PointF>();

                                for (int i = 0; i < strOX.Count; i++)
                                {
                                    float x = offX + step * i;
                                    if (dataItem.Items.ElementAt(item).Data.ContainsKey(strOX[i]))
                                    {
                                        dataItem.Items.ElementAt(item).Data.TryGetValue(strOX[i], out int value);
                                        float y = Height - offch - value * (Height - offY - offch) * Convert.ToSingle(animationManager.GetProgress()) / max;
                                        points.Add(new PointF(x, y));
                                    }
                                }


                                if (maxCount > dataIte.Data.Count)
                                {
                                    float x = offX + step * (maxCount - 1);
                                    float y = Height - offch - 0 * (Height - offY - offch) * Convert.ToSingle(animationManager.GetProgress()) / max;
                                    points.Add(new PointF(x, y));
                                }

                                if (points.Count > 1)
                                {
                                    g.SmoothingMode = SmoothingMode.AntiAlias;

                                    // Khai báo Pen và SolidBrush với màu từ dataIte.Color
                                    using (Pen linePen = new Pen(dataIte.Color, 1))
                                    using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(20, dataIte.Color)))
                                    using (GraphicsPath graphicsPath = new GraphicsPath())
                                    {
                                        // Vẽ và fill màu
                                        if (graphStyle == Style.Flat) graphicsPath.AddLines(points.ToArray());
                                        else graphicsPath.AddCurve(points.ToArray());
                                        if (showArea)
                                            using (GraphicsPath areaPath = (GraphicsPath)graphicsPath.Clone())
                                            {
                                                areaPath.AddLine(new PointF(points[points.Count - 1].X, Height - offch), new PointF(points[0].X, Height - offch));
                                                //areaPath.CloseFigure();
                                                g.FillPath(fillBrush, areaPath);
                                            }

                                        g.DrawPath(linePen, graphicsPath);

                                        // Vẽ điểm nếu cần
                                        if (showPoints) for (int p = 0; p < points.Count - 1; p++)
                                                using (var pointBrush = new SolidBrush(dataIte.Color))
                                                    g.FillEllipse(pointBrush, new RectangleF(points[p].X - pointSize / 2, points[p].Y - pointSize / 2, pointSize, pointSize));

                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    // Fill hình chữ nhật màu DimGray và draw string "No data" màu trắng nếu không có dữ liệu
                    g.FillRectangle(new SolidBrush(Color.DimGray), new RectangleF(0, 0, Width, Height));
                    g.DrawString("No data", Font, new SolidBrush(Color.White), new PointF(Width / 2 - g.MeasureString("No data", Font).Width / 2, Height / 2 - g.MeasureString("No data", Font).Height / 2));
                }
            }
            catch
            {
                // Fill hình chữ nhật màu DimGray và draw string "No data" màu trắng nếu không có dữ liệu
                g.FillRectangle(new SolidBrush(Color.DimGray), new RectangleF(0, 0, Width, Height));
                g.DrawString("No data", Font, new SolidBrush(Color.White), new PointF(Width / 2 - g.MeasureString("No data", Font).Width / 2, Height / 2 - g.MeasureString("No data", Font).Height / 2));
            }
            base.OnPaint(e);
        }

    }

}
