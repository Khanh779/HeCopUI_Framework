using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HClockDigital : Control
    {
        Timer timer1;
        public HClockDigital()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            BackColor = Color.Transparent;
            timer1 = new Timer();
            timer1.Interval = 1000;
            Font = new Font("Segoe UI", 25f);
            ForeColor = Color.DodgerBlue;
            Paint += HClockDigital_Paint;
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            hour = DateTime.Now.Hour;
            min = DateTime.Now.Minute;
            sec = DateTime.Now.Second;
            misec = DateTime.Now.Millisecond;
            Invalidate();
        }

        int sec = 0;
        int hour = 0;
        int min = 0;
        int misec = 0;

        public int Interval
        {
            get { return timer1.Interval; }
            set
            {
                timer1.Interval = value; Invalidate();
            }
        }

        private System.Drawing.Text.TextRenderingHint textRenderingHint = GetAppResources.SetTextRender();
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get { return textRenderingHint; }
            set
            {
                textRenderingHint = value;
                Invalidate();
            }
        }

        public bool ShowMillisecond { get; set; } = false;

        private void HClockDigital_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.TextRenderingHint = textRenderingHint;
            StringFormat SF = new StringFormat(); SF.LineAlignment = SF.Alignment = StringAlignment.Center;
            if (ShowMillisecond)
            {
                g.DrawString(String.Format("{0:00}:{1:00}:{2:00}:{3:00}", hour, min, sec, misec), Font, new SolidBrush(ForeColor), ClientRectangle, SF);
            }
            else
                g.DrawString(String.Format("{0:00}:{1:00}:{2:00}", hour, min, sec), Font, new SolidBrush(ForeColor), ClientRectangle, SF);
        }
    }
}
