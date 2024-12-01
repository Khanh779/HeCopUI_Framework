﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.ScrollBar
{
    [DefaultEvent("Scroll")]
    public class HScrollBar : Control
    {
        private bool isDragging = false;
        private float dragOffsetX = 0;
        private int _min = 0;
        private int _max = 100;
        private int _value = 0;
        private int maxChange = 10;
        private int minChange = 1;
        private RectangleF thumbBound = RectangleF.Empty;
        private RectangleF leftArrowBound = RectangleF.Empty;
        private RectangleF rightArrowBound = RectangleF.Empty;

        public event ScrollEventHandler Scroll;

        protected virtual void OnScrollValueChanged(object sender, ScrollEventArgs e)
        {
            Scroll?.Invoke(this, e);
        }

        public int LargeChange
        {
            get { return maxChange; }
            set { maxChange = value; Invalidate(); }
        }

        public int SmallChange
        {
            get { return minChange; }
            set
            {
                if (value > maxChange)
                {
                    minChange = maxChange;
                }
                else if (value < _min)
                {
                    minChange = _min;
                }
                else
                {
                    minChange = value;
                }
                Invalidate();
            }
        }

        public int Minimum
        {
            get { return _min; }
            set
            {
                _min = value;
                Invalidate();
            }
        }

        public int Maximum
        {
            get { return _max; }
            set
            {
                if (value <= _value)
                {
                    _value = value;
                }
                else
                    _max = value;
                Invalidate();
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (value <= _min)
                    _value = _min;
                else if (value >= _max - maxChange + 1)
                    _value = _max - maxChange + 1;
                else
                    _value = value;

                OnScrollValueChanged(this, new ScrollEventArgs(ScrollEventType.ThumbTrack, _value));
                Invalidate();
            }
        }

        public HScrollBar()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.ResizeRedraw |
               ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);

            Width = 100;
            Height = 10;
            BackColor = Color.Transparent;
        }

        private Color thumbColor = Color.FromArgb(102, 100, 252);
        public Color ThumbColor
        {
            get { return thumbColor; }
            set { thumbColor = value; Invalidate(); }
        }

        private Color barColor = Color.FromArgb(56, 67, 87);
        public Color BarColor
        {
            get { return barColor; }
            set { barColor = value; Invalidate(); }
        }

        private Padding thumbPadding = new Padding(0);
        public Padding ThumbPadding
        {
            get { return thumbPadding; }
            set { thumbPadding = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            // Draw the scrollbar track
            using (Brush barBrush = new SolidBrush(BarColor))
                e.Graphics.FillRectangle(barBrush, new Rectangle(0, 0, Width, Height));

            // Draw left arrow
            using (var arrowBrush = new SolidBrush(ThumbColor))
            {
                float arrowSize = Height * 0.2f;
                leftArrowBound = new RectangleF(0, 0, Height, Height);
                e.Graphics.FillPolygon(arrowBrush, new PointF[]
                {
                    new PointF(leftArrowBound.Left + arrowSize, leftArrowBound.Height / 2),
                    new PointF(leftArrowBound.Right - arrowSize, leftArrowBound.Top + arrowSize),
                    new PointF(leftArrowBound.Right - arrowSize, leftArrowBound.Bottom - arrowSize)
                });

                // Draw right arrow
                rightArrowBound = new RectangleF(Width - Height - 1, 0, Height, Height);
                e.Graphics.FillPolygon(arrowBrush, new PointF[]
                {
                    new PointF(rightArrowBound.Left + arrowSize, rightArrowBound.Top + arrowSize),
                    new PointF(rightArrowBound.Left + arrowSize, rightArrowBound.Bottom - arrowSize),
                    new PointF(rightArrowBound.Right - arrowSize, rightArrowBound.Height / 2)
                });
            }

            float thumbPosition = ((float)_value / (_max - _min)) * thumbTrackWidth;
            thumbBound = new RectangleF(thumbPosition + thumbPadding.Left + leftArrowBound.Width - 1, thumbPadding.Top, thumbWidth, Height - thumbPadding.Vertical);

            // Draw the thumb
            using (var thumbBrush = new SolidBrush(Color.FromArgb((isHoverThumb ? 180 : 255), ThumbColor)))
            {
                e.Graphics.FillRectangle(thumbBrush, thumbBound);
            }
        }

        private float GetThumbSize()
        {
            // get the size of the track the thumb can occupy
            float trackSize = Width - leftArrowBound.Width * 2;

            if (_max == 0 || maxChange == 0)
            {
                return trackSize;
            }

            float newThumbSize = (maxChange * (float)trackSize) /
              _max;

            return Convert.ToInt32(Math.Min((float)trackSize, Math.Max(newThumbSize, 10f)));
        }

        bool isHoverThumb => thumbBound.Contains(PointToClient(MousePosition));

        private float thumbWidth => GetThumbSize();
        float thumbTrackWidth => rightArrowBound.X - leftArrowBound.Width - thumbPadding.Horizontal;

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDragging)
            {
                // Calculate new thumb position
                float newX = e.X - dragOffsetX;
                float newValue = ((newX - leftArrowBound.Width) / thumbTrackWidth) * (_max - _min) + _min;
                if ((int)newValue <= _max - maxChange + 1 && (int)newValue >= _min)
                    Value = (int)newValue;
            }
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (thumbBound.Contains(e.Location))
                {
                    isDragging = true;
                    dragOffsetX = e.X - thumbBound.X;
                }
                else if (leftArrowBound.Contains(e.Location))
                {
                    Value = Math.Max(_min, _value - minChange);
                }
                else if (rightArrowBound.Contains(e.Location))
                {
                    Value = Math.Min(_max - maxChange + 1, _value + minChange);
                }
                else
                {
                    if (e.X < thumbBound.X)
                    {
                        Value = Math.Max(_min, _value - maxChange);
                    }
                    else if (e.X > thumbBound.X + thumbBound.Width)
                    {
                        Value = Math.Min(_max - maxChange + 1, _value + maxChange);
                    }
                }
                Invalidate();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta > 0)
            {
                Value = Math.Max(_min, _value - minChange);
            }
            else if (e.Delta < 0)
            {
                Value = Math.Min(_max - maxChange + 1, _value + minChange);
            }
        }
    }
}
