using OnScreenSizeMarkup.Maui.Extensions;
using UIKit;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;

#if MACCATALYST
internal static partial class ScreenDensityPlatform 
{
	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
		
		var scale = displayInfo.Density;
		var dpi = scale * 160;
		
		if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
		{
			dpi = scale * 132;
		} 
		else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
		{
			dpi = scale * 163;
		}

		return (dpi, dpi);
	}
}
#endif