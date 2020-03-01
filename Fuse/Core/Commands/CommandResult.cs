using Fuse.Core.Exceptions;
using System;

namespace Fuse.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(bool successful)
        {
            Successful = successful;
        }

        public CommandResult(bool successful, FuseException exception)
        {
            Successful = successful;
            Exception = exception;
        }

        public static CommandResult Success => new CommandResult(true);
        public static CommandResult Fail => new CommandResult(false, new FuseException());
        public static CommandResult Except<ExceptionType>() => new CommandResult(false, (FuseException) Activator.CreateInstance(typeof(ExceptionType)));

        public bool Successful { get; }
        public FuseException Exception { get; }
    }
}
