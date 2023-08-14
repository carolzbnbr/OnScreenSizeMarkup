using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Providers;

/// <summary>
/// Defines the functionality to categorize a device's screen size based on its physical dimensions.
/// </summary>
public interface IScreenCategoryProvider
{
	/// <summary>
	/// Determines the category of the current device's screen size based on its physical dimensions.
	/// </summary>
	/// <returns>
	/// A value from the ScreenCategories enumeration indicating whether the screen size is ExtraSmall, Small, Medium, Large, or ExtraLarge.
	/// </returns>
	ScreenCategories GetCategory();
}