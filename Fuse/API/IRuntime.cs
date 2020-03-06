using System.Threading.Tasks;

namespace Fuse.API
{
    public interface IRuntime
    {
        Task InitAsync();

        public string GetPath(string path);
        void RegisterTask(Task task);
        Task RegisterTaskAsync(Task task);
        Task<T> RegisterTaskAsync<T>(Task<T> task);

        public string ConfigFile { get; }

        public string WorkingDirectory { get; }
    }
}