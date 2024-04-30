using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeCopUI_Framework.Struct;

namespace HeCopUI_Framework.Converter
{
    public class CornerRadiusConverter : TypeConverter
    {

        public CornerRadiusConverter()
        {
        }

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
                string text2 = text.Trim();
                if (text2.Length == 0)
                {
                    return null;
                }

                if (culture == null)
                {
                    culture = CultureInfo.CurrentCulture;
                }

                char c = culture.TextInfo.ListSeparator[0];
                string[] array = text2.Split(c);
                float[] array2 = new float[array.Length];
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = (float)converter.ConvertFromString(context, culture, array[i]);
                }

                if (array2.Length == 4)
                {
                    return new CornerRadius(array2[0], array2[1], array2[2], array2[3]);
                }

                throw new ArgumentException("TextParseFailedFormat:\n" + text2);
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            if (value is CornerRadius)
            {
                if (destinationType == typeof(string))
                {
                    CornerRadius radius = (CornerRadius)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
                    string[] array = new string[4];
                    int num = 0;
                    array[num++] = converter.ConvertToString(context, culture, radius.TopLeft);
                    array[num++] = converter.ConvertToString(context, culture, radius.TopRight);
                    array[num++] = converter.ConvertToString(context, culture, radius.BottomLeft);
                    array[num++] = converter.ConvertToString(context, culture, radius.BottomRight);
                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    CornerRadius radius2 = (CornerRadius)value;
                    if (radius2.ShouldSerializeAll())
                    {
                        return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new Type[1] { typeof(float) }), new object[1] { radius2.All });
                    }

                    return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new Type[4]
                    {
                    typeof(float),
                    typeof(float),
                    typeof(float),
                    typeof(float)
                    }), new object[4] { radius2.TopLeft, radius2.TopRight, radius2.BottomLeft, radius2.BottomRight });
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }



        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }

            CornerRadius radius = (CornerRadius)context.PropertyDescriptor.GetValue(context.Instance);
            float num = (float)propertyValues["All"];
            if (radius.All != num)
            {
                return new CornerRadius(num);
            }

            return new CornerRadius((float)propertyValues["TopLeft"], (float)propertyValues["TopRight"], (float)propertyValues["BottomLeft"], (float)propertyValues["BottomRight"]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(CornerRadius), attributes);
            return props.Sort(new string[] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

    }
}
