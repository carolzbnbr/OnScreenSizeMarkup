using System;
using System.Threading.Tasks;
using NUnit.Framework;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Forms.Tests.Internals.Inputs;
using OnScreenSizeMarkup.Forms.Tests.Internals.Models;

namespace OnScreenSizeMarkup.Forms.Tests.Core
{
	[TestFixture]
	public class DefaultCategoryFallbackHandler_TryGetCategoryByPhysicalSize
	{

		[TestCaseSource(typeof(FileInputSource<ScreenDeviceInfo>))]
		public  void Add_MultipleObjectsFromJson_ReturnsScreenCategory(ScreenDeviceInfo json)
		{
			// Arrange
			var fallbackHandler = new DefaultCategoryFallbackHandler();

			// Act
			fallbackHandler.TryGetCategoryByPhysicalSize((double)json.ScreenWidth, (double)json.ScreenHeight, out var actExpected);

			// Assert
			Assert.AreEqual(json.ScreenCategory, actExpected,message: $"{json.ScreenWidth}x{json.ScreenHeight}");
		}



	}
}
