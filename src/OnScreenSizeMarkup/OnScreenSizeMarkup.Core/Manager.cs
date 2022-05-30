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

        /// <summary>
        /// Returns the current <see cref="ScreenCategories"/> set for the device.
        /// </summary>
        public ScreenCategories? CurrentCategory { get; internal set; } = null;

        public ICategoryFallbackHandler Handler { get; set; }

        public static Manager Current { get; } = new Manager();
    }
}
