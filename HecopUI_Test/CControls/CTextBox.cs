using System;
using System.Drawing;
using System.Windows.Forms;

namespace HecopUI_Test.CControls
{
    public class CTextBox : Control
    {
        private Timer cursorTimer;
        private bool cursorVisible = true;
        private int cursorPosition = 0;
        private bool textSelected = false;

        public CTextBox()
        {
            this.DoubleBuffered = true;
            this.Font = new Font("Arial", 10f, FontStyle.Regular);
            this.ForeColor = Color.Black;
            this.BackColor = Color.White;

            // Timer for cursor blinking
            cursorTimer = new Timer();
            cursorTimer.Interval = 500; // 500ms blink interval
            cursorTimer.Tick += (s, e) =>
            {
                cursorVisible = !cursorVisible;
                this.Invalidate();
            };
            cursorTimer.Start();

            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Draw border
            using (Pen pen = new Pen(Color.Gray, 1))
            {
                g.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
            }

            // Draw text
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                g.DrawString(this.Text, this.Font, brush, new PointF(5, (Height - Font.Height) / 2));
            }

            // Draw selection if text is selected
            if (textSelected)
            {
                Size textSize = TextRenderer.MeasureText(this.Text, this.Font);
                using (Brush selectionBrush = new SolidBrush(Color.Blue))
                {
                    g.FillRectangle(selectionBrush, new RectangleF(5, (Height - Font.Height) / 2, textSize.Width, textSize.Height));
                }

                using (Brush textBrush = new SolidBrush(Color.White))
                {
                    g.DrawString(this.Text, this.Font, textBrush, new PointF(0, (Height - Font.Height) / 2));
                }

            }

            // Draw cursor if focused
            if (this.Focused && cursorVisible && !textSelected)
            {
                string textUpToCursor = this.Text.Substring(0, cursorPosition);
                Size textSize = TextRenderer.MeasureText(textUpToCursor, this.Font);
                float cursorX = textSize.Width +5;  // Điều chỉnh để con trỏ đứng sát chữ hơn
                float cursorY = (Height - Font.Height) / 2;
                g.DrawLine(Pens.Black, cursorX, cursorY, cursorX, cursorY + Font.Height);
            }

            // Draw watermark if no text
            if (string.IsNullOrEmpty(this.Text))
            {
                using (Brush brush = new SolidBrush(Color.Gray))
                {
                    g.DrawString("Enter watermark", this.Font, brush, new PointF(5, (Height - Font.Height) / 2));
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            this.Focus();

            // Calculate cursor position based on click
            using (Graphics g = this.CreateGraphics())
            {
                for (int i = 0; i <= this.Text.Length; i++)
                {
                    Size textSize = TextRenderer.MeasureText(this.Text.Substring(0, i), this.Font);
                    if (e.X <= textSize.Width)
                    {
                        cursorPosition = i;
                        break;
                    }
                }
            }
            textSelected = false;
            this.Invalidate(); // Redraw the control to show updated cursor position
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (textSelected && !char.IsControl(e.KeyChar))
            {
                this.Text = e.KeyChar.ToString();
                cursorPosition = 1;
                textSelected = false;
            }
            else
            {
                // Handle backspace
                if (e.KeyChar == (char)Keys.Back)
                {
                    if (this.Text.Length > 0 && cursorPosition > 0)
                    {
                        this.Text = this.Text.Remove(cursorPosition - 1, 1);
                        cursorPosition--;
                    }
                }
                else if (!char.IsControl(e.KeyChar))
                {
                    this.Text = this.Text.Insert(cursorPosition, e.KeyChar.ToString());
                    cursorPosition++;
                }
            }

            this.Invalidate(); // Redraw the control
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.KeyCode == Keys.A)
            {
                // Select all text
                textSelected = true;
                cursorPosition = this.Text.Length;
            }
            else if (e.Control && e.KeyCode == Keys.C && textSelected)
            {
                // Copy selected text
                Clipboard.SetText(this.Text);
            }
            else if (e.Control && e.KeyCode == Keys.X && textSelected)
            {
                // Cut selected text
                Clipboard.SetText(this.Text);
                this.Text = string.Empty;
                cursorPosition = 0;
                textSelected = false;
            }
            else if (e.KeyCode == Keys.Delete && textSelected)
            {
                // Delete selected text
                this.Text = string.Empty;
                cursorPosition = 0;
                textSelected = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (cursorPosition > 0) cursorPosition--;
                textSelected = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (cursorPosition < this.Text.Length) cursorPosition++;
                textSelected = false;
            }

            this.Invalidate(); // Redraw the control
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            cursorTimer.Start();
            this.Invalidate(); // Redraw the control to show cursor
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            cursorTimer.Stop();
            cursorVisible = false;
            this.Invalidate(); // Redraw the control to hide cursor
        }
    }
}
