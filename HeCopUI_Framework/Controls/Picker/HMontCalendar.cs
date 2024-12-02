using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HMontCalendar : Control
    {




        private RectangleF TopDateRect;
        private RectangleF WeekRect;

        private List<List<DateRect>> DateRectangles;

        private RectangleF PreviousMonthRect;
        private RectangleF NextMonthRect;
        private RectangleF PreviousYearRect;
        private RectangleF NextYearRect;

        private DateTime CurrentDate;
        public DateTime Date { get { return CurrentDate; } set { CurrentDate = value; Invalidate(); } }


        private int DateRectDefaultSize;
        private int HoverX;
        private int HoverY;
        private int SelectedX;
        private int SelectedY;

        private bool previousYearHovered;
        private bool previousMonthHovered;
        private bool nextMonthHovered;
        private bool nextYearHovered;

        #region Events
        public delegate void DateChanged(DateTime newDateTime);
        public event DateChanged onDateChanged;
        #endregion

        #region Mouse
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (DateRectangles[i][j].Drawn)
                    {
                        if (DateRectangles[i][j].Rect.Contains(e.Location))
                        {
                            if (HoverX != i || HoverY != j)
                            {
                                HoverX = i;
                                previousYearHovered = false;
                                nextYearHovered = false;
                                HoverY = j;
                                Invalidate();
                            }
                            return;
                        }
                    }
                }
            }

            if (PreviousYearRect.Contains(e.Location))
            {
                previousYearHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (PreviousMonthRect.Contains(e.Location))
            {
                previousMonthHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (NextMonthRect.Contains(e.Location))
            {
                nextMonthHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (NextYearRect.Contains(e.Location))
            {
                nextYearHovered = true;
                HoverX = -1;
                Invalidate();
                return;
            }
            if (HoverX >= 0 || previousYearHovered || previousMonthHovered || nextMonthHovered || nextYearHovered)
            {
                HoverX = -1;
                previousYearHovered = false;
                previousMonthHovered = false;
                nextMonthHovered = false;
                nextYearHovered = false;
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (HoverX >= 0)
            {
                SelectedX = HoverX;
                SelectedY = HoverY;
                CurrentDate = DateRectangles[SelectedX][SelectedY].Date;
                Invalidate();
                if (onDateChanged != null)
                {
                    onDateChanged(CurrentDate);
                }
                return;
            }

            if (PreviousYearRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddYears(-1));
            if (PreviousMonthRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddMonths(-1));
            if (NextMonthRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddMonths(1));
            if (NextYearRect.Contains(e.Location))
                CurrentDate = FirstDayOfMonth(CurrentDate.AddYears(1));
            CalculateRectangles();
            Invalidate();
            if (onDateChanged != null)
            {
                onDateChanged(CurrentDate);
            }
            TimeTitle = CurrentDate;
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoverX = -1;
            HoverY = -1;
            previousYearHovered = false;
            previousMonthHovered = false;
            nextMonthHovered = false;
            nextYearHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        #endregion

        private void CalculateRectangles()
        {
            //日期位置List
            DateRectangles = new List<List<DateRect>>();
            for (int i = 0; i < 7; i++)
            {
                DateRectangles.Add(new List<DateRect>());
                for (int j = 0; j < 7; j++)
                {
                    DateRectangles[i].Add(new DateRect(new RectangleF(15 + (j * (Width - 30) / 7), WeekRect.Y + WeekRect.Height + (i * DateRectDefaultSize), DateRectDefaultSize, DateRectDefaultSize)));
                }
            }
            DateTime FirstDay = FirstDayOfMonth(CurrentDate);
            var temp = 0;
            for (int i = FirstDay.DayOfWeek == DayOfWeek.Sunday ? 6 : (int)FirstDay.DayOfWeek - 1; i > 0; i--, temp++)
            {
                DateRectangles[temp / 7][temp % 7].Drawn = false;
                DateRectangles[temp / 7][temp % 7].Date = FirstDay.AddDays(-i);
            }
            for (DateTime date = FirstDay; date <= LastDayOfMonth(CurrentDate); date = date.AddDays(1), temp++)
            {
                if (date.DayOfYear == CurrentDate.DayOfYear && date.Year == CurrentDate.Year)
                {
                    SelectedX = temp / 7;
                    SelectedY = temp % 7;
                }
                DateRectangles[temp / 7][temp % 7].Drawn = true;
                DateRectangles[temp / 7][temp % 7].Date = date;
            }
            DateTime LastDay = LastDayOfMonth(CurrentDate);
            for (int i = 0; temp < 42; i++, temp++)
            {
                DateRectangles[temp / 7][temp % 7].Drawn = false;
                DateRectangles[temp / 7][temp % 7].Date = LastDay.AddDays(i + 1);
            }
        }




        private new Font Font = HeCopUI_Framework.Extensions.HFonts.GetFont(Properties.Resources.Roboto_Regular, 10);





        protected override void OnResize(EventArgs e)
        {
            Size = new Size(305, 324);
        }

        public HMontCalendar()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            Size = new Size(305, 324);
            DateRectDefaultSize = (Width - 25) / 7;
            TopDateRect = new RectangleF(20, 5, Width - 35, DateRectDefaultSize);
            WeekRect = new RectangleF(0, TopDateRect.Y + TopDateRect.Height, DateRectDefaultSize, DateRectDefaultSize);

            PreviousYearRect = new RectangleF(10, TopDateRect.Y, 20, DateRectDefaultSize);
            PreviousMonthRect = new RectangleF(35, TopDateRect.Y + 1, 20, DateRectDefaultSize);
            NextMonthRect = new RectangleF(Width - 40, TopDateRect.Y + 1, 20, DateRectDefaultSize);
            NextYearRect = new RectangleF(Width - 25, TopDateRect.Y, 20, DateRectDefaultSize);

            CurrentDate = DateTime.Now;

            HoverX = -1;
            HoverY = -1;
            TimeTitle = DateTime.Now;
            CalculateRectangles();
        }

        private Color borderColor = Color.DodgerBlue;
        private Color previousButtonHover = Global.PrimaryColors.BackHoverColor1;
        private Color PlaceholderText = Color.Gray;
        private Color MainText = Color.FromArgb(51, 51, 51);
        private Color toDayColor = Color.DodgerBlue;

        public Color TitleColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value; Invalidate();
            }
        }

        public Color NormalDayColor
        {
            get { return MainText; }
            set
            {
                MainText = value; Invalidate();
            }
        }

        public Color PreviousButtonColor
        {
            get { return previousButtonHover; }
            set
            {
                previousButtonHover = value; Invalidate();
            }
        }

        public Color PlaceHolderText
        {
            get { return PlaceholderText; }
            set
            {
                PlaceholderText = value; Invalidate();
            }
        }

        public Color ToDayColor
        {
            get { return toDayColor; }
            set
            {
                toDayColor = value; Invalidate();
            }
        }



        private TextRenderingHint textRenderingHint = TextRenderingHint.ClearTypeGridFit;
        public TextRenderingHint TextRendering
        {
            get { return textRenderingHint; }
            set
            {
                textRenderingHint = value; Invalidate();
            }
        }

        private Color daySelected = Global.PrimaryColors.BackPressColor1;
        private Color dayHover = Global.PrimaryColors.BackHoverColor1;
        public Color DaySelectedColor
        {
            get { return daySelected; }
            set
            {
                daySelected = value; Invalidate();
            }
        }

        public Color DayHoverColor
        {
            get { return dayHover; }
            set
            {
                dayHover = value; Invalidate();
            }
        }


        private Color yearmontTitleColor = Color.White;
        public Color YearMonthColor
        {
            get { return yearmontTitleColor; }
            set
            {
                yearmontTitleColor = value; Invalidate();
            }
        }

        void TitleTime(Graphics graphics, StringFormat SF)
        {
            SizeF a = graphics.MeasureString(string.Format("{0}/ {1,2}", TimeTitle.Year, TimeTitle.Month).ToString(), new Font(Font, FontStyle.Bold));
            graphics.FillPath(new SolidBrush(TitleColor), HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF((Width - a.Width) / 2, TopDateRect.Top + 5, a.Width + 10, a.Height + 10), 4, 0));
            graphics.DrawString(string.Format("{0}/ {1}", TimeTitle.Year, TimeTitle.Month), new Font(Font, FontStyle.Bold), new SolidBrush(yearmontTitleColor), TopDateRect, SF);

        }



        DateTime TimeTitle = new DateTime();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var graphics = e.Graphics;
            Helper.GraphicsHelper.SetHightGraphics(graphics);
            graphics.TextRenderingHint = TextRendering;



            var bg = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, 1, 1);
            graphics.FillPath(new SolidBrush(Color.White), bg);
            //graphics.DrawPath(new Pen(borderColor, borderThickness) { Alignment= PenAlignment.Inset }, bg);

            var SF = new StringFormat();
            Helper.TextHelper.SetStringAlign(SF, ContentAlignment.MiddleCenter);

            TitleTime(graphics, SF);
            graphics.DrawString("7", new Font("webdings", 12f), new SolidBrush(previousYearHovered ? previousButtonHover : PlaceholderText), PreviousYearRect, SF);
            graphics.DrawString("3", new Font("webdings", 12f), new SolidBrush(previousMonthHovered ? previousButtonHover : PlaceholderText), PreviousMonthRect, SF);
            graphics.DrawString("4", new Font("webdings", 12f), new SolidBrush(nextMonthHovered ? previousButtonHover : PlaceholderText), NextMonthRect, SF);
            graphics.DrawString("8", new Font("webdings", 12f), new SolidBrush(nextYearHovered ? previousButtonHover : PlaceholderText), NextYearRect, SF);



            DateTime FirstDay = FirstDayOfMonth(CurrentDate);
            for (int i = 0; i < 7; i++)
            {
                string strName;
                int DayOfWeek = (int)DateTime.Now.DayOfWeek - 1;
                if (DayOfWeek < 0) DayOfWeek = 6;

                strName = DateTime.Now.AddDays(-DayOfWeek + i).ToString("ddd");
                graphics.DrawString(strName, Font, new SolidBrush(MainText), new RectangleF(15 + i * (Width - 30) / 7, WeekRect.Y, WeekRect.Width, WeekRect.Height), SF);
            }

            //绘制分割线
            graphics.DrawLine(new Pen(borderColor, 0.5f), 10, WeekRect.Y + WeekRect.Height, Width - 10, WeekRect.Y + WeekRect.Height);

            //绘制日期
            //DateTime FirstDay = FirstDayOfMonth(CurrentDate);
            for (int i = 0; i < 42; i++)
            {
                var tempDate = DateRectangles[i / 7][i % 7];
                var brush = new SolidBrush(MainText);
                //突出显示鼠标所指
                if (HoverX == i / 7 && HoverY == i % 7)
                {
                    var rect1 = tempDate.Rect;
                    var bg1 = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(rect1.X + 2, rect1.Y + 2, rect1.Width - 4, rect1.Width - 4), 3);
                    graphics.FillPath(new SolidBrush(dayHover), bg1);
                    //graphics.FillRectangle(new SolidBrush(ThemeColors.ThreeLevelBorder), new RectangleF(rect1.X + 3, rect1.Y + 3, rect1.Width - 6, rect1.Width - 6));

                }
                //突出显示今天
                if (tempDate.Date == DateTime.Today)
                {
                    brush = new SolidBrush(toDayColor);

                }


                //突出显示所选日期
                // Date
                if (tempDate.Date == Date)
                {
                    var rect1 = tempDate.Rect;
                    var bg1 = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(rect1.X + 2, rect1.Y + 2, rect1.Width - 4, rect1.Width - 4), 3);
                    graphics.FillPath(new SolidBrush(daySelected), bg1);

                    //graphics.FillRectangle(new SolidBrush(ThemeColors.PrimaryColor), new RectangleF(rect1.X+3,rect1.Y+3,rect1.Width-6,rect1.Width-6));
                    brush = new SolidBrush(Color.White);
                }
                graphics.DrawString(DateRectangles[i / 7][i % 7].Date.Day.ToString(), Font, DateRectangles[i / 7][i % 7].Drawn ? brush : new SolidBrush(Color.DimGray), DateRectangles[i / 7][i % 7].Rect, SF);

                if (HoverX == i / 7 && HoverY == i % 7)
                    graphics.DrawString(DateRectangles[i / 7][i % 7].Date.Day.ToString(), Font,
                      new SolidBrush(HoverDayColor), DateRectangles[i / 7][i % 7].Rect, SF);

                graphics.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1), ClientRectangle);
            }
        }

        public Color HoverDayColor { get; set; } = Color.White;

        public DateTime FirstDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }

        public DateTime LastDayOfMonth(DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        }

        private class DateRect
        {
            public RectangleF Rect;
            public bool Drawn = false;
            public DateTime Date;

            public DateRect(RectangleF pRect)
            {
                Rect = pRect;
            }
        }
    }
}
