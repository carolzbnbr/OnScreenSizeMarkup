
namespace  OnScreenSizeMarkup.Maui.Categories;

/// <summary>
/// Responsible for identify the screen size of the device model on either device name or device screen dimentions.
/// </summary>
internal  interface IScreenCategorizer
{
	ScreenCategories GetCategoryByDiagonalSize(double deviceActualDiagonalSize);
}