using System.Runtime.CompilerServices;
using OnScreenSizeMarkup.Maui.Categories;

namespace OnScreenSizeMarkup.Maui.Helpers;

#pragma warning disable IDE0040 // Add accessibility modifiers
internal static class ConsoleHelpers
#pragma warning restore IDE0040 // Add accessibility modifiers
{
	public static void WriteLine( this string message, LogLevels level = LogLevels.Info,  [CallerFilePath]string? callerFilePath = null, [CallerMemberName] string memberName = null!)
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