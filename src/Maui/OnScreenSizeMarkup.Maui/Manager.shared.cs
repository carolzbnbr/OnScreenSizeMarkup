using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(" OnScreenSizeMarkup.Maui")]

namespace  OnScreenSizeMarkup.Maui
{
    public class Manager
    {
        internal Manager()
        {
            Handler = new DefaultCategoryFallbackHandler();
        }

        public bool IsDebugMode { get; set; }

        /// <summary>
        /// Returns the current <see cref="ScreenCategories"/> set for the device.
        /// </summary>
        public ScreenCategories? CurrentCategory { get; internal set; } = null;

        public ICategoryFallbackHandler Handler { get; set; }

        public static Manager Current { get; } = new Manager();
    }
}
