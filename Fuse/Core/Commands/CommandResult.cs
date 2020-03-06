using System;

namespace Fuse.Core.Commands
{
    public class CommandResult
    {
        public CommandResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public CommandResult(Exception exception)
        {
            IsSuccess = false;
            Exception = exception;
        }

        public static CommandResult Success => new CommandResult(true);
        public static CommandResult Fail => new CommandResult(new Exception());
        public static CommandResult FailWithMessage(string text) => new CommandResult(new Exception(text));
        public static CommandResult Except<T>() => new CommandResult((Exception) Activator.CreateInstance(typeof(T)));
        public static CommandResult Except<T>(string text) => new CommandResult((Exception) Activator.CreateInstance(typeof(T), text));

        public bool IsSuccess { get; }
        public Exception Exception { get; }
    }
}
