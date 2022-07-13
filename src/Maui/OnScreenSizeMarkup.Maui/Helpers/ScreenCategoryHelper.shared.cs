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

        private static ScreenCategories GetCategoryInternal()
        {
            var diagonalSize = DiagonalSizeHelper.GetScreenDiagonalInches();
            
            var category = Manager.Current.Categorizer.GetCategoryByDiagonalSize(diagonalSize);
            
            $"{nameof(OnScreenSize)} - Current screen category is \"{category}\", and screen diagonal size is \"{diagonalSize}\"".WriteToLog(DebugLevels.Info);
            
            if (category == ScreenCategories.NotSet)
            {
                throw new CategoryNotSetException($"Fail to categorize your current screen. Screen-Diagonal-Size:{diagonalSize}.");
            }
            
            return category;
        }

    }
