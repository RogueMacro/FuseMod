using System.Collections.Generic;
using Fuse.API;

namespace Fuse.Core
{
    public class BroadcastCommand : ICommand
    {
        public string Name => "say";
        public string[] Aliases => null;
        public string Syntax => "say <message>";
        public string Description => "Outputs the message to the chat in the format: '[Server] <message>'";

        public void Execute(string[] args)
        {
            if (args.Length == 1)
            {
                ChatHandler.Current.Say(args[0], new KeyValuePair<string, object>("isServerMessage", true));
            }
        }
    }
}
