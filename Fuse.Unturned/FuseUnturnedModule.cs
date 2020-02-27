using Fuse.Core.Initialization;
using Fuse.Core.Utilities;
using SDG.Framework.Modules;
using SDG.Unturned;
using System.IO;
using System.Reflection;

namespace Fuse.Unturned
{
    public class FuseUnturnedModule : IModuleNexus
    {
        public void initialize()
        {
            var dllPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var fileManager = new FileManager(dllPath);
            fileManager.Cd("../../Servers".ExtendPath(Provider.serverID));

            FuseInitializer.Initialize(fileManager);
        }

        public void shutdown()
        {
        }
    }
}