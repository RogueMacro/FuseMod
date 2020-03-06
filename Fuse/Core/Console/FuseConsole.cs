using System;
using SysConsole = System.Console;

namespace Fuse.Core.Console
{
    public static class FuseConsole
    {
        public static void Fatal(string text) => Error(text, true);

        public static void Error(string text, bool isFatal = false)
        {
            Print(text, "Error", ConsoleColor.Red);

            if (isFatal)
                throw new Exception(text);
        }

        public static T Error<T>(string text)
        {
            Error(text);
            return default;
        }

        public static void Warning(string text)
        {
            Print(text, "Warning", ConsoleColor.Yellow);
        }

        public static void Success(string text)
        {
            Print(text, "Success", ConsoleColor.Green);
        }

        public static void Info(string text)
        {
            Print(text, "Info", ConsoleColor.Cyan);
        }

        public static void Print(string text, string type, ConsoleColor color)
        {
            var originalColor = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = color;
            SysConsole.WriteLine($"[{type}] {text}");
            SysConsole.ForegroundColor = originalColor;
        }
    }
}
