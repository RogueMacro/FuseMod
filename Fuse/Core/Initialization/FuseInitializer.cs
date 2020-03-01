using Fuse.API;
using Fuse.Core.Console;
using Fuse.Core.Commands;
using Fuse.Core.DependencyInjection;
using Fuse.Core.Utilities;
using Fuse.Properties;
using SysConsole = System.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fuse.Core.Initialization
{
    public static class FuseInitializer
    {
        private static readonly IEnumerable<Type> fuseTypes = 
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from type in assembly.GetTypes()
            select type;

        public static void Initialize(string path)
        {
            var fileManager = new FileManager(path);
            InitializeAsync(fileManager).RunAsync();
        }

        public static async Task InitializeAsync(string path)
        {
            var fileManager = new FileManager(path);
            await InitializeAsync(fileManager);
        }

        public static void Initialize(FileManager fileManager)
        {
            InitializeAsync(fileManager).RunAsync();
        }

        public static async Task InitializeAsync(FileManager fileManager)
        {
            DisplayInitMessage();

            await LoadRuntimeAsync();

            InitFiles(fileManager);

            InitChatHandler();

            InitCommandHandler();
            LoadFuseCommands();

            LoadPlugins();

            FuseConsole.Success("Initialized FuseMod");
        }

        public static async Task LoadRuntimeAsync()
        {
            var container = ContainerConfig.Configure();
            var runtime = new Runtime();
            await runtime.InitAsync();
        }

        public static void InitFiles(FileManager fileManager, bool force=false)
        {
            if (fileManager.DirectoryExists("Fuse") && !force)
                return;

            fileManager.MoveToNew("Fuse");

            if (!fileManager.FileExists("config.xml") || force)
                fileManager.WriteToFile("config.xml", Resources.DefaultConfig);
        }

        private static void InitCommandHandler()
        {
            var commandHandlers = GetDerivedTypes<CommandHandler>();

            commandHandlers.Remove(typeof(CommandHandler));

            if (commandHandlers.Count == 0)
            {
                FuseConsole.Error("Could not find any CommandHandlers");
            }
            else if (commandHandlers.Count > 1)
            {
                FuseConsole.Error("Too many CommandHandlers detected");
            }
            else
            {
                Type type = commandHandlers.Single();
                CommandHandler.Current = (CommandHandler) Activator.CreateInstance(type);
            }
        }

        private static void InitChatHandler()
        {
            var chatHandlers = GetDerivedTypes<ChatHandler>();

            chatHandlers.Remove(typeof(ChatHandler));

            if (chatHandlers.Count() == 0)
            {
                FuseConsole.Error("Could not find any ChatHandlers");
            }
            else if (chatHandlers.Count() > 1)
            {
                FuseConsole.Error("Too many ChatHandlers detected");
            }
            else
            {
                Type type = chatHandlers.Single();
                ChatHandler.Current = (ChatHandler) Activator.CreateInstance(type);
            }
        }

        private static void DisplayInitMessage()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = versionInfo.ProductVersion;

            SysConsole.ForegroundColor = ConsoleColor.Cyan;
            SysConsole.WriteLine($@"FuseMod v{version}");
            SysConsole.ResetColor();
        }

        private static void LoadFuseCommands()
        {
            var commands = GetDerivedTypes<ICommand>();

            foreach (var command in commands)
                CommandHandler.RegisterCommand(command);
        }

        private static void LoadPlugins()
        {
            
        }

        private static List<Type> GetDerivedTypes<T>()
        {
            var types = new List<Type>();

            foreach (var type in fuseTypes)
            {
                if (typeof(T).IsAssignableFrom(type))
                    types.Add(type);
            }

            return types;
        }
    }
}
