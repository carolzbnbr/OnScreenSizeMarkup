using OnScreenSizeMarkup.Maui;
using OnScreenSizeMarkup.Maui.Categories;

namespace Samples;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Manager.Current.LogLevel = LogLevels.Verbose;
        Manager.Current.IsLogEnabled = true;
        MainPage = new AppShell();
    }
}