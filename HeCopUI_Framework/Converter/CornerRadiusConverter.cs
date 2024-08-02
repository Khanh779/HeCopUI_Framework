using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.ComponentModel.Design.Serialization;
using HeCopUI_Framework.Struct;
using System.Reflection;
using System.Windows.Forms;

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
            //if (destinationType == typeof(InstanceDescriptor))
            //    return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string text)
            {
                string trimmedText = text.Trim();
                if (trimmedText.Length == 0)
                {
                    return null;
                }

                if (culture == null)
                {
                    culture = CultureInfo.CurrentCulture;
                }

                char separator = culture.TextInfo.ListSeparator[0];
                string[] parts = trimmedText.Split(separator);
                float[] values = new float[parts.Length];
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));

                for (int i = 0; i < parts.Length; i++)
                {
                    values[i] = (float)converter.ConvertFromString(context, culture, parts[i]);
                }

                if (values.Length == 4)
                {
                    return new CornerRadius(values[0], values[1], values[2], values[3]);
                }

                throw new ArgumentException($"TextParseFailedFormat: {trimmedText}. Expected format: TopLeft, TopRight, BottomLeft, BottomRight");
            }

            return base.ConvertFrom(context, culture, value);
        }


        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException(nameof(destinationType));
            }

            if (value is CornerRadius radius)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(float));
                    string[] parts = new string[4];
                    parts[0] = converter.ConvertToString(context, culture, radius.TopLeft);
                    parts[1] = converter.ConvertToString(context, culture, radius.TopRight);
                    parts[2] = converter.ConvertToString(context, culture, radius.BottomLeft);
                    parts[3] = converter.ConvertToString(context, culture, radius.BottomRight);

                    return string.Join(separator, parts);
                }

                //if (destinationType == typeof(InstanceDescriptor))
                //{
                //    ConstructorInfo ctor = typeof(CornerRadius).GetConstructor(new Type[]
                //    {
                //        typeof(float), typeof(float), typeof(float), typeof(float)
                //    });

                //    if (ctor != null)
                //    {
                //        return new InstanceDescriptor(ctor, new object[]
                //        {
                //            radius.TopLeft, radius.TopRight, radius.BottomLeft, radius.BottomRight
                //        });
                //    }

                //}
                return new CornerRadius(radius.TopLeft, radius.TopRight, radius.BottomLeft, radius.BottomRight);
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }


        public override object CreateInstance(ITypeDescriptorContext context, System.Collections.IDictionary propertyValues)
        {
            //if (context == null)
            //{
            //    throw new ArgumentNullException(nameof(context));
            //}

            //if (propertyValues == null)
            //{
            //    throw new ArgumentNullException(nameof(propertyValues));
            //}

            if (propertyValues.Contains("All"))
            {
                float all = (float)propertyValues["All"];
                return new CornerRadius(all);
            }

            return new CornerRadius(
                (float)propertyValues["TopLeft"],
                (float)propertyValues["TopRight"],
                (float)propertyValues["BottomLeft"],
                (float)propertyValues["BottomRight"]
            );
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
