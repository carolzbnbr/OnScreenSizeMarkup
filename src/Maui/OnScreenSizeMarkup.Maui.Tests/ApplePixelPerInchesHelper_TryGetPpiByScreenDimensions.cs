using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ApplePixelPerInchesHelper_TryGetPpiByScreenDimensions
{
    [Theory]
    [InlineData(320, 480, 163)]
    [InlineData(428, 926, 458)]
    [InlineData(834, 1194, 264)]
    [InlineData(1024,1366, 264)]
    public void Should_ReturnTrue_And_CorrectPPI_When_DeviceSizeIsFound(double width, double height, int expectedPPI)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiByScreenDimensions((width, height), out var actualPPI);

        Assert.Equal(expectedPPI, actualPPI);
        Assert.Equal(true, actualReturn);
    }
    
    [Theory]
    [InlineData(1000, 100)]
    [InlineData(90000, 400)]
    [InlineData(0, 0)]
    public void Should_ReturnFalse_When_DeviceSizeIsNotFound(double width, double height)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiByScreenDimensions((width, height), out var actualPPI);

        Assert.Equal(false, actualReturn);
    }
}