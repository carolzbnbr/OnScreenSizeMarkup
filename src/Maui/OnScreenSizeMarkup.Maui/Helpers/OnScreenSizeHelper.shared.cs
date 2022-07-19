using System.Collections.Generic;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Handlers;
using OnScreenSizeMarkup.Maui.Helpers;

namespace OnScreenSizeMarkup.Maui.Helpers;

public static class OnScreenSizeHelpers
{
	
	internal static double GetScreenDiagonalInches()
	{
		var dpi =  ScreenDensityPlatform.GetPixelPerInches();
		
		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
	     
		return GetScreenDiagonalInches(displayInfo.Width, displayInfo.Height,displayInfo.Density, dpi.xdpi, dpi.ydpi );
	}
        
	internal static double GetScreenDiagonalInches(double width, double height, double scale, double xDpi, double yDpi)
	{
		var width1 = width;
		var height1 = height;
	        
		var horizontal = width1 / xDpi;
		var vertical = height1 / yDpi;

		var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));

		var diagonalReturnValue = diagonal.RoundUp();

		ConsoleHelpers.WriteLine($"{nameof(OnScreenSizeExtension)} - DiagonalSize: {diagonalReturnValue},  PPI/DPI: x:\"{xDpi}\", y:\"{yDpi}\"", LogLevels.Info);
	        
		return diagonal.RoundUp();
	}

	public static T OnScreenSize<T>(T defaultSize= default(T)!,
		T extraSmall = default(T)!,
		T small = default(T)!,
		T medium = default(T)!,
		T large = default(T)!,
		T extraLarge = default(T)!)
	{
		var screenSize = ScreenCategoryHelper.GetCategory();
		switch (screenSize)
		{
			case ScreenCategories.ExtraSmall:
				return extraSmall;
			case ScreenCategories.Small:
				return small;
			case ScreenCategories.Medium:
				return medium;
			case ScreenCategories.Large:
				return large;
			case ScreenCategories.ExtraLarge:
				return extraLarge;
		}

		if (EqualityComparer<T>.Default.Equals(defaultSize, default(T)))
		{
			throw new ArgumentException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(defaultSize)} set.");
		}
		
		return defaultSize;
	}
}