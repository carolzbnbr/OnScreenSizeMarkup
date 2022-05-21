using System;
namespace OnScreenSizeMarkup.Core
{
    internal class ScreenSizeInfo
    {
        public ScreenSizeInfo(int width, int height, ScreenCategories category)
        {
            this.Category = category;
            this.Width = width;
            this.Height = height;
        }

        public ScreenCategories Category { get; set; }
        public int Width { get; }
        public int Height { get; }
    }
}
