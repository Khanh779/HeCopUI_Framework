using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Forms
{
    public partial class Shadow_Test : Control
    {
        public Shadow_Test()
        {

        }

        int rad = 0;
        public int Radius
        {
            get { return rad; }
            set
            {
                rad = value; Invalidate();
            }
        }

        int shadowSize = 5;
        public int ShadowSize
        {
            get { return shadowSize; }
            set
            {
                shadowSize = value; Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            g.CompositingMode = CompositingMode.SourceOver;
            Rectangle rect = ClientRectangle;
            //g.CompositingMode = CompositingMode.SourceCopy;
            // Tạo một đối tượng GraphicsPath để vẽ hình dạng của bóng đổ
            // Kích thước bóng đổ
            GraphicsPath path = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new Rectangle(rect.X, rect.Y, rect.Width, rect.Height), rad, 0);

            //path.AddRectangle(new Rectangle(rect.X + shadowSize, rect.Y + shadowSize, rect.Width, rect.Height));

            // Tạo một đối tượng PathGradientBrush để tạo bóng đổ gradient
            Color c1 = Color.FromArgb(255, Color.Black);
            Color c2 = Color.FromArgb(20, Color.Black);
            PathGradientBrush brush = new PathGradientBrush(path);
            brush.CenterColor = c1;
            brush.SurroundColors = new Color[] { c2 };

            // Vẽ bóng đổ
            g.FillPath(brush, path);

            // Vẽ nội dung của control
            // ...

            // Giải phóng đối tượng path và brush sau khi sử dụng
            path.Dispose();
            brush.Dispose();
            base.OnPaint(e);
        }

    }
}
