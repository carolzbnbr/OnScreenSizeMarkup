using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Predefined sets of mappings.
/// </summary>
public static class DefaultMappings
{
	/// <summary>
	/// Mappings for dealing with mobile devices screen sizes.
	/// </summary>
	public static ScreenMappingList MobileMappings { get;   } = new ScreenMappingList
	{
		new SizeMappingInfo(3.8, ScreenCategories.ExtraSmall, EvaluationModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(4.9, ScreenCategories.Small, EvaluationModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(6.2, ScreenCategories.Medium, EvaluationModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(7.9, ScreenCategories.Large, EvaluationModes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(double.MaxValue, ScreenCategories.ExtraLarge, EvaluationModes.SmallerThanOrEqualsTo),
	};
}

