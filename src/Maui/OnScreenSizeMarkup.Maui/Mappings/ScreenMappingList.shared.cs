using OnScreenSizeMarkup.Maui.Extensions;

namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Responsible for store <see cref="SizeMappingInfo"/> items and avoid duplicates.
/// </summary>
public class ScreenMappingList : List<SizeMappingInfo>
{
	/// <summary>
	/// Add item to the underling list, removing existing items having the same <see cref="SizeMappingInfo.DiagonalSize"/>.
	/// </summary>
	/// <param name="item"></param>
	public new void Add(SizeMappingInfo item)
	{
		if (item == null)
		{
			return;
		}

		const double TOLERANCE = 0.0000001;
		
		//Avoid duplicate items having the same DiagonalSize.
		//It helps ensure the correct execution of the comparison logic inside screen-mapping implementation 
		var removalCandidate = this.FirstOrDefault(f => f.DiagonalSize.EqualsTo(item.DiagonalSize));
		
		if (removalCandidate != null)
		{
			$"Replacing existing {nameof(SizeMappingInfo)} item (Category:{item.Category.ToString()}, DiagonalSize:{item.DiagonalSize}, ComparerType:{item.ComparerType.ToString()}) by the provided {nameof(SizeMappingInfo)}  item.".WriteToLog();
			base.Remove(removalCandidate);
		}

		base.Add(item);
	}
}