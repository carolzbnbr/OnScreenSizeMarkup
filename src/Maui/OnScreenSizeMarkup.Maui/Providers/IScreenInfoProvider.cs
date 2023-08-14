using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Providers;

/// <summary>
/// Provides information related to the device's screen properties.
/// </summary>
public interface IScreenInfoProvider
{
	/// <summary>
	/// Returns the physical diagonal size of the current device's screen in inches.
	/// </summary>
	/// <returns>The diagonal size of the screen in inches.</returns>
	double GetScreenDiagonalInches();
}