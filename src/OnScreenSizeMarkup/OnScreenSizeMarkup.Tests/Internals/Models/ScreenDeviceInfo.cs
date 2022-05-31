using System;
using Newtonsoft.Json;
using OnScreenSizeMarkup.Core;

namespace OnScreenSizeMarkup.Forms.Tests.Internals.Models
{
    public class ScreenDeviceInfo
    {
        public ScreenDeviceInfo()
        {
        }

        public string Device { get; set; }

        public string OperatingSystem { get; set; }

        public string Physical_Size { get; set; }

        public string Physical_Size_CM { get; set; }


        [JsonProperty("Width")]
        public double ScreenWidth { get; set; }

        [JsonProperty("Height")]
        public double ScreenHeight { get; set; }

        public string DeviceWidth { get; set; }

        public string PIX_PER_INCH { get; set; }

        public string POPULARITY { get; set; }

        public int Screen_Category { get; set; }

        public ScreenCategories ScreenCategory { get => (ScreenCategories)Screen_Category; }

    }
}
