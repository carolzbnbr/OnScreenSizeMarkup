using System.Diagnostics.CodeAnalysis;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Handlers;

namespace OnScreenSizeMarkup.Maui.Helpers;

[SuppressMessage("Style", "IDE0040:Add accessibility modifiers")]
internal static class DiagonalSizeHelper
{

	public static double GetScreenDiagonalInches()
	{
		var dpi =  DensityCalculatorPlatform.GetPixelPerInches();
		
		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
	     
		return GetScreenDiagonalInches(displayInfo.Width, displayInfo.Height,displayInfo.Density, dpi.xdpi, dpi.ydpi );
	}
        
	public static double GetScreenDiagonalInches(double width, double height, double scale, double xDpi, double yDpi)
	{
		var width1 = width;
		var height1 = height;
	        
		// var width1 = width * scale;
		// var height1 = height * scale;
	        
		var horizontal = width1 / xDpi;
		var vertical = height1 / yDpi;

		var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));

		var diagonalReturnValue = diagonal.RoundUp();

		ConsoleHelpers.WriteLine($"{nameof(OnScreenSizeExtension)} - DiagonalSize: {diagonalReturnValue},  PPI/DPI: x:\"{xDpi}\", y:\"{yDpi}\"", LogLevels.Info);
	        
		return diagonal.RoundUp();
	}
    

}