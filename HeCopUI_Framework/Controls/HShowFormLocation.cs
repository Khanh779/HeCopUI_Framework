using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HShowFormLocation : Component
    {
        public HShowFormLocation()
        {
        }

        int locx = 0; int locy = 0;
        private Form targetForm;
        public Form TargetForm
        {
            get { return targetForm; }
            set
            {
                targetForm = value;
                targetForm.Load += (sender, e) =>
                  {
                      if (UseAnimation)
                      {
                          timeLoad.Interval = Interval;
                          timeLoad.Tick += timer_Tick;
                          timeLoad.Start();
                      }
                      switch (ShowFormLocation)
                      {
                          case ShowLocation.MiddleCenter:
                              locx = Screen.PrimaryScreen.WorkingArea.Width / 2 - TargetForm.Width / 2;
                              locy = Screen.PrimaryScreen.WorkingArea.Height / 2 - TargetForm.Height / 2;
                              TargetForm.Location = new Point(locx, locy);
                              break;
                          case ShowLocation.TopLeft:
                              locx = locy = 0;
                              TargetForm.Location = new Point(locx, locy);
                              break;
                          case ShowLocation.BottomRight:
                              locx = Screen.PrimaryScreen.WorkingArea.Width - TargetForm.Width; locy = Screen.PrimaryScreen.WorkingArea.Height - TargetForm.Height;
                              TargetForm.Location = new Point(locx, locy);
                              break;
                      }

                  };
            }
        }

        Timer timeLoad = new Timer();
        public int Interval { get; set; } = 10;
        public bool UseAnimation { get; set; } = false;
        public enum AnimateStyle
        {
            FadeIn, FadeOut, ZoomIn, None
        }

        double opaci = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            TargetForm.Opacity = opaci;
            switch (ShowAnimationStyle)
            {
                case AnimateStyle.FadeIn:
                    if (opaci < 1)
                    {
                        opaci += 0.1;
                        TargetForm.Invalidate();
                    }
                    else
                    {
                        timeLoad.Stop();
                        timeLoad.Dispose();
                    }
                    break;

            }
        }

        public AnimateStyle ShowAnimationStyle { get; set; } = HShowFormLocation.AnimateStyle.None;

        public enum ShowLocation { TopLeft, TopCenter, TopRight, MiddleLeft, MiddleCenter, MiddleRight, BottomLeft, BottomCenter, BottomRight }

        public ShowLocation ShowFormLocation { get; set; } = ShowLocation.MiddleCenter;
    }
}
