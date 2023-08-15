using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Helpers;

namespace OnScreenSizeMarkup.Maui.Providers;

/// <summary>
/// Determines the category that best matches the device's screen size.
/// </summary>
public class ScreenCategoryProvider : IScreenCategoryProvider
{
	readonly IScreenInfoProvider screenInfoProvider;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="screenInfoProvider"></param>
	public ScreenCategoryProvider(IScreenInfoProvider screenInfoProvider)
	{
		this.screenInfoProvider = screenInfoProvider;
	}

	static IScreenCategoryProvider? instance = null!;
	/// <summary>
	/// Provides access to this instance.
	/// This should only be used if the component has not been registered with MAUI's dependency injection using <see cref="ConfigureServices.AddOnScreenSize"/>.
	/// </summary>
	public static IScreenCategoryProvider Instance
	{
		get
		{
			if (instance == null)
			{
				instance = UniversalFactory.CreateScreenCategoryProvider();
			}
			return instance;
		}
	}
	
	public ScreenCategories GetCategory()
	{
		if (TryGetCategory(out var category))
		{

			return category;
		}

		return ScreenCategories.NotSet;
	}

	bool TryGetCategory(out ScreenCategories category)
	{
		if (Manager.Current.CurrentCategory != null)
		{
			if (Manager.Current.CurrentCategory.Value != ScreenCategories.NotSet)
			{
				category = Manager.Current.CurrentCategory.Value;
				return true;
			}
		}
		category = GetCategoryInternal();

		Manager.Current.CurrentCategory =category;
		return true;
	}

	ScreenCategories GetCategoryInternal()
	{
#if WINDOWS
	    return Manager.Current.DefaultScreenCategoryFallbackPlatform;
#else
		var diagonalSize = screenInfoProvider.GetScreenDiagonalInches();
            
		var category = Manager.Current.Categorizer.GetCategoryByDiagonalSize(Manager.Current.Mappings, diagonalSize);
	    
		LogHelpers.WriteLine(string.Format("{0} - Current screen category is \"{1}\", and screen diagonal size is \"{2}\"",nameof(OnScreenSizeExtension),category, diagonalSize), LogLevels.Info);
            
		if (category == ScreenCategories.NotSet)
		{
			throw new InvalidOperationException(string.Format("Fail to categorize your current screen. Screen-Diagonal-Size:{0}.", diagonalSize));
		}
            
		return category;
#endif
	}
}