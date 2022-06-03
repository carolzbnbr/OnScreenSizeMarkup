using System.Collections.Generic;

namespace  OnScreenSizeMarkup.Maui
{
    /// <summary>
    /// Responsible for identify the screen size of the device model on either device name or device screen dimentions.
    /// </summary>
    public  interface ICategoryFallbackHandler
    {
        ///// <summary>
        ///// Attempt to get the screen size by a provided device-model name.
        ///// </summary>
        ///// <param name="deviceModel">device model</param>
        ///// <param name="category"></param>
        ///// <returns></returns>
        //bool TryGetCategoryByDeviceModel(string deviceModel, out ScreenCategories category);

        /// <summary>
        /// Attempt to get the <see cref="ScreenCategories"/> by device's physical size (width/height).
        /// </summary>
        /// <param name="deviceWidth"></param>
        /// <param name="deviceHeight"></param>
        /// <returns>The <see cref="ScreenCategories"/> a device size fits in</returns>
        ScreenCategories GetCategoryByPhysicalSize(double deviceWidth, double deviceHeight);

    }

  
}
