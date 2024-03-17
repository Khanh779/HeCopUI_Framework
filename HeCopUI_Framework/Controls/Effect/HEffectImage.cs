using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeCopUI_Framework.Controls.Effect
{
    public partial class HEffectImage:Control
    {
        public HEffectImage()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor| ControlStyles.OptimizedDoubleBuffer, true);
        }

        int _intensity = 100;
        public int Intensity
        {
            get { return _intensity; }
            set { _intensity = value; Invalidate(); }
        }

        Color _targetColor = System.Drawing.Color.White;
        public Color TargetColor
        {
            get { return _targetColor; }
            set { _targetColor = value; Invalidate(); }
        }

        Image _image=null;
        public Image Image
        {
            get { return _image; }
            set { _image = value; Invalidate(); }
        }

        Size _size= new Size(100, 100);
        public Size ImageSize
        {
            get { return _size; }
            set { _size = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            GetAppResources.GetControlGraphicsEffect(g);
            if (_image != null)
            {
                Bitmap bitmap = new Bitmap((Bitmap)_image.Clone(), _size);
                bitmap.MakeTransparent();
                bitmap = (Bitmap)Effects.ColorLightEffect.ApplyGlow(bitmap, Color.White, 20, _intensity).Clone();
                g.DrawImage(bitmap, new Rectangle(Width / 2 - _size.Width / 2, Height / 2 - _size.Height / 2, _size.Width, _size.Height));
                bitmap?.Dispose();
            }
            //ApplyLightEffect(g,0,0,10, _intensity);
            base.OnPaint(e);
        }

        private  void ApplyLightEffect(Graphics g, int centerX, int centerY, int lightRadius, int lightIntensity)
        {
            using (Bitmap lightBitmap = new Bitmap(2 * lightRadius, 2 * lightRadius))
            {
                using (Graphics lightGraphics = Graphics.FromImage(lightBitmap))
                {
                    GetAppResources.GetControlGraphicsEffect(lightGraphics);
                    // Vẽ ánh sáng lên Bitmap riêng
                    using (Brush brush = new SolidBrush(Color.FromArgb(lightIntensity, Color.White)))
                    {
                        lightGraphics.FillEllipse(brush, lightRadius, lightRadius, 2 * lightRadius, 2 * lightRadius);
                    }
                }

                // Vẽ Bitmap ánh sáng lên hình ảnh chính
                g.DrawImage(lightBitmap, centerX - lightRadius, centerY - lightRadius);
            }
        }
    }
}
