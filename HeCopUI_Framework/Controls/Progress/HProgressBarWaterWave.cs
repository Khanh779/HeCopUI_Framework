
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    /// <summary>
    /// Class UCWave.
    /// Implements the <see cref="System.Windows.Forms.Control" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Control" />
    public class HProgressBarWaterWave : Control
    {


        /// <summary>
        /// The m wave color
        /// </summary>
        private Color m_waveColor = Color.FromArgb(255, 77, 59);

        /// <summary>
        /// Gets or sets the color of the wave.
        /// </summary>
        /// <value>The color of the wave.</value>
        public Color WaveColor
        {
            get { return m_waveColor; }
            set { m_waveColor = value; }
        }

        /// <summary>
        /// The m wave width
        /// </summary>
        private int m_waveWidth = 200;
        /// <summary>
        /// Sets or gets wave width
        /// </summary>
        /// <value>The width of the wave.</value>
        public int WaveWidth
        {
            get { return m_waveWidth; }
            set
            {
                m_waveWidth = value;
                m_waveWidth = m_waveWidth / 10 * 10;
                intLeftX = value * -1;
            }
        }

        /// <summary>
        /// The m wave height
        /// </summary>
        private int m_waveHeight = 30;
        /// <summary>
        /// Sets or gets wave height
        /// </summary>
        /// <value>The height of the wave.</value>
        public int WaveHeight
        {
            get { return m_waveHeight; }
            set { m_waveHeight = value; }
        }

        /// <summary>
        /// The m wave sleep
        /// </summary>
        private int m_waveSleep = 50;
        /// <summary>
        /// Sets or gets time.
        /// </summary>
        /// <value>The wave sleep.</value>
        public int WaveSleep
        {
            get { return m_waveSleep; }
            set
            {
                if (value <= 0)
                    return;
                m_waveSleep = value;

            }
        }


        /// <summary>
        /// The timer
        /// </summary>
        Timer timer;
        /// <summary>
        /// The int left x
        /// </summary>
        int intLeftX = -200;
        /// <summary>
        /// Initializes a new instance of the <see cref="HProgressBarWaterWave" /> class.
        /// </summary>
        public HProgressBarWaterWave()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Size = new Size(600, 100);
            Init();

            this.VisibleChanged += UCWave_VisibleChanged;
        }

        void Init()
        {
            timer = new Timer();
            timer.Interval = m_waveSleep;
            timer.Tick += timer_Tick;
        }

        protected override void OnCreateControl()
        {
            Init();
            // if (IsHandleCreated) timer.Start();
            base.OnCreateControl();
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (IsHandleCreated) timer.Start();
            base.OnInvalidated(e);
        }

        /// <summary>
        /// Handles the VisibleChanged event of the UCWave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void UCWave_VisibleChanged(object sender, EventArgs e)
        {
            timer.Enabled = this.Visible;
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        void timer_Tick(object sender, EventArgs e)
        {
            intLeftX -= 10;
            if (intLeftX == m_waveWidth * -2)
                intLeftX = m_waveWidth * -1;
            this.Invalidate();
        }
        /// <summary>
        /// Handles the <see cref="E:Paint" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Bitmap bitmap = new Bitmap(Width, Height);
            #region Wave
            var g = Graphics.FromImage(bitmap);
            GetAppResources.GetControlGraphicsEffect(g);
            List<Point> lst1 = new List<Point>();
            List<Point> lst2 = new List<Point>();
            int m_intX = intLeftX;
            while (true)
            {
                lst1.Add(new Point(m_intX, 1));
                lst1.Add(new Point(m_intX + m_waveWidth / 2, m_waveHeight));

                lst2.Add(new Point(m_intX + m_waveWidth / 2, 1));
                lst2.Add(new Point(m_intX + m_waveWidth / 2 + m_waveWidth / 2, m_waveHeight));
                m_intX += m_waveWidth;
                if (m_intX > this.Width + m_waveWidth)
                    break;
            }

            GraphicsPath path1 = new GraphicsPath();
            path1.AddCurve(lst1.ToArray(), 0.5F);
            path1.AddLine(this.Width + 1, -1, this.Width + 1, Height);
            path1.AddLine(this.Width + 1, Height, -1, Height);
            path1.AddLine(-1, Height, -1, -1);

            GraphicsPath path2 = new GraphicsPath();
            path2.AddCurve(lst2.ToArray(), 0.5F);
            path2.AddLine(this.Width + 1, -1, this.Width + 1, Height);
            path2.AddLine(this.Width + 1, Height, -1, Height);
            path2.AddLine(-1, Height, -1, -1);

            g.FillPath(new SolidBrush(Color.FromArgb(220, m_waveColor.R, m_waveColor.G, m_waveColor.B)), path1);
            g.FillPath(new SolidBrush(Color.FromArgb(220, m_waveColor.R, m_waveColor.G, m_waveColor.B)), path2);
            #endregion
            g.DrawString(Value + "%", Font, new SolidBrush(ForeColor), ClientRectangle, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
            Bitmap ProgressImage = new Bitmap(Width, Height);
            Graphics gr = Graphics.FromImage(ProgressImage);
            GetAppResources.GetControlGraphicsEffect(gr);
            gr.DrawImage(bitmap, new Rectangle(0, Height - (value * Height / maximum), Width, value * Height / maximum));
            gr.Dispose();
            GetAppResources.GetControlGraphicsEffect(e.Graphics);
            switch (ProgressShape)
            {
                case ProgressShapeType.Circular:
                    e.Graphics.FillEllipse(new TextureBrush(ProgressImage), new Rectangle(BorderThickness / 2, BorderThickness / 2, Width - BorderThickness / 2 - 3, Height - BorderThickness / 2 - 3));
                    e.Graphics.DrawEllipse(new Pen(new SolidBrush(BorderColor), BorderThickness), new Rectangle(BorderThickness / 2, BorderThickness / 2, Width - BorderThickness / 2 - 3, Height - BorderThickness / 2 - 3));
                    break;
                case ProgressShapeType.RoundRectangle:
                    e.Graphics.FillPath(new TextureBrush(ProgressImage), HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, Radius));
                    e.Graphics.DrawPath(new Pen(new SolidBrush(BorderColor), BorderThickness), HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(ClientRectangle, Radius, BorderThickness));
                    break;
            }
        }

        public Color BorderColor { get; set; } = Color.Gray;
        public int BorderThickness { get; set; } = 5;

        public int Radius { get; set; } = 0;
        public enum ProgressShapeType { RoundRectangle, Circular }
        public ProgressShapeType ProgressShape { get; set; } = ProgressShapeType.Circular;


        int maximum = 100;
        int minimum = 0;
        int value = 0;
        public int Maximum { get => maximum; set { maximum = value; Invalidate(); } }
        public int Minimum { get => minimum; set { minimum = value; Invalidate(); } }
        public int Value { get => value; set { this.value = value; Invalidate(); } }
    }
}
