using System.Diagnostics.CodeAnalysis;
using OnScreenSizeMarkup.Maui.Comparers;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Mappings;

namespace  OnScreenSizeMarkup.Maui.Categories;

/// <summary>
/// Responsible for categorizing the device's actual screen size to <see cref="ScreenCategories"/> based on <see cref="Manager.Mappings"/>
/// </summary>
[SuppressMessage("Style", "IDE0040:Add accessibility modifiers")]
internal  class ScreenCategorizer : IScreenCategorizer
{
	public ScreenCategories GetCategoryByDiagonalSize(List<SizeMappingInfo> mappings, double deviceActualDiagonalSize)
	{
		ScreenCategories category;   
		if (TryCategorizeByFixedSize(mappings, deviceActualDiagonalSize, out category))
		{
			return category;
		}
		
		if (TryCategorizeBySmallerOrEqualsTo(mappings, deviceActualDiagonalSize, out category))
		{
			return category;
		}

		return ScreenCategories.NotSet;
	}
	
	/// <summary>
	/// Attempt to categorize a screen based on fixed mapping screen size. 
	/// </summary>
	/// <param name="mappings"></param>
	/// <param name="deviceActualDiagonalSize"></param>
	/// <param name="category"></param>
	/// <returns></returns>
	private static bool TryCategorizeByFixedSize(List<SizeMappingInfo> mappings, double deviceActualDiagonalSize, out ScreenCategories category)
	{
		category = ScreenCategories.NotSet;
		
		var diagonalSizeMappingsEquals = mappings.Where((f => f.ComparisonMode == ComparisonModes.SpecificSize)).ToArray();
		for (var index = 0; index < diagonalSizeMappingsEquals.Length; index++)
		{
			var sizeInfo = diagonalSizeMappingsEquals[index];
			if (deviceActualDiagonalSize.EqualsTo(sizeInfo.DiagonalSize))
			{
				category = sizeInfo.Category;
				return true;
			}
		}

		return false;
	}

	private static bool TryCategorizeBySmallerOrEqualsTo(List<SizeMappingInfo> mappings, double deviceActualDiagonalSize, out ScreenCategories category)
	{

		var mappingsLocal = mappings.Where(f => f.ComparisonMode == ComparisonModes.SmallerThanOrEqualsTo).OrderBy(f => f.DiagonalSize).ToList();
		mappingsLocal.Sort(new DiagonalSizeMappingComparer());

		category = ScreenCategories.NotSet;
		var diagonalSizeMappings = mappingsLocal.ToArray();
		
		for (var index = 0; index < diagonalSizeMappings.Length; index++)
		{
			var sizeInfo = diagonalSizeMappings[index];
			if (deviceActualDiagonalSize <= sizeInfo.DiagonalSize)
			{
				category = sizeInfo.Category;
				return true;
			}
		}

		return false;
	}
	
}

