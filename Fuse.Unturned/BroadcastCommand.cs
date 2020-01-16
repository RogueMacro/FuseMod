using System;
using Fuse.API;
using UnityEngine;

namespace Fuse.Unturned
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
                ChatHandler.Say(args[0], Color.green);
            }
        }
    }
}
