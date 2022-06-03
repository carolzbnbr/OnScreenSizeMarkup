using NUnit.Framework;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Forms.Extensions;
using OnScreenSizeMarkup.Forms.Tests.Internals.Models;
using Xamarin.Forms;

namespace OnScreenSizeMarkup.Tests.Forms
{
    [TestFixture]
    public class ValueConversionExtensions_ConvertTo
    {
        
        [Test]
        public  void ConvertToFloat_UsingObject()
        {
            // Arrange
            object floatValue = 115; 
            
            
            // Act
            var actualValue = floatValue.ConvertTo(typeof(float), null);

            // Assert
            Assert.AreEqual((float)115, actualValue);
        }
        
        [Test]
        public  void String_number_as_object__returns_float_equivalent()
        {
            Manager.Current.IsDebugMode = true;
            // Arrange
            object floatValue = "115"; 
            
            
            // Act
            var actualValue = floatValue.ConvertTo(typeof(float), null);

            // Assert
            Assert.AreEqual((float)115, actualValue);
        }
    }
    
}