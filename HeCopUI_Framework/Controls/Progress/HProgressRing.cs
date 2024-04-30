using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace HeCopUI_Framework.Controls.Progress
{
    /// <summary>
    /// Custom control for displaying a progress ring to indicate waiting for a task to complete.
    /// </summary>
    public class HProgressRing : Control
    {
        private int startAngle = 0;
        private int sweepAngle = 0;
        private Color foregroundColor1 = Color.SeaGreen;
        private Color foregroundColor2 = Color.FromArgb(0, 168, 148);
        private Timer animationTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="HProgressRing"/> class.
        /// </summary>
        public HProgressRing()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);

            // Initialize Timer for animation
            animationTimer = new Timer();
            animationTimer.Interval = 50; // Set the time between animation frames
            animationTimer.Tick += UpdateAnimation;
            startAngle = sweepAngle = angle;
            animationTimer.Start();
        }

        private double speed = 1;
        /// <summary>
        /// Gets or sets the speed of the progress ring.
        /// 
        public double Speed
        {
            get { return speed; }
            set
            {
                if (value <= 0) speed = 0.1;
                else if (value >= 100) speed = 100;
                else speed = value;
                startAngle = sweepAngle = angle;
                Invalidate();
            }
        }

        private bool isLeap = false;
        int stepIncrement = 10;
        /// <summary>
        /// Gets or sets the step increment of the progress ring.
        /// 
        public int StepIncrement
        {
            get { return stepIncrement; }
            set
            {
                if (value <= 0) stepIncrement = 1;
                else if (value >= 100) stepIncrement = 100;
                else stepIncrement = value;
            }
        }

        int duration = 50;
        /// <summary>
        /// Gets or sets the duration of the progress ring.
        /// 
        public int Duration
        {
            get { return duration; }
            set
            {
                if (value <= 0) duration = 1;
                else if (value >= 100) duration = 100;
                else duration = value;
                if(animationTimer != null)
                {
                    animationTimer.Interval = duration;
                }
            }
        }

        int angle = 0;
        /// <summary>
        /// Gets or sets the angle of the progress ring.
        /// </summary>
        public int Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                startAngle = sweepAngle = angle;
                Invalidate();
            }
        }

        private void UpdateAnimation(object sender, EventArgs e)
        {
            // Update startAngle and sweepAngle to create a rotation effect

            if (startAngle < 360 && !isLeap) startAngle += (int)(StepIncrement * speed);

            if (sweepAngle < 360 && !isLeap)
            {
                sweepAngle += (int)(StepIncrement * speed);
                if (sweepAngle >= 360) isLeap = true;
            }

            if (isLeap)
            {
                startAngle += (int)(StepIncrement * speed);
                sweepAngle -= (int)(StepIncrement * speed);
                if (startAngle >= 360 && sweepAngle <= 0)
                {
                    startAngle =0;
                    sweepAngle=0;
                    isLeap = false;
                }
            }

            // Redraw the control
            Invalidate();
        }

        int scale = 70;
        ///<summary>
        /// Gets or sets the scale of the progress ring.
        ///</summary>
        public int ScaleFactory
        {
            get { return scale; }
            set
            {
                if (value <= 0) scale = 0;
                else if (value >= 100) scale = 100;
                else scale = value;
                Invalidate();
            }
        }

        System.Drawing.Drawing2D.LineCap startCap = System.Drawing.Drawing2D.LineCap.Round;
        ///<summary>
        /// Gets or sets the start cap of the progress ring.
        ///</summary>
        public System.Drawing.Drawing2D.LineCap StartCap
        {
            get { return startCap; }
            set
            {
                startCap = value;
                Invalidate();
            }
        }

        System.Drawing.Drawing2D.LineCap endCap = System.Drawing.Drawing2D.LineCap.Round;
        ///<summary>
        ///Gets or sets the end cap of the progress ring.
        ///</summary>
        public System.Drawing.Drawing2D.LineCap EndCap
        {
            get { return endCap; }
            set
            {
                endCap = value;
                Invalidate();
            }
        }

        LinearGradientMode linearGradientMode = LinearGradientMode.BackwardDiagonal;
        /// <summary>
        /// Gets or sets the linear gradient mode of the progress ring.
        /// </summary>
        public LinearGradientMode LinearGradientMode
        {
            get { return linearGradientMode; }
            set
            {
                linearGradientMode = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Paints the control.
        /// </summary>
        /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var diameterCircular = Math.Min(Width, Height);

            var fixSca = ((diameterCircular - thickness) * scale) / 100;
            DrawProgressRing(e.Graphics, (Width - fixSca) / 2, (Height - fixSca) / 2, fixSca);

          

        }

        private void DrawProgressRing(Graphics g, float x, float y, float diameter)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, foregroundColor1, ForegroundColor2, linearGradientMode))
            using (var pen = new Pen(brush, Thickness) { Alignment= PenAlignment.Inset, StartCap = StartCap, EndCap = EndCap })
            {
                g.DrawArc(pen,
                    x, y, diameter, diameter, startAngle + angle, sweepAngle);
            }
        }

        private void DrawProgressRing(Graphics g, float x, float y, SizeF size)
        {
            var diameter = Math.Min(size.Width, size.Height);
            DrawProgressRing(g, x, y, diameter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                animationTimer.Dispose();
            }
            base.Dispose(disposing);
        }


        private int thickness = 5;

        /// <summary>
        /// Gets or sets the thickness of the progress ring.
        /// </summary>
        public int Thickness
        {
            get { return thickness; }
            set
            {
                if (thickness != value)
                {
                    thickness = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the foreground2 color of the progress ring.
        /// </summary>
        public Color ForegroundColor2
        {
            get { return foregroundColor2; }
            set
            {
                if (foregroundColor2 != value)
                {
                    foregroundColor2 = value;
                    Invalidate();
                }
            }
        }


        /// <summary>
        /// Gets or sets the foreground1 color of the progress ring.
        /// </summary>
        public Color ForegroundColor1
        {
            get { return foregroundColor1; }
            set
            {
                if (foregroundColor1 != value)
                {
                    foregroundColor1 = value;
                    Invalidate();
                }
            }
        }

    }
}
