using System;
using System.Diagnostics;
using System.Reflection;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Core.Exceptions;
using OnScreenSizeMarkup.Forms.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OnScreenSizeMarkup.Forms
{
    //[ContentProperty(nameof(TypeName))]
    public class OnScreenSizeExtension : OnScreenSizeExtensionBase<object>, IMarkupExtension
    {
        public  OnScreenSizeExtension()
        {
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var valueProvider = serviceProvider?.GetService<IProvideValueTarget>() ?? throw new ArgumentException();

            BindableProperty bp;
            PropertyInfo pi = null;
            Type propertyType = null;

            if (valueProvider.TargetObject is Setter setter)
            {
                bp = setter.Property;
            }
            else
            {
                bp = valueProvider.TargetProperty as BindableProperty;
                pi = valueProvider.TargetProperty as PropertyInfo;
            }

            propertyType = bp?.ReturnType ?? pi?.PropertyType ?? throw new InvalidOperationException("Não foi posivel determinar a propriedade para fornecer o valor.");

            var value = GetValue(serviceProvider);


            return value.ConvertTo(propertyType, bp);
        }


        private object GetValue(IServiceProvider serviceProvider)
        {
            var screenSize = ScreenCategoryExtension.GetCategory();
            if (screenSize != ScreenCategories.NotSet)
            {
                if (_values[screenSize] != null)
                {
                    return _values[screenSize];
                }
            }

            if (DefaultSize == null)
            {
                throw new XamlParseException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(DefaultSize)} set.");
            }
            else
            {
                return DefaultSize;
            }
        }


    }
}
