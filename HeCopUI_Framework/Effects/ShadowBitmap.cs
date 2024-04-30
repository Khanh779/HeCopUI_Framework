using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using HeCopUI_Framework.Components;

namespace HeCopUI_Framework.Effects
{
    public class ShadowBitmap
    {

        public Bitmap DrawShadow(int width, int height, Color shadowColor, int radius, float opacity)
        {
            Bitmap shadowBitmap = new Bitmap(width, height);
            shadowBitmap.MakeTransparent();

            using (Graphics shadowGraphics = Graphics.FromImage(shadowBitmap))
            {
                shadowGraphics.SmoothingMode = SmoothingMode.HighQuality;
                // Tạo hiệu ứng shadow
                using (GraphicsPath path = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(0, 0, width, height), radius))
                {
                    shadowGraphics.FillPath(new SolidBrush(shadowColor), path);
                }
            }

            //var a = new float[][]
            //{
            //    new float[] {1, 0, 0, 0, 0},
            //    new float[] {0, 1, 0, 0, 0},
            //    new float[] {0, 0, 1, 0, 0},
            //    new float[] {0, 0, 0, opacity, 0},
            //        new float[] {0, 0, 0, 0, 1},
            //};

            // Áp dụng độ mờ cho shadow
            ColorMatrix colorMatrix = new ColorMatrix();
            colorMatrix.Matrix33 = opacity;

            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            var bitmap = new Bitmap(shadowBitmap.Width, shadowBitmap.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(shadowBitmap, new Rectangle(0, 0, shadowBitmap.Width, shadowBitmap.Height), 0, 0, shadowBitmap.Width, shadowBitmap.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            return bitmap;
        }

       

    }
}
