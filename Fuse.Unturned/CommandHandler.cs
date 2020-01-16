using System;
using System.Collections.Generic;
using Fuse.API;

namespace Fuse.Unturned
{
    public static class CommandHandler
    {
        private static readonly List<ICommand> Commands = new List<ICommand>();

        public static void HandleCommand(string text)
        {
            foreach (var command in Commands)
            {
                Console.WriteLine("Command text: " + text);
                Console.WriteLine("Command type: " + command.ToString());
                if (text.StartsWith(command.ToString()))
                {
                    //command.Execute();
                }
            }
        }

        public static void RegisterCommand<T>() where T : ICommand
        {
            Commands.Add(typeof(T));
        }

        public static void Init()
        {
            RegisterCommand<BroadcastCommand>();
        }
    }
}
