using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ApplePixelPerInchesHelper_TryGetPpiByDeviceName
{
    [Theory]
    [InlineData("iPhone 11 Pro Max", 458)]
    [InlineData("iPhone 13 PRO MAX", 458)]
    [InlineData("iPhone 13 Pro", 460)]
    [InlineData("IPHONE 8 PLUS", 401)]
    [InlineData("iPhone 6 Plus", 401)]
    public void Should_ReturnTrue_And_CorrectPPI_When_DeviceNameIsKnown(string appleDeviceName, int expectedPPI)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiByDeviceName(appleDeviceName, out var actualPPI);

        Assert.Equal(expectedPPI, actualPPI);
        Assert.Equal(true, actualReturn);
    }
    
    [Theory]
    [InlineData("iPhone old")]
    [InlineData("iPhone master blaster")]
    [InlineData("Null")]
    public void Should_ReturnFalse_When_DeviceNameIsUnkown(string appleDeviceModel)
    {
        bool expected = false;
        
        var actual = ApplePixelPerInchesHelper.TryGetPpiByDeviceModel(appleDeviceModel, out var actualPPI);
    
        Assert.Equal(expected, actual);
    }
}