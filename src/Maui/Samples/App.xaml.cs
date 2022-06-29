namespace Samples;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        OnScreenSizeMarkup.Maui.Manager.Current.IsDebugMode = true;
        MainPage = new AppShell();
    }
}