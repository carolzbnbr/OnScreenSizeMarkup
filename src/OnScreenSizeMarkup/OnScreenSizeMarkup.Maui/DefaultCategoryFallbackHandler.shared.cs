using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnScreenSizeMarkup.Maui;

//https://www.omnicalculator.com/other/screen-size#:~:text=To%20calculate%20screen%20size%3A,the%20area%20of%20the%20screen.

public partial class DefaultCategoryFallbackHandler : ICategoryFallbackHandler
{
	private ScreenCategories Category { get; set; }


    /// <summary>
    /// Attempt to get the <see cref="ScreenCategories"/> by device's physical size (width/height).
    /// </summary>
    /// <param name="deviceWidth"></param>
    /// <param name="deviceHeight"></param>
    /// <returns>The <see cref="ScreenCategories"/> a device size fits in</returns>
    public ScreenCategories GetCategoryByPhysicalSize(double deviceWidth, double deviceHeight)
    {
        RequestScreenCategoryPlatform(deviceWidth, deviceHeight);

        return Category;
    }
	
	 partial void RequestScreenCategoryPlatform(double deviceWidth, double deviceHeight);
}
