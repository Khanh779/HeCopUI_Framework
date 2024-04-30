using HeCopUI_Framework.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(Button))]
    public partial class HImageButton : Control
    {
        ToolTip TT = null;
        public HImageButton()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;
            Size = new Size(50, 50);
            Paint += PictuButton_Paint;
            MouseHover += (sender, e) =>
              {
                  //hov = true;
                  Invalidate();
              };
            TT = new ToolTip();
            MouseEnter += (sender, e) =>
            {
                hov = true;
                Invalidate();
            };
            MouseLeave += (sender, e) =>
            {
                hov = false;
                Invalidate();
            };
            MouseDown += (sender, e) =>
              {
                  dow = true;
                  Invalidate();
              };
            MouseUp += (sender, e) =>
            {
                dow = false;
                Invalidate();
            };
        }

        bool hov;
        bool dow;

        public bool ShowTip { get; set; } = false;
        public string TipText { get; set; } = "Enter Text Here";


        private void PictuButton_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            GraphicsPath path = new GraphicsPath();
            float sizex = dow ? BS.Width : hov ? BSH.Width : BS.Width;
            float sizey = dow ? BS.Height : hov ? BSH.Height : BS.Height;
            if (ButtonImage != null)
                g.DrawImage(CropCircle(ButtonImage, path), (Width / 2 - sizex / 2), (Height / 2 - sizey / 2), sizex, sizey);

        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (ShowTip == true)
            {
                TT.SetToolTip(this, TipText);

            }
            base.OnInvalidated(e);
        }

        private ShapeType ShapeType = ShapeType.Rectangle;
        public ShapeType HShapeType
        {
            get { return ShapeType; }
            set
            {
                ShapeType = value; Invalidate();
            }
        }

        private Bitmap CropCircle(Image img, GraphicsPath gp)
        {
            AnimateImage();
            var roundedImage = new Bitmap(img.Width, img.Height, img.PixelFormat);
            roundedImage.MakeTransparent();
            float sizex = dow ? BS.Width : hov ? BSH.Width : BS.Width;
            float sizey = dow ? BS.Height : hov ? BSH.Height : BS.Height;
            ImageAnimator.UpdateFrames();
            using (var g = Graphics.FromImage(roundedImage))
            {
                GetAppResources.GetControlGraphicsEffect(g);
                Brush brush = new TextureBrush(img);
                switch (HShapeType)
                {
                    case ShapeType.Rectangle:
                        gp.AddRectangle(new RectangleF(0, 0, img.Width, img.Height));
                        break;
                    case ShapeType.Circular:
                        gp.AddEllipse(new RectangleF(0, 0, img.Width, img.Height));
                        break;
                }
                g.FillPath(brush, gp);
            }
            return roundedImage;
        }


        bool currentlyAnimating = false;
        private void OnFrameChanged(object o, EventArgs e)
        {

            this.Invalidate();
        }
        public void AnimateImage()
        {

            if (!currentlyAnimating)
            {

                //Begin the animation only once.
                ImageAnimator.Animate(BI, new EventHandler(this.OnFrameChanged));
                currentlyAnimating = true;
            }
        }

        private Size BSH = new Size(20, 20);
        public Size ImageHoverSize
        {
            get { return BSH; }
            set
            {
                BSH = value; Invalidate();
            }
        }

        private Size BS = new Size(20, 20);
        public Size ImageSize
        {
            get { return BS; }
            set
            {
                BS = value; Invalidate();
            }
        }

        private Image BI;
        public Image ButtonImage
        {
            get { return BI; }
            set
            {
                BI = value; Invalidate();
            }
        }
    }
}
