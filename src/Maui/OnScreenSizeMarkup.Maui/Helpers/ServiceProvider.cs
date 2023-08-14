namespace OnScreenSizeMarkup.Maui.Helpers;


static class ServiceProvider
{
	internal static TService GetService<TService>() => Current.GetService<TService>()!;

	static IServiceProvider Current
	{
		get
		{
#if WINDOWS10_0_17763_0_OR_GREATER
    return MauiWinUIApplication.Current.Services;
#elif ANDROID
    return MauiApplication.Current.Services;
#elif IOS || MACCATALYST
    return MauiUIApplicationDelegate.Current.Services;
#else
			return null!;
#endif
		}
		
	}
}