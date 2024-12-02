using HeCopUI_Framework.Animations;
using HeCopUI_Framework.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart
{
    [ToolboxBitmap(typeof(System.Windows.Forms.DataVisualization.Charting.Chart))]
    public partial class HRadarChart : Control
    {
        AnimationManager animationManager;
        public HRadarChart()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            animationManager = new AnimationManager(true);
            animationManager.OnAnimationProgress += sender =>
            {


                Invalidate();
            };

        }



        protected override void OnCreateControl()
        {
            if (_series == null)
            {
                addNew();
            }


            base.OnCreateControl();
        }

        private Series[] _series = null;
        public Series[] Series
        {
            get
            {

                return _series;
            }
            set
            {
                _series = value;

                animationManager.StartNewAnimation(AnimationDirection.In);
                Invalidate();
            }
        }


        // Tạo các biến liên quan tới radar chart
        private int _maxValue = 100;
        private int _minValue = 0;
        private int _step = 20;

        public int Step
        {
            get { return _step; }
            set
            {
                _step = value; Invalidate();
            }
        }

        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                Invalidate();
            }
        }

        void addNew()
        {
            var list = new List<Series>
            {
                new Series() { Color = Color.OrangeRed, Text = "serieName1", Values = new float[] { 90, 50, 70, 40, 60 } }
            };
            //list.Add(new Series() { Color = Color.LimeGreen, Text = "serieName2", Values = new float[] { 80, 70,30, 60 } });
            //list.Add(new Series() { Color = Color.DodgerBlue, Text = "serieName3", Values = new float[] { 70,20, 60, 50 } });
            Series = list.ToArray();
        }

        float maxarea()
        {
            float n = 0;
            for (int i = 0; i < _series.Length; i++)
            {
                if (_series[i].Values.Length > n)
                    n = _series[i].Values.Length;
            }
            return n;
        }

        Font legendFont = new Font("Segoe UI", 10);
        Color legenColor = Color.FromArgb(50, 50, 50);
        public Font LegendFont
        {
            get { return legendFont; }
            set
            {
                legendFont = value;
                Invalidate();
            }
        }

        public Color LegendColor
        {
            get { return legenColor; }
            set
            {
                legenColor = value;
                Invalidate();
            }
        }

        int pointSize = 8;
        public int PointSize
        {
            get { return pointSize; }
            set
            {
                pointSize = value;
                Invalidate();
            }
        }

        System.Drawing.Text.TextRenderingHint textRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get { return textRenderingHint; }
            set
            {
                textRenderingHint = value;
                Invalidate();
            }
        }

        Color radarColor = Color.FromArgb(120, 120, 120);
        public Color RadarColor
        {
            get { return radarColor; }
            set
            {
                radarColor = value;
                Invalidate();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            // Gọi lại hàm vẽ control
            Invalidate();
        }

        bool numberVisible = true;
        public bool NumberVisible
        {
            get { return numberVisible; }
            set
            {
                numberVisible = value;
                Invalidate();
            }
        }

        float getSum()
        {
            float n = 0;
            for (int i = 0; i < _series.Length; i++)
            {
                for (int j = 0; j < _series[i].Values.Length; j++)
                    n += _series[i].Values[j];
            }
            return n;
        }


        float step = 0;
        float radius = 0;

        string title = "Radar Chart";
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                Invalidate();
            }
        }

        Color titleColor = Color.FromArgb(50, 50, 50);
        public Color TitleColor
        {
            get { return titleColor; }
            set
            {
                titleColor = value;
                Invalidate();
            }
        }

        TitleChartAlign titleChartAlign = TitleChartAlign.TopLeft;
        public TitleChartAlign TitleChartAlign
        {
            get { return titleChartAlign; }
            set
            {
                titleChartAlign = value;
                Invalidate();
            }
        }

        Font _titleFont = new Font("Segoe UI", 12);
        public Font TitleFont
        {
            get { return _titleFont; }
            set
            {
                _titleFont = value;
                Invalidate();
            }
        }

        bool showTitle = true;
        public bool ShowTitle
        {
            get { return showTitle; }
            set
            {
                showTitle = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Helper.GraphicsHelper.SetHightGraphics(e.Graphics);
            Bitmap bitmap = new Bitmap(Width, Height);
            bitmap.MakeTransparent();
            Graphics g = Graphics.FromImage(bitmap);
            float startAngle = -90;
            float offsetw = (legendType == LegendType.Right ? 4f : 2);
            Helper.GraphicsHelper.SetHightGraphics(g);
            GraphicsPath path = new GraphicsPath();
            g.TextRenderingHint = textRenderingHint;
            PointF[] points = new PointF[0];
            try
            {
                // Vẽ các thành phần để tạo ra radar chart
                radius = (Math.Min((Width / (legendType == LegendType.Right ? 2.5f : 1)), Height) / 2) - (legendType == LegendType.None ? (showTitle ? TitleFont.Height : 0) : 0);
                step = radius / (_maxValue - _minValue) * _step;
                float locy = Height / 2 - ((Series.Length + 1) * legendFont.Size);
                float currentRadius = 0;

                for (currentRadius = 0; currentRadius <= radius; currentRadius += step)
                {
                    g.DrawEllipse(new Pen(radarColor, 1) { Alignment = PenAlignment.Center }, Width / offsetw - currentRadius, Height / 2 - currentRadius, currentRadius * 2, currentRadius * 2);
                }

                // Vẽ các thành phần còn lại để tạo ra radar chart hoàn chỉnh

                float angle = startAngle;
                for (angle = startAngle; angle < 360; angle += (360 / maxarea()))
                {
                    g.DrawLine(new Pen(radarColor, 1) { Alignment = PenAlignment.Center }, Width / offsetw, Height / 2, Width / offsetw + (float)Math.Cos(angle * Math.PI / 180) * radius, Height / 2 + (float)Math.Sin(angle * Math.PI / 180) * radius);
                }

                // Vẽ các đường và điểm

                for (int i = 0; i < _series.Length; i++)
                {

                    angle = startAngle;
                    float angleStep = 360f / _series[i].Values.Length;
                    points = new PointF[_series[i].Values.Length];

                    for (int j = 0; j < _series[i].Values.Length; j++)
                    {
                        float value = _series[i].Values[j];
                        float x = (float)(Width / offsetw + Math.Cos(angle * Math.PI / 180) * (value * (float)animationManager.GetProgress()) / _maxValue * radius);
                        float y = (float)(Height / 2 + Math.Sin(angle * Math.PI / 180) * (value * (float)animationManager.GetProgress()) / _maxValue * radius);
                        points[j] = new PointF(x, y);
                        angle += angleStep;
                    }

                    g.DrawLines(new Pen(_series[i].Color, 2), points);
                    g.DrawLine(new Pen(_series[i].Color, 2), points[points.Length - 1], points[0]);

                    for (int j = 0; j < _series[i].Values.Length; j++)
                    {
                        g.FillEllipse(new SolidBrush(_series[i].Color), points[j].X - pointSize / 2, points[j].Y - pointSize / 2, pointSize, pointSize);
                        path.AddEllipse(new RectangleF(points[j].X - pointSize / 2, points[j].Y - pointSize / 2, pointSize, pointSize));
                    }
                }

                // Vẽ chú thích (legend)
                if (legendType == LegendType.Right)
                {
                    g.DrawLine(new Pen(radarColor, 1), Width / 2 - 5, Height / 3f, Width / 2 - 5, Height - Height / 3f);

                    for (int i = 0; i < Series.Length; i++)
                    {
                        locy += legendFont.Height;
                        g.FillRectangle(new SolidBrush(Series[i].Color), new RectangleF(Width / 2 + 8, locy, 12, 12));
                        g.DrawString(Series[i].Text, legendFont, new SolidBrush(legenColor), new PointF(Width / 2 + 21, locy + 6 - legendFont.Height / 2));
                    }
                }

                // Vẽ các chữ số
                float currentStep = 0;
                if (numberVisible == true)
                    while (currentStep <= _maxValue)
                    {
                        float x = (float)(Width / offsetw + Math.Cos(startAngle * Math.PI / 180) * currentStep / _maxValue * radius);
                        float y = (float)(Height / 2 + Math.Sin(startAngle * Math.PI / 180) * currentStep / _maxValue * radius);
                        g.DrawString(currentStep.ToString(), new Font("Segoe UI", 8), new SolidBrush(radarColor), x, y);
                        currentStep += _step;
                    }

                // Hiển thị tooltip khi chuột di chuyển qua điểm
                if (!DesignMode && ShowValuesTip && hover)
                {
                    Point mousePosition = PointToClient(MousePosition);

                    for (int i = 0; i < Series.Length; i++)
                    {
                        for (int j = 0; j < Series[i].Values.Length; j++)
                        {

                            if (IsMouseOverPoint(mousePosition, new PointF(points[j].X - PointSize / 2, points[j].Y - PointSize / 2)))
                            {
                                PointF point = points[j];
                                float value = Series[i].Values[j];
                                string text = Series[i].Text;
                                string tooltip = $"{text}: {value}";
                                SizeF size = g.MeasureString(tooltip, Font);
                                PointF ttlo = new PointF(Width - mousePosition.X > size.Width + 4 ? mousePosition.X + 20 : mousePosition.X - size.Width - 4,
                                    Height - mousePosition.Y > size.Height + 4 ? mousePosition.Y : mousePosition.Y - size.Height - 4);

                                g.FillRectangle(new SolidBrush(Color.DodgerBlue), ttlo.X, ttlo.Y + 10, size.Width + 4, size.Height + 4);
                                g.DrawString(tooltip, Font, new SolidBrush(Color.White), ttlo.X + 2, ttlo.Y + 12);
                            }
                        }
                    }
                }

                if (showTitle)
                {
                    // Vẽ tiêu đề
                    float tx = (TitleChartAlign == TitleChartAlign.TopLeft || TitleChartAlign == TitleChartAlign.BottomLeft) ? 0 :
                              (TitleChartAlign == TitleChartAlign.TopCenter || TitleChartAlign == TitleChartAlign.BottomCenter) ? Width / 2 - g.MeasureString(title, new Font("Segoe UI", 12)).Width / 2 :
                              (TitleChartAlign == TitleChartAlign.TopRight || TitleChartAlign == TitleChartAlign.BottomRight) ? Width - g.MeasureString(title, new Font("Segoe UI", 12)).Width : 0;
                    // Tạo float ty để vẽ tiêu đề theo chiều dọc, gồm 3 trường hợp: Top, Center, Bottom
                    float ty = TitleChartAlign == TitleChartAlign.TopLeft ? 0 :
                               TitleChartAlign == TitleChartAlign.TopCenter ? 0 :
                               TitleChartAlign == TitleChartAlign.TopRight ? 0 :
                               (TitleChartAlign == TitleChartAlign.BottomLeft || TitleChartAlign == TitleChartAlign.BottomRight ||
                               TitleChartAlign == TitleChartAlign.BottomCenter) ? Height - g.MeasureString(title, new Font("Segoe UI", 12)).Height : 0;
                    g.DrawString(title, new Font("Segoe UI", 12), new SolidBrush(titleColor), tx, ty);
                }
            }
            catch
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), 0, 0, Width, Height);
                g.DrawString("No data", new Font("Segoe UI", 10), new SolidBrush(Color.White), Width / 2 - 20, Height / 2 - 5);
            }

            e.Graphics.DrawImage(bitmap, 0, 0);
            base.OnPaint(e);
        }


        float GetValueXOY(int n, float x, float y, float offsetw, float angle)
        {
            if (n > 1) n = 0;



            float valuex = (_maxValue * (x - Width / offsetw)) / (radius * Convert.ToSingle((double)animationManager.GetProgress() * Math.Cos(angle * Math.PI / 180)));

            float valuey = (_maxValue * (y - Height / 2)) / (radius * Convert.ToSingle((double)animationManager.GetProgress() * Math.Sin(angle * Math.PI / 180)));

            return n == 1 ? valuex : valuey;
        }

        private bool IsMouseOverPoint(Point mousePosition, PointF point)
        {
            // Kiểm tra xem chuột có nằm trong khoảng của một điểm không
            return mousePosition.X >= point.X && mousePosition.X <= point.X + pointSize &&
                   mousePosition.Y >= point.Y && mousePosition.Y <= point.Y + pointSize;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Invalidate();
            base.OnMouseMove(e);
        }

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

        LegendType legendType = LegendType.Right;
        public LegendType LegendType
        {
            get { return legendType; }
            set
            {
                legendType = value;
                Invalidate();
            }
        }

        public bool ShowValuesTip { get; set; } = false; bool hover = false;
    }

    public class Series
    {
        public Color Color { get; set; } = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256));
        public float[] Values { get; set; } = { 0, 0, 0, 0, 0 };
        public string Text { get; set; } = "SerieName";
    }
}
