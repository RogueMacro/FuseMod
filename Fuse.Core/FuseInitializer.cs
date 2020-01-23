using System;
using System.Diagnostics;
using System.Reflection;

namespace Fuse.Core
{
    public static class FuseInitializer
    {
        public static void Init()
        {
            DisplayInitMessage();

            CommandHandler.Init();
            CommandHandler.RegisterAllCommands();

            //ChatHandler.Current.Say("FuseMod is loaded and ready");
        }

        private static void DisplayInitMessage()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = versionInfo.ProductVersion;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"FuseMod {version}");
            Console.ResetColor();
        }

        public static void InitFiles(string path)
        {
            var fm = new FileManager(path);
            InitFiles(fm);
        }

        public static void InitFiles(FileManager fileManager)
        {
            fileManager.MoveToNew("Fuse");


        }
    }
}
