using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using HeCopUI_Framework.Struct;
using System.Reflection;
using System.Linq;

namespace HeCopUI_Framework.Converter
{
    public class CornerRadiusConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string text)
            {
                text = text.Trim();
                if (!text.Contains(','))
                {
                    return new CornerRadius(float.Parse(text));
                }
                var values = text.Split(',');
                return new CornerRadius(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is CornerRadius radius)
            {
                if (destinationType == typeof(string))
                {
                    return $"{radius.TopLeft}, {radius.TopRight}, {radius.BottomLeft}, {radius.BottomRight}";
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo ctor = typeof(CornerRadius).GetConstructor(
                        new Type[] { typeof(float), typeof(float), typeof(float), typeof(float) });
                    if (ctor != null)
                    {
                        return new InstanceDescriptor(ctor, new object[] { radius.TopLeft, radius.TopRight, radius.BottomLeft, radius.BottomRight });
                    }
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (propertyValues == null)
            {
                throw new ArgumentNullException(nameof(propertyValues));
            }

            CornerRadius radius = (CornerRadius)context.PropertyDescriptor.GetValue(context.Instance);
            if (radius.All != (float)propertyValues["All"])
            {
                return new CornerRadius((float)propertyValues["All"]);
            }

            return new CornerRadius((float)propertyValues["TopLeft"], (float)propertyValues["TopRight"], (float)propertyValues["BottomLeft"], (float)propertyValues["BottomRight"]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => true;

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(CornerRadius), attributes)
                                 .Sort(new string[] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context) => true;
    }
}