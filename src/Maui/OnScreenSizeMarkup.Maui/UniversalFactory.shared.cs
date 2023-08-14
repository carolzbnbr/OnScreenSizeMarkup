using OnScreenSizeMarkup.Maui.Providers;
using ServiceProvider = OnScreenSizeMarkup.Maui.Helpers.ServiceProvider;

namespace OnScreenSizeMarkup.Maui;

/// <summary>
/// The UniversalFactory class serves as a centralized factory for creating instances of classes.
/// It is specifically designed to support client applications that do not rely on dependency injection.
/// This enables a consistent and manageable way to construct objects across different parts of the application.
/// </summary>
public class UniversalFactory
{
	
	internal static IScreenCategoryProvider CreateScreenCategoryProvider()
	{
		if (ConfigureServices.IsRegistered)
		{
			return ServiceProvider.GetService<IScreenCategoryProvider>();
		}

		return new ScreenCategoryProvider(CreateScreenInfoProvider());
	}
	
	static IScreenInfoProvider CreateScreenInfoProvider()
	{
		return new ScreenInfoProvider();
	}

	
}