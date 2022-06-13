/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace  OnScreenSizeMarkup.Maui;

//https://www.omnicalculator.com/other/screen-size#:~:text=To%20calculate%20screen%20size%3A,the%20area%20of%20the%20screen.

public class DiagonalScreenCategoryHandler : ICategoryFallbackHandler
{

	public ScreenCategories GetCategoryByPhysicalSize(double deviceWidth, double deviceHeight)
	{

		var deviceDiagonalScreenSize = GetDiagonalScreenSize(deviceWidth, deviceHeight);

		if (deviceDiagonalScreenSize <= 40)
		{
			return ScreenCategories.ExtraSmall;
		}
		else if (deviceDiagonalScreenSize is (> 40 and <= 65))
		{
			return ScreenCategories.Small;
		}

		else if (deviceDiagonalScreenSize is (> 65 and <= 76))
		{
			return ScreenCategories.Medium;
		}
		else if (deviceDiagonalScreenSize is (> 76 and <= 92))
		{
			return ScreenCategories.Large;
		}

		return ScreenCategories.ExtraLarge;

	}

	private static double GetDiagonalScreenSize(double deviceWidth, double deviceHeight)
	{
		var result = (deviceWidth * 2) + (deviceHeight * 2);
		return Math.Sqrt(result);
	}
}*/