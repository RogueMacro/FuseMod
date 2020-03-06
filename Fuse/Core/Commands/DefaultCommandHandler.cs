using Fuse.API;
using System;
using System.Collections.Generic;

namespace Fuse.Core.Commands
{
    public class DefaultCommandHandler : ICommandHandler
    {
        private readonly ICommandProvider _provider;

        public DefaultCommandHandler(ICommandProvider provider)
        {
            _provider = provider;
        }

        public void HandleCommand(string text)
        {

        }
    }
}
