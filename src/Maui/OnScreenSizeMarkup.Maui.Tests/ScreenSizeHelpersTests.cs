using System;
using NSubstitute;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Providers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ScreenSizeHelpersTests
{
    [Theory]
    [InlineData(ScreenCategories.ExtraSmall, 5, 2.0, 10.0)]
    [InlineData(ScreenCategories.Small, 5, 3.0, 15.0)]
    [InlineData(ScreenCategories.Medium, 5, 4.0, 20.0)]
    [InlineData(ScreenCategories.Large, 5, 5.0, 25.0)]
    [InlineData(ScreenCategories.ExtraLarge, 5, 6.0, 30.0)]
    [InlineData(ScreenCategories.NotSet, 5, 1.0, 5.0)]
    public void TestOnScreenSize_IConvertible(ScreenCategories screenCategory, IConvertible baseSize, double factor, double expected)
    {
        var screenCategoryProvider = Substitute.For<IScreenCategoryProvider>();
        screenCategoryProvider.GetCategory().Returns(screenCategory);
    
        var screenSizeHelpers = new ScreenSizeHelpers(screenCategoryProvider);
        double result = (double)screenSizeHelpers.OnScreenSize(baseSize, extraSmallFactor: factor, smallFactor: factor, mediumFactor: factor, largeFactor: factor, extraLargeFactor: factor);
    
        Assert.Equal(expected, result);
    }
}