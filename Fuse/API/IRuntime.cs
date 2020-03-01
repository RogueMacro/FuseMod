using System.Threading.Tasks;

namespace Fuse.API
{
    public interface IRuntime
    {
        void Init();
        Task InitAsync();
    }
}