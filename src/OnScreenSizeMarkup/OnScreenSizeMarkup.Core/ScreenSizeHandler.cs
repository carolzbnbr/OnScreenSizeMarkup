using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnScreenSizeMarkup.Core
{
    public class ScreenSizeHandler : IScreenSizeHandler
    {
        protected static Dictionary<string, ScreenSizeGroups>  modelPerSize = new Dictionary<string, ScreenSizeGroups>
        {
              { "iPhone1_1".ToLower(), ScreenSizeGroups.Small },
                { "iPhone1,2".ToLower(),  ScreenSizeGroups.Small },
                { "iPhone2,1".ToLower(), ScreenSizeGroups.Small },
                { "iPhone3,1".ToLower(), ScreenSizeGroups.Small  },
                { "iPhone3,2".ToLower(), ScreenSizeGroups.Small },
                { "iPhone3,3".ToLower(), ScreenSizeGroups.Small },
                { "iPhone4,1".ToLower(),  ScreenSizeGroups.Small },
                { "iPhone5,1".ToLower(),  ScreenSizeGroups.Small },
                { "iPhone5,2".ToLower(), ScreenSizeGroups.Small },
                { "iPhone5,3".ToLower(),  ScreenSizeGroups.Small  },
                { "iPhone5,4".ToLower(), ScreenSizeGroups.Small  },
                { "iPhone6,1".ToLower(),  ScreenSizeGroups.Small},
                { "iPhone6,2".ToLower(),  ScreenSizeGroups.Small  },
                { "iPhone7,1".ToLower(), ScreenSizeGroups.Large },
                { "iPhone7,2".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone8,1".ToLower(),  ScreenSizeGroups.Medium  },
                { "iPhone8,2".ToLower(), ScreenSizeGroups.Large  },
                { "iPhone8,4".ToLower(), ScreenSizeGroups.Medium  },
                { "iPhone9,1".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone9,2".ToLower(),  ScreenSizeGroups.Large },
                { "iPhone9,3".ToLower(),  ScreenSizeGroups.Medium },
                { "iPhone9,4".ToLower(), ScreenSizeGroups.Large },
                { "iPhone10,1".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone10,2".ToLower(), ScreenSizeGroups.Large },
                { "iPhone10,3".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone10,4".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone10,5".ToLower(), ScreenSizeGroups.Large },
                { "iPhone10,6".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone11,2".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone11,4".ToLower(), ScreenSizeGroups.Large },
                { "iPhone11,6".ToLower(), ScreenSizeGroups.Large },
                { "iPhone11,8".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone12,1".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone12,3".ToLower(),  ScreenSizeGroups.Medium },
                { "iPhone12,5".ToLower(), ScreenSizeGroups.Large },
                { "iPhone12,8".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone13,1".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone13,2".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone13,3".ToLower(), ScreenSizeGroups.Medium }, //
                { "iPhone13,4".ToLower(), ScreenSizeGroups.Large }, //
                { "iPhone14,2".ToLower(), ScreenSizeGroups.Medium }, //
                { "iPhone14,3".ToLower(), ScreenSizeGroups.Large }, //
                { "iPhone14,4".ToLower(), ScreenSizeGroups.Medium },
                { "iPhone14,5".ToLower(), ScreenSizeGroups.Medium },
                { "Pad12,2".ToLower(),  ScreenSizeGroups.ExtraLarge },
                { "iPad_9th_Gen".ToLower(),  ScreenSizeGroups.ExtraLarge },
                { "iPad1,2".ToLower(),  ScreenSizeGroups.ExtraLarge },
                 { "iPad2,1".ToLower(), ScreenSizeGroups.ExtraLarge },
                 { "iPad2,2".ToLower(), ScreenSizeGroups.ExtraLarge },
                 { "iPad2,3".ToLower(),  ScreenSizeGroups.ExtraLarge },
                 { "iPad2,4".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad2,5".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad2,6".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad2,7".ToLower(), ScreenSizeGroups.ExtraLarge },
                 { "iPad3,1".ToLower(), ScreenSizeGroups.ExtraLarge },
                 { "iPad3,2".ToLower(), ScreenSizeGroups.ExtraLarge },
                 { "iPad3,3".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad3,4".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad3,5".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad3,6".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,1".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,2".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,3".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,4".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,5".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,6".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,7".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,8".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad4,9".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad5,1".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad5,2".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad5,3".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad5,4".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad6,4".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad6,7".ToLower(),ScreenSizeGroups.ExtraLarge },
                { "iPad6,8".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad6,11".ToLower(), ScreenSizeGroups.ExtraLarge }, //   _
                { "iPad6,12".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad7,1".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad7,2".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad7,3".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad7,4".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad7,5".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad7,6".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad7,11".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad7,12".ToLower(), ScreenSizeGroups.ExtraLarge },
                { "iPad8,1".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,2".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,3".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,4".ToLower(), ScreenSizeGroups.ExtraLarge}, //   
                { "iPad8,5".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,6".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,7".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,8".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,9".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,10".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,11".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad8,12".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,1".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,2".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,3".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,4".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,6".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad11,7".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad12,1".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad12,2".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,1".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,2".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,4".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,5".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,6".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,7".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,8".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,9".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,10".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                { "iPad13,11".ToLower(), ScreenSizeGroups.ExtraLarge } , //
                { "iPad14,1".ToLower(), ScreenSizeGroups.ExtraLarge }, //   
                 { "iPad14,2".ToLower(), ScreenSizeGroups.ExtraLarge },

        };

        private static List<ScreenSizeInfo> _screenSizes = new List<ScreenSizeInfo>
        {
            { new ScreenSizeInfo(480,800, ScreenSizeGroups.ExtraSmall)}, //Samsung Galaxy S,
            { new ScreenSizeInfo(720,1280, ScreenSizeGroups.Small)}, //Nesus S
            { new ScreenSizeInfo(750,1334, ScreenSizeGroups.Medium)}, //iphone 6, iphone 6s. iphone7, iphone 8

            { new ScreenSizeInfo(1125,2436, ScreenSizeGroups.Medium)}, //iphone X, Apple iPhone XS
            { new ScreenSizeInfo(828,1792, ScreenSizeGroups.Medium)}, //iphone 11, iPhone XR
            { new ScreenSizeInfo(1080,1920, ScreenSizeGroups.Large)}, //iphone 6s PLUS, iphone 7 PLUS, iphone 8 Plus
            { new ScreenSizeInfo(1242,2688, ScreenSizeGroups.Large)}, //Apple iPhone XS Max
            { new ScreenSizeInfo(1284,2778, ScreenSizeGroups.Large)}, //Apple iPhone 12 Pro Max, iPhone 13 Pro Max
            { new ScreenSizeInfo(1440,3200, ScreenSizeGroups.ExtraLarge)}, //Samsung Galaxy S20+	
            { new ScreenSizeInfo(2732,2048, ScreenSizeGroups.ExtraLarge)}, //Apple iPad Pro 12.9
        };

        /// <summary>
        /// Attempt to get the screen size by a provided device-model name.
        /// </summary>
        /// <param name="deviceModel">device model</param>
        /// <param name="screenSize"></param>
        /// <returns></returns>
        public virtual bool TryGetSizeByDeviceModel(string deviceModel, out ScreenSizeGroups screenSize)
        {
            if (string.IsNullOrWhiteSpace(deviceModel))
            {
                screenSize = ScreenSizeGroups.NotSet;
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
        public virtual bool TryGetSizeByPhysicalSize(double deviceWidth, double deviceHeight, out ScreenSizeGroups screenSize)
        {
            screenSize = ScreenSizeGroups.NotSet;

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
