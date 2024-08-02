using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Calendar
{
    [DefaultEvent("DateChangedEvent")]
    public class CalendarControl : Control
    {
        private DateTime currentMonth;
        private DateTime selectedDate;
        DateTime _minDate = new DateTime(1753, 1, 1);
        DateTime _maxDate = DateTime.MaxValue;

        public CalendarControl()
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            this.UpdateStyles();
            currentMonth = DateTime.Today;
            selectedDate = DateTime.Today;

            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += (sender, e) => Invalidate();
         
        }


        int titleHeight = 30;
        Padding calendarPadding = new Padding(5, 5, 5, 5);
        int daysHeight = 30;
        Font dayFont = new Font("Arial", 10);
        Font numberDayFont = new Font("Arial", 10);
        Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);


        Color titleColor = Color.FromArgb(31, 34, 41);
        Color borderColor = Color.Gray;
        Color calendarColor = Color.FromArgb(56, 67, 87);
        Color dayOfMonthColor = Color.LightGray;
        Color daysColor = Color.FromArgb(66, 136, 231);
        Color selectedDateColor = Color.FromArgb(67, 164, 80);
        Color selectDayColor = Color.FromArgb(67, 164, 80);
        Color hoverDateColor = Color.FromArgb(66, 136, 231);
        Color monthColor = Color.WhiteSmoke;
        Color navigationButtonColor = Color.FromArgb(66, 136, 231);
        Color timeColor = Color.FromArgb(66, 136, 231);

        bool showTime = false;
        Timer timer;

        public bool ShowTime
        {
            get { return showTime; }
            set
            {
                showTime = value;
                timer.Enabled = value;
                Invalidate();
            }
        }

        public Color TimeColor
        {
            get { return timeColor; }
            set { timeColor = value; Invalidate(); }
        }


        public DateTime ToDay
        {
            get { return currentMonth; }
            set { currentMonth = value; Invalidate(); }
        }

        public DateTime MinDate
        {
            get { return _minDate; }
            set { _minDate = value; Invalidate(); }
        }

        public DateTime MaxDate
        {
            get { return _maxDate; }
            set { _maxDate = value; Invalidate(); }
        }

        public Color NavigationButtonColor
        {
            get { return navigationButtonColor; }
            set { navigationButtonColor = value; Invalidate(); }
        }

        public Padding CalendarPadding
        {
            get { return calendarPadding; }
            set { calendarPadding = value; Invalidate(); }
        }

        public int TitleHeight
        {
            get { return titleHeight; }
            set { titleHeight = value; Invalidate(); }
        }

        public int DaysHeight
        {
            get { return daysHeight; }
            set { daysHeight = value; Invalidate(); }
        }

        public Font DaysFont
        {
            get { return dayFont; }
            set { dayFont = value; Invalidate(); }
        }

        public Font NumberDayFont
        {
            get { return numberDayFont; }
            set { numberDayFont = value; Invalidate(); }
        }

        public Color TitleColor
        {
            get { return titleColor; }
            set { titleColor = value; Invalidate(); }
        }


        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        public Color CalendarColor
        {
            get { return calendarColor; }
            set { calendarColor = value; Invalidate(); }
        }

        public Color DayOfMonthColor
        {
            get { return dayOfMonthColor; }
            set { dayOfMonthColor = value; Invalidate(); }
        }

        public Color SelectedDateColor
        {
            get { return selectedDateColor; }
            set {selectedDateColor = value; Invalidate(); }
        }

        public Color SelectDayColor
        {
            get { return selectDayColor; }
            set { selectDayColor = value; Invalidate(); }
        }

        public Color DaysColor
        {
            get { return daysColor; }
            set { daysColor = value; Invalidate(); }
        }

        public Color HoverDateColor
        {
            get { return hoverDateColor; }
            set { hoverDateColor = value; Invalidate(); }
        }

        public Color MonthColor
        {
            get
            {
                return monthColor;
            }
            set
            {
                monthColor = value;
                Invalidate();
            }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; Invalidate(); }
        }

        public Font HeaderFont
        {
            get
            {
                return headerFont;
            }
            set
            {
                headerFont = value;
                Invalidate();
            }
        }

        bool showWeekNumber = false;

        public bool ShowWeekNumbers
        {
            get { return showWeekNumber; }
            set { showWeekNumber = value; Invalidate(); }
        }

        Font weekNumberFont = new Font("Arial", 10);
        public Font WeekNumberFont
        {
            get { return weekNumberFont; }
            set { weekNumberFont = value; Invalidate(); }
        }

        int numberWeekOffset = 0;

        Color weekNumberColor = Color.FromArgb(66, 136, 231);

        public Color WeekNumberColor
        {
            get { return weekNumberColor; }
            set { weekNumberColor = value; Invalidate(); }
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); 
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            DrawCalendar(e.Graphics);
        }


        RectangleF prevMonthButton;
        RectangleF nextMonthButton;
        Dictionary<RectangleF, DateTime> dateRects = new Dictionary<RectangleF, DateTime>();


        private void DrawCalendar(Graphics g)
        {
            RectangleF dayCalendarBound = new RectangleF(calendarPadding.Left, titleHeight + calendarPadding.Top, Width - calendarPadding.Right - calendarPadding.Left,
              Height - titleHeight - calendarPadding.Top - calendarPadding.Bottom);

            using (var titleBru = new SolidBrush(titleColor)) g.FillRectangle(titleBru, new Rectangle(0, 0, Width, Height));

            float timeWidth = ShowTime ? g.MeasureString(DateTime.Now.ToString("HH:mm:ss"), headerFont).Width : dayCalendarBound.Left;

            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            if (ShowTime)
                using (var timeBru = new SolidBrush(timeColor))
                    g.DrawString(DateTime.Now.ToString("HH:mm:ss"), headerFont, timeBru,
                                           new RectangleF(2 + dayCalendarBound.Left, 5, timeWidth, titleHeight), stringFormat);

            using (var monthBru = new SolidBrush(monthColor))
            {
                var monthRe = new RectangleF(2 + timeWidth, 5, dayCalendarBound.Width - (ShowTime ? prevMonthButton.Width * 2 : 0), titleHeight);

                switch (MonthDisplay)
                {
                    case MonthDisplayType.Name:
                        g.DrawString(currentMonth.ToString("MMMM yyyy"), headerFont, monthBru, monthRe, stringFormat);
                        break;
                    case MonthDisplayType.Number:
                        g.DrawString(currentMonth.ToString("yyyy/MM"), headerFont, monthBru, monthRe, stringFormat);
                        break;
                }

                //g.DrawString(currentMonth.ToString("yyyy/MM"), headerFont, monthBru, monthRe, stringFormat);
            }

            DrawNavigationButtons(g);


            using (var calenBru = new SolidBrush(calendarColor))
                g.FillRectangle(calenBru, dayCalendarBound);

            numberWeekOffset = showWeekNumber ? 30 : 0;

            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            using (var daysBru = new SolidBrush(daysColor))
                for (int i = 0; i < days.Length; i++)
                {
                    RectangleF dayRect = new RectangleF(i * ((dayCalendarBound.Width - numberWeekOffset) / days.Length) + numberWeekOffset + calendarPadding.Left, titleHeight + calendarPadding.Top, (dayCalendarBound.Width - numberWeekOffset) / days.Length, daysHeight);
                    g.DrawString(days[i], dayFont, daysBru, dayRect, stringFormat);

                    //g.DrawRectangle(new Pen(Brushes.AliceBlue, 2), dayRect.X , dayRect.Y, dayRect.Width, dayRect.Height);
                }

            // Draw line
            using (var pen = new Pen(navigationButtonColor, 1))
                g.DrawLine(pen, new Point((int)dayCalendarBound.X + numberWeekOffset + 5, titleHeight + daysHeight), new Point((int)dayCalendarBound.Width, titleHeight + daysHeight));

            DrawNumberDay(g, dayCalendarBound);

            //if (dayCalendarBound.Contains(PointToClient(MousePosition)) && !DesignMode)
            //    PaintRippleEffectWhenMouseMove(g);
        }

        //void PaintRippleEffectWhenMouseMove(Graphics g)
        //{
        //    Point point = PointToClient(MousePosition);
        //    int sizeCur = 50;
        //    using (GraphicsPath path = new GraphicsPath())
        //    {
        //        path.AddEllipse(point.X - sizeCur / 2, point.Y - sizeCur / 2, sizeCur, sizeCur);

        //        using (PathGradientBrush effectBrush = new PathGradientBrush(path))
        //        {
        //            effectBrush.CenterColor = Color.FromArgb(50, glowColor);
        //            effectBrush.SurroundColors = new Color[] { Color.Transparent };

        //            g.FillPath(effectBrush, path);
        //        }
        //    }

        //}



        private void DrawNavigationButtons(Graphics g)
        {
            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Point point = PointToClient(MousePosition);
            int alpha = 100;

            using (Font navFont = new Font("Webdings", 10, FontStyle.Bold))
            {
                SizeF buttonSize = g.MeasureString("3", navFont);

                nextMonthButton = new RectangleF(Width - buttonSize.Width - 5, 10, buttonSize.Width, buttonSize.Height);
                prevMonthButton = new RectangleF(Width - buttonSize.Width * 2 - 10, 10, buttonSize.Width, buttonSize.Height);

                using (var nagBrush = new SolidBrush(prevMonthButton.Contains(point) ? Color.FromArgb(alpha, navigationButtonColor) : navigationButtonColor))
                    g.DrawString("3", navFont, nagBrush, prevMonthButton, stringFormat);

                using (var nagBrush = new SolidBrush(nextMonthButton.Contains(point) ? Color.FromArgb(alpha, navigationButtonColor) : navigationButtonColor))
                    g.DrawString("4", navFont, nagBrush, nextMonthButton, stringFormat);
            }

        }

        private void DrawNumberDay(Graphics g, RectangleF dayCalendarBound)
        {
          
            // Adjust bounds
            dayCalendarBound = new RectangleF(dayCalendarBound.X, dayCalendarBound.Y + titleHeight, dayCalendarBound.Width, dayCalendarBound.Height - titleHeight - calendarPadding.Top - calendarPadding.Bottom);

            // Initialize date variables
            DateTime firstDayOfMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);
            DateTime currentDay = firstDayOfMonth;
            int daysInMonth = DateTime.DaysInMonth(firstDayOfMonth.Year, firstDayOfMonth.Month);
            int startDayOffset = (int)firstDayOfMonth.DayOfWeek;
            DateTime previousMonth = firstDayOfMonth.AddMonths(-1);
            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

            // Calculate day dimensions
            float dayWidth = (dayCalendarBound.Width - numberWeekOffset) / 7 * 0.9f;
            float dayHeight = dayCalendarBound.Height / 6 * 0.9f;

            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Draw week numbers if enabled
            if (ShowWeekNumbers)
            {
                float weekNumX = dayCalendarBound.Left;
                int weekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(firstDayOfMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
                using (var weekBrush = new SolidBrush(WeekNumberColor))
                {
                    for (int i = 0; i < 6; i++) // Assuming there are at most 6 rows of weeks
                    {
                        float weekNumY = dayCalendarBound.Top + i * dayCalendarBound.Height / 6 + (dayCalendarBound.Height / 6 - dayHeight) / 2;
                        g.DrawString(weekNum.ToString(), weekNumberFont, weekBrush, new RectangleF(weekNumX, weekNumY, numberWeekOffset - 1, dayHeight), stringFormat);
                        weekNum++;
                    }
                    using (var pen = new Pen(weekBrush, 1))
                        g.DrawLine(pen, weekNumX + numberWeekOffset - 5, dayCalendarBound.Top, weekNumX + numberWeekOffset - 5, dayCalendarBound.Bottom);
                }
            }

            // Draw days
            for (int week = 0; week < 6; week++)
            {
                for (int day = 0; day < 7; day++)
                {
                    float x = numberWeekOffset + dayCalendarBound.Left + day * (dayCalendarBound.Width - numberWeekOffset) / 7 + ((dayCalendarBound.Width - numberWeekOffset) / 7 - dayWidth) / 2;
                    float y = dayCalendarBound.Top + week * dayCalendarBound.Height / 6 + (dayCalendarBound.Height / 6 - dayHeight) / 2;
                    RectangleF dayRect = new RectangleF(x, y, dayWidth, dayHeight);

                    string dayNumber;
                    DateTime liDate;

                    if (week == 0 && day < startDayOffset)
                    {
                        dayNumber = (daysInPreviousMonth - startDayOffset + day + 1).ToString();
                        liDate = new DateTime(previousMonth.Year, previousMonth.Month, daysInPreviousMonth - startDayOffset + day + 1);
                    }
                    else if (currentDay.Day <= daysInMonth)
                    {
                        dayNumber = currentDay.Day.ToString();
                        liDate = currentDay;
                        currentDay = currentDay.AddDays(1);
                    }
                    else
                    {
                        dayNumber = currentDay.Day.ToString();
                        liDate = currentDay;
                        currentDay = currentDay.AddDays(1);
                    }

                    dateRects[dayRect] = liDate;

                    bool isHover = dayRect.Contains(PointToClient(MousePosition)) && !DesignMode;
                    bool isToday = liDate.Date == DateTime.Today.Date;
                    bool isSelected = liDate.Date == selectedDate.Date;
                    bool isCurrentMonth = liDate.Month == currentMonth.Month;
                    Color dayForeColor = isToday ? SelectedDateColor :
                                         isSelected ? selectDayColor :
                                         isHover ? HoverDateColor :
                                         isCurrentMonth ? dayOfMonthColor :
                                         Color.FromArgb(100, dayOfMonthColor);

                    using (var dayForeBrush = new SolidBrush(dayForeColor))
                    {
                        g.DrawString(dayNumber, numberDayFont, dayForeBrush, dayRect, stringFormat);
                        using (var pen = new Pen(dayForeBrush, 1))
                            g.DrawRectangle(pen, Rectangle.Round(dayRect));
                    }
                }
            }
        }


        //Color glowColor = Color.White;
        //public Color GlowColor
        //{
        //    get { return glowColor; }
        //    set { glowColor = value; Invalidate(); }
        //}


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                if (!DesignMode)
                {
                    if (prevMonthButton.Contains(e.Location))
                        currentMonth = currentMonth.AddMonths(-1);

                    if (nextMonthButton.Contains(e.Location))
                        currentMonth = currentMonth.AddMonths(1);

                    if (dateRects.Count > 0)
                    {
                        foreach (var item in dateRects)
                        {
                            if (item.Key.Contains(e.Location) && (item.Value >= MinDate && item.Value <= MaxDate))
                            {
                                selectedDate = item.Value;
                                DateTime Start = new DateTime(selectedDate.Year, SelectedDate.Month, SelectedDate.Day, 0, 0, 0);
                                DateTime St = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 23, 59, 59);
                                DateChanged?.Invoke(this, new DateRangeEventArgs(Start, St));
                                Invalidate();
                                return;
                            }
                        }

                    }

                }

            }


            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Invalidate();
        }

        event EventHandler<DateRangeEventArgs> DateChanged;
        public event EventHandler<DateRangeEventArgs> DateChangedEvent
        {
            add
            {
                DateChanged += value;
            }
            remove
            {
                DateChanged -= value;
            }
        }

        MonthDisplayType monthDisplayType = MonthDisplayType.Number;
        public MonthDisplayType MonthDisplay
        {
            get { return monthDisplayType; }
            set { monthDisplayType = value; Invalidate(); }
        }

    }


    // Thêm dạng enum để chỉnh loại hiển thị tháng: tên hoặc số
    public enum MonthDisplayType
    {
        Number,
        Name
    }

}
