using OnScreenSizeMarkup.Maui;

namespace Samples;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        OnScreenSizeMarkup.Maui.Manager.Current.IsDebugMode = true;
        
        OnScreenSizeMarkup.Maui.Manager.Current.Mappings.GetMappings.Add(new SizeMappingInfo( ){   });
        MainPage = new AppShell();
    }
}