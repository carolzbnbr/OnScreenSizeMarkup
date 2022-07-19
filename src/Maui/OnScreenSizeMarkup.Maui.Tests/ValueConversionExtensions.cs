
using Microsoft.Maui.Controls;
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
        Assert.Equal(expected.GetType(), actual.GetType());
        Assert.Equal(expected.Count, ((RowDefinitionCollection)actual).Count);
    }
}