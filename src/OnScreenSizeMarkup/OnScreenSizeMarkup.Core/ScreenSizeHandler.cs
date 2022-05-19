using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnScreenSizeMarkup.Core
{
    public class ScreenSizeHandler : IScreenSizeHandler
    {
        protected static Dictionary<string, ScreenCategories>  modelPerSize = new Dictionary<string, ScreenCategories>
        {
              { "iPhone1_1".ToLower(), ScreenCategories.Small },
                { "iPhone1,2".ToLower(),  ScreenCategories.Small },
                { "iPhone2,1".ToLower(), ScreenCategories.Small },
                { "iPhone3,1".ToLower(), ScreenCategories.Small  },
                { "iPhone3,2".ToLower(), ScreenCategories.Small },
                { "iPhone3,3".ToLower(), ScreenCategories.Small },
                { "iPhone4,1".ToLower(),  ScreenCategories.Small },
                { "iPhone5,1".ToLower(),  ScreenCategories.Small },
                { "iPhone5,2".ToLower(), ScreenCategories.Small },
                { "iPhone5,3".ToLower(),  ScreenCategories.Small  },
                { "iPhone5,4".ToLower(), ScreenCategories.Small  },
                { "iPhone6,1".ToLower(),  ScreenCategories.Small},
                { "iPhone6,2".ToLower(),  ScreenCategories.Small  },
                { "iPhone7,1".ToLower(), ScreenCategories.Large },
                { "iPhone7,2".ToLower(), ScreenCategories.Medium },
                { "iPhone8,1".ToLower(),  ScreenCategories.Medium  },
                { "iPhone8,2".ToLower(), ScreenCategories.Large  },
                { "iPhone8,4".ToLower(), ScreenCategories.Medium  },
                { "iPhone9,1".ToLower(), ScreenCategories.Medium },
                { "iPhone9,2".ToLower(),  ScreenCategories.Large },
                { "iPhone9,3".ToLower(),  ScreenCategories.Medium },
                { "iPhone9,4".ToLower(), ScreenCategories.Large },
                { "iPhone10,1".ToLower(), ScreenCategories.Medium },
                { "iPhone10,2".ToLower(), ScreenCategories.Large },
                { "iPhone10,3".ToLower(), ScreenCategories.Medium },
                { "iPhone10,4".ToLower(), ScreenCategories.Medium },
                { "iPhone10,5".ToLower(), ScreenCategories.Large },
                { "iPhone10,6".ToLower(), ScreenCategories.Medium },
                { "iPhone11,2".ToLower(), ScreenCategories.Medium },
                { "iPhone11,4".ToLower(), ScreenCategories.Large },
                { "iPhone11,6".ToLower(), ScreenCategories.Large },
                { "iPhone11,8".ToLower(), ScreenCategories.Medium },
                { "iPhone12,1".ToLower(), ScreenCategories.Medium },
                { "iPhone12,3".ToLower(),  ScreenCategories.Medium },
                { "iPhone12,5".ToLower(), ScreenCategories.Large },
                { "iPhone12,8".ToLower(), ScreenCategories.Medium },
                { "iPhone13,1".ToLower(), ScreenCategories.Medium },
                { "iPhone13,2".ToLower(), ScreenCategories.Medium },
                { "iPhone13,3".ToLower(), ScreenCategories.Medium }, //
                { "iPhone13,4".ToLower(), ScreenCategories.Large }, //
                { "iPhone14,2".ToLower(), ScreenCategories.Medium }, //
                { "iPhone14,3".ToLower(), ScreenCategories.Large }, //
                { "iPhone14,4".ToLower(), ScreenCategories.Medium },
                { "iPhone14,5".ToLower(), ScreenCategories.Medium },
                { "Pad12,2".ToLower(),  ScreenCategories.ExtraLarge },
                { "iPad_9th_Gen".ToLower(),  ScreenCategories.ExtraLarge },
                { "iPad1,2".ToLower(),  ScreenCategories.ExtraLarge },
                 { "iPad2,1".ToLower(), ScreenCategories.ExtraLarge },
                 { "iPad2,2".ToLower(), ScreenCategories.ExtraLarge },
                 { "iPad2,3".ToLower(),  ScreenCategories.ExtraLarge },
                 { "iPad2,4".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad2,5".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad2,6".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad2,7".ToLower(), ScreenCategories.ExtraLarge },
                 { "iPad3,1".ToLower(), ScreenCategories.ExtraLarge },
                 { "iPad3,2".ToLower(), ScreenCategories.ExtraLarge },
                 { "iPad3,3".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad3,4".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad3,5".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad3,6".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,1".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,2".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,3".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,4".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,5".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,6".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,7".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,8".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad4,9".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad5,1".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad5,2".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad5,3".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad5,4".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad6,4".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad6,7".ToLower(),ScreenCategories.ExtraLarge },
                { "iPad6,8".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad6,11".ToLower(), ScreenCategories.ExtraLarge }, //   _
                { "iPad6,12".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad7,1".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad7,2".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad7,3".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad7,4".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad7,5".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad7,6".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad7,11".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad7,12".ToLower(), ScreenCategories.ExtraLarge },
                { "iPad8,1".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,2".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,3".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,4".ToLower(), ScreenCategories.ExtraLarge}, //   
                { "iPad8,5".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,6".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,7".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,8".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,9".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,10".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,11".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad8,12".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,1".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,2".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,3".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,4".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,6".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad11,7".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad12,1".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad12,2".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,1".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,2".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,4".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,5".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,6".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,7".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,8".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,9".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,10".ToLower(), ScreenCategories.ExtraLarge }, //   
                { "iPad13,11".ToLower(), ScreenCategories.ExtraLarge } , //
                { "iPad14,1".ToLower(), ScreenCategories.ExtraLarge }, //   
                 { "iPad14,2".ToLower(), ScreenCategories.ExtraLarge },

        };

        private static List<ScreenSizeInfo> _screenSizes = new List<ScreenSizeInfo>
        {
            { new ScreenSizeInfo(480,800, ScreenCategories.ExtraSmall)}, //Samsung Galaxy S,
            { new ScreenSizeInfo(720,1280, ScreenCategories.Small)}, //Nesus S
            { new ScreenSizeInfo(750,1334, ScreenCategories.Medium)}, //iphone 6, iphone 6s. iphone7, iphone 8

            { new ScreenSizeInfo(1125,2436, ScreenCategories.Medium)}, //iphone X, Apple iPhone XS
            { new ScreenSizeInfo(828,1792, ScreenCategories.Medium)}, //iphone 11, iPhone XR
            { new ScreenSizeInfo(1080,1920, ScreenCategories.Large)}, //iphone 6s PLUS, iphone 7 PLUS, iphone 8 Plus
            { new ScreenSizeInfo(1242,2688, ScreenCategories.Large)}, //Apple iPhone XS Max
            { new ScreenSizeInfo(1284,2778, ScreenCategories.Large)}, //Apple iPhone 12 Pro Max, iPhone 13 Pro Max
            { new ScreenSizeInfo(1440,3200, ScreenCategories.ExtraLarge)}, //Samsung Galaxy S20+	
            { new ScreenSizeInfo(2732,2048, ScreenCategories.ExtraLarge)}, //Apple iPad Pro 12.9
        };

        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        public virtual bool TryGetSizeByDeviceModel(string deviceModel, out ScreenCategories screenSize)
        {
            if (string.IsNullOrWhiteSpace(deviceModel))
            {
                screenSize = ScreenCategories.NotSet;
                return false;
            }

            var deviceNameLocal = deviceModel.Trim().ToLower();

            if (modelPerSize.TryGetValue(deviceNameLocal, out screenSize))
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
        /// <param name="screenSize"></param>
        /// <returns></returns>
        public virtual bool TryGetSizeByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenCategories screenSize)
        {
            screenSize = ScreenCategories.NotSet;

            for (int i = 0; i < _screenSizes.Count; i++)
            {
                ScreenSizeInfo sizeInfo = _screenSizes[i];
                if (deviceWidth <= sizeInfo.Width &&
                    deviceHeight <= sizeInfo.Height)
                {
                    screenSize = sizeInfo.ScreenSize;
                    return true;
                }
            }
            return false;
        }
    }
}
