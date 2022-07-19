namespace OnScreenSizeMarkup.Maui.Comparers;

/// <summary>
/// Compares two <see cref="SizeMappingInfo.DiagonalSize"/>s values.
/// </summary>
#pragma warning disable IDE0040 // Add accessibility modifiers
internal class DiagonalSizeComparer: IComparer<SizeMappingInfo>
#pragma warning restore IDE0040 // Add accessibility modifiers
{
	public int Compare(SizeMappingInfo? x, SizeMappingInfo? y)
	{
		if (x == null || y == null)
		{
			return -1;
		}

		if (x.DiagonalSize == y.DiagonalSize)
		{
			return 0;
		}
		else if (x.DiagonalSize < y.DiagonalSize)
		{
			return -1;
		}

		return 1;
	}
	
	
	
}