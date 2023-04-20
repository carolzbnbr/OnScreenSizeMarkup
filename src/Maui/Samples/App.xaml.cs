using OnScreenSizeMarkup.Maui;
using OnScreenSizeMarkup.Maui.Categories;

namespace Samples;

public partial class App : Application
{
    public App()
    {
        Manager.Current.LogLevel = LogLevels.Verbose;
        Manager.Current.IsLogEnabled = true;
        Manager.Current.UseNativeScreenResolution = true;
        InitializeComponent();
   
        MainPage = new AppShell();
    }
}