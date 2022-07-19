using OnScreenSizeMarkup.Maui;

namespace Samples;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        OnScreenSizeMarkup.Maui.Manager.Current.IsLogEnabled = true;


        MainPage = new AppShell();
    }
}