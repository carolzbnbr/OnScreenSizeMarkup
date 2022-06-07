using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Forms.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnScreenSizeMarkup.Forms
{
    [ContentProperty(nameof(DefaultSize))]
    public  class OnScreenSizeExtension<T> : OnScreenSizeExtensionBase<T>, IMarkupExtension<T>
    {

        public OnScreenSizeExtension()
        {
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
        
        public T ProvideValue(IServiceProvider serviceProvider)
        {

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }
        
            var bindableProperty = GetBindableProperty(serviceProvider, out var propertyType);

            var value = GetValue();

            return value.ConvertTo(propertyType, bindableProperty, valueConverter: Converter, valueConverterParameter: ConverterParameter);
        }

        private static BindableProperty GetBindableProperty(IServiceProvider serviceProvider, out Type propertyType)
        {
            var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException();

            BindableProperty bp;
            PropertyInfo pi = null;
            propertyType = null;

            if (valueProvider.TargetObject is Setter setter)
            {
                bp = setter.Property;
            }
            else
            {
                bp = valueProvider.TargetProperty as BindableProperty;
                pi = valueProvider.TargetProperty as PropertyInfo;
            }

            propertyType = bp?.ReturnType ?? pi?.PropertyType ??
                throw new InvalidOperationException("OnScreenMarkup: Could not get the property type for a provided value.");
            return bp;
        }
      
        private  T GetValue()
        {
            var screenSize = ScreenCategoryExtension.GetCategory();
            if (screenSize != ScreenCategories.NotSet)
            {
                if (_valuesDefinitionIndicator[screenSize])
                {
                    return _values[screenSize];
                }
            }

            if (Equals(DefaultSize,defaultNull))
            {
                throw new XamlParseException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(DefaultSize)} set.");
            }
            
            return (T)DefaultSize;
        }
        


    }
}