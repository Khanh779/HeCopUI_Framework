using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace HeCopUI_Framework.Effects
{
    internal class SlideEffect
    {
        private void ApplySlideEffect(Control.ControlCollection controls)
        {
            int slideDistance = 300; // Khoảng cách di chuyển
            int duration = 500; // Thời gian di chuyển (milliseconds)

            List<Point> originalLocations = new List<Point>();

            // Lưu trữ vị trí ban đầu của tất cả các control
            foreach (Control control in controls)
            {
                originalLocations.Add(control.Location);
            }

            // Di chuyển tất cả các control ra khỏi màn hình
            foreach (Control control in controls)
            {
                control.Location = new Point(control.Location.X - slideDistance, control.Location.Y);
            }

            // Tạo Timer để thực hiện hiệu ứng slide
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, e) =>
            {
                bool allControlsReachedDestination = true;

                for (int i = 0; i < controls.Count; i++)
                {
                    int newX = controls[i].Location.X + (int)(slideDistance * 10.0 / duration);

                    // Kiểm tra nếu control đã đến vị trí đích
                    if (newX < originalLocations[i].X)
                    {
                        controls[i].Location = new Point(newX, controls[i].Location.Y);
                        allControlsReachedDestination = false;
                    }
                    else
                    {
                        controls[i].Location = originalLocations[i];
                    }
                }

                if (allControlsReachedDestination)
                {
                    timer.Stop();
                    timer.Dispose();
                }
            };

            timer.Start();
        }
    }
}
