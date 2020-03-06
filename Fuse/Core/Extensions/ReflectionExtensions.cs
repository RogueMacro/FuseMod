using Fuse.API;
using Fuse.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Fuse.Core.Extensions
{
    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> GetDerivedTypes<T>(this Assembly assembly)
        {
            return assembly.GetTypes().Where(type => typeof(T).IsAssignableFrom(type));
        }

        public static void RegisterCommands(this Assembly assembly)
        {
            foreach (var type in assembly.GetDerivedTypes<ICommand>())
            {
                //DefaultCommandHandler.RegisterCommand(type);
            }
        }
    }
}
