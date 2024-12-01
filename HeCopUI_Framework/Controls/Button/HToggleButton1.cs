using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Button
{
    [ToolboxBitmap(typeof(CheckBox))]
    public partial class HToggleButton1 : Control
    {
        Rectangle contentRectangle = Rectangle.Empty;
        Point[] pts2 = new Point[4];
        Rectangle controlBounds = Rectangle.Empty;



        protected override void OnCreateControl()
        {
            Invalidate();
            base.OnCreateControl();
        }

        public HToggleButton1()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            ForeColor = Color.White;
            if (dblclick == true)
            {

            }

            isMouseDown = false;
            BackColor = Color.Transparent;
            Paint += HToggleButton1_Paint;
            BackColor = Color.Transparent;
            Size = MinimumSize = new Size(56, 26);
            SliderColor = Color.DarkGray;
            InActiveColor = HeCopUI_Framework.Global.PrimaryColors.OffToggleButtonColor;
            ActiveColor = HeCopUI_Framework.Global.PrimaryColors.OnToggleButtonColor;
        }

#pragma warning disable CS0414 // The field 'HToggleButton1.isMouseDown' is assigned but its value is never used
        bool isMouseDown = true;
#pragma warning restore CS0414 // The field 'HToggleButton1.isMouseDown' is assigned but its value is never used

        System.Drawing.Text.TextRenderingHint textRen = System.Drawing.Text.TextRenderingHint.SystemDefault;
        public System.Drawing.Text.TextRenderingHint TextRendering
        {
            get { return textRen; }
            set
            {
                textRen = value; Invalidate();
            }
        }

        private void HToggleButton1_Paint(object sender, PaintEventArgs e)
        {
            controlBounds = e.ClipRectangle;
            GetAppResources.GetControlGraphicsEffect(e.Graphics);
            e.Graphics.TextRenderingHint = textRen;
            e.Graphics.ResetClip();
            DrawWindowsStyle(e);
            StringFormat SF = new StringFormat();
            SF.LineAlignment = SF.Alignment = StringAlignment.Center;
            SF.Trimming = StringTrimming.EllipsisCharacter;
            string Status = "";
            int x = 0;
            int y = 0;
            if (toggleState == ToggleButtonState.ON)
            {
                Status = activeText;
                x = 2;
                y = 16;
            }
            if (toggleState == ToggleButtonState.OFF)
            {
                Status = inActiveText;
                x = 14;
                y = 16;
            }
            if (showStatusText == true)
            {
                e.Graphics.DrawString(Status, Font, new SolidBrush(textColor), new RectangleF(x, 0, Width - y, Height - 2), SF);
            }
        }


        #region Windows style
        private Rectangle WindowSliderBounds
        {
            get
            {
                Rectangle rect = Rectangle.Empty;
                if (sliderPoint.X > controlBounds.Right - 15)
                    sliderPoint.X = controlBounds.Right - 15;
                if (sliderPoint.X < controlBounds.Left)
                    sliderPoint.X = controlBounds.Left;
                rect = new Rectangle(sliderPoint.X, controlBounds.Y, 15, Height);
                return rect;
            }
        }


        /// <summary>
        /// make sure the diff in rect is acceptable
        /// </summary>
        /// <param name="e"></param>
        private void DrawWindowsStyle(PaintEventArgs e)
        {
            contentRectangle = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y, Width - 1, Height - 1);
            if (!isMouseMoved)
            {
                if (ToggleState == ToggleButtonState.ON)
                    sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                else
                    sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
            }
            Pen p = new Pen(Color.FromArgb(159, 159, 159))
            {
                Width = 1.9f
            };
            //e.Graphics.DrawRectangle(p, contentRectangle);
            e.Graphics.DrawRectangle(p, Rectangle.Inflate(contentRectangle, -2, -2));
            Rectangle r1 = new Rectangle(Rectangle.Inflate(contentRectangle, -2, -2).Left, Rectangle.Inflate(contentRectangle, -2, -2).Y, WindowSliderBounds.Left - Rectangle.Inflate(contentRectangle, -2, -2).Left, Rectangle.Inflate(contentRectangle, -2, -2).Height);
            Rectangle r2 = new Rectangle(WindowSliderBounds.Right, r1.Y, Rectangle.Inflate(contentRectangle, -2, -2).Right - WindowSliderBounds.Right, r1.Height);

            using (SolidBrush sb = new SolidBrush(ActiveColor))
            {
                e.Graphics.FillRectangle(sb, r1);
            }
            using (SolidBrush sb = new SolidBrush(SliderColor))
            {
                e.Graphics.FillRectangle(sb, WindowSliderBounds);
            }
            using (SolidBrush sb = new SolidBrush(InActiveColor))
            {
                e.Graphics.FillRectangle(sb, r2);
            }


        }

        #endregion








        private Point[] GetPolygonPoints(Rectangle r)
        {
            Point[] pts;

            Point p1 = new Point(ipadx, r.Y + (r.Height / 3));
            Point p2 = new Point(p1.X + 40, r.Y);
            Point p4 = new Point(p1.X + 20, r.Bottom);
            Point p3 = new Point(p4.X + 40, r.Height - (r.Height / 3));
            return pts = new Point[] { p1, p2, p3, p4 };
        }



        #region EventHandlers

        //private bool iosSelected = false;

        bool dblclick = false;



        public event ToggleButtonStateChanged ButtonStateChanged;

        protected void RaiseButtonStateChanged()
        {
            if (ButtonStateChanged != null)
                ButtonStateChanged(this, new ToggleButtonStateEventArgs(ToggleState));
        }


        public delegate void ToggleButtonStateChanged(object sender, ToggleButtonStateEventArgs e);

        public class ToggleButtonStateEventArgs : EventArgs
        {
            public ToggleButtonStateEventArgs(ToggleButtonState ButtonState)
            {

            }

            //Arguements Can be Included
        }



        private Rectangle GetRectangle()
        {
            return new Rectangle(2, 2, Width - 5, Height - 5); ;
        }


        Point downpos = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                if (!DesignMode)
                {
                    isMouseDown = true;
                    downpos = e.Location;
                }
                if (ToggleState == ToggleButtonState.ON)
                {
                    toggleState = ToggleButtonState.OFF;
                }
                else if (ToggleState == ToggleButtonState.OFF)
                {
                    toggleState = ToggleButtonState.ON;
                }

            }
            Invalidate();
        }

        void Loc()
        {
            sliderPoint = downpos;
            dblclick = !dblclick;
            switchrec = !switchrec;
            {
                if (WindowSliderBounds.X < (controlBounds.Width / 2))
                {
                    sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
                    ToggleState = ToggleButtonState.OFF;
                }
                else
                {
                    sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                    ToggleState = ToggleButtonState.ON;

                }
            }
        }

        bool isMouseMoved = false; Point sliderPoint = Point.Empty; int padx = 0; int ipadx = 2;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left && !DesignMode)
            {
                sliderPoint = e.Location;
                isMouseMoved = true;

                {

                    padx = e.X;

                    {
                        padx = contentRectangle.Left;
                        ToggleState = ToggleButtonState.OFF;
                    }

                    if (padx >= contentRectangle.Right - (contentRectangle.Width / 2))
                    {
                        padx = contentRectangle.Right - (contentRectangle.Width / 2);
                        ToggleState = ToggleButtonState.ON;
                    }
                }

                Refresh();
            }
        }
        bool switchrec = false;
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!DesignMode)
            {
                Invalidate();
                if (isMouseMoved)
                {

                    {
                        sliderPoint = e.Location;

                        if (WindowSliderBounds.X < (controlBounds.Width / 2))
                        {
                            sliderPoint = new Point(controlBounds.Left, sliderPoint.Y);
                            ToggleState = ToggleButtonState.OFF;
                        }
                        else
                        {
                            sliderPoint = new Point(controlBounds.Right - 15, sliderPoint.Y);
                            ToggleState = ToggleButtonState.ON;

                        }
                    }
                    {
                        padx = e.Location.X;
                        if (padx < contentRectangle.Width / 4)
                        {
                            padx = contentRectangle.Left;
                            ToggleState = ToggleButtonState.OFF;
                        }
                        else
                        {
                            padx = contentRectangle.Right - (contentRectangle.Width / 2);
                            ToggleState = ToggleButtonState.ON;
                        }
                    }
                    Invalidate();
                    Update();

                }

                isMouseMoved = false;
                isMouseDown = false;
            }
        }
        #endregion

        #region properties
        private string activeText = "ON";
        public string ActiveText
        {
            get
            {
                return activeText;
            }
            set
            {
                activeText = value; Invalidate();
            }
        }

        private string inActiveText = "OFF";
        public string InActiveText
        {
            get
            {
                return inActiveText;
            }
            set
            {
                inActiveText = value; Invalidate();
            }
        }


        private bool showStatusText = true;
        public bool ShowStatusText
        {
            get { return showStatusText; }
            set
            {
                showStatusText = value; Invalidate();
            }
        }

        private Color activeColor = Color.FromArgb(27, 161, 226);
        public Color ActiveColor
        {
            get
            {
                return activeColor;
            }
            set
            {
                activeColor = value;
                Refresh();
            }
        }

        private Color sliderColor = Color.Black;
        public Color SliderColor
        {
            get
            {
                return sliderColor;
            }
            set
            {
                sliderColor = value;
                Refresh();
            }
        }
        private Color textColor = Color.White;
        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                Refresh();
            }
        }
        private Color inActiveColor = Color.FromArgb(70, 70, 70);
        public Color InActiveColor
        {
            get
            {
                return inActiveColor;
            }
            set
            {
                inActiveColor = value;
                Refresh();
            }
        }


        private ToggleButtonState toggleState = ToggleButtonState.OFF;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ToggleButtonState ToggleState
        {
            get
            {
                return toggleState;
            }
            set
            {
                if (toggleState != value)
                {
                    RaiseButtonStateChanged();
                    toggleState = value;
                    Invalidate();
                    Refresh();
                }
            }

        }

        private void RefreshToggleState(ToggleButtonState state)
        {
            ToggleState = state;
        }
        public enum ToggleButtonState
        {
            ON,
            OFF
        }


        #endregion

        #region Other
        public static FileInfo FindApplicationFile(string fileName)
        {
            string startPath = Path.Combine(Application.StartupPath, fileName);
            FileInfo file = new FileInfo(startPath);
            while (!file.Exists)
            {
                if (file.Directory.Parent == null)
                {
                    return null;
                }
                DirectoryInfo parentDir = file.Directory.Parent;
                file = new FileInfo(Path.Combine(parentDir.FullName, file.Name));
            }
            return file;
        }

        #endregion
    }
}
