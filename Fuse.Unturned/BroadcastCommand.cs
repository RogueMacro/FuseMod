using Fuse.API;
using Fuse.Core.Commands;
using Fuse.Core.Console;
using Fuse.Core.Exceptions;
using UnityEngine;

namespace Fuse.Unturned
{
    public class BroadcastCommand : ICommand
    {
        public string Name => "broadcast";
        public string[] Aliases => new[] { "bc" };
        public string Syntax => "<message>";
        public string Description => "Outputs the message to the chat in the format: '[Server] <message>'";

        public bool Enabled => true;

        public CommandResult Execute(string[] args)
        {
            if (args.Length == 1)
            {
                ChatHandler.Current.Say(args[0], ("color", Color.green));

                return CommandResult.Success;
            }

            return CommandResult.Except<InvalidCommandArgumentException>();
        }
    }
}
