using Fuse.API;
using Fuse.Core.Commands;
using System;
using System.Linq;

namespace Fuse.Unturned
{
    public class UnturnedCommandHandler : CommandHandler
    {
        public override void HandleText(string text)
        {
            var separated = text.Split(' ');
            var name = separated[0];
            var args = separated.Where(s => s != name).ToArray();

            foreach (var command in Commands)
            {
                Console.WriteLine("ICommand text: " + text);
                Console.WriteLine("ICommand name: " + name);
                Console.WriteLine("ICommand args: " + args);
                Console.WriteLine("ICommand type: " + command);

                if (!text.StartsWith(command.ToString()))
                    continue;

                Console.WriteLine("Found command: " + name);
                ((ICommand)command).Execute(args);
            }
        }
    }
}