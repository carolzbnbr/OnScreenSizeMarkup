
namespace OnScreenSizeMarkup.Maui.Helpers;

/// <summary>
/// Provides methods to manipulate sizes based on the physical screen size of the device.
/// </summary>
public interface IScreenSizeHelpers
{
	/// <summary>
	/// Multiplies the provided <paramref name="baseValue"/> by a factor corresponding to the physical screen size of the device.
	/// </summary>
	/// <param name="baseValue">The base size to be multiplied.</param>
	/// <param name="extraSmallFactor">Factor for ExtraSmall sized screens.</param>
	/// <param name="smallFactor">Factor for Small sized screens.</param>
	/// <param name="mediumFactor">Factor for Medium sized screens.</param>
	/// <param name="largeFactor">Factor for Large sized screens.</param>
	/// <param name="extraLargeFactor">Factor for ExtraLarge sized screens.</param>
	/// <returns>The result of the multiplication based on the screen size.</returns>
	IConvertible OnScreenSize(IConvertible baseValue,
		double extraSmallFactor = default(double)!,
		double smallFactor = default(double)!,
		double mediumFactor = default(double)!,
		double largeFactor = default(double)!,
		double extraLargeFactor = default(double)!);
	
	
	/// <summary>
	/// Selects and returns one of the provided values based on the device's physical screen size.
	/// </summary>
	/// <typeparam name="T">Type of the value to be returned.</typeparam>
	/// <param name="defaultSize">Default value.</param>
	/// <param name="extraSmall">Value for ExtraSmall sized screens.</param>
	/// <param name="small">Value for Small sized screens.</param>
	/// <param name="medium">Value for Medium sized screens.</param>
	/// <param name="large">Value for Large sized screens.</param>
	/// <param name="extraLarge">Value for ExtraLarge sized screens.</param>
	/// <returns>The value corresponding to the screen size.</returns>
	/// <exception cref="ArgumentException">Thrown if required parameters are not provided.</exception>
	T OnScreenSize<T>(T defaultSize = default(T)!,
		T extraSmall = default(T)!,
		T small = default(T)!,
		T medium = default(T)!,
		T large = default(T)!,
		T extraLarge = default(T)!);
}