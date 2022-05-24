using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OnScreenSizeMarkup.Forms")]

namespace OnScreenSizeMarkup.Core
{
    public class Manager
    {
        internal Manager()
        {
            Handler = new DefaultCategoryFallbackHandler();
        }

        internal ScreenCategories? CurrentCategory { get; set; } = null;

        public ICategoryFallbackHandler Handler { get; set; }

        public static Manager Current { get; } = new Manager();
    }
}
