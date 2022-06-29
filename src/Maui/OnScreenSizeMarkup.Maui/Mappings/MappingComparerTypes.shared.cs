namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Mapping comparer Types.
/// Used to determine how a <see cref="SizeMappingInfo.DiagonalSize"/> should compare against an actual diagonal screen.
/// </summary>
public enum MappingComparerTypes
{
	/// <summary>
	/// Smaller than or equals to the current device diagonal screen size.
	/// </summary>
	SmallerThanOrEqualsTo = 0,
	/// <summary>
	/// Compares for equality  the current device diagonal screen size to the mapping item.
	/// </summary>
	EqualsTo = 1
}