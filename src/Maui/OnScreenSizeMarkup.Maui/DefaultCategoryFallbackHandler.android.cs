/*
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




}
*/
