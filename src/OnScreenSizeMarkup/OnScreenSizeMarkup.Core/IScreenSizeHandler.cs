using System.Collections.Generic;

namespace OnScreenSizeMarkup.Core
{
    /// <summary>
    /// Responsible for identify the screen size of the device model on either device name or device screen dimentions.
    /// </summary>
    public  interface IScreenSizeHandler
    {
        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        bool TryGetSizeByDeviceModel(string deviceModel, out ScreenCategories screenSize);

        /// <summary>
        /// Attempt to get the screen-size by device's physical size (width/height).
        /// </summary>
        /// <param name="deviceWidth"></param>
        /// <param name="deviceHeight"></param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        bool TryGetSizeByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenCategories screenSize);

    }

  
}
