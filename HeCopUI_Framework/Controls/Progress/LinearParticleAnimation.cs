using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Progress
{
    public class LinearParticleAnimation : Control
    {
        private Timer animationTimer;
        private List<Particle> particles;

        public LinearParticleAnimation()
        {
            //DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(400, 400);
            animationTimer = new Timer { Interval = 50 };
            animationTimer.Tick += AnimationTimer_Tick;
            InitializeParticles();
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            foreach (Particle particle in particles)
            {
                particle.maxX = Width;
                particle.maxY = Height;
                //particle.color= Color.FromArgb(100, rand.Next(256), rand.Next(256), rand.Next(256));
                particle.Update();
            }
            var fi = particles.First();
            if (fi.x == -fi.size)
            {
                fi.speed = rand.Next(2, 6);
                fi.size = rand.Next(10, 30);
                fi.color = Color.FromArgb(60, rand.Next(256), rand.Next(256), rand.Next(256));
            }
            Invalidate();
        }

        Random rand = new Random();

        private void InitializeParticles()
        {
            particles = new List<Particle>();

            for (int i = 0; i < 10; i++)
            {
                int size = rand.Next(10, 30);
                int speed = rand.Next(2, 6);
                Color color = Color.FromArgb(60, rand.Next(256), rand.Next(256), rand.Next(256));
                int startX = -size; // Start particles off-screen
                int startY = rand.Next(Height - size);
                particles.Add(new Particle(startX, startY, size, speed, color, Width, Height));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Particle particle in particles)
            {
                particle.Draw(e.Graphics);
            }

        }

        private class Particle
        {
            public int size;
            public int speed;
            public Color color;
            public int x;
            public int y;
            public int maxX;
            public int maxY;

            public Particle(int x, int y, int size, int speed, Color color, int maxX, int maxY)
            {
                this.x = x;
                this.y = y;
                this.size = size;
                this.speed = speed;
                this.color = color;
                this.maxX = maxX;
                this.maxY = maxY;
            }

            public void Update()
            {
                x += speed;
                // Reset particle when it goes off-screen
                if (x > maxX)
                {
                    x = -size;
                    y = new Random().Next(maxY - size);
                }
            }

            public void Draw(Graphics g)
            {
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, x, y, size, size);
                }
            }
        }
    }
}
