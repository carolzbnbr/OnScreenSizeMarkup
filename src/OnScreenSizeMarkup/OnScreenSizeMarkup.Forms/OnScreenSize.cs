using System;
using System.Collections.Generic;
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
    public class OnScreenSize : IMarkupExtension
    {


        private Dictionary<ScreenCategories, object> _values = new Dictionary<ScreenCategories, object>() {
            { ScreenCategories.ExtraSmall, null},
            { ScreenCategories.Small, null},
            { ScreenCategories.Medium,  null},
            { ScreenCategories.Large,  null},
            { ScreenCategories.ExtraLarge,  null},
        };


        public OnScreenSize()
        {
        }

        /// <summary>
        /// Tamanho-padrao na tela que deve ser assumido quando não for possivel determinar o tamanho dela com base na lista <see cref="_screenSizes"/>
        /// </summary>
        public object DefaultSize { get; set; }


        public object ExtraSmall
        {
            get
            {

                return _values[ScreenCategories.ExtraSmall];
            }
            set
            {
                _values[ScreenCategories.ExtraSmall] = value;
            }
        }

        public object Small
        {
            get
            {

                return _values[ScreenCategories.Small];
            }
            set
            {
                _values[ScreenCategories.Small] = value;
            }
        }
        public object Medium
        {
            get
            {

                return _values[ScreenCategories.Medium];
            }
            set
            {
                _values[ScreenCategories.Medium] = value;
            }
        }

        public object Large
        {
            get
            {

                return _values[ScreenCategories.Large];
            }
            set
            {
                _values[ScreenCategories.Large] = value;
            }
        }

        public object ExtraLarge
        {
            get
            {

                return _values[ScreenCategories.ExtraLarge];
            }
            set
            {
                _values[ScreenCategories.ExtraLarge] = value;
            }
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
                throw new XamlParseException($"{nameof(OnScreenSize)} markup requires a {nameof(DefaultSize)} set.");
            }
            else
            {
                return DefaultSize;
            }
        }


    }
}
