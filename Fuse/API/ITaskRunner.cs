using System;
using System.Threading.Tasks;

namespace Fuse.API
{
    public interface ITaskRunner : IDisposable
    {
        public void Run(Action action);
        public void Run(Task task);
        public void Wait();
    }
}
