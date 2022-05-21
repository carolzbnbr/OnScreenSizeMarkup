using System.Collections.Generic;

namespace OnScreenSizeMarkup.Core
{
    /// <summary>
    /// Responsible for identify the screen size of the device model on either device name or device screen dimentions.
    /// </summary>
    public  interface ICategoryFallbackHandler
    {
        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="category"></param>
        /// <returns></returns>
        bool TryGetCategoryByDeviceModel(string deviceModel, out ScreenCategories category);

        /// <summary>
        /// Attempt to get the screen-size by device's physical size (width/height).
        /// </summary>
        /// <param name="deviceWidth"></param>
        /// <param name="deviceHeight"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        bool TryGetCategoryByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenCategories category);

    }

  
}
