using System.IO;
using System.Reflection;
using Fuse.Core;
using SDG.Framework.Modules;
using SDG.Unturned;

namespace Fuse.Unturned
{
    public class FuseUnturnedModule : IModuleNexus
    {
        public void initialize()
        {
            UnturnedChatHandler.SetAsCurrent();
            FuseInitializer.Init();

            var serverId = Provider.serverID;
            var dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileManager = new FileManager(dllPath);
            fileManager.Cd("../../Servers".ExtendPath(serverId));

            if (!fileManager.DirectoryExists("Fuse"))
                FuseInitializer.InitFiles(fileManager);
        }

        public void shutdown()
        {
            
        }
    }
}
