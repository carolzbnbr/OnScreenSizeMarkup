using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using OnScreenSizeMarkup.Maui.Categories;
using OnScreenSizeMarkup.Maui.Mappings;
#pragma warning disable CS8618
#pragma warning disable CS1591

[assembly: InternalsVisibleTo("OnScreenSizeMarkup.Maui")]
[assembly: InternalsVisibleTo("Samples")]
[assembly: InternalsVisibleTo("OnScreenSizeMarkup.Maui.Tests")]

namespace  OnScreenSizeMarkup.Maui;

/// <summary>
/// Central point for defining specific settings for the Markup extension.
/// </summary>
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
public class Manager
{
    private Manager()
    {
    }

    /// <summary>
    /// List of mappings that defines which screen diagonal-sizes (in inches) corresponds to a specific <see cref="ScreenCategories"/> and also
    /// how they should be evaluated during runtime in order to correctly classify screens.
    /// </summary>
    /// <remarks>
    /// You can override this values by setting your own mappings.
    /// </remarks>
    public ScreenMappingList Mappings { get; set; } = DefaultMappings.MobileMappings;
    
    /// <summary>
    /// Display console messages for debugging purposes.
    /// </summary>
    public bool IsDebugMode { get; set; }

    /// <summary>
    /// When <see cref="IsDebugMode"/> is true, defines how detailed the log messages should be logged to.
    /// </summary>
    public DebugLevels DebugLevel { get; set; } = DebugLevels.Info;

    /// <summary>
    /// Returns the current <see cref="ScreenCategories"/> set for the device.
    /// </summary>
    public ScreenCategories? CurrentCategory { get; internal set; } = null;

    internal IScreenCategorizer Categorizer { get; } = new ScreenCategorizer();

    /// <summary>
    /// Gets the singleton instance of this class.
    /// </summary>
    public static Manager Current { get; } = new Manager();
}

