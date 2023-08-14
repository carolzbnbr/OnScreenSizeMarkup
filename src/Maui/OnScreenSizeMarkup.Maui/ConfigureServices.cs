using OnScreenSizeMarkup.Maui.Providers;

namespace OnScreenSizeMarkup.Maui;

/// <summary>
/// 
/// </summary>
public static class ConfigureServices
{
	/// <summary>
	/// Determina se houve ou não registro uso de injecao de dependencia.
	/// </summary>
	internal static bool IsRegistered { get; private set; }

	/// <summary>
	/// Registers 
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddOnScreenSize(this IServiceCollection services)
    {
        
        services
            .AddSingleton<IScreenCategoryProvider, ScreenCategoryProvider>()
            .AddSingleton<IScreenInfoProvider, ScreenInfoProvider>()
            .AddSingleton<IScreenSizeHelpers, ScreenSizeHelpers>()
        
            ;
        IsRegistered = true;
        return services;
    }
}