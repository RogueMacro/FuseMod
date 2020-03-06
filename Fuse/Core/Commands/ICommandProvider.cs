using Fuse.API;
using System.Collections.Generic;

namespace Fuse.Core.Commands
{
    public interface ICommandProvider
    {
        List<ICommand> Commands { get; }

        ICommand GetCommand(string name);
        void RegisterCommand<T>() where T : ICommand;
    }
}