using System;
using System.ComponentModel;
using System.Globalization;
using Our.Umbraco.Ditto;

namespace Our.Umbraco.DitFlo.Ditto.TypeConverters
{
    public class InvertBooleanConverter : DittoConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(bool)) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, 
            CultureInfo culture, object value)
        {
            return !((bool)value);
        }
    }
}
