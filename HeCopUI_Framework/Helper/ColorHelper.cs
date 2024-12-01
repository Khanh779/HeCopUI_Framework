using System.Drawing;

namespace HeCopUI_Framework.Helper
{
    public class ColorHelper
    {

        public static Color BlendColor(Color backgroundColor, Color frontColor, double blend)
        {
            var ratio = blend / 255d;
            var invRatio = 1d - ratio;
            var a = (int)((backgroundColor.A * invRatio) + (frontColor.A * ratio));
            var r = (int)((backgroundColor.R * invRatio) + (frontColor.R * ratio));
            var g = (int)((backgroundColor.G * invRatio) + (frontColor.G * ratio));
            var b = (int)((backgroundColor.B * invRatio) + (frontColor.B * ratio));
            return Color.FromArgb(a, r, g, b);
        }

        public static Color GetLighterColor(Color baseColor, int percentage)
        {
            int r0 = baseColor.R;
            int g0 = baseColor.G;
            int b0 = baseColor.B;

            int r = r0 + (int)((255 - r0) * (percentage / 100f));
            int g = g0 + (int)((255 - g0) * (percentage / 100f));
            int b = b0 + (int)((255 - b0) * (percentage / 100f));

            if (r > 255)
                r = 255;
            if (g > 255)
                g = 255;
            if (b > 255)
                b = 255;

            return Color.FromArgb(baseColor.A, r, g, b);
        }

        public static Color GetDarkerColor(Color baseColor, int percentage)
        {
            int r0 = baseColor.R;
            int g0 = baseColor.G;
            int b0 = baseColor.B;

            int r = r0 - (int)(r0 * (percentage / 100f));
            int g = g0 - (int)(g0 * (percentage / 100f));
            int b = b0 - (int)(b0 * (percentage / 100f));

            if (r < 0)
                r = 0;
            if (g < 0)
                g = 0;
            if (b < 0)
                b = 0;

            return Color.FromArgb(baseColor.A, r, g, b);
        }

        public static Color[] GetLighterArrayColors(Color baseColor, int arrayLength, float maxPercentage)
        {
            if (maxPercentage < 2)
                maxPercentage = 2f;
            if (maxPercentage > 100)
                maxPercentage = 100f;

            Color[] arrc = new Color[arrayLength];
            float average = maxPercentage / arrayLength;
            for (int i = 0; i < arrayLength; i++)
            {
                arrc[arrayLength - i - 1] = GetLighterColor(baseColor, (int)(average * i));
            }
            return arrc;
        }

        public static Color[] GetLighterArrayColors(Color baseColor, int arrayLength)
        {
            return GetLighterArrayColors(baseColor, arrayLength, 100f);
        }
    }
}
