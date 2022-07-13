namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Types of evaluation available for classify a screen.
/// Used to determine how a <see cref="SizeMappingInfo.DiagonalSize"/> should be compared against a device diagonal size.
/// </summary>
public enum EvaluationModes
{
	/// <summary>
	/// Smaller than or equals to the current device diagonal screen size.
	/// </summary>
	SmallerThanOrEqualsTo = 0,
	/// <summary>
	/// Compares the current device diagonal screen size that is running the app to match the exact diagonal screen size provided
	/// </summary>
	SpecificSize = 1
}