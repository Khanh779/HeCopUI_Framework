

using HeCopUI_Framework.Extensions;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(HNumeric), "Bitmaps.Numeric.bmp")]

    [DefaultProperty("Text")]
    [ComVisible(true)]
    public class HNumeric : Control
    {



        #region Global Vars

        private readonly Methods _mth;
        private readonly Utilites _utl;

        #endregion Global Vars

        #region Internal Vars



        private Point _point;
        private int _value;
        private readonly Timer _holdTimer;

        private int _maximum = 100;
        private int _minimum;
        private Color _backgroundColor = Color.FromArgb(245, 245, 245);
        private Color _disabledForeColor = Color.DimGray;
        private Color _disabledBackColor = Color.FromArgb(200, 200, 200);
        private Color _disabledBorderColor = Color.Gray;
        private Color _borderColor = Global.PrimaryColors.BorderNormalColor1;
        private Color _symbolsColor = Color.Black;

        #endregion Internal Vars

        #region Constructors

        public HNumeric()
        {
            SetStyle(
                ControlStyles.ResizeRedraw |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
            _mth = new Methods();
            _utl = new Utilites();
            _point = new Point(0, 0);

            _holdTimer = new Timer()
            {
                Interval = 10,
                AutoReset = true,
                Enabled = false
            };
            _holdTimer.Elapsed += HoldTimer_Tick;
        }


        #endregion Constructors

        #region Draw Control

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);

            const char plus = '+';
            const char minus = '-';

            using (var bg = new SolidBrush(Enabled ? BackColor : DisabledBackColor))
            {
                using (var p = new Pen(Enabled ? BorderColor : DisabledBorderColor))
                {
                    using (var s = new SolidBrush(Enabled ? SymbolsColor : DisabledForeColor))
                    {
                        using (var tb = new SolidBrush(Enabled ? ForeColor : DisabledForeColor))
                        {
                            using (var f2 = HeCopUI_Framework.Extensions.HFonts.GetFont(Properties.Resources.Roboto_Medium, 11))
                            {
                                using (var sf = new StringFormat { LineAlignment = StringAlignment.Center })
                                {
                                    g.FillRectangle(bg, rect);
                                    g.DrawString(plus.ToString(), f2, s, new Rectangle(Width - 45, 1, 25, Height - 1), sf);
                                    g.DrawString(minus.ToString(), f2, s, new Rectangle(Width - 25, -1, 20, Height - 1), sf);
                                    g.DrawString(Value.ToString(), Font, tb, new Rectangle(0, 0, Width - 50, Height - 1), _mth.SetPosition(StringAlignment.Far));
                                    g.DrawRectangle(p, rect);
                                }
                            }
                        }
                    }
                }
            }

        }

        #endregion



        #region Properties

        /// <summary>
        /// Gets or sets the maximum number of the Numeric.
        /// </summary>
        public int Maximum
        {
            get { return _maximum; }
            set
            {
                _maximum = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the minimum number of the Numeric.
        /// </summary>
        public int Minimum
        {
            get { return _minimum; }
            set
            {
                _minimum = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the current number of the Numeric.
        /// </summary>		
        public int Value
        {
            get => _value;
            set
            {
                if (value <= Maximum & value >= Minimum)
                    _value = value;
                Invalidate();
            }
        }



        /// <summary>
        /// Gets or sets the control backcolor.
        /// </summary>
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the forecolor of the control whenever while disabled
        /// </summary>
        public Color DisabledForeColor
        {
            get { return _disabledForeColor; }
            set
            {
                _disabledForeColor = value;
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets disabled backcolor used by the control
        /// </summary>
        public Color DisabledBackColor
        {
            get { return _disabledBackColor; }
            set
            {
                _disabledBackColor = value;
                Invalidate();
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
                Invalidate();
            }
        }


        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }




        /// <summary>
        /// Gets or sets arrow color used by the control
        /// </summary>
        public Color SymbolsColor
        {
            get { return _symbolsColor; }
            set
            {
                _symbolsColor = value;
                Invalidate();
            }
        }






        #endregion

        #region Events

        /// <summary>
        /// Handling the mouse moving event so that we can detect if the cursor located in the postion of our need.
        /// </summary>
        /// <param name="e">MouseEventArgs</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            _point = e.Location;
            Invalidate();
            Cursor = _point.X > Width - 50 ? Cursors.Hand : Cursors.IBeam;


        }

        /// <summary>
        /// Handling on click event so that we can increase or decrease the value.
        /// </summary>
        /// <param name="e">EventArgs</param>
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Revaluate();
        }

        /// <summary>
        /// Here we set the smooth mouse hand.
        /// </summary>
        /// <param name="m"></param>


        /// <summary>
        /// Here we handle the height of the control while resizing, we provide the fixed height.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Height = 26;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_point.X <= Width - 45 || _point.X >= Width - 3)
                return;
            if (e.Button == MouseButtons.Left)
            {
                _holdTimer.Enabled = true;
            }

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _holdTimer.Enabled = false;
        }

        private void HoldTimer_Tick(object sender, EventArgs args)
        {
            //Revaluate();
        }

        private void Revaluate()
        {
            if (_point.X <= Width - 45 || _point.X >= Width - 3)
                return;
            if (_point.X > Width - 45 && _point.X < Width - 25)
            {
                if (Value < Maximum)
                    Value += 1;
            }
            else
            {
                if (Value > Minimum)
                    Value -= 1;
            }
        }

        #endregion

    }
}