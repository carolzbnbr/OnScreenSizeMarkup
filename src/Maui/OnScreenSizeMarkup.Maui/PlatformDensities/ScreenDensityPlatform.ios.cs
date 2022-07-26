using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;
using UIKit;


using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
#pragma warning disable CS8603
namespace OnScreenSizeMarkup.Maui.PlatformDensities;


#if IOS
internal static partial  class ScreenDensityPlatform 
{
	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

		var dimensions = (displayInfo.Width / displayInfo.Density, displayInfo.Height / displayInfo.Density);

		AppleScreenDensityHelper.TryGetPpiWithFallBacks(DeviceInfo.Current.Model, DeviceInfo.Current.Name, dimensions, out var ppi);
		return (ppi , ppi);
	}
}
#endif