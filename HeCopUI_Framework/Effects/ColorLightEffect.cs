using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace HeCopUI_Framework.Effects
{
    public class ColorLightEffect
    {
        public static Bitmap ApplyColorLightEffect(Bitmap originalBitmap, Color targetColor, float intensity)
        {
            // Tạo một Bitmap mới từ hình ảnh ban đầu
            Bitmap bitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
            bitmap.MakeTransparent();
            // Tạo đối tượng Graphics để vẽ trên Bitmap
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Tạo một mặt nạ (mask) dựa trên màu cụ thể
                for (int x = 0; x < originalBitmap.Width; x++)
                {
                    for (int y = 0; y < originalBitmap.Height; y++)
                    {
                        Color pixelColor = originalBitmap.GetPixel(x, y);
                        if (pixelColor == targetColor)
                        {
                            // Tăng độ sáng của pixel có màu cụ thể
                            int red = (int)(pixelColor.R * intensity);
                            int green = (int)(pixelColor.G * intensity);
                            int blue = (int)(pixelColor.B * intensity);
                            Color newColor = Color.FromArgb(red, green, blue);
                            bitmap.SetPixel(x, y, newColor);
                        }
                        else
                        {
                            // Giữ nguyên màu của các pixel khác
                            bitmap.SetPixel(x, y, pixelColor);
                        }
                    }
                }
            }

            return bitmap;
        }

        public static Bitmap ApplyLightEffect(Bitmap sourceBitmap, int lightX, int lightY, int intensity)
        {
            // Tạo một bản sao của hình ảnh gốc
            Bitmap illuminatedBitmap = new Bitmap(sourceBitmap);
            illuminatedBitmap.MakeTransparent();
            // Lấy dữ liệu hình ảnh từ Bitmap
            BitmapData bitmapData = illuminatedBitmap.LockBits(
                new Rectangle(0, 0, illuminatedBitmap.Width, illuminatedBitmap.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            // Tính toán ánh sáng cho từng điểm ảnh
            unsafe
            {
                byte* ptr = (byte*)bitmapData.Scan0;

                for (int y = 0; y < illuminatedBitmap.Height; y++)
                {
                    for (int x = 0; x < illuminatedBitmap.Width; x++)
                    {
                        int distanceToLight = (int)Math.Sqrt((x - lightX) * (x - lightX) + (y - lightY) * (y - lightY));
                        int alpha = intensity - distanceToLight; // Áp dụng độ sáng theo khoảng cách
                                                                 // Điều chỉnh giá trị của các kênh màu (RGBA) tùy thuộc vào độ sáng

                        // Giới hạn giá trị alpha trong khoảng 0-255
                        alpha = Math.Max(0, Math.Min(255, alpha));
                        // Áp dụng độ sáng cho mỗi kênh màu (RGB)


                        // Tính toán chỉ số của điểm ảnh trong mảng dữ liệu
                        int index = y * bitmapData.Stride + x * 4;
                        byte red = ptr[index];
                        byte green = ptr[index + 1];
                        byte blue = ptr[index + 2];

                        red = (byte)Math.Max(0, Math.Min(255, red + alpha));
                        green = (byte)Math.Max(0, Math.Min(255, green + alpha));
                        blue = (byte)Math.Max(0, Math.Min(255, blue + alpha));

                        // Áp dụng giá trị mới cho các kênh màu
                        ptr[index] = red;      // Kênh màu Red
                        ptr[index + 1] = green; // Kênh màu Green
                        ptr[index + 2] = blue;  // Kênh màu Blue
                        ptr[index + 3] = (byte)alpha; // Kênh alpha


                    }
                }
            }

            // Giải phóng bộ nhớ của dữ liệu hình ảnh
            illuminatedBitmap.UnlockBits(bitmapData);

            return illuminatedBitmap;
        }

        public static Bitmap ApplyGlow(Bitmap sourceBitmap, Color glowColor, int radius, int blurIntensity)
        {
            // Tạo một Bitmap mới có kích thước bằng với ảnh nguồn
            Bitmap glowBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            using (Graphics graphics = Graphics.FromImage(glowBitmap))
            {
                // Tạo một Brush với màu sắc của Glow
                using (SolidBrush glowBrush = new SolidBrush(glowColor))
                {
                    // Tạo hiệu ứng glow bằng cách vẽ nhiều bản sao của ảnh nguồn với kích thước và màu sắc khác nhau
                    for (int i = 0; i < blurIntensity; i++)
                    {
                        using (GraphicsPath path = HeCopUI_Framework.Helper.DrawHelper.GetRoundPath(new RectangleF(-i, -i, sourceBitmap.Width + 2 * i, sourceBitmap.Height + 2 * i), radius))
                        {
                            // Tạo một EffectBrush với GradientBrush để tạo hiệu ứng mờ
                            using (PathGradientBrush effectBrush = new PathGradientBrush(path))
                            {
                                effectBrush.CenterColor = Color.FromArgb(120, glowColor);
                                effectBrush.SurroundColors = new Color[] { Color.FromArgb(0, glowColor) };

                                // Chỉ định ma trận biến đổi để di chuyển hiệu ứng glow xung quanh
                                Matrix matrix = new Matrix();
                                matrix.Translate(i, i);
                                effectBrush.Transform = matrix;

                                // Vẽ hình ảnh nguồn lên Bitmap với hiệu ứng glow
                                graphics.FillRectangle(effectBrush, 0, 0, sourceBitmap.Width, sourceBitmap.Height);
                            }
                        }
                    }

                    // Vẽ ảnh nguồn lên Bitmap để hiển thị nền
                    graphics.DrawImage(sourceBitmap, 0, 0);
                }
            }

            return glowBitmap;
        }
    }
}
