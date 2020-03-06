using Fuse.API;
using System;
using System.Collections.Generic;

namespace Fuse.Core.Commands
{
    public class CommandProvider : ICommandProvider
    {
        public List<ICommand> Commands { get; private set; }

        private ILogger _logger { get; }

        public CommandProvider(ILogger logger)
        {
            _logger = logger;
        }

        public ICommand GetCommand(string name)
        {
            foreach (var command in Commands)
            {
                if (command.Name == name)
                    return command;
            }
            
            return null;
        }

        public void RegisterCommand<T>() where T : ICommand
        {
            

            var instance = (ICommand) Activator.CreateInstance(typeof(T));
            Commands.Add(instance);
        }
    }
}
