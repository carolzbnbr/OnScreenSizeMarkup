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


        private Dictionary<ScreenSizeGroups, object> _values = new Dictionary<ScreenSizeGroups, object>() {
            { ScreenSizeGroups.ExtraSmall, null},
            { ScreenSizeGroups.Small, null},
            { ScreenSizeGroups.Medium,  null},
            { ScreenSizeGroups.Large,  null},
            { ScreenSizeGroups.ExtraLarge,  null},
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

                return _values[ScreenSizeGroups.ExtraSmall];
            }
            set
            {
                _values[ScreenSizeGroups.ExtraSmall] = value;
            }
        }

        public object Small
        {
            get
            {

                return _values[ScreenSizeGroups.Small];
            }
            set
            {
                _values[ScreenSizeGroups.Small] = value;
            }
        }
        public object Medium
        {
            get
            {

                return _values[ScreenSizeGroups.Medium];
            }
            set
            {
                _values[ScreenSizeGroups.Medium] = value;
            }
        }

        public object Large
        {
            get
            {

                return _values[ScreenSizeGroups.Large];
            }
            set
            {
                _values[ScreenSizeGroups.Large] = value;
            }
        }

        public object ExtraLarge
        {
            get
            {

                return _values[ScreenSizeGroups.ExtraLarge];
            }
            set
            {
                _values[ScreenSizeGroups.ExtraLarge] = value;
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
            var screenSize = GetScreenSize();
            if (screenSize != ScreenSizeGroups.NotSet)
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


        private ScreenSizeGroups GetScreenSize()
        {
            if (TryGetScreenSize(out var screenSize))
            {

                return screenSize;
            }

            return ScreenSizeGroups.NotSet;
        }


        private  bool TryGetScreenSize(out ScreenSizeGroups screenSize)
        {
            if (Manager.Current.DeviceScreenSize != null)
            {
                if (Manager.Current.DeviceScreenSize.Value != ScreenSizeGroups.NotSet)
                {
                    screenSize = Manager.Current.DeviceScreenSize.Value;
                    return true;
                }
            }

            screenSize = GetHandlerScreenSize();

#if DEBUG
            Console.WriteLine($"ScreenSize: {screenSize}. Physiscal Device Size: {DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height}");
#endif
            Manager.Current.DeviceScreenSize = screenSize;
            return true;
        }

        private  ScreenSizeGroups GetHandlerScreenSize()
        {
            ScreenSizeGroups screenSize;
            if (!Manager.Current.Handler.TryGetSizeByDeviceModel(DeviceInfo.Model, out screenSize) || screenSize == ScreenSizeGroups.NotSet)
            {
               var physicalSize = GetPhysicalSize();

                if (!Manager.Current.Handler.TryGetSizeByPhysicalSize(physicalSize.DeviceWidth, physicalSize.DeviceHeight, out screenSize) || screenSize == ScreenSizeGroups.NotSet)
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
