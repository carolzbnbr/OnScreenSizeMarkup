using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnScreenSizeMarkup.Core
{

    //https://www.omnicalculator.com/other/screen-size#:~:text=To%20calculate%20screen%20size%3A,the%20area%20of%20the%20screen.

    public class DefaultCategoryFallbackHandler : ICategoryFallbackHandler
    {

        #region Category Dictionaries
        protected static Dictionary<string, ScreenCategories>  modelCategories =  new Dictionary<string, ScreenCategories>(StringComparer.InvariantCultureIgnoreCase)
        {       
                { "iPhone1_1", ScreenCategories.Small },
                { "iPhone1,2",  ScreenCategories.Small },
                { "iPhone2,1", ScreenCategories.Small },
                { "iPhone3,1", ScreenCategories.Small  },
                { "iPhone3,2", ScreenCategories.Small },
                { "iPhone3,3", ScreenCategories.Small },
                { "iPhone4,1",  ScreenCategories.Small },
                { "iPhone5,1",  ScreenCategories.Small },
                { "iPhone5,2", ScreenCategories.Small },
                { "iPhone5,3",  ScreenCategories.Small  },
                { "iPhone5,4", ScreenCategories.Small  },
                { "iPhone6,1",  ScreenCategories.Small},
                { "iPhone6,2",  ScreenCategories.Small  },
                { "iPhone7,1", ScreenCategories.Large },
                { "iPhone7,2", ScreenCategories.Medium },
                { "iPhone8,1",  ScreenCategories.Medium  },
                { "iPhone8,2", ScreenCategories.Large  },
                { "iPhone8,4", ScreenCategories.Medium  },
                { "iPhone9,1", ScreenCategories.Medium },
                { "iPhone9,2",  ScreenCategories.Large },
                { "iPhone9,3",  ScreenCategories.Medium },
                { "iPhone9,4", ScreenCategories.Large },
                { "iPhone10,1", ScreenCategories.Medium },
                { "iPhone10,2", ScreenCategories.Large },
                { "iPhone10,3", ScreenCategories.Medium },
                { "iPhone10,4", ScreenCategories.Medium },
                { "iPhone10,5", ScreenCategories.Large },
                { "iPhone10,6", ScreenCategories.Medium },
                { "iPhone11,2", ScreenCategories.Medium },
                { "iPhone11,4", ScreenCategories.Large },
                { "iPhone11,6", ScreenCategories.Large },
                { "iPhone11,8", ScreenCategories.Medium },
                { "iPhone12,1", ScreenCategories.Medium },
                { "iPhone12,3",  ScreenCategories.Medium },
                { "iPhone12,5", ScreenCategories.Large },
                { "iPhone12,8", ScreenCategories.Medium },
                { "iPhone13,1", ScreenCategories.Medium },
                { "iPhone13,2", ScreenCategories.Medium },
                { "iPhone13,3", ScreenCategories.Medium }, 
                { "iPhone13,4", ScreenCategories.Large },
                { "iPhone14,2", ScreenCategories.Medium },
                { "iPhone14,3", ScreenCategories.Large },
                { "iPhone14,4", ScreenCategories.Medium },
                { "iPhone14,5", ScreenCategories.Medium },
                { "Pad12,2",    ScreenCategories.ExtraLarge },
                { "iPad_9th_Gen", ScreenCategories.ExtraLarge },
                { "iPad1,2",  ScreenCategories.ExtraLarge },
                { "iPad2,1", ScreenCategories.ExtraLarge },
                { "iPad2,2", ScreenCategories.ExtraLarge },
                { "iPad2,3",  ScreenCategories.ExtraLarge },
                { "iPad2,4", ScreenCategories.ExtraLarge },
                { "iPad2,5", ScreenCategories.ExtraLarge },
                { "iPad2,6", ScreenCategories.ExtraLarge },
                { "iPad2,7", ScreenCategories.ExtraLarge },
                { "iPad3,1", ScreenCategories.ExtraLarge },
                { "iPad3,2", ScreenCategories.ExtraLarge },
                { "iPad3,3", ScreenCategories.ExtraLarge },
                { "iPad3,4", ScreenCategories.ExtraLarge },
                { "iPad3,5", ScreenCategories.ExtraLarge },
                { "iPad3,6", ScreenCategories.ExtraLarge },
                { "iPad4,1", ScreenCategories.ExtraLarge },
                { "iPad4,2", ScreenCategories.ExtraLarge },
                { "iPad4,3", ScreenCategories.ExtraLarge },
                { "iPad4,4", ScreenCategories.ExtraLarge },
                { "iPad4,5", ScreenCategories.ExtraLarge },
                { "iPad4,6", ScreenCategories.ExtraLarge },
                { "iPad4,7", ScreenCategories.ExtraLarge },
                { "iPad4,8", ScreenCategories.ExtraLarge },
                { "iPad4,9", ScreenCategories.ExtraLarge },
                { "iPad5,1", ScreenCategories.ExtraLarge },
                { "iPad5,2", ScreenCategories.ExtraLarge },
                { "iPad5,3", ScreenCategories.ExtraLarge },
                { "iPad5,4", ScreenCategories.ExtraLarge },
                { "iPad6,4", ScreenCategories.ExtraLarge },
                { "iPad6,7",ScreenCategories.ExtraLarge },
                { "iPad6,8", ScreenCategories.ExtraLarge },
                { "iPad6,11", ScreenCategories.ExtraLarge }, 
                { "iPad6,12", ScreenCategories.ExtraLarge },
                { "iPad7,1", ScreenCategories.ExtraLarge },
                { "iPad7,2", ScreenCategories.ExtraLarge },
                { "iPad7,3", ScreenCategories.ExtraLarge },   
                { "iPad7,4", ScreenCategories.ExtraLarge },   
                { "iPad7,5", ScreenCategories.ExtraLarge },   
                { "iPad7,6", ScreenCategories.ExtraLarge },   
                { "iPad7,11", ScreenCategories.ExtraLarge },   
                { "iPad7,12", ScreenCategories.ExtraLarge },
                { "iPad8,1", ScreenCategories.ExtraLarge },   
                { "iPad8,2", ScreenCategories.ExtraLarge },   
                { "iPad8,3", ScreenCategories.ExtraLarge },   
                { "iPad8,4", ScreenCategories.ExtraLarge},   
                { "iPad8,5", ScreenCategories.ExtraLarge },   
                { "iPad8,6", ScreenCategories.ExtraLarge },   
                { "iPad8,7", ScreenCategories.ExtraLarge },   
                { "iPad8,8", ScreenCategories.ExtraLarge },   
                { "iPad8,9", ScreenCategories.ExtraLarge },   
                { "iPad8,10", ScreenCategories.ExtraLarge },   
                { "iPad8,11", ScreenCategories.ExtraLarge },   
                { "iPad8,12", ScreenCategories.ExtraLarge },   
                { "iPad11,1", ScreenCategories.ExtraLarge },   
                { "iPad11,2", ScreenCategories.ExtraLarge },   
                { "iPad11,3", ScreenCategories.ExtraLarge },   
                { "iPad11,4", ScreenCategories.ExtraLarge },   
                { "iPad11,6", ScreenCategories.ExtraLarge },   
                { "iPad11,7", ScreenCategories.ExtraLarge },   
                { "iPad12,1", ScreenCategories.ExtraLarge },   
                { "iPad12,2", ScreenCategories.ExtraLarge },   
                { "iPad13,1", ScreenCategories.ExtraLarge },   
                { "iPad13,2", ScreenCategories.ExtraLarge },   
                { "iPad13,4", ScreenCategories.ExtraLarge },   
                { "iPad13,5", ScreenCategories.ExtraLarge },   
                { "iPad13,6", ScreenCategories.ExtraLarge },   
                { "iPad13,7", ScreenCategories.ExtraLarge },   
                { "iPad13,8", ScreenCategories.ExtraLarge },   
                { "iPad13,9", ScreenCategories.ExtraLarge },   
                { "iPad13,10", ScreenCategories.ExtraLarge },   
                { "iPad13,11", ScreenCategories.ExtraLarge },
                { "iPad14,1", ScreenCategories.ExtraLarge },   
                { "iPad14,2", ScreenCategories.ExtraLarge },
        };

        private static ScreenSizeInfo[] screenSizeCategories = new ScreenSizeInfo[]
         {
            new ScreenSizeInfo(480,800, ScreenCategories.ExtraSmall), 
            new ScreenSizeInfo(720,1280, ScreenCategories.Small), 
            new ScreenSizeInfo(750,1334, ScreenCategories.Medium), 
            new ScreenSizeInfo(1125,2436, ScreenCategories.Medium),
            new ScreenSizeInfo(828,1792, ScreenCategories.Medium),
            new ScreenSizeInfo(1080,1920, ScreenCategories.Large),
            new ScreenSizeInfo(1242,2688, ScreenCategories.Large),
            new ScreenSizeInfo(1284,2778, ScreenCategories.Large),
            new ScreenSizeInfo(1440,3200, ScreenCategories.ExtraLarge),
            new ScreenSizeInfo(2732,2048, ScreenCategories.ExtraLarge),
        };
#endregion

        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="category"></param>
        /// <returns></returns>
        public virtual bool TryGetCategoryByDeviceModel(string deviceModel, out ScreenCategories category)
        {
            if (string.IsNullOrWhiteSpace(deviceModel))
            {
                category = ScreenCategories.NotSet;
                return false;
            }

            var deviceNameLocal = deviceModel.Trim();

            if (modelCategories.TryGetValue(deviceNameLocal, out category))
            {
                return true;
            }

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
            category = ScreenCategories.NotSet;
            for (int i = 0; i < screenSizeCategories.Length; i++)
            {
                ScreenSizeInfo sizeInfo = screenSizeCategories[i];
                if (deviceWidth <= sizeInfo.Width &&
                    deviceHeight <= sizeInfo.Height)
                {
                    category = sizeInfo.Category;
                    return true;
                }
            }
            return false;

        }
    }
}
