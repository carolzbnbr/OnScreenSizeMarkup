namespace OnScreenSizeMarkup.Maui.Comparers;

/// <summary>
/// Compares <see cref="SizeMappingInfo.DiagonalSize"/> for the given instances.
/// </summary>
#pragma warning disable IDE0040 // Add accessibility modifiers
internal class DiagonalSizeMappingComparer: IComparer<SizeMappingInfo>
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