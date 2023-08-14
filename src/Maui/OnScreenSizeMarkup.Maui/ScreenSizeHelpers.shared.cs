using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Helpers;
using OnScreenSizeMarkup.Maui.Providers;

namespace OnScreenSizeMarkup.Maui;

/// <summary>
/// Provides methods to manipulate sizes based on the physical screen size of the device.
/// </summary>
public class ScreenSizeHelpers: IScreenSizeHelpers
{
	readonly IScreenCategoryProvider screenCategoryProvider;
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="screenCategoryProvider"></param>
	public ScreenSizeHelpers(IScreenCategoryProvider screenCategoryProvider)
	{
		this.screenCategoryProvider = screenCategoryProvider;
	}
	 
	
	/// <inheritdoc />
	public  IConvertible OnScreenSize(IConvertible baseSize,
		double extraSmallFactor = default(double)!,
		double smallFactor = default(double)!,
		double mediumFactor = default(double)!,
		double largeFactor = default(double)!,
		double extraLargeFactor = default(double)!)
	{

		double factorValue = default(double);
		var screenSize = screenCategoryProvider.GetCategory();
		switch (screenSize)
		{
			case ScreenCategories.ExtraSmall:
				factorValue = extraSmallFactor;
				break;
			case ScreenCategories.Small:
				factorValue = smallFactor;
				break;
			case ScreenCategories.Medium:
				factorValue = mediumFactor;
				break;
			case ScreenCategories.Large:
				factorValue = largeFactor;
				break;
			case ScreenCategories.ExtraLarge:
				factorValue = extraLargeFactor;
				break;
			case ScreenCategories.NotSet:
				factorValue = 1;
				break;
		}

		var retValue = ProportionalSizeConverter.Multiply(typeof(double), baseSize, factorValue);
		
		return retValue;
	}


	/// <inheritdoc />
	public T OnScreenSize<T>(T defaultSize= default(T)!,
		T extraSmall = default(T)!,
		T small = default(T)!,
		T medium = default(T)!,
		T large = default(T)!,
		T extraLarge = default(T)!)
	{
		var screenSize = screenCategoryProvider.GetCategory();
		switch (screenSize)
		{
			case ScreenCategories.ExtraSmall:
				return extraSmall;
			case ScreenCategories.Small:
				return small;
			case ScreenCategories.Medium:
				return medium;
			case ScreenCategories.Large:
				return large;
			case ScreenCategories.ExtraLarge:
				return extraLarge;
		}

		if (EqualityComparer<T>.Default.Equals(defaultSize, default(T)))
		{
			throw new ArgumentException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(defaultSize)} set.");
		}
		
		return defaultSize;
	}
}