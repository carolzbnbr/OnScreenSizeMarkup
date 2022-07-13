using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Extensions;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Collection of <see cref="SizeMappingInfo"/> to avoiding handling duplicate items during the addition of new items. 
/// </summary>
public class ScreenMappingList : List<SizeMappingInfo>
{
	/// <summary>
	/// Add item to the underling list while removing existing items having the same <see cref="SizeMappingInfo.DiagonalSize"/> and.
	/// </summary>
	/// <param name="item"></param>
	public new void Add(SizeMappingInfo? item)
	{
		if (item == null)
		{
			return;
		}

		//Find potential duplicates items
		//It ensures the correct execution of the comparison logic inside screen-mapping implementation
		//so that whether a developer attempts to set a specific device diagonal size to have a fixed category, it does not affect the existing mappings. 
		var removalCandidate = this.FirstOrDefault(f => f.ComparerMode == EvaluationModes.SpecificSize  && 
																					f.ComparerMode == item.ComparerMode &&  
																					f.DiagonalSize.EqualsTo(item.DiagonalSize));
		
		if (removalCandidate != null)
		{
			$"Replacing existing {nameof(SizeMappingInfo)} item (Category:{item.Category.ToString()}, DiagonalSize:{item.DiagonalSize}, ComparerMode:{item.ComparerMode.ToString()}) by the provided {nameof(SizeMappingInfo)}  item.".WriteToLog(DebugLevels.Verbose);
			base.Remove(removalCandidate);
		}

		base.Add(item);
	}
}