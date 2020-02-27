using System;
using SysConsole = System.Console;

namespace Fuse.Core.Console
{
    public static class FuseConsole
    {
        public static void Error(string text, bool isFatal = true)
        {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = ConsoleColor.Red;
            SysConsole.WriteLine("[Error] " + text);
            SysConsole.ForegroundColor = color;

            if (isFatal)
                throw new Exception(text);
        }

        public static void Warning(string text)
        {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = ConsoleColor.Yellow;
            SysConsole.WriteLine("[Warning] " + text);
            SysConsole.ForegroundColor = color;
        }

        public static void Success(string text)
        {
            var color = SysConsole.ForegroundColor;
            SysConsole.ForegroundColor = ConsoleColor.Green;
            SysConsole.WriteLine("[Success] " + text);
            SysConsole.ForegroundColor = color;
        }
    }
}
