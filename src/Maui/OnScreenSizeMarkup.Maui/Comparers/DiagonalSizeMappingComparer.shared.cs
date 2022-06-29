namespace OnScreenSizeMarkup.Maui.Comparers;

internal class DiagonalSizeMappingComparer: IComparer<SizeMappingInfo>
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