using System.Runtime.CompilerServices;
using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Extensions;

public static class DebugExtensions
{
	public static void WriteToLog(this string message, DebugLevels level = DebugLevels.Info,  [CallerFilePath]string? callerFilePath = null, [CallerMemberName] string memberName = null!)
	{
		if (!Manager.Current.IsDebugMode)
		{
			return;
		}
		if (Manager.Current.DebugLevel != level)
		{
			return;
		}
		
		var classFilename = Path.GetFileNameWithoutExtension(callerFilePath);
		if (string.IsNullOrWhiteSpace(memberName))
		{
			memberName = "";
		}
		Console.WriteLine($"** DEBUG ** {nameof(OnScreenSizeMarkup)} ({classFilename}.{memberName}): {message}");
	}
}