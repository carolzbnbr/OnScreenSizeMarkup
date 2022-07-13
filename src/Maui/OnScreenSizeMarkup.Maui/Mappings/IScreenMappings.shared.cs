namespace OnScreenSizeMarkup.Maui.Mappings;

/// <summary>
/// Provides access to  <see cref="ScreenMappingList"/> in which mappings are stored.
/// </summary>
public  interface IScreenMappings
{
	/// <summary>
	/// Access the <see cref="ScreenMappingList"/> in which mappings are stored.
	/// </summary>
	public ScreenMappingList MobileMappings { get; }
}