
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Converters;
using Xunit;


namespace OnScreenSizeMarkup.Maui.Tests;

public class ValueConversionExtensionsTests
{
    [Fact]
    public void ConvertTo_String_To_RowDefinition()
    {
        var stringToParse = "0.25*, 0.13*, 0.08*, 230, *";
        
        var expected =  (RowDefinitionCollection)new RowDefinitionCollectionTypeConverter().ConvertFromInvariantString(stringToParse);
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(RowDefinitionCollection), Grid.RowDefinitionsProperty);
        
        //assert
        Assert.IsType<RowDefinitionCollection>(actual);
        Assert.Equal(expected.Count, ((RowDefinitionCollection)actual).Count);
    }
    
    [Fact]
    public void ConvertTo_String_To_CornerRadius()
    {
        var stringToParse = "200 200 200 200";
        
        var expected = new CornerRadiusTypeConverter().ConvertFromInvariantString(stringToParse);
        
        var actual = Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(Microsoft.Maui.CornerRadius ), VerticalStackLayout.SpacingProperty);
        
        //assert
        Assert.IsType<CornerRadius>(actual);
        //assert
        var actualCast = (CornerRadius)actual;
        Assert.Equal(200, actualCast.TopLeft);
    }
    [Fact]
    public void ConvertTo_String_To_Thickness()
    {
        var stringToParse = "5,0";
        
        var expected = new ThicknessTypeConverter().ConvertFromInvariantString(stringToParse);
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(Microsoft.Maui.Thickness ), VerticalStackLayout.SpacingProperty);
        
        //assert
        Assert.IsType<Thickness>(actual);
    }
}