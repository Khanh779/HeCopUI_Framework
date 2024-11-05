using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Globalization;
using System;
using HeCopUI_Framework.Structs;
using System.Windows.Forms;

namespace HeCopUI_Framework.Converter
{
    public class CornerRadiusConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string text)
            {
                string[] parts = text.Split(new char[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 1)
                {
                    float all = float.Parse(parts[0], culture);
                    return new CornerRadius(all);
                }
                else if (parts.Length == 4)
                {
                    float topLeft = float.Parse(parts[0], culture);
                    float topRight = float.Parse(parts[1], culture);
                    float bottomRight = float.Parse(parts[2], culture);
                    float bottomLeft = float.Parse(parts[3], culture);
                    return new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is CornerRadius cornerRadius)
            {
                if (cornerRadius.All == -1f)
                {
                    return $"{cornerRadius.TopLeft.ToString(culture)} {cornerRadius.TopRight.ToString(culture)} {cornerRadius.BottomRight.ToString(culture)} {cornerRadius.BottomLeft.ToString(culture)}";
                }
                else
                {
                    return cornerRadius.All.ToString(culture);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
