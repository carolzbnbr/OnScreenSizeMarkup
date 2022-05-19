using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OnScreenSizeMarkup.Forms")]

namespace OnScreenSizeMarkup.Core
{
    public class Manager
    {
        internal Manager()
        {
            ResetHandler();
        }

        public void ResetHandler()
        {
            DeviceScreenSize = null;
            Handler = new ScreenSizeHandler();
        }

        internal ScreenCategories? DeviceScreenSize { get; set; }

        public IScreenSizeHandler Handler { get; set; }

        public static Manager Current { get; } = new Manager();
    }
}
