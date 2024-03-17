

using HeCopUI_Framework.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HHTrackBar), "Bitmaps.Slider.bmp")]

    [DefaultProperty("Value")]
    [DefaultEvent("Scroll")]
    [ComVisible(true)]
    public class HHTrackBar : Control
    {



        #region Global Vars

        private readonly Utilites _utl;

        #endregion Global Vars

        #region Internal Vars


        private bool _variable;
        private Rectangle _track;
        private int _maximum;
        private int _minimum;
        private int _value;
        private int _currentValue;

        private Color _valueColor;
        private Color _handlerColor;
        private Color _backgroundColor;
        private Color _disabledValueColor;
        private Color _disabledBackColor;
        private Color _disabledBorderColor;
        private Color _disabledHandlerColor;

        #endregion Internal Vars

        #region Constructors

        public HHTrackBar()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            _maximum = 100;
            _minimum = 0;
            _value = 0;
            _currentValue = Convert.ToInt32(Value / (double)(Maximum) - (2 * Width));
            UpdateStyles();
            _utl = new Utilites();


        }

        #endregion Constructors


        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;

            Cursor = Cursors.Hand;

            using (var bg = new SolidBrush(Enabled ? BackgroundColor : DisabledBackColor))
            {
                using (var v = new SolidBrush(Enabled ? ValueColor : DisabledValueColor))
                {
                    using (var vc = new SolidBrush(Enabled ? HandlerColor : DisabledHandlerColor))
                    {
                        g.FillRectangle(bg, new Rectangle(0, 6, Width, 4));
                        if (_currentValue != 0)
                            g.FillRectangle(v, new Rectangle(0, 6, _currentValue, 4));
                        g.FillRectangle(vc, _track);
                    }
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the upper limit of the range this TrackBar is working with.
        /// </summary>

        public int Maximum
        {
            get => _maximum;
            set
            {
                _maximum = value;
                RenewCurrentValue();
                MoveTrack();
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the lower limit of the range this TrackBar is working with.
        /// </summary>
        public int Minimum
        {
            get => _minimum;
            set
            {
                if (!(value < 0))
                {
                    _minimum = value;
                    RenewCurrentValue();
                    MoveTrack();
                    Invalidate();
                }
            }
        }

        public delegate void ValueEventChanged(object sender, EventArgs e);

        public event ValueEventChanged ValueChanged;

        /// <summary>
        /// Gets or sets a numeric value that represents the current position of the scroll box on the track bar.
        /// </summary>
        public int Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    RenewCurrentValue();
                    MoveTrack();
                    Invalidate();
                    Scroll?.Invoke(this);
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        [Browsable(false)]
        public override Color BackColor => Color.Transparent;

        /// <summary>
        /// Gets or sets the value color in normal mouse sate.
        /// </summary>
        public Color ValueColor
        {
            get { return _valueColor; }
            set
            {
                _valueColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the handler color.
        /// </summary>
        public Color HandlerColor
        {
            get { return _handlerColor; }
            set
            {
                _handlerColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the control BackColor.
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the value of the control whenever while disabled
        /// </summary>
        public Color DisabledValueColor
        {
            get { return _disabledValueColor; }
            set
            {
                _disabledValueColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets disabled BackColor used by the control
        /// </summary>
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set
            {
                _disabledBackColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the border color while the control disabled.
        /// </summary>
        public Color DisabledBorderColor
        {
            get { return _disabledBorderColor; }
            set
            {
                _disabledBorderColor = value;
                Refresh();
            }
        }


        /// <summary>
        /// Gets or sets the handler color while the control disabled.
        /// </summary>
        public Color DisabledHandlerColor
        {
            get { return _disabledHandlerColor; }
            set
            {
                _disabledHandlerColor = value;
                Refresh();
            }
        }

        private bool _isDerivedStyle = true;

        /// <summary>
        /// Gets or sets the whether this control reflect to parent form style.
        /// Set it to false if you want the style of this control be independent. 
        /// </summary>
        public bool IsDerivedStyle
        {
            get { return _isDerivedStyle; }
            set
            {
                _isDerivedStyle = value;
                Refresh();
            }
        }


        #endregion

        #region Events

        public event ScrollEventHandler Scroll;
        public delegate void ScrollEventHandler(object sender);

        /// <summary>
        /// Handling mouse move event so that we can handle the thumb value.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_variable && e.X > -1 && e.X < Width + 1)
            {
                Value = Minimum + (int)Math.Round((double)(Maximum - Minimum) * e.X / Width);
            }
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Handling mouse down event so that we can put the thumb in clicked state.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Height > 0)
            {
                RenewCurrentValue();
                _track = new Rectangle(_currentValue, 0, 6, 16);
                _variable = new Rectangle(_currentValue, 0, 6, 16).Contains(e.Location);
            }
            base.OnMouseDown(e);
        }

        /// <summary>
        /// Handling mouse up event.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            _variable = false;
            base.OnMouseUp(e);
        }

        /// <summary>
        /// Handling key press event so that we can change the track value by keys.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
            {
                if (Value != 0)
                {
                    Value -= 1;
                }

            }
            else if (e.KeyCode == Keys.Add || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
            {
                if (Value != Maximum)
                {
                    Value += 1;
                }

            }
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Handling the height and value of the track while resizing the control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            RenewCurrentValue();
            MoveTrack();
            //Height = 16;
            Invalidate();
            base.OnResize(e);
        }

        /// <summary>
        /// The Method to provide the track value.
        /// </summary>
        private void MoveTrack()
        {
            _track = new Rectangle(_currentValue, 0, 6, 16);
        }

        /// <summary>
        /// The Method to renew the value of the track.
        /// </summary>
        public void RenewCurrentValue()
        {
            _currentValue = Convert.ToInt32(Math.Round((double)(Value - Minimum) / (Maximum - Minimum) * (Width - 6)));
            Invalidate();
        }

        #endregion

    }
}