
using Microsoft.Maui.Controls;
using Xunit;


namespace OnScreenSizeMarkup.Maui.Tests;

public class ValueConversionExtension_ConvertTo
{
    [Fact]
    public void Convert_RowDefinition_String_To_RowDefinition()
    {
        var expected =  (RowDefinitionCollection)new RowDefinitionCollectionTypeConverter().ConvertFromInvariantString("0.25*, 0.13*, 0.08*, 230, *");
        
        var actual = OnScreenSizeMarkup.Maui.Extensions.ValueConversionExtensions.ConvertTo( "0.25*, 0.13*, 0.08*, 230, *", typeof(object), Grid.RowDefinitionsProperty);
        
        
        //assert
        Assert.Equal(expected.GetType(), actual.GetType());
        Assert.Equal(expected.Count, ((RowDefinitionCollection)actual).Count);
        Assert.Equal(4, ((RowDefinitionCollection)actual).Count);
        
    }
}