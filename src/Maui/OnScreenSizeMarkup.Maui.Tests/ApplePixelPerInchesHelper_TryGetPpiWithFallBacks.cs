using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ApplePixelPerInchesHelper_TryGetPpiWithFallBacks
{
    [Theory]
    [InlineData("iPhone14,2", "iPhone 13 Pro", 390, 844, 460)]
    [InlineData("iPhone10,4","iPhone 8", 375, 667, 326)]
    public void Should_ReturnTrue_And_CorrectPPI_When_CorrectValuesAreProvided(string deviceModel, string deviceName, double width, double height, int expectedPPI)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiWithFallBacks(deviceModel, deviceName, (width, height), out var actualPPI);

        Assert.Equal(expectedPPI, actualPPI);
        Assert.Equal(true, actualReturn);
    }
    
    [Theory]
    [InlineData("XXXXX", "Samsung Galaxy 7", 190, 544)]
    [InlineData("HARDWARE_ID","Phone name", 215, 47)]
    public void Should_ReturnFalse_When_InvalidValuesAreProvided(string deviceModel, string deviceName, double width, double height)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiWithFallBacks(deviceModel, deviceName, (width, height), out var actualPPI);

        Assert.Equal(false, actualReturn);
    }
}