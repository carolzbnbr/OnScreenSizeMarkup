using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using OnScreenSizeMarkup.Maui.Comparers;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Mappings;

namespace  OnScreenSizeMarkup.Maui.Categories;

/// <summary>
/// Responsible for categorizing the device's actual screen size to <see cref="ScreenCategories"/>
/// </summary>
[SuppressMessage("Style", "IDE0040:Add accessibility modifiers")]
internal  class ScreenCategorizer : IScreenCategorizer
{
	public ScreenCategorizer()
	{
		
	}
	
	public ScreenCategories GetCategoryByDiagonalSize(double deviceActualDiagonalSize)
	{
		Manager.Current.Mappings.GetMappings.Sort(new DiagonalSizeMappingComparer());

		ScreenCategories category;   
		if (TryCategorizeByEquality(deviceActualDiagonalSize, out category))
		{
			return category;
		}
		
		if (TryCategorizeBySmallerOrEqualsTo(deviceActualDiagonalSize, out category))
		{
			return category;
		}

		return ScreenCategories.NotSet;
	}
	
	
	private static bool TryCategorizeBySmallerOrEqualsTo(double deviceActualDiagonalSize, out ScreenCategories category)
	{
		category = ScreenCategories.NotSet;
		var diagonalSizeMappings = Manager.Current.Mappings.GetMappings.Where((f => f.ComparerType == MappingComparerTypes.SmallerThanOrEqualsTo)).ToArray();
		
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
	private static bool TryCategorizeByEquality(double deviceActualDiagonalSize, out ScreenCategories category)
	{
		category = ScreenCategories.NotSet;
		
		var diagonalSizeMappingsEquals = Manager.Current.Mappings.GetMappings.Where((f => f.ComparerType == MappingComparerTypes.EqualsTo)).ToArray();
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
	
}

