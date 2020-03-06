using Fuse.API;
using Fuse.Core.Console;
using System;

namespace Fuse.Core.Logging
{
    public class DebugLogger : ILogger
    {
        public void Log(string text)
        {
            FuseConsole.Info(text);
        }
    }
}
