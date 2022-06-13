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

            $"{nameof(OnScreenSize)} - Screen-Category:{category} - Physical-Device-Size:{DeviceDisplay.MainDisplayInfo.Width}x{DeviceDisplay.MainDisplayInfo.Height} - Device-Model:\"{Microsoft.Maui.Devices.DeviceInfo.Model}\"".WriteToLog();
            
            Manager.Current.CurrentCategory = category;
            return true;
        }

#pragma warning disable IDE0040
        private static ScreenCategories GetHandlerCategory()
#pragma warning restore IDE0040
        {
            var physicalSize = GetPhysicalSize();
            
            var category = Manager.Current.Handler.GetCategoryByDeviceModel(Microsoft.Maui.Devices.DeviceInfo.Model);
            if (category != ScreenCategories.NotSet)
            {
	            return category;
            }

            category = Manager.Current.Handler.GetCategoryByPhysicalSize(physicalSize.DeviceWidth, physicalSize.DeviceHeight);

            if (category == ScreenCategories.NotSet)
            {
                throw new UnkownScreenSizeException($"Fail to classify this device screen size based on device-model \"{Microsoft.Maui.Devices.DeviceInfo.Model}\" or device Width/Height ({physicalSize.DeviceWidth}x{physicalSize.DeviceHeight}). Maybe you need to implement your own version of the handler.");
            }

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
