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
            return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
        }

        // Overrides the ConvertFrom method of TypeConverter.
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                string text2 = ((string)value).Trim();

                if(!text2.Contains(','))
                {
                    return new CornerRadius(float.Parse(text2));
                }
                else
                {
                    string[] v = text2.Split(',');
                    return new CornerRadius(float.Parse(v[0]), float.Parse(v[1]), float.Parse(v[2]), float.Parse(v[3]));
                }
              

                throw new ArgumentException("TextParseFailedFormat:\n" + value);
            }
            return base.ConvertFrom(context, culture, value);
        }

        // Overrides the ConvertTo method of TypeConverter.
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is CornerRadius)
            {
                if (destinationType == typeof(string))
                {
                    CornerRadius cornerRadius = (CornerRadius)value;
                    return cornerRadius.TopLeft+", "+ cornerRadius.TopRight+", "+ cornerRadius.BottomLeft+", "+ cornerRadius.BottomRight;
                }
            }

            if (destinationType == typeof(CornerRadius))
            {
                CornerRadius cornerRadius = (CornerRadius)value;
                if(cornerRadius.ShouldSerializeAll())
                {
                    return new object[] { cornerRadius.All };
                }    

                return new object[] { cornerRadius.TopLeft, cornerRadius.TopRight, cornerRadius.BottomLeft, cornerRadius.BottomRight };
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