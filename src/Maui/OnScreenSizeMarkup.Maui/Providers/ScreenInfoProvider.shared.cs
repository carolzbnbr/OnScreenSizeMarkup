using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Helpers;
using OnScreenSizeMarkup.Maui.PlatformDensities;

namespace OnScreenSizeMarkup.Maui.Providers;


/// <summary>
/// Provides information related to the device's screen properties.
/// </summary>
public class ScreenInfoProvider : IScreenInfoProvider
{
	
	static IScreenInfoProvider? instance = null!;
	/// <summary>
	/// Provides access to this instance.
	/// This should only be used if the component has not been registered with MAUI's dependency injection using <see cref="ConfigureServices.AddOnScreenSize"/>.
	/// </summary>
	public static IScreenInfoProvider Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UniversalFactory.CreateScreenInfoProvider();
			}
			return instance;
		}
	}


	/// <summary>
	/// Returns the physical diagonal size of the current device's screen in inches.
	/// </summary>
	/// <returns>The diagonal size of the screen in inches.</returns>
	public double GetScreenDiagonalInches()
	{
		var dpi =  ScreenDensityPlatform.GetPixelPerInches();

		(double width, double height) resolution;
		if (Manager.Current.UseNativeScreenResolution)
		{
			resolution = ScreenDensityPlatform.GetNativeScreenResolution();
		}
		else
		{
			resolution = (Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo.Width, Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo.Height);
		}

		var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
		return GetScreenDiagonalInches(resolution.width, resolution.height, displayInfo.Density, dpi.xdpi, dpi.ydpi);
	}


	static double GetScreenDiagonalInches(double width, double height, double scale, double xDpi, double yDpi)
	{
		var horizontal = width / xDpi;
		var vertical = height / yDpi;

		var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));

		var diagonalReturnValue = diagonal.RoundUp();

		LogHelpers.WriteLine($"{nameof(OnScreenSizeExtension)} - DiagonalSize: {diagonalReturnValue},  PPI/DPI: x:\"{xDpi}\", y:\"{yDpi}\"", LogLevels.Info);
		return diagonalReturnValue;
	}
	
}