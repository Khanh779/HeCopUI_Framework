using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    public class WaveProgressLoading : Control
    {
        private int waveCount = 5;
        private int waveWidth = 10;
        private int maxHeight = 60;
        private List<double> progress;

        public enum AnimationStyle
        {
            Ascending,
            Descending,
            Synchronized

        }

        AnimationStyle animationStyle = AnimationStyle.Ascending;
        public AnimationStyle WaveAnimationStyle
        {
            get { return animationStyle; }
            set
            {
                animationStyle = value;
                switch (value)
                {
                    case AnimationStyle.Ascending:
                        progress.Clear();
                        for (int i = 0; i < waveCount; i++)
                        {
                            progress.Add(0);
                        }
                        break;
                    case AnimationStyle.Descending:
                        progress.Clear();
                        for (int i = 0; i < waveCount; i++)
                        {
                            progress.Add(maxHeight);
                        }
                        break;
                    case AnimationStyle.Synchronized:
                        progress.Clear();
                        for (int i = 0; i < waveCount; i++)
                        {
                            progress.Add(0);
                        }
                        break;
                }
                Invalidate();
            }
        }


        Timer timer;

        public WaveProgressLoading()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, value: true);
            progress = new List<double>();
            DoubleBuffered = true;
            timer = new Timer
            {
                Interval = 40
            };
            timer.Tick += Timer_Tick;
            timer.Start();

        }


        double valAn = 0.03;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progress.Count > 0)
            {
                // Tăng giá trị của các hình chữ nhật theo thứ tự
                for (int i = 0; i < progress.Count; i++)
                {

                    switch (WaveAnimationStyle)
                    {
                        case AnimationStyle.Ascending:
                            progress[i] = progress[i > 0 ? i - 1 : i] += valAn;
                            if (progress[i] > 1)
                                progress[i] = 0;
                            break;
                        case AnimationStyle.Descending:
                            progress[i] = progress[i > 0 ? i - 1 : i] -= valAn;
                            if (progress[i] < 0)
                                progress[i] = 1;
                            break;
                        case AnimationStyle.Synchronized:
                            progress[i] += valAn;
                            if (progress[i] > 1)
                                progress[i] = 0;
                            break;
                    }


                }

            }

            Invalidate();
        }

        public int WaveCount
        {
            get { return waveCount; }
            set
            {
                if (value > 0)
                {
                    waveCount = value;

                    Invalidate();
                }
            }
        }

        public int WaveWidth
        {
            get { return waveWidth; }
            set
            {
                if (value > 0)
                {
                    waveWidth = value;
                    Invalidate();
                }
            }
        }


        public int MaxHeight
        {
            get { return maxHeight; }
            set
            {
                if (value > 0)
                {
                    maxHeight = value;
                    Invalidate();
                }
            }
        }

        int spaceBetweenWave = 20;
        public int SpaceBetweenWave
        {
            get { return spaceBetweenWave; }
            set
            {
                if (value > 0)
                {
                    spaceBetweenWave = value;
                    Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int x = 0;

            float totalWidth = waveCount * waveWidth + (waveCount - 1) * spaceBetweenWave; // Tổng chiều rộng của các hình chữ nhật và khoảng cách
            float startX = (Width - totalWidth) / 2; // Vị trí x để căn giữa

            using (Brush brush = new SolidBrush(ForeColor))
            {
                if (progress.Count > 0)
                    for (int i = 0; i < progress.Count; i++)
                    {
                        var a = Convert.ToSingle(progress[i]) * maxHeight;
                        float rectHeight = a;
                        RectangleF rect = new RectangleF(startX + x, (Height - rectHeight) / 2, waveWidth, rectHeight);
                        e.Graphics.FillRectangle(brush, rect);
                        x += waveWidth + spaceBetweenWave; // Cộng thêm khoảng cách
                    }
            }
        }
    }
}
