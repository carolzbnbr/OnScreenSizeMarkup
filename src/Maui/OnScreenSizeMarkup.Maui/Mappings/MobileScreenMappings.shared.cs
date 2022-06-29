using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Mappings focused on Android and ios devices diagonal inches.
/// </summary>
public class MobileScreenMappings : IScreenMappings
{
	/// <summary>
	/// Access the <see cref="ScreenMappingList"/> in which mappings are stored.
	/// </summary>
	public ScreenMappingList GetMappings { get;   } = new ScreenMappingList
	{
		new SizeMappingInfo(3.8, ScreenCategories.ExtraSmall, MappingComparerTypes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(4.9, ScreenCategories.Small, MappingComparerTypes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(6.2, ScreenCategories.Medium, MappingComparerTypes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(7.9, ScreenCategories.Large, MappingComparerTypes.SmallerThanOrEqualsTo),
		new SizeMappingInfo(double.MaxValue, ScreenCategories.ExtraLarge, MappingComparerTypes.SmallerThanOrEqualsTo),
	};
}

