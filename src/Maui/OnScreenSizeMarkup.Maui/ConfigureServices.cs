using OnScreenSizeMarkup.Maui.Helpers;
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
	/// Register the library's services for dependency injection.
	/// </summary>
	/// <example>
	/// Sample code on how to register this library on your MauiProgram's class:
	/// <code>
	/// <![CDATA[
	/// public static class MauiProgram
	/// {
	/// 		public static MauiApp CreateMauiApp()
	/// 		{
	/// 			var builder = MauiApp.CreateBuilder();
	/// 			builder
	/// 				.UseMauiApp<App>()
	/// 				.ConfigureFonts(fonts =>
	/// 				{
	/// 					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
	/// 					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
	/// 				});
	/// 
	/// 			builder.Services.AddOnScreenSize();  // Add this line
	/// 			...
	/// 			return builder.Build();
	/// 		}
	/// }
	/// ]]>
	/// </code>
	/// </example>
	/// <param name="services"></param>
	/// <returns></returns>
	public static IServiceCollection AddOnScreenSize(this IServiceCollection services)
    {
        
        services
            .AddSingleton<IScreenCategoryProvider, ScreenCategoryProvider>()
            .AddSingleton<IScreenInfoProvider, ScreenInfoProvider>()
            .AddSingleton<IScreenSizeHelpers, OnScreenSizeHelpers>()
        
            ;
        IsRegistered = true;
        return services;
    }
}