using System.Diagnostics.CodeAnalysis;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Exceptions;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Handlers;

namespace OnScreenSizeMarkup.Maui.Helpers;

    [SuppressMessage("Style", "IDE0040:Add accessibility modifiers")]
    internal static class ScreenCategoryHelper
    {

        public static ScreenCategories GetCategory()
        {
            if (TryGetCategory(out var category))
            {

                return category;
            }

            return ScreenCategories.NotSet;
        }


        private static bool TryGetCategory(out ScreenCategories category)
        {
            if (Manager.Current.CurrentCategory != null)
            {
                if (Manager.Current.CurrentCategory.Value != ScreenCategories.NotSet)
                {
                    category = Manager.Current.CurrentCategory.Value;
                    return true;
                }
            }
            category = GetCategoryInternal();

            Manager.Current.CurrentCategory =category;
            return true;
        }

        public static double GetScreenDiagonalInches()
        {
	        var dpi =  DensityCalculatorPlatform.GetPixelPerInches();
		
	       

	        var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
	     
	       return GetScreenDiagonalInches(displayInfo.Width, displayInfo.Height,displayInfo.Density, dpi.xdpi, dpi.ydpi );
        }
        
        public static double GetScreenDiagonalInches(double width, double height, double scale, double xDpi, double yDpi)
        {
	        var width1 = width;
	        var height1 = height;
	        
	        // var width1 = width * scale;
	        // var height1 = height * scale;
	        
	        var horizontal = width1 / xDpi;
	        var vertical = height1 / yDpi;

	        var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));

	        var diagonalReturnValue = diagonal.RoundUp();
	        
	        $"{nameof(OnScreenSize)} - DiagonalSize: {diagonalReturnValue},  PPI/DPI: x:\"{xDpi}\", y:\"{yDpi}\"".WriteToLog();
	        
	        return diagonal.RoundUp();
        }
        private static ScreenCategories GetCategoryInternal()
        {
            var diagonalSize = GetScreenDiagonalInches();
            
            var category = Manager.Current.Categorizer.GetCategoryByDiagonalSize(diagonalSize);
            
            $"{nameof(OnScreenSize)} - Current screen category is \"{category}\", and screen diagonal size is \"{diagonalSize}\"".WriteToLog();
            
            if (category == ScreenCategories.NotSet)
            {
                throw new CategoryNotSetException($"Fail to categorize your current screen. Screen-Diagonal-Size:{diagonalSize}.");
            }
            
            return category;
        }

    }
