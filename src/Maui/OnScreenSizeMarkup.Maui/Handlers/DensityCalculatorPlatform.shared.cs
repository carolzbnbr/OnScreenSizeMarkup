namespace OnScreenSizeMarkup.Maui.Handlers;


#if !(IOS || ANDROID || MACCATALYST || WINDOWS)
internal static partial class DensityCalculatorPlatform
{

	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		throw new NotSupportedException("Platform implementation not found");
	}
}
#endif
