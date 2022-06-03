using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content.Res;
using Android.Text;
using Android.Text.Style;
using Android.Widget;

namespace OnScreenSizeMarkup.Maui;

    //https://www.omnicalculator.com/other/screen-size#:~:text=To%20calculate%20screen%20size%3A,the%20area%20of%20the%20screen.

partial class DefaultCategoryFallbackHandler 
{


	 partial void RequestScreenCategoryPlatform(double deviceWidth, double deviceHeight)
    {
        var configuration = new Configuration();

        if (configuration.IsLayoutSizeAtLeast((int)ScreenLayout.SizeSmall))
        {
            Category = ScreenCategories.Small;
        }
        if (configuration.IsLayoutSizeAtLeast((int)ScreenLayout.SizeNormal))
        {
            Category = ScreenCategories.Medium;
        }
        else if (configuration.IsLayoutSizeAtLeast((int)ScreenLayout.SizeLarge))
        {
            Category = ScreenCategories.Large;
        }
        else if (configuration.IsLayoutSizeAtLeast((int)ScreenLayout.SizeXlarge))
        {
            Category = ScreenCategories.ExtraLarge;
        }

        Category = ScreenCategories.NotSet;

        //return Category;
    }




    //private partial ScreenCategories GetCategoryByPhysicalSizePlatform(double deviceWidth, double deviceHeight)
    //{
    //    if (Configuration.IsLayoutSizeAtLeast(ScreenLayout.SCREENLAYOUT_SIZE_LARGE))
    //    {

    //    }
    //    if ((Resources.Configuration.ScreenLayout & Configuration.SCREENLAYOUT_SIZE_MASK) == Configuration.SCREENLAYOUT_SIZE_LARGE)
    //    {
    //        // on a large screen device ...

    //    }

    //    return ScreenCategories.NotSet;
    //}



    ///// <summary>
    ///// Attempt to get the screen-size by device's physical size (width/height).
    ///// </summary>
    ///// <param name="deviceWidth"></param>
    ///// <param name="deviceHeight"></param>
    ///// <param name="category"></param>
    ///// <returns></returns>
    //public partial bool TryGetCategoryByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenCategories category)
    //{
    //    category = ScreenCategories.NotSet;
    //    for (int i = 0; i < screenSizeCategories.Length; i++)
    //    {
    //        ScreenSizeInfo sizeInfo = screenSizeCategories[i];
    //        if (deviceWidth <= sizeInfo.Width &&
    //            deviceHeight <= sizeInfo.Height)
    //        {
    //            category = sizeInfo.Category;
    //            return true;
    //        }
    //    }
    //    return false;

    //}
   
}
