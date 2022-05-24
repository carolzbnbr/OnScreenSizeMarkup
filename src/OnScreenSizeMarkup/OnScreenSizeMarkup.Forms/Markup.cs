using System;
using System.Collections.Generic;
using OnScreenSizeMarkup.Core;
using OnScreenSizeMarkup.Forms.Extensions;
using Xamarin.Forms.Xaml;

namespace OnScreenSizeMarkup.Forms
{
    public static class Markup
    {
        public static T OnScreenSize<T>(T defaultSize= default(T),
                                T extraSmall = default(T),
                                T small = default(T),
                                T medium = default(T),
                                T large = default(T),
                                T extraLarge = default(T))
        {
            var screenSize = ScreenCategoryExtension.GetCategory();
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
                throw new XamlParseException($"{nameof(Markup)}.{nameof(OnScreenSize)} markup requires a {nameof(defaultSize)} set.");
            }
            else
            {
                return defaultSize;
            }
        }
    }
}
