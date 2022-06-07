using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace OnScreenSizeMarkup.Core.Extensions
{
    public static class DebugExtensions
    {
        public static void WriteToLog(this string message,  [CallerFilePath]string callerFilePath = null, [CallerMemberName] string memberName = null)
        {
            if (!Manager.Current.IsDebugMode)
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
}