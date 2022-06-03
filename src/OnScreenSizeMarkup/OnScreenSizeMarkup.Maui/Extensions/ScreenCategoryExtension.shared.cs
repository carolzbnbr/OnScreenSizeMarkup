using System;
using Microsoft.Maui.Devices;
using OnScreenSizeMarkup.Maui.Exceptions;

namespace OnScreenSizeMarkup.Maui.Extensions
{
    public static class ScreenCategoryExtension
    {

        internal static ScreenCategories GetCategory()
        {
            if (TryGetCategory(out var category))
            {

                return category;
            }

            return ScreenCategories.NotSet;
        }


        private static bool TryGetCategory(out ScreenCategories category)
        {
            if (Manager.Current.CurrentCategory != null)
            {
                if (Manager.Current.CurrentCategory.Value != ScreenCategories.NotSet)
                {
                    category = Manager.Current.CurrentCategory.Value;
                    return true;
                }
            }

            category = GetHandlerCategory();

            Console.WriteLine($"{nameof(OnScreenSize)} - Screen-Category:{category} - Physical-Device-Size:{DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height}");

            Manager.Current.CurrentCategory = category;
            return true;
        }

        private static ScreenCategories GetHandlerCategory()
        {
            var physicalSize = GetPhysicalSize();

            var category = Manager.Current.Handler.GetCategoryByPhysicalSize(physicalSize.DeviceWidth, physicalSize.DeviceHeight);

            if (category == ScreenCategories.NotSet)
            {
                throw new UnkownScreenSizeException($"Fail to classify this device screen size based on Width/Height ({physicalSize.DeviceWidth}x{physicalSize.DeviceHeight}). Maybe you need to implement your own version of the handler.");
            }


            //if (!Manager.Current.Handler.TryGetCategoryByDeviceModel(DeviceInfo.Model, out screenSize) || screenSize == ScreenCategories.NotSet)
            //{
            //    var physicalSize = GetPhysicalSize();

            //    if (!Manager.Current.Handler.TryGetCategoryByPhysicalSize(physicalSize.DeviceWidth, physicalSize.DeviceHeight, out screenSize) || screenSize == ScreenCategories.NotSet)
            //    {
            //        throw new UnkownScreenSizeException($"Fail to classify this device screen size based on Width/Height ({DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height}). Maybe you need to implement your own version of the handler.");
            //    }
            //}

            return category;
        }

        private static  (double DeviceWidth, double DeviceHeight) GetPhysicalSize()
        {
            var device = DeviceDisplay.MainDisplayInfo;

            var deviceWidth = device.Width;
            var deviceHeight = device.Height;
            if (DeviceInfo.Idiom == DeviceIdiom.Tablet)
            {
                deviceWidth = Math.Max(device.Width, device.Height);
                deviceHeight = Math.Min(device.Width, device.Height);
            }

            return (deviceWidth, deviceHeight);
        }
    }
}
