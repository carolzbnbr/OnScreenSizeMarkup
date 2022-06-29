using System.Runtime.CompilerServices;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Mappings;
#pragma warning disable CS8618
#pragma warning disable CS1591

[assembly: InternalsVisibleTo("OnScreenSizeMarkup.Maui")]
[assembly: InternalsVisibleTo("Samples")]

namespace  OnScreenSizeMarkup.Maui;

public class Manager
{
    private Manager()
    {
    }

    /// <summary>
    /// Gets/sets the mappings that defines which screen diagonal-sizes (in inches) corresponds to a specific <see cref="ScreenCategories"/>.
    /// </summary>
    public IScreenMappings Mappings { get; set; } = new MobileScreenMappings();
    
    public bool IsDebugMode { get; set; }

    /// <summary>
    /// Returns the current <see cref="ScreenCategories"/> set for the device.
    /// </summary>
    public ScreenCategories? CurrentCategory { get; internal set; } = null;

    internal IScreenCategorizer Categorizer { get; } = new ScreenCategorizer();

    public static Manager Current { get; } = new Manager();
}

