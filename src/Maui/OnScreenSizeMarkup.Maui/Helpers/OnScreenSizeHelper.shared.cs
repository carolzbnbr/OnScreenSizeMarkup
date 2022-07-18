using System.Collections.Generic;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Exceptions;
using OnScreenSizeMarkup.Maui.Extensions;
using OnScreenSizeMarkup.Maui.Helpers;

namespace OnScreenSizeMarkup.Maui.Helpers;

public static class OnScreenSizeHelpers
{
	public static T OnScreenSize<T>(T defaultSize= default(T)!,
		T extraSmall = default(T)!,
		T small = default(T)!,
		T medium = default(T)!,
		T large = default(T)!,
		T extraLarge = default(T)!)
	{
		var screenSize = ScreenCategoryHelper.GetCategory();
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
			throw new XamlMarkupException($"{nameof(OnScreenSizeExtension)} markup requires a {nameof(defaultSize)} set.");
		}
		else
		{
			return defaultSize;
		}
	}
}