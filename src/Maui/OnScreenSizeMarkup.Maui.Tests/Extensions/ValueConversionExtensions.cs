using System.ComponentModel;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Converters;
using Xunit;

namespace OnScreenSizeMarkup.Maui.Tests.Extensions;

public class ValueConversionExtensionsTests
{
    [Fact]
    public void ConvertTo_String_To_GridLength()
    {
        var stringToParse = "160";
        
        var expected =  (GridLength)new GridLengthTypeConverter().ConvertFromInvariantString(stringToParse);
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(GridLength), RowDefinition.HeightProperty);
        
        //assert
        Assert.IsType<GridLength>(actual);
        Assert.Equal(expected, ((GridLength)actual));
    }
    
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
        
        var actual = Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(Microsoft.Maui.CornerRadius ), VerticalStackLayout.SpacingProperty);
        
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
    
    [Fact]
    public void ConvertTo_String_To_Double()
    {
        var stringToParse = "5.0";
        
        var expected = new DoubleCollectionConverter().ConvertFromInvariantString(stringToParse);
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(double ), null!);
        
        //assert
        Assert.IsType<double>(actual);
    }
    
    [Fact]
    public void ConvertTo_String_To_Int()
    {
        var stringToParse = "5";
        
        var expected = new Int32Converter().ConvertFromInvariantString(stringToParse);
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( stringToParse, typeof(int ), null!);
        
        //assert
        Assert.IsType<int>(actual);
    }
}