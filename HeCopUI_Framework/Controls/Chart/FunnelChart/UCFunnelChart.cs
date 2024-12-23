﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Chart.FunnelChart
{
    /// <summary>
    /// Class UCFunnelChart.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public class UCFunnelChart : UserControl
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        [Browsable(true)]
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                ResetTitleSize();
                Invalidate();
            }
        }

        /// <summary>
        /// The title font
        /// </summary>
        private Font titleFont = new Font("Arial", 12);
        /// <summary>
        /// Gets or sets the title font.
        /// </summary>
        /// <value>The title font.</value>
        [Browsable(true)]
        public Font TitleFont
        {
            get { return titleFont; }
            set
            {
                titleFont = value;
                ResetTitleSize();
                Invalidate();
            }
        }

        /// <summary>
        /// The title fore color
        /// </summary>
        private Color titleForeColor = Color.Black;
        /// <summary>
        /// Gets or sets the color of the title fore.
        /// </summary>
        /// <value>The color of the title fore.</value>
        [Browsable(true)]

        public Color TitleForeColor
        {
            get { return titleForeColor; }
            set
            {
                titleForeColor = value;
                Invalidate();
            }
        }
        /// <summary>
        /// The items
        /// </summary>
        private FunelChartItem[] items;
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        [Browsable(true)]

        public FunelChartItem[] Items
        {
            get { return items; }
            set
            {
                items = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The direction
        /// </summary>
        private FunelChartDirection direction = FunelChartDirection.UP;
        /// <summary>
        /// Gets or sets the direction.
        /// </summary>
        /// <value>The direction.</value>
        [Browsable(true)]

        public FunelChartDirection Direction
        {
            get { return direction; }
            set
            {
                direction = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The alignment
        /// </summary>
        private FunelChartAlignment alignment = FunelChartAlignment.Center;
        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        [Browsable(true)]

        public FunelChartAlignment Alignment
        {
            get { return alignment; }
            set
            {
                alignment = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The item text align
        /// </summary>
        private FunelChartAlignment itemTextAlign = FunelChartAlignment.Center;
        /// <summary>
        /// Gets or sets the item text align.
        /// </summary>
        /// <value>The item text align.</value>
        [Browsable(true)]

        public FunelChartAlignment ItemTextAlign
        {
            get { return itemTextAlign; }
            set
            {
                itemTextAlign = value;
                ResetWorkingRect();
                Invalidate();
            }
        }
        /// <summary>
        /// The show value
        /// </summary>
        private bool showValue = false;
        /// <summary>
        /// Gets or sets a value indicating whether [show value].
        /// </summary>
        /// <value><c>true</c> if [show value]; otherwise, <c>false</c>.</value>
        [Browsable(true)]

        public bool ShowValue
        {
            get { return showValue; }
            set
            {
                showValue = value;
                Invalidate();
            }
        }


        /// <summary>
        /// The value format
        /// </summary>
        private string valueFormat = "0.##";
        /// <summary>
        /// Gets or sets the value format.
        /// </summary>
        /// <value>The value format.</value>
        [Browsable(true)]
        public string ValueFormat
        {
            get { return valueFormat; }
            set
            {
                valueFormat = value;
                Invalidate();
            }
        }

        /// <summary>
        /// The m rect working
        /// </summary>
        RectangleF m_rectWorking;
        /// <summary>
        /// The m title size
        /// </summary>
        SizeF m_titleSize = SizeF.Empty;
        /// <summary>
        /// The int split width
        /// </summary>
        int intSplitWidth = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="UCFunnelChart"/> class.
        /// </summary>
        public UCFunnelChart()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            FontChanged += UCFunnelChart_FontChanged;
            Font = new Font("微软雅黑", 8);

            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            SizeChanged += UCFunnelChart_SizeChanged;
            Size = new System.Drawing.Size(150, 150);
            items = new FunelChartItem[0];
            if (!DesignMode)
            {
                items = new FunelChartItem[5];
                for (int i = 0; i < 5; i++)
                {
                    items[i] = new FunelChartItem()
                    {
                        Text = "item" + i,
                        Value = 10 * (i + 1)
                    };
                }
            }
        }

        /// <summary>
        /// Handles the FontChanged event of the UCFunnelChart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void UCFunnelChart_FontChanged(object sender, EventArgs e)
        {
            ResetWorkingRect();
        }

        /// <summary>
        /// Handles the SizeChanged event of the UCFunnelChart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void UCFunnelChart_SizeChanged(object sender, EventArgs e)
        {
            ResetWorkingRect();
        }

        /// <summary>
        /// Resets the working rect.
        /// </summary>
        private void ResetWorkingRect()
        {
            if (itemTextAlign == FunelChartAlignment.Center)
            {
                m_rectWorking = new RectangleF(0, m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10), Width, Height - (m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10)));
            }
            else if (itemTextAlign == FunelChartAlignment.Left)
            {
                float fltMax = 0;
                if (items != null && items.Length > 0)
                {
                    using (Graphics g = CreateGraphics())
                    {
                        fltMax = items.Max(p => g.MeasureString(p.Text, Font).Width);
                    }
                }
                m_rectWorking = new RectangleF(fltMax, m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10), Width - fltMax, Height - (m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10)));
            }
            else
            {
                float fltMax = 0;
                if (items != null && items.Length > 0)
                {
                    using (Graphics g = CreateGraphics())
                    {
                        fltMax = items.Max(p => g.MeasureString(p.Text, Font).Width);
                    }
                }
                m_rectWorking = new RectangleF(0, m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10), Width - fltMax, Height - (m_titleSize.Height == 0 ? 0 : (m_titleSize.Height + 10)));
            }
        }


        Color[] GetListChartsColors
        {
            #region Danh sách màu
            get
            {
                List<Color> list = new List<Color>
                {
                    Color.FromArgb(55, 162, 218),
                    Color.FromArgb(50, 197, 233),
                    Color.FromArgb(103, 224, 227),
                    Color.FromArgb(159, 230, 184),
                    Color.FromArgb(255, 219, 92),
                    Color.FromArgb(255, 159, 127),
                    Color.FromArgb(251, 114, 147),
                    Color.FromArgb(224, 98, 174),
                    Color.FromArgb(230, 144, 209),
                    Color.FromArgb(231, 188, 243),
                    Color.FromArgb(157, 150, 245),
                    Color.FromArgb(131, 120, 234),
                    Color.FromArgb(150, 191, 255),
                    Color.FromArgb(243, 67, 54),
                    Color.FromArgb(156, 39, 176),
                    Color.FromArgb(103, 58, 183),
                    Color.FromArgb(63, 81, 181),
                    Color.FromArgb(33, 150, 243),
                    Color.FromArgb(0, 188, 211),
                    Color.FromArgb(3, 169, 244),
                    Color.FromArgb(0, 150, 136),
                    Color.FromArgb(139, 195, 74),
                    Color.FromArgb(76, 175, 80),
                    Color.FromArgb(204, 219, 57),
                    Color.FromArgb(233, 30, 99),
                    Color.FromArgb(254, 234, 59),
                    Color.FromArgb(254, 192, 7),
                    Color.FromArgb(254, 152, 0),
                    Color.FromArgb(255, 87, 34),
                    Color.FromArgb(121, 85, 72),
                    Color.FromArgb(158, 158, 158),
                    Color.FromArgb(96, 125, 139),
                    Color.FromArgb(252, 117, 85),
                    Color.FromArgb(172, 113, 191),
                    Color.FromArgb(115, 131, 253),
                    Color.FromArgb(78, 206, 255),
                    Color.FromArgb(121, 195, 82),
                    Color.FromArgb(255, 163, 28),
                    Color.FromArgb(255, 185, 15),
                    Color.FromArgb(255, 181, 197),
                    Color.FromArgb(255, 110, 180),
                    Color.FromArgb(255, 69, 0),
                    Color.FromArgb(255, 48, 48),
                    Color.FromArgb(154, 205, 50),
                    Color.FromArgb(155, 205, 155),
                    Color.FromArgb(154, 50, 205),
                    Color.FromArgb(131, 111, 255),
                    Color.FromArgb(124, 205, 124),
                    Color.FromArgb(0, 206, 209),
                    Color.FromArgb(0, 178, 238),
                    Color.FromArgb(56, 142, 142)
                };
                return list.ToArray();
            }
            #endregion
        }

        /// <summary>
        /// Resets the size of the title.
        /// </summary>
        private void ResetTitleSize()
        {
            if (string.IsNullOrEmpty(title))
            {
                m_titleSize = SizeF.Empty;
            }
            else
            {
                using (Graphics g = CreateGraphics())
                {
                    m_titleSize = g.MeasureString(title, titleFont);
                    m_titleSize.Height += 20;
                }
            }
            ResetWorkingRect();
        }

        /// <summary>
        /// 引发 <see cref="E:System.Windows.Forms.Control.Paint" /> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.Windows.Forms.PaintEventArgs" />。</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(g);

            if (!string.IsNullOrEmpty(title))
            {
                g.DrawString(title, titleFont, new SolidBrush(titleForeColor), new RectangleF(0, 0, Width, m_titleSize.Height), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            }

            if (items == null || items.Length <= 0)
            {
                g.DrawString("没有数据", Font, new SolidBrush(Color.Black), m_rectWorking, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                return;
            }

            List<FunelChartItem> lstItems;
            if (direction == FunelChartDirection.UP)
            {
                lstItems = items.OrderBy(p => p.Value).ToList();
            }
            else
            {
                lstItems = items.OrderByDescending(p => p.Value).ToList();
            }

            List<RectangleF> lstRects = new List<RectangleF>();
            List<GraphicsPath> lstPaths = new List<GraphicsPath>();
            float maxValue = lstItems.Max(p => p.Value);
            float dblSplitHeight = m_rectWorking.Height / lstItems.Count;
            for (int i = 0; i < lstItems.Count; i++)
            {
                FunelChartItem item = lstItems[i];
                if (item.ValueColor == null || item.ValueColor == Color.Empty || item.ValueColor == Color.Transparent)
                    item.ValueColor = GetListChartsColors[i];

                switch (alignment)
                {
                    case FunelChartAlignment.Left:
                        lstRects.Add(new RectangleF(m_rectWorking.Left, m_rectWorking.Top + dblSplitHeight * i, item.Value / maxValue * m_rectWorking.Width, dblSplitHeight));
                        break;
                    case FunelChartAlignment.Center:
                        lstRects.Add(new RectangleF(m_rectWorking.Left + (m_rectWorking.Width - (item.Value / maxValue * m_rectWorking.Width)) / 2, m_rectWorking.Top + dblSplitHeight * i, item.Value / maxValue * m_rectWorking.Width, dblSplitHeight));
                        break;
                    case FunelChartAlignment.Right:
                        lstRects.Add(new RectangleF(m_rectWorking.Right - (item.Value / maxValue * m_rectWorking.Width), m_rectWorking.Top + dblSplitHeight * i, item.Value / maxValue * m_rectWorking.Width, dblSplitHeight));
                        break;
                }
            }

            for (int i = 0; i < lstRects.Count; i++)
            {
                var rect = lstRects[i];
                GraphicsPath path = new GraphicsPath();
                List<PointF> lstPoints = new List<PointF>();
                if (direction == FunelChartDirection.UP)
                {
                    switch (alignment)
                    {
                        case FunelChartAlignment.Left:
                            lstPoints.Add(new PointF(rect.Left, rect.Top));
                            if (i != 0)
                            {
                                lstPoints.Add(new PointF(lstRects[i - 1].Right, rect.Top));
                            }
                            break;
                        case FunelChartAlignment.Center:
                            if (i == 0)
                            {
                                lstPoints.Add(new PointF(rect.Left + rect.Width / 2, rect.Top));
                            }
                            else
                            {
                                lstPoints.Add(new PointF(lstRects[i - 1].Left, rect.Top));
                                lstPoints.Add(new PointF(lstRects[i - 1].Right, rect.Top));
                            }
                            break;
                        case FunelChartAlignment.Right:
                            if (i == 0)
                            {
                                lstPoints.Add(new PointF(rect.Right, rect.Top));
                            }
                            else
                            {
                                lstPoints.Add(new PointF(rect.Right - lstRects[i - 1].Width, rect.Top));
                                lstPoints.Add(new PointF(rect.Right, rect.Top));
                            }
                            break;
                    }
                    lstPoints.Add(new PointF(rect.Right, rect.Bottom - intSplitWidth));
                    lstPoints.Add(new PointF(rect.Left, rect.Bottom - intSplitWidth));
                }
                else
                {
                    lstPoints.Add(new PointF(rect.Left, rect.Top + intSplitWidth));
                    lstPoints.Add(new PointF(rect.Right, rect.Top + intSplitWidth));
                    switch (alignment)
                    {
                        case FunelChartAlignment.Left:
                            if (i == lstRects.Count - 1)
                            {
                                lstPoints.Add(new PointF(rect.Left, rect.Bottom));
                            }
                            else
                            {
                                lstPoints.Add(new PointF(lstRects[i + 1].Right, rect.Bottom));
                                lstPoints.Add(new PointF(rect.Left, rect.Bottom));
                            }
                            break;
                        case FunelChartAlignment.Center:
                            if (i == lstRects.Count - 1)
                            {
                                lstPoints.Add(new PointF(rect.Left + rect.Width / 2, rect.Bottom));
                            }
                            else
                            {
                                lstPoints.Add(new PointF(lstRects[i + 1].Right, rect.Bottom));
                                lstPoints.Add(new PointF(lstRects[i + 1].Left, rect.Bottom));
                            }
                            break;
                        case FunelChartAlignment.Right:
                            if (i == lstRects.Count - 1)
                            {
                                lstPoints.Add(new PointF(rect.Right, rect.Bottom));
                            }
                            else
                            {
                                lstPoints.Add(new PointF(rect.Right, rect.Bottom));
                                lstPoints.Add(new PointF(lstRects[i + 1].Left, rect.Bottom));
                            }
                            break;
                    }
                }
                path.AddLines(lstPoints.ToArray());
                path.CloseAllFigures();
                // g.DrawPath(new Pen(new SolidBrush(lstItems[i].ValueColor.Value)), path);
                g.FillPath(new SolidBrush(lstItems[i].ValueColor.Value), path);

                //写字
                if (itemTextAlign == FunelChartAlignment.Center)
                {
                    g.DrawString(lstItems[i].Text + (ShowValue ? lstItems[i].Value.ToString("\n" + valueFormat) : ""), Font, new SolidBrush((lstItems[i].TextForeColor == null || lstItems[i].TextForeColor == Color.Empty || lstItems[i].TextForeColor == Color.Transparent) ? Color.White : lstItems[i].TextForeColor.Value), rect, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                else if (itemTextAlign == FunelChartAlignment.Left)
                {
                    g.DrawString(lstItems[i].Text + (ShowValue ? lstItems[i].Value.ToString("\n" + valueFormat) : ""), Font, new SolidBrush((lstItems[i].TextForeColor == null || lstItems[i].TextForeColor == Color.Empty || lstItems[i].TextForeColor == Color.Transparent) ? lstItems[i].ValueColor.Value : lstItems[i].TextForeColor.Value), new RectangleF(0, rect.Top, rect.Left, rect.Height), new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                    g.DrawLine(new Pen(new SolidBrush((lstItems[i].TextForeColor == null || lstItems[i].TextForeColor == Color.Empty || lstItems[i].TextForeColor == Color.Transparent) ? lstItems[i].ValueColor.Value : lstItems[i].TextForeColor.Value)), rect.Left, rect.Top + rect.Height / 2, rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
                }
                else
                {
                    g.DrawString(lstItems[i].Text + (ShowValue ? lstItems[i].Value.ToString("\n" + valueFormat) : ""), Font, new SolidBrush((lstItems[i].TextForeColor == null || lstItems[i].TextForeColor == Color.Empty || lstItems[i].TextForeColor == Color.Transparent) ? lstItems[i].ValueColor.Value : lstItems[i].TextForeColor.Value), new RectangleF(rect.Right, rect.Top, Width - rect.Right, rect.Height), new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    g.DrawLine(new Pen(new SolidBrush((lstItems[i].TextForeColor == null || lstItems[i].TextForeColor == Color.Empty || lstItems[i].TextForeColor == Color.Transparent) ? lstItems[i].ValueColor.Value : lstItems[i].TextForeColor.Value)), rect.Left + rect.Width / 2, rect.Top + rect.Height / 2, rect.Right, rect.Top + rect.Height / 2);
                }
            }
        }
    }
}
