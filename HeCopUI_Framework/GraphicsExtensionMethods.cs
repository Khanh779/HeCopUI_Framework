using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HeCopUI_Framework
{
    public static class GraphicsExtensionMethods
    {
        public static Color ToGrayScale(this Color originalColor)
        {
            if (originalColor.Equals(Color.Transparent))
                return originalColor;

            int grayScale = (int)((originalColor.R * .299) + (originalColor.G * .587) + (originalColor.B * .114));
            return Color.FromArgb(grayScale, grayScale, grayScale);
        }

        public static void EnableDoubleBuffering(Control control)
        {
            // Get the type of the control
            Type controlType = control.GetType();

            // Find the property "DoubleBuffered" and set its value to true
            PropertyInfo propertyInfo = controlType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(control, true, null);
        }
    }
}
