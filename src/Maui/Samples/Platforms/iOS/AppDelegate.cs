using System.Runtime.InteropServices;
using Foundation;
using UIKit;

namespace Samples;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp()
    {
        Calculate();
        return MauiProgram.CreateMauiApp();
    }

    private void Calculate()
    {
        double scale = (double)UIScreen.MainScreen.Scale;

        double ppi = 458;// scale * 458;// (scale * (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad  ? 132 : 458));

        double width = UIScreen.MainScreen.Bounds.Size.Width * scale;
        double height = UIScreen.MainScreen.Bounds.Size.Height * scale;

        double horizontal = width / ppi;
        double vertical = height / ppi;

        var diagonal = Math.Sqrt(Math.Pow(horizontal, 2) + Math.Pow(vertical, 2));
        Console.WriteLine($"{diagonal}");
    }
    
    public static (double xdpi, double ydpi) GetPixelPerInches()
    {
        var displayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;
		
        var scale = displayInfo.Density;
        var dpi = scale * 160;
		
        if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
        {
            dpi = scale * 132;
        } 
        else if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
        {
            dpi = scale * 163;
        }

        return (dpi, dpi);
    }
}