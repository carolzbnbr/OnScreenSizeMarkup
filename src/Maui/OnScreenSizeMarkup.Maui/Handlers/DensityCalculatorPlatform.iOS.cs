using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;
using UIKit;


using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
#pragma warning disable CS8603
namespace OnScreenSizeMarkup.Maui.Handlers;


#if IOS
internal static partial  class DensityCalculatorPlatform 
{

	
	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayInfo = DeviceDisplay.Current.MainDisplayInfo;

		(double xdpi, double ydpi) dimensions = new (displayInfo.Width / displayInfo.Density, displayInfo.Height / displayInfo.Density);

		AppleHelper.TryGetPpiWithFallBacks(DeviceInfo.Current.Model, DeviceInfo.Current.Name, dimensions, out var ppi);
		return (ppi , ppi);

	}
}

#endif