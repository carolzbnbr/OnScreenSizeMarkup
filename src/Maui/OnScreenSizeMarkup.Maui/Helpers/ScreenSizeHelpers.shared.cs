using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Providers;

namespace OnScreenSizeMarkup.Maui.Helpers;

/// <summary>
/// Provides methods to manipulate sizes based on the physical screen size of the device.
/// </summary>
public class OnScreenSizeHelpers: IScreenSizeHelpers
{
	readonly IScreenCategoryProvider screenCategoryProvider;
	
	/// <summary>
	/// 
	/// </summary>
	/// <param name="screenCategoryProvider"></param>
	public OnScreenSizeHelpers(IScreenCategoryProvider screenCategoryProvider)
	{
		this.screenCategoryProvider = screenCategoryProvider;
	}

	static IScreenSizeHelpers? instance = null!;
	/// <summary>
	/// Provides access to this instance.
	/// This should only be used if the component has not been registered with MAUI's dependency injection using <see cref="ConfigureServices.AddOnScreenSize"/>.
	/// </summary>
	public static IScreenSizeHelpers Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UniversalFactory.CreateScreenSizeHelpers();
			}
			return instance;
		}
	}
	

	/// <inheritdoc />
	public  IConvertible OnScreenSize(IConvertible baseValue,
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

		var retValue = ProportionalSizeConverter.Multiply(typeof(double), baseValue, factorValue);
		
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