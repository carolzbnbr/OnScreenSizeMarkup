using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Helpers;

namespace OnScreenSizeMarkup.Maui.Providers;

public class ScreenCategoryProvider : IScreenCategoryProvider
{
	readonly IScreenInfoProvider screenInfoProvider;

	public ScreenCategoryProvider(IScreenInfoProvider screenInfoProvider)
	{
		this.screenInfoProvider = screenInfoProvider;
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