using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Calendar
{
    [DefaultEvent("DateChangedEvent")]
    public class SimpleCalendarControl : Control
    {
        private DateTime _selectedDay;
        public DateTime SelectedDate
        {
            get { return _selectedDay; }
            set { _selectedDay = value; }
        }

        private Color _SelectedDateColor = Color.Red;
        public Color SelectedDateColor
        {
            get { return _SelectedDateColor; }
            set { _SelectedDateColor = value; }
        }

        private Color _todayColor = Color.Blue;
        public Color TodayColor
        {
            get { return _todayColor; }
            set { _todayColor = value; }
        }

        private Color _HoverDateColor = Color.Green;
        public Color HoverDateColor
        {
            get { return _HoverDateColor; }
            set { _HoverDateColor = value; }
        }

        private Color _normalDayColor = Color.Black;
        public Color DayColor
        {
            get { return _normalDayColor; }
            set { _normalDayColor = value; }
        }

        private DateTime _currentMonth;
        private DateTime _minDate = DateTime.MinValue;
        private DateTime _maxDate = DateTime.MaxValue;

        private Rectangle btnPreviousMonth;
        private Rectangle btnNextMonth;
        RectangleF yearTitleBound;

        bool showWeeks = false;

        Padding calendarPadding = new Padding(2, 2, 2, 2);

        private int titleHeight = 30;
        private int daysHeight = 30;

        Color dayOfWeekColor = Color.Black;
        Color headerColor = Color.Black;
        Color weekNumber = Color.Black;


        public Color WeekNumberColor
        {
            get => weekNumber;
            set
            {
                weekNumber = value;
                Invalidate();
            }
        }



        public Color HeaderColor
        {
            get
            {
                return headerColor;
            }
            set
            {
                headerColor = value;
                Invalidate();
            }
        }

        public Color DayOfWeekColor
        {
            get
            {
                return dayOfWeekColor;
            }
            set
            {
                dayOfWeekColor = value;
                Invalidate();
            }
        }



        public bool ShowWeekNumbers
        {
            get => showWeeks;
            set
            {
                showWeeks = value;
                Invalidate();
            }
        }


        public Padding CalendarPadding
        {
            get => calendarPadding;
            set
            {
                calendarPadding = value;
                Invalidate();
            }
        }

        public DateTime ToDay
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                Invalidate();
            }
        }

        public DateTime MaxDate
        {
            get => _maxDate;
            set
            {
                _maxDate = value;
                Invalidate();
            }
        }

        public DateTime MinDate
        {
            get => _minDate;
            set
            {
                _minDate = value;
                Invalidate();
            }
        }

        public int DaysHeight
        {
            get => daysHeight;
            set
            {
                daysHeight = value;
                Invalidate();
            }
        }

        public int TitleHeight
        {
            get => titleHeight;
            set
            {
                titleHeight = value;
                Invalidate();
            }
        }

        public SimpleCalendarControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.UserPaint, true);

            _currentMonth = DateTime.Now;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (!DesignMode)
                Invalidate();
        }


        RectangleF calendarBound;
        Dictionary<RectangleF, int> yearInts = new Dictionary<RectangleF, int>();
        bool showYearChange = false;
        Dictionary<RectangleF, DateTime> listDate = new Dictionary<RectangleF, DateTime>();
        private int startYear = 2020;

        public bool ShowYearChange
        {
            get => showYearChange;
            set
            {
                showYearChange = value;
                Invalidate();
            }
        }

        private void DrawYearCalendar(Graphics g)
        {
            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            calendarBound = new RectangleF(calendarPadding.Left, calendarPadding.Top + titleHeight, Width - calendarPadding.Left - calendarPadding.Right,
                Height - titleHeight - calendarPadding.Top - calendarPadding.Bottom);
            startYear = _currentMonth.Year - 4;

            float x = calendarBound.X;
            float y = calendarBound.Y;
            float cellWidth = calendarBound.Width / 4; // 4 columns
            float cellHeight = (calendarBound.Height - 30) / 3; // 3 rows

            using (Font font = new Font("Arial", 10))
            using (Brush headerBrush = new SolidBrush(HeaderColor))
            using (Brush yearBrush = new SolidBrush(DayColor))
            {
                g.DrawString($"{startYear} - {startYear + 9}", font, headerBrush, new RectangleF(btnPreviousMonth.Width, y, calendarBound.Width - btnNextMonth.Width, titleHeight), stringFormat);

                y += titleHeight + 10;

                for (int i = 0; i < 12; i++)
                {
                    int row = i / 4;
                    int col = i % 4;
                    int year = startYear - 1 + i; // Adjust the year range
                    string yearText = year.ToString();

                    RectangleF cellRect = new RectangleF(x + col * cellWidth, y + row * cellHeight, cellWidth, cellHeight);
                    bool isCurrentYear = year == DateTime.Now.Year;

                    using (Brush brush = new SolidBrush(cellRect.Contains(PointToClient(MousePosition)) ? HoverDateColor : isCurrentYear ? TodayColor : DayColor))
                    {
                        g.FillRectangle(brush, cellRect);
                        g.DrawString(yearText, font, Brushes.White, cellRect, stringFormat);
                        yearInts[cellRect] = year;
                    }
                }
            }
        }


        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!DesignMode)
                {
                    if (showYearChange == false)
                    {
                        if (btnPreviousMonth.Contains(e.Location))
                        {
                            _currentMonth = _currentMonth.AddMonths(-1);
                            Invalidate();
                        }
                        if (btnNextMonth.Contains(e.Location))
                        {
                            _currentMonth = _currentMonth.AddMonths(1);
                            Invalidate();
                        }
                        if (listDate.Count > 0)
                        {
                            foreach (var item in listDate)
                            {
                                if (item.Key.Contains(e.Location))
                                {
                                    if (item.Value >= MinDate && item.Value <= MaxDate)
                                    {
                                        SelectedDate = item.Value;
                                        Invalidate();
                                        DateTime Start = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 0, 0, 0);
                                        DateTime St = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, 23, 59, 59);
                                        DateChanged?.Invoke(this, new DateRangeEventArgs(Start, St));
                                    }
                                    break;
                                }
                            }
                        }


                    }
                    if (showYearChange == true)
                    {
                        foreach (var item in yearInts)
                        {
                            if (item.Key.Contains(e.Location))
                            {
                                _currentMonth = new DateTime(item.Value, _currentMonth.Month, 1);
                                showYearChange = false;
                                Invalidate();
                                break;
                            }
                        }
                    }

                    if (yearTitleBound.Contains(e.Location))
                    {
                        showYearChange = !showYearChange;
                        Invalidate();
                    }
                }
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            Invalidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (showYearChange == false)
            {
                DrawNavigationButtons(g);
                DrawMonthCalendar(g);
            }
            if (showYearChange == true)
            {
                DrawYearCalendar(g);
            }

            using (var pen = new Pen(new SolidBrush(Color.Black), 1) { Alignment = System.Drawing.Drawing2D.PenAlignment.Inset })
                g.DrawRectangle(pen, 1, 1, Width - 1, Height - 1);
        }

        void DrawNavigationButtons(Graphics g)
        {
            Font font = new Font("Webdings", 12);

            string previousMonth = "3";
            string nextMonth = "4";

            SizeF previousSize = g.MeasureString(previousMonth, font);
            SizeF nextSize = g.MeasureString(nextMonth, font);

            float x = 0;
            float y = 0;

            using (var brush = new SolidBrush(Color.Black))
            {
                btnPreviousMonth = new Rectangle((int)x, (int)y, (int)previousSize.Width, (int)previousSize.Height);
                g.DrawString(previousMonth, font, brush, x, y);

                x = Width - nextSize.Width - 2;
                btnNextMonth = new Rectangle((int)x, (int)y, (int)nextSize.Width, (int)nextSize.Height);
                g.DrawString(nextMonth, font, brush, x, y);
            }

        }


        #region DrawMonthCalendar

        private void DrawMonthCalendar(Graphics g)
        {
            Point selectDayPo = PointToClient(Cursor.Position);
            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            DateTime firstDayOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);

            DateTime previousMonth = firstDayOfMonth.AddMonths(-1);
            int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);

            int dayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            int alphaDayHint = 100;
            int numberWeekOffset = showWeeks ? 30 : 0;
            int daysCalen = 0;

            calendarBound = new RectangleF(
                calendarPadding.Left,
                calendarPadding.Top + titleHeight + daysHeight,
                Width - calendarPadding.Left - calendarPadding.Right,
                Height - titleHeight - daysHeight - calendarPadding.Top - calendarPadding.Bottom
            );

            float x = calendarBound.X + numberWeekOffset;
            float y = 0;

            yearTitleBound = new RectangleF(btnPreviousMonth.Width, calendarPadding.Top, btnNextMonth.Location.X - btnPreviousMonth.Width, titleHeight);

            float dayWidth = (calendarBound.Width - numberWeekOffset) / 7;
            float dayHeight = (calendarBound.Height - 1) / 6;

            using (Font font = new Font("Arial", 10))
            using (Brush headerBrush = new SolidBrush(HeaderColor))
            using (Brush dayOfWeekBrush = new SolidBrush(DayOfWeekColor))
            using (Brush weekNumberBrush = new SolidBrush(weekNumber))
            using (Pen weekNumberPen = new Pen(new SolidBrush(WeekNumberColor)))
            {
                //g.DrawString(firstDayOfMonth.ToString("MMMM") + " " + _currentMonth.Year, font, headerBrush,
                //    new RectangleF(btnPreviousMonth.Width, calendarPadding.Top, calendarBound.Width - btnNextMonth.Width, titleHeight), stringFormat);

                g.FillRectangle(new SolidBrush(Color.Pink), yearTitleBound);
                g.DrawString(firstDayOfMonth.ToString("MMMM") + " " + _currentMonth.Year, font, headerBrush, yearTitleBound, stringFormat);

                y += titleHeight;

                string[] daysOfWeek = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

                for (int i = 0; i < daysOfWeek.Length; i++)
                {
                    g.DrawString(daysOfWeek[i], font, dayOfWeekBrush, new RectangleF(x + i * dayWidth, y, dayWidth, daysHeight), stringFormat);
                }

                y += daysHeight;

                if (showWeeks)
                {
                    float weekNumX = calendarPadding.Left;
                    float weekNumY = y;
                    int weekNum = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(firstDayOfMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

                    for (int i = 0; i < 6; i++) // Assuming there are at most 6 rows of weeks
                    {
                        g.DrawString(weekNum.ToString(), font, weekNumberBrush, new RectangleF(weekNumX, weekNumY, numberWeekOffset, dayHeight), stringFormat);
                        weekNumY += dayHeight;
                        weekNum++;
                    }

                    g.DrawLine(weekNumberPen, weekNumX + numberWeekOffset - 5, y, weekNumX + numberWeekOffset - 5, weekNumY);
                }

                x = calendarBound.X + numberWeekOffset;

                for (int i = 0; i < dayOfWeek; i++)
                {
                    if (showDaysOutOfMonth)
                    {
                        DateTime date = previousMonth.AddDays(daysInPreviousMonth - dayOfWeek + i);
                        listDate[new RectangleF(x, y, dayWidth, dayHeight)] = date;
                    }
                    x += dayWidth;
                    daysCalen++;
                }

                for (int i = 1; i <= daysInMonth; i++)
                {
                    DateTime date = new DateTime(_currentMonth.Year, _currentMonth.Month, i);
                    listDate[new RectangleF(x, y, dayWidth, dayHeight)] = date;
                    x += dayWidth;
                    daysCalen++;

                    if (dayOfWeek >= 6)
                    {
                        dayOfWeek = 0;
                        x = calendarBound.X + numberWeekOffset;
                        y += dayHeight;
                    }
                    else
                    {
                        dayOfWeek++;
                    }
                }

                if (showDaysOutOfMonth)
                {
                    for (int i = 1; daysCalen < 42; i++)
                    {
                        DateTime date = new DateTime(_currentMonth.Year, _currentMonth.Month, 1).AddMonths(1).AddDays(i - 1);
                        if (date <= MaxDate)
                        {
                            listDate[new RectangleF(x, y, dayWidth, dayHeight)] = date;
                            x += dayWidth;
                            daysCalen++;

                            if (dayOfWeek >= 6)
                            {
                                dayOfWeek = 0;
                                x = calendarBound.X + numberWeekOffset;
                                y += dayHeight;
                            }
                            else
                            {
                                dayOfWeek++;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            foreach (var item in listDate)
            {
                bool isCurrentMonth = item.Value.Month == _currentMonth.Month;
                bool isHover = item.Key.Contains(selectDayPo) && !DesignMode;
                bool isToday = item.Value == DateTime.Today;
                bool isSelected = item.Value == SelectedDate;

                using (Brush normalBrush = new SolidBrush(isSelected ? SelectedDateColor : isToday ? TodayColor : isHover ? HoverDateColor : isCurrentMonth == false ? Color.FromArgb(alphaDayHint, DayColor) : DayColor))
                {
                    g.FillRectangle(normalBrush, item.Key);
                    g.DrawString(item.Value.Day.ToString(), Font, Brushes.White, item.Key, stringFormat);
                }
            }
        }

        #endregion


        public event EventHandler<DateRangeEventArgs> DateChangedEvent
        {
            add { DateChanged += value; }
            remove { DateChanged -= value; }
        }

        private event EventHandler<DateRangeEventArgs> DateChanged;

        bool showDaysOutOfMonth = true;
        public bool ShowDaysOutOfMonth
        {
            get => showDaysOutOfMonth;
            set
            {
                showDaysOutOfMonth = value;
                Invalidate();
            }
        }
    }


}
