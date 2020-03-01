using Fuse.API;
using Fuse.Core.Utilities;
using System.Threading.Tasks;

namespace Fuse.Core.DependencyInjection
{
    public class Runtime : IRuntime
    {
        public void Init()
        {
            AsyncHelper.RunSync(InitAsync());
        }

        public async Task InitAsync()
        {

        }
    }
}
