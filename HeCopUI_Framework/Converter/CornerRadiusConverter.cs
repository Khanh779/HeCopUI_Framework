using HeCopUI_Framework.Structs;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace HeCopUI_Framework.Converter
{
    // Summary:
    //     Provides a type converter to convert System.Windows.Forms.CornerRadius values 
    //     to and from various other representations.
    public class CornerRadiusConverter : TypeConverter
    {
        // Summary:
        //     Returns whether this converter can convert an object of one type to the type
        //     of this converter.
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        // Summary:
        //     Returns whether this converter can convert the object to the specified type,
        //     using the specified context.
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        // Summary:
        //     Converts the given object to the type of this converter, using the specified
        //     context and culture information.
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
                float[] radiusValues = new float[parts.Length];
                TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));

                for (int i = 0; i < radiusValues.Length; i++)
                {
                    radiusValues[i] = (float)floatConverter.ConvertFromString(context, culture, parts[i]);
                }

                if (radiusValues.Length == 4)
                {
                    return new CornerRadius(radiusValues[0], radiusValues[1], radiusValues[2], radiusValues[3]);
                }

                throw new ArgumentException($"Cannot convert '{trimmedText}' to CornerRadius. Expected format: 'TopLeft, TopRight, BottomLeft, BottomRight'.");

            }

            return base.ConvertFrom(context, culture, value);
        }

        // Summary:
        //     Converts the given value object to the specified type, using the specified context
        //     and culture information.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException(nameof(destinationType));
            }

            if (value is CornerRadius cornerRadius)
            {
                if (destinationType == typeof(string))
                {
                    if (culture == null)
                    {
                        culture = CultureInfo.CurrentCulture;
                    }

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter floatConverter = TypeDescriptor.GetConverter(typeof(float));
                    string[] radiusStrings = new string[4];
                    radiusStrings[0] = floatConverter.ConvertToString(context, culture, cornerRadius.TopLeft);
                    radiusStrings[1] = floatConverter.ConvertToString(context, culture, cornerRadius.TopRight);
                    radiusStrings[2] = floatConverter.ConvertToString(context, culture, cornerRadius.BottomLeft);
                    radiusStrings[3] = floatConverter.ConvertToString(context, culture, cornerRadius.BottomRight);
                    return string.Join(separator, radiusStrings);
                }

                if (destinationType == typeof(InstanceDescriptor))
                {
                    ConstructorInfo constructor = typeof(CornerRadius).GetConstructor(new Type[] { typeof(float), typeof(float), typeof(float), typeof(float) });
                    if (constructor != null)
                    {
                        return new InstanceDescriptor(constructor, new object[] { cornerRadius.TopLeft, cornerRadius.TopRight, cornerRadius.BottomLeft, cornerRadius.BottomRight });
                    }
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        // Summary:
        //     Creates an instance of the type that this System.ComponentModel.TypeConverter
        //     is associated with, using the specified context, given a set of property values
        //     for the object.
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (propertyValues == null)
            {
                throw new ArgumentNullException(nameof(propertyValues));
            }

            CornerRadius currentRadius = (CornerRadius)context.PropertyDescriptor.GetValue(context.Instance);
            float all = (float)propertyValues["All"];

            if (currentRadius.TopLeft != all || currentRadius.TopRight != all ||
                currentRadius.BottomLeft != all || currentRadius.BottomRight != all)
            {
                return new CornerRadius(all);
            }

            return new CornerRadius(
                (float)propertyValues["TopLeft"],
                (float)propertyValues["TopRight"],
                (float)propertyValues["BottomLeft"],
                (float)propertyValues["BottomRight"]
            );
        }

        // Summary:
        //     Returns whether changing a value on this object requires a call to 
        //     System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary)
        //     to create a new value, using the specified context.
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // Summary:
        //     Returns a collection of properties for the type of array specified by the value
        //     parameter, using the specified context and attributes.
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CornerRadius), attributes);
            return properties.Sort(new string[] { "All", "TopLeft", "TopRight", "BottomLeft", "BottomRight" });
        }

        // Summary:
        //     Returns whether this object supports properties, using the specified context.
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        // Summary:
        //     Initializes a new instance of the System.Windows.Forms.CornerRadiusConverter class.
        public CornerRadiusConverter()
        {
        }
    }
}
