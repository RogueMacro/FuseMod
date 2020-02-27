using Fuse.API;
using System;
using System.Collections.Generic;

namespace Fuse.Core.Commands
{
    public abstract class CommandHandler
    {
        protected static readonly List<Type> Commands = new List<Type>();

        public static CommandHandler Current;

        protected virtual void OnInit() { }

        public abstract void HandleText(string text);

        public static void RegisterCommand<T>() where T : ICommand
        {
            Commands.Add(typeof(T));
        }

        public static void RegisterCommand(Type type)
        {
            if (type.IsAssignableFrom(typeof(ICommand)))
                Commands.Add(type);
        }
    }
}
