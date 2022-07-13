namespace OnScreenSizeMarkup.Maui.Helpers;

public static class DoubleExtensions
{

	public static double RoundUp(this double value)
	{
		var valueUp = Math.Ceiling(value * 100) / 100;
		
		var valueRounded = Math.Round(valueUp,1);
		
		return (double)valueRounded;
	}	
}