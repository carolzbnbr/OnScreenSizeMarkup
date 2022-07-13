using OnScreenSizeMarkup.Maui.Helpers;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests;

public class ApplePixelPerInchesHelper_TryGetPpiByDeviceModel
{
    [Theory]
    [InlineData("iPhone5,2", 326)]
    [InlineData("iPhone12,3", 458)]
    public void Should_ReturnTrue_And_CorrectPPI_When_DeviceModelIsKnown(string appleDeviceModel, int expectedPPI)
    {
        var actualReturn = ApplePixelPerInchesHelper.TryGetPpiByDeviceModel(appleDeviceModel, out var actualPPI);

        Assert.Equal(expectedPPI, actualPPI);
        Assert.Equal(true, actualReturn);
    }
    
    [Theory]
    [InlineData("X86_64")]
    [InlineData("arm64")]
    [InlineData("i386")]
    [InlineData("unkown-device-model")]
    public void Should_ReturnFalse_When_DeviceModelIsUnkown(string appleDeviceModel)
    {
        bool expected = false;
        
        var actual = ApplePixelPerInchesHelper.TryGetPpiByDeviceModel(appleDeviceModel, out var actualPPI);

        Assert.Equal(expected, actual);
    }
}