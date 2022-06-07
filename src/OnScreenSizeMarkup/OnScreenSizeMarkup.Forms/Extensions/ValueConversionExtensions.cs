using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Core.Extensions;
using Xamarin.Forms;

namespace OnScreenSizeMarkup.Forms.Extensions
{
    public static class ValueConversionExtensions
    {
        private static Dictionary<Type, TypeConverter> _converter = new ();

        /// <summary>
        /// Tenta converter o valor de <paramref name="value"/> para <paramref name="toType"/>, usando se necessário as informações de <paramref name="bindableProperty"/>
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="toType">destination type</param>
        /// <param name="bindableProperty"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(this T value, Type toType, BindableProperty bindableProperty, IValueConverter valueConverter = null, object valueConverterParameter = null)
        {
            //

            if (Manager.Current.IsDebugMode)

            {
                var log1 =$"Attempting To Convert \"{(value == null ? "null": (T)value)}\" of type:{(value == null ? "null": value.GetType())} to Type:{(toType == null ? "null" : toType)} on bindable Property of type:{(bindableProperty == null ? "null": bindableProperty.ReturnType)}";
                log1.WriteToLog();
            }

            
            if (valueConverter != null)
            {
                return (T)valueConverter.Convert(value, toType, valueConverterParameter, CultureInfo.CurrentUICulture);
            }
            

            if (value.GetType() == toType)
            {
                return value;
            }

            T returnValue = default(T);
            
            if (_converter.TryGetValue(toType, out var converter))
            {
                if (value is not string stringValue)
                {
                    stringValue = converter.ConvertToInvariantString(value);
                }
                returnValue = (T)converter.ConvertFromInvariantString(stringValue);     
                
                return returnValue;
            }

            if (toType.IsEnum)
            {
                if (value is string stringValue)
                {
                    returnValue = (T)Enum.Parse(toType, stringValue);
                }
                return returnValue;
            }

            if (toType == typeof(RowDefinitionCollection))
            {
                converter = (TypeConverter)new RowDefinitionCollectionTypeConverter();
                _converter.Add(toType, converter);
                
                if (value is not string stringValue)
                {
                    stringValue = converter.ConvertToInvariantString(value);
                }
                returnValue = (T)converter.ConvertFromInvariantString(stringValue);     
                return returnValue;
            }

            if (toType == typeof(ColumnDefinitionCollection))
            {
                converter = (TypeConverter)new ColumnDefinitionCollectionTypeConverter();
                _converter.Add(toType, converter);
                
                if (value is not string stringValue)
                {
                    stringValue = converter.ConvertToInvariantString(value);
                }
                returnValue = (T)converter.ConvertFromInvariantString(stringValue);     
                return returnValue;
                
            }

            if (toType.Namespace.StartsWith("Xamarin.Forms"))
            {
                var typeConverter = toType.GetCustomAttribute<TypeConverterAttribute>(true);

                if (typeConverter != null && typeConverter.ConverterTypeName != null)
                {
                    var converterType = Type.GetType(typeConverter.ConverterTypeName);

                    converter = (TypeConverter)Activator.CreateInstance(converterType);

                    _converter.Add(toType, converter);
                    
                    if (value is not string stringValue)
                    {
                        stringValue = converter.ConvertToInvariantString(value);
                    }
                    return (T)converter.ConvertFromInvariantString(stringValue);                
                }
            }

            if (bindableProperty != null && toType == typeof(System.Double) && bindableProperty.PropertyName.Equals("FontSize", StringComparison.InvariantCultureIgnoreCase))
            {
                if (value is not string stringValue)
                {
                    stringValue = new FontSizeConverter().ConvertToInvariantString(value);
                }
                returnValue = (T) new FontSizeConverter().ConvertFromInvariantString(stringValue);

                return returnValue;
            }

            returnValue = (T)Convert.ChangeType(value, toType, CultureInfo.InvariantCulture);
            return returnValue;
        }


    }
}
