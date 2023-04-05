using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.App;
using Android.Hardware.Display;
using Point = Android.Graphics.Point;

namespace OnScreenSizeMarkup.Maui.PlatformDensities;

#if ANDROID
[SuppressMessage("Style", "IDE0040:Adicionar modificadores de acessibilidade")]
internal static partial class ScreenDensityPlatform 
{
	public static (double xdpi, double ydpi) GetPixelPerInches()
	{
		var displayMetrics = Android.App.Application.Context.Resources?.DisplayMetrics;
		
		return (displayMetrics?.Xdpi ?? 0, displayMetrics?.Ydpi ?? 0);
	}

	public static (double width, double height) GetNativeScreenResolution()
	{
		var displayMetrics = new DisplayMetrics();
		var windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
		var display = windowManager!.DefaultDisplay!;
		if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
		{
			display.GetRealMetrics(displayMetrics);
		}
		else
		{
			display.GetMetrics(displayMetrics);
		}

		var widthInDp = (float)displayMetrics.WidthPixels / displayMetrics.Density;
		var heightInDp = (float)displayMetrics.HeightPixels / displayMetrics.Density;
		var widthInPixels = (int)(widthInDp * displayMetrics.Density);
		var heightInPixels = (int)(heightInDp * displayMetrics.Density);

		//var mainDisplayInfo = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo;

		//var displayMetrics = Android.App.Application.Context.Resources?.DisplayMetrics;

		return (widthInPixels, heightInPixels);
	}
}
#endif