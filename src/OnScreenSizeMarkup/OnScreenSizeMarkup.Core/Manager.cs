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

     
        public ICategoryFallbackHandler Handler { get; set; }

        public static Manager Current { get; } = new Manager();
    }
}
