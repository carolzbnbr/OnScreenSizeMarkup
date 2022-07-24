using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.App;
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
}
#endif