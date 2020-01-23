using Fuse.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Fuse.Core
{
    public static class CommandHandler
    {
        public static bool IsCaseSensitive = false;

        private static readonly List<ICommand> Commands = new List<ICommand>();

        public static void HandleCommand(string text)
        {
            Console.WriteLine("Handling command: " + text);
            Console.WriteLine("Commands: ");
            Commands.ForEach(c => Console.WriteLine("Commands: " + c.Name));

            var separated = text.Split(' ');
            var name = separated[0];
            var args = separated.Where(s => s != name).ToArray();

            foreach (var command in Commands)
            {
                Console.WriteLine("Command name: " + name);
                Console.WriteLine("Command args: " + args);
                Console.WriteLine("Command type: " + command);

                var isCommand = IsCaseSensitive
                    ? name == command.Name
                    : string.Equals(name, command.Name, StringComparison.CurrentCultureIgnoreCase);

                if (isCommand)
                {
                    command.Execute(args);
                }
            }
        }

        public static void RegisterAllCommands()
        {
            foreach (var command in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                .Where(command => command.GetInterfaces().Contains(typeof(ICommand))))
            {
                RegisterCommand(command);
            }
        }

        public static void RegisterCommand<T>() where T : ICommand
        {
            RegisterCommand(typeof(T));
        }

        public static void RegisterCommand(Type type)
        {
            Console.WriteLine($"Registering command: '{type}'", ConsoleColor.Green);
            var instance = (ICommand) Activator.CreateInstance(type);
            if (!Commands.Contains(instance))
                Commands.Add(instance);
        }

        public static void Init()
        {
            //RegisterCommand<BroadcastCommand>();
        }
    }
}
