using Microsoft.Maui.Controls;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ScreebCalculationsExtension_GetDiagonal
{
 
    //[InlineData(320, 480, 163, 3.5)] //Apple iPhone 3GS
    //[InlineData(750, 1334, 326, 4.7)] //Apple iPhone 6
    //[InlineData(1080, 1920, 401, 5.5)] //Apple iPhone 6/7/8 Plus
    //[InlineData(1125, 2436, 463, 5.8)] //iphone X
    //[InlineData(828, 1792, 326, 6.1)] //iphone 11
    [Fact]
    public void GetDiagonalSize()
    {
        var actual = ScreenCategoryHelper.GetCategory();
        

        Assert.Equal(ScreenCategories.Large, actual);
    }
}