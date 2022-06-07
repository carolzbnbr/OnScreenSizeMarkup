using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnScreenSizeMarkup.Core
{

    //https://www.omnicalculator.com/other/screen-size#:~:text=To%20calculate%20screen%20size%3A,the%20area%20of%20the%20screen.

    public class DiagonalScreenCategoryHandler : ICategoryFallbackHandler
    {


        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="category"></param>
        /// <returns></returns>
        public virtual bool TryGetCategoryByDeviceModel(string deviceModel, out ScreenCategories category)
        {
            category = ScreenCategories.NotSet;
            return false;
        }

        /// <summary>
        /// Attempt to get the screen-size by device's physical size (width/height).
        /// </summary>
        /// <param name="deviceWidth"></param>
        /// <param name="deviceHeight"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public virtual bool TryGetCategoryByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenCategories category)
        {

            var deviceDiagonalScreenSize = GetDiagonalScreenSize(deviceWidth, deviceHeight);

            if (deviceDiagonalScreenSize <= 40)
            {
                category = ScreenCategories.ExtraSmall;
                return true;
            }
            else if (deviceDiagonalScreenSize is (> 40 and <= 65)) 
            {
                category = ScreenCategories.Small;
                return true;
            }
         
            else if (deviceDiagonalScreenSize is (> 65 and <= 76)) 
            {
                category = ScreenCategories.Medium;
                return true;
            }
            else if (deviceDiagonalScreenSize is (> 76 and <= 92)) 
            {
                category = ScreenCategories.Large;
                return true;
            }

            category = ScreenCategories.ExtraLarge;
            return true;

          
        }



        private double GetDiagonalScreenSize(double deviceWidth, double deviceHeight)
        {
            var result = (deviceWidth * 2) + (deviceHeight * 2);
            return Math.Sqrt(result);
        }
    }
}
