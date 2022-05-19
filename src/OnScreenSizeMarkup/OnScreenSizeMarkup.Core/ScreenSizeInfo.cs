using System;
namespace OnScreenSizeMarkup.Core
{
    internal class ScreenSizeInfo
    {
        public ScreenSizeInfo(int width, int height, ScreenCategories screenSize)
        {
            this.ScreenSize = screenSize;
            Width = width;
            Height = height;
        }

        public ScreenCategories ScreenSize { get; set; }
        public int Width { get; }
        public int Height { get; }
    }
}
