namespace OnScreenSizeMarkup.Maui.Helpers;

public static class ScreenCalculationsHelper
{



	public static double GetPixelsPerInches(double diagonalSize, double width, double height)
	{
		var widthPow = Math.Pow(width, 2);
		var heightPow = Math.Pow(height, 2);
		var ppi = Math.Sqrt(widthPow + heightPow) / diagonalSize;
		return ppi;
	}

	public static double RoundUp(this double value)
	{
		var valueUp = Math.Ceiling(value * 100) / 100;
		
		var valueRounded = Math.Round(valueUp,1);
		
		return (double)valueRounded;
	}

	/// <summary>
	/// Returns the diagonal size of the screen.
	/// </summary>
	/// <param name="width"></param>
	/// <param name="height"></param>
	/// <returns></returns>
	public static double GetDiagonalSize(double width, double height)
	{
		var horizontalPow = Math.Pow(width, 2);
		 var verticalPow = Math.Pow(height, 2);

		 var diagonal = (decimal)Math.Sqrt(horizontalPow + verticalPow);
		 
		var diagonalUp = Math.Ceiling(diagonal * 100) / 100;
		
		var diagonalRounded = Math.Round(diagonalUp,1);
		
		return (double)diagonalRounded;
	}

	public static decimal GetScreenSizeArea(double width, double height, int scaleFactor)
	{
		//convert to logical resolution
		var logicalWidth = width/ scaleFactor;
		var logicalHeight = height / scaleFactor;

		var logicalArea = logicalHeight + logicalHeight;
		
	
		var logicalAreaUp = (decimal)Math.Ceiling(logicalArea * 100) / 100;
		
		var logicalAreaRounded = Math.Round(logicalAreaUp,1);
		
		return logicalAreaRounded;
	}

	public static double GetScreenAspectRatio(double width, double height)
	{
		var aspectRatio = width / height;
		return aspectRatio;
	}
}