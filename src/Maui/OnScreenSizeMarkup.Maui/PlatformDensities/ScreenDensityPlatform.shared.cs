using System.Diagnostics.CodeAnalysis;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;


#if !(IOS || ANDROID || MACCATALYST || WINDOWS)
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
internal static partial class ScreenDensityPlatform
{
	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		throw new NotSupportedException("Platform implementation not found");
	}

	public static (double width, double height) GetNativeScreenResolution()
	{
		throw new NotSupportedException("Platform implementation not found");
	}
}
#endif
