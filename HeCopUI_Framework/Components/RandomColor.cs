using System;
using System.Drawing;

public static class RandomColor
{
    private static Random _random = new Random();
    public static Color GetRandomColor()
    {
        // Tạo một giá trị ngẫu nhiên cho hue (màu sắc)
        int hue = _random.Next(360);
        // Đặt độ bão hòa và độ sáng là 1.0 để tạo màu sáng và bão hòa
        float saturation = 1.0f;
        float lightness = 1.0f;
        // Chuyển đổi giá trị HSL sang RGB để tạo màu
        return FromHsl(hue, saturation, lightness);
    }

    private static Color FromHsl(int hue, float saturation, float lightness)
    {
        // Chuyển đổi giá trị HSL sang RGB
        float chroma = (1 - Math.Abs(2 * lightness - 1)) * saturation;
        float huePrime = hue / 60f;
        float x = chroma * (1 - Math.Abs(huePrime % 2 - 1));
        float r1, g1, b1;

        if (huePrime >= 0 && huePrime < 1)
        {
            r1 = chroma;
            g1 = x;
            b1 = 0;
        }
        else if (huePrime >= 1 && huePrime < 2)
        {
            r1 = x;
            g1 = chroma;
            b1 = 0;
        }
        else if (huePrime >= 2 && huePrime < 3)
        {
            r1 = 0;
            g1 = chroma;
            b1 = x;
        }
        else if (huePrime >= 3 && huePrime < 4)
        {
            r1 = 0;
            g1 = x;
            b1 = chroma;
        }
        else if (huePrime >= 4 && huePrime < 5)
        {
            r1 = x;
            g1 = 0;
            b1 = chroma;
        }
        else
        {
            r1 = chroma;
            g1 = 0;
            b1 = x;
        }

        float m = lightness - chroma / 2;
        int r = (int)((r1 + m) * 255);
        int g = (int)((g1 + m) * 255);
        int b = (int)((b1 + m) * 255);

        return Color.FromArgb(r, g, b);
    }
}