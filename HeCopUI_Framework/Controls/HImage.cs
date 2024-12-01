using HeCopUI_Framework.Components;
using HeCopUI_Framework.Enums;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls
{
    [ToolboxBitmap(typeof(Image))]
    public partial class HImage : Control
    {
        public HImage()
        {
            SetStyle(GetAppResources.SetControlStyles(), true);
            DoubleBuffered = true;
            //ProcessImg();
            Size = new Size(100, 100);
        }


        public enum ImageSizeMode
        {
            Custom, Zoom, Fill
        }

        private ImageSizeMode ISM = ImageSizeMode.Zoom;
        public ImageSizeMode SetImageSizeMode
        {
            get { return ISM; }
            set
            {
                ISM = value;
                //ProcessImg();
                Invalidate();
            }
        }

        private Size IS = new Size(150, 150);
        public Size ImageSize
        {
            get { return IS; }
            set
            {
                IS = value;
                //ProcessImg();
                Invalidate();
            }
        }



        private ShapeType ShapeType = ShapeType.Rectangle;
        public ShapeType HShapeType
        {
            get { return ShapeType; }
            set
            {
                ShapeType = value;
                // ProcessImg();
                Invalidate();
            }
        }

        int blurIntensity = 0;
        public int BlurIntensity
        {
            get { return blurIntensity; }
            set
            {
                blurIntensity = value;
                //ProcessImg();
                Invalidate();
            }
        }

        private Image BI;
        public Image Image
        {
            get { return BI; }
            set
            {
                BI = value;
                //ProcessImg();
                Invalidate();
            }
        }



        Bitmap blurBitmap = null;
        int SWi = 1; int SHi = 1;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            try
            {
                AnimateImage();
                int SStart = 0; int SEnd = 0;
                #region ImageSizeMode
                switch (SetImageSizeMode)
                {
                    case ImageSizeMode.Zoom:
                        if (Width <= BI.Width)
                        {
                            SWi = Width;
                            if (SEnd != 0)
                                SEnd = Height / 2 - BI.Height / 2;
                            if (SStart != 0)
                                SStart = Width / 2 - BI.Height / 2;
                        }
                        if (Width > BI.Width)
                        {
                            SWi = BI.Width;
                            SStart = Width / 2 - BI.Height / 2;
                            SEnd = Height / 2 - BI.Height / 2;
                            if (SEnd < 0) SEnd = 0;
                        }
                        if (Height <= BI.Height)
                        {
                            SHi = Height;
                            if (SStart != 0)
                                SStart = Width / 2 - BI.Height / 2;
                            if (SEnd != 0)
                                SEnd = Height / 2 - BI.Height / 2;
                        }
                        if (Height > BI.Height)
                        {
                            SHi = BI.Height;
                            SStart = Width / 2 - BI.Height / 2;
                            SEnd = Height / 2 - BI.Height / 2;
                            if (SStart < 0) SStart = 0;
                        }

                        break;
                    case ImageSizeMode.Custom:
                        SStart = Width / 2 - IS.Width / 2;
                        SEnd = Height / 2 - IS.Height / 2;
                        SWi = IS.Width; SHi = IS.Height;
                        break;
                    case ImageSizeMode.Fill:
                        SWi = Width; SHi = Height;
                        break;

                }
                #endregion
                //Get the next frame ready for rendering.
                ImageAnimator.UpdateFrames();

                //Rectangle rect = new Rectangle(0, 0, SWi, SHi);
                GraphicsPath path = new GraphicsPath();

                ProcessImg();


                if (BI != null && blurBitmap != null)
                    g.DrawImage(CropCircle(blurBitmap, path), new Rectangle(SStart, SEnd, SWi, SHi));
                blurBitmap?.Dispose();
                path?.Dispose();

            }

            catch { }

        }

        void ProcessImg()
        {
            if (BI != null)
            {
                blurBitmap?.Dispose();
                blurBitmap = new Bitmap(SWi, SHi);
                blurBitmap.MakeTransparent();
                using (var gb = Graphics.FromImage(blurBitmap))
                {
                    gb.DrawImage((Bitmap)BI, new Rectangle(0, 0, SWi, SHi));
                    if (blurIntensity > 0)
                        blurBitmap = ImageBlur.ApplyImageBlur(blurBitmap, blurIntensity, kernelMode);
                }
            }
        }

        private KernelMode kernelMode = KernelMode.BoxBlur;
        public KernelMode KernelMode
        {
            get { return kernelMode; }
            set
            {
                kernelMode = value;
                Invalidate();
            }
        }

        private Bitmap CropCircle(Image img, GraphicsPath gp)
        {
            var roundedImage = new Bitmap(SWi, SHi);
            roundedImage.MakeTransparent();
            using (var g = Graphics.FromImage(roundedImage))
            {
                GetAppResources.GetControlGraphicsEffect(g);
                g.DrawImage(img, new Rectangle(0, 0, SWi, SHi));

                using (Brush brush = new TextureBrush(roundedImage, new Rectangle(0, 0, SWi, SHi)))
                {
                    g.Clear(Color.Transparent);
                    switch (HShapeType)
                    {
                        case ShapeType.Rectangle:
                            gp.AddRectangle(new RectangleF(0, 0, SWi, SHi));
                            break;
                        case ShapeType.Circular:
                            gp.AddEllipse(0, 0, SWi, SHi);
                            break;
                    }
                    g.FillPath(brush, gp);
                    brush?.Dispose();
                    gp?.Dispose();
                }


            }
            return roundedImage;
        }


        private void OnFrameChanged(object o, EventArgs e)
        {

            Invalidate();
        }



        public void AnimateImage()
        {

            if (ImageAnimator.CanAnimate(BI) && !DesignMode)
            {
                ImageAnimator.Animate(BI, new EventHandler(OnFrameChanged));
            }
        }
    }
}
