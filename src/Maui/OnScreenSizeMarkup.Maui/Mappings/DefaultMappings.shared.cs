using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Predefined lists of mappings for using on <see cref="OnScreenSizeExtension"/>.
/// </summary>
public static class DefaultMappings
{
	/// <summary>
	/// Mappings for categorizing mobile devices screen sizes.
	/// </summary>
	public static List<SizeMappingInfo> MobileMappings { get;   } = new List<SizeMappingInfo>
	{
		new SizeMappingInfo(3.8, ScreenCategories.ExtraSmall, ComparisonModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(4.9, ScreenCategories.Small, ComparisonModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(6.2, ScreenCategories.Medium, ComparisonModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(7.9, ScreenCategories.Large, ComparisonModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(double.MaxValue, ScreenCategories.ExtraLarge, ComparisonModes.SmallerThanOrEqualsTo),
	};
}

