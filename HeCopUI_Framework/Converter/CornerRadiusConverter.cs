using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System.Globalization;
using System;
using HeCopUI_Framework.Structs;
using System.Windows.Forms;
using System.Collections;

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
                int[] array2 = new int[array.Length];
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
                }

                if (array2.Length == 4)
                {
                    return new CornerRadius(array2[0], array2[1], array2[2], array2[3]);
                }

                // return error
                throw new ArgumentException("Invalid format");
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
                    CornerRadius padding = (CornerRadius)value;
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
                    string[] array = new string[4];
                    int num = 0;
                    array[num++] = converter.ConvertToString(context, culture, padding.TopLeft);
                    array[num++] = converter.ConvertToString(context, culture, padding.TopRight);
                    array[num++] = converter.ConvertToString(context, culture, padding.BottomLeft);
                    array[num++] = converter.ConvertToString(context, culture, padding.BottomRight);
                    return string.Join(separator, array);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    CornerRadius padding2 = (CornerRadius)value;
                    if (padding2.ShouldSerializeAll())
                    {
                        return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new Type[1] { typeof(int) }), new object[1] { padding2.All });
                    }

                    return new InstanceDescriptor(typeof(CornerRadius).GetConstructor(new Type[4]
                    {
                        typeof(int),
                        typeof(int),
                        typeof(int),
                        typeof(int)
                    }), new object[4] { padding2.TopLeft, padding2.TopRight, padding2.BottomLeft, padding2.BottomRight });
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

            CornerRadius padding = (CornerRadius)context.PropertyDescriptor.GetValue(context.Instance);
            int num = (int)propertyValues["All"];
            if (padding.All != num)
            {
                return new CornerRadius(num);
            }

            return new CornerRadius((int)propertyValues["TopLeft"], (int)propertyValues["TopRight"], (int)propertyValues["BottomLeft"], (int)propertyValues["BottomRight"]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

      
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CornerRadius), attributes);
            return properties.Sort(new string[5] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" });
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }


        public CornerRadiusConverter()
        {
        }
    }
}
