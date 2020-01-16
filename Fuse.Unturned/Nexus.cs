using SDG.Framework.Modules;
using Fuse.Core;

namespace Fuse.Unturned
{
    // ReSharper disable once UnusedMember.Global
    public class Nexus : IModuleNexus
    {
        public void initialize()
        {
            FuseLoader.Plug();
            CommandHandler.Init();
            ChatHandler.Init();
        }

        public void shutdown()
        {
            
        }
    }
}
