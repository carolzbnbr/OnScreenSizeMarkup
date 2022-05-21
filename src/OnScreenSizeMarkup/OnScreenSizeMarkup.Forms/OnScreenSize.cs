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
            var screenSize = GetCategory();
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


        private ScreenCategories GetCategory()
        {
            if (TryGetCategory(out var category))
            {

                return category;
            }

            return ScreenCategories.NotSet;
        }

        private ScreenCategories? currentCategory = null;

        private  bool TryGetCategory(out ScreenCategories category)
        {
            if (currentCategory != null)
            {
                if (currentCategory.Value != ScreenCategories.NotSet)
                {
                    category = currentCategory.Value;
                    return true;
                }
            }

            category = GetHandlerCategory();

#if DEBUG
            Console.WriteLine($"{nameof(OnScreenSize)} - Category:{category} - Physical Device Size:{DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height}");
#endif
            currentCategory = category;
            return true;
        }

        private  ScreenCategories GetHandlerCategory()
        {
            ScreenCategories screenSize;
            if (!Manager.Current.Handler.TryGetCategoryByDeviceModel(DeviceInfo.Model, out screenSize) || screenSize == ScreenCategories.NotSet)
            {
               var physicalSize = GetPhysicalSize();

                if (!Manager.Current.Handler.TryGetCategoryByPhysicalSize(physicalSize.DeviceWidth, physicalSize.DeviceHeight, out screenSize) || screenSize == ScreenCategories.NotSet)
                {
                    throw new UnkownScreenSizeException($"Fail to classify this device screen size based on Width/Height ({DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height}). Maybe you need to implement your own version of the handler.");
                }
            }

            return screenSize;
        }

        private (double DeviceWidth, double DeviceHeight) GetPhysicalSize()
        {
            var device = DeviceDisplay.MainDisplayInfo;

            var deviceWidth = device.Width;
            var deviceHeight = device.Height;
            if (Xamarin.Essentials.DeviceInfo.Idiom == Xamarin.Essentials.DeviceIdiom.Tablet)
            {
                deviceWidth = Math.Max(device.Width, device.Height);
                deviceHeight = Math.Min(device.Width, device.Height);
            }

            return (deviceWidth, deviceHeight);
        }
    }
}
