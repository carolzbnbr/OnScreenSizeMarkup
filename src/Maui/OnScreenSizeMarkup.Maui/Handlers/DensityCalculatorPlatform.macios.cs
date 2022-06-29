using OnScreenSizeMarkup.Maui.Extensions;
using UIKit;

namespace OnScreenSizeMarkup.Maui.Handlers;

#if MACCATALYST
internal static partial class DensityCalculatorPlatform 
{
	/*public static double GetScreenDiagonalInches()
	{
		var dpi = GetPixelPerInches();
		
		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
		
		var width = displayInfo.Width * displayInfo.Density;
		var height = displayInfo.Height * displayInfo.Density;
        
		var horizontal = width / dpi;
		var vertical = height / dpi;

		var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));

		return diagonal.RoundUp();
	}
	*/

	
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