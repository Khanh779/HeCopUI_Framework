using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeCopUI_Framework.ImageProcessor
{

    public class StackBlur
    {
        public static Bitmap ApplyStackBlur(Bitmap source, int radius)
        {
            if (radius < 1) return source;

            Bitmap result = new Bitmap(source.Width, source.Height);
            result.MakeTransparent();
            int w = source.Width;
            int h = source.Height;
            int[] r = new int[w * h];
            int[] g = new int[w * h];
            int[] b = new int[w * h];

            // Extract pixel data
            for (int y = 0; y < h; y++)
            {
                for (int x = 0; x < w; x++)
                {
                    Color c = source.GetPixel(x, y);
                    int i = y * w + x;
                    r[i] = c.R;
                    g[i] = c.G;
                    b[i] = c.B;
                }
            }

            int[] vmin = new int[Math.Max(w, h)];
            int div = radius + radius + 1;
            int[] dv = new int[256 * div];
            for (int i = 0; i < 256 * div; i++)
            {
                dv[i] = (i / div);
            }

            int yw = 0, yi = 0;
            for (int y = 0; y < h; y++)
            {
                int rsum = 0, gsum = 0, bsum = 0;
                int rbs = radius + 1; // `rbs` is the radius + 1
                for (int i = -radius; i <= radius; i++)
                {
                    int p = yi + Math.Min(w - 1, Math.Max(i, 0));
                    rsum += r[p];
                    gsum += g[p];
                    bsum += b[p];
                }
                for (int x = 0; x < w; x++)
                {
                    int rIndex = Math.Max(0, Math.Min(255 * div - 1, rsum));
                    int gIndex = Math.Max(0, Math.Min(255 * div - 1, gsum));
                    int bIndex = Math.Max(0, Math.Min(255 * div - 1, bsum));

                    result.SetPixel(x, y, Color.FromArgb(dv[rIndex], dv[gIndex], dv[bIndex]));

                    if (y == 0)
                    {
                        vmin[x] = Math.Min(x + rbs, w - 1);
                    }
                    int p1 = yw + vmin[x];
                    int p2 = yw + Math.Max(x - radius, 0);

                    rsum += r[p1] - r[p2];
                    gsum += g[p1] - g[p2];
                    bsum += b[p1] - b[p2];

                    yi++;
                }
                yw += w;
            }

            for (int x = 0; x < w; x++)
            {
                int rsum = 0, gsum = 0, bsum = 0;
                int yp = -radius * w;
                for (int i = -radius; i <= radius; i++)
                {
                    yi = Math.Max(0, yp) + x;
                    rsum += r[yi];
                    gsum += g[yi];
                    bsum += b[yi];
                    yp += w;
                }
                yi = x;
                for (int y = 0; y < h; y++)
                {
                    int rIndex = Math.Max(0, Math.Min(255 * div - 1, rsum));
                    int gIndex = Math.Max(0, Math.Min(255 * div - 1, gsum));
                    int bIndex = Math.Max(0, Math.Min(255 * div - 1, bsum));

                    result.SetPixel(x, y, Color.FromArgb(dv[rIndex], dv[gIndex], dv[bIndex]));

                    if (x == 0)
                    {
                        vmin[y] = Math.Min(y + radius + 1, h - 1) * w;
                    }
                    int p1 = x + vmin[y];
                    int p2 = x + Math.Max(y - radius, 0) * w;

                    rsum += r[p1] - r[p2];
                    gsum += g[p1] - g[p2];
                    bsum += b[p1] - b[p2];

                    yi += w;
                }
            }

            return result;
        }
    }

}
