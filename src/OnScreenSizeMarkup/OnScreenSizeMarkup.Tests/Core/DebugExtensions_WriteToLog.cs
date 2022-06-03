using System;
using System.IO;
using NUnit.Framework;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Core.Extensions;
using OnScreenSizeMarkup.Forms.Extensions;
using Xamarin.Forms;

namespace OnScreenSizeMarkup.Forms.Tests.Core
{
   
    
    [TestFixture]
    public class DebugExtensions_WriteToLog
    {
        
        [Test]
        public  void ConvertToFloat_UsingObject()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);
                
            // Arrange
            Manager.Current.IsDebugMode = true;
            var expected = "** DEBUG ** OnScreenSizeMarkup (DebugExtensions_WriteToLog.ConvertToFloat_UsingObject): Ola\n";
            
            // Act
            "Ola".WriteToLog();

            // Assert
            Assert.AreEqual(expected, sw.ToString());
        }
        
    }

}