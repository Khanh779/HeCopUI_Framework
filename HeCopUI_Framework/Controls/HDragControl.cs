using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    public partial class HDragControl : Component, IComponent
    {
        public HDragControl()
        {

        }


        private Control TF;
        public Control TargetControl
        {
            get { return TF; }
            set
            {
                TF = value; TF.Invalidate();
            }
        }
        private Control TC;
        public Control GetControl
        {
            get { return TC; }
            set
            {
                TC = value;
                try
                {
                    TC.MouseDown += TC_MouseDown; TC.MouseUp += TC_MouseUp;
                    TC.MouseMove += TC_MouseMove;
                }
                catch { }
                TC.Invalidate();
            }
        }

        bool isMouseDown;

        int xLast;
        int yLast;

        private void TC_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                int newY = TF.Top + (e.Y - yLast);
                int newX = TF.Left + (e.X - xLast);

                TF.Location = new Point(newX, newY);
            }
        }

        private void TC_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void TC_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                xLast = e.X;
                yLast = e.Y;

            }
        }
    }
}
