using System.Threading.Tasks;

namespace Fuse.Core.Utilities
{
    public static class AsyncHelper
    {
        public static void RunSync(this Task task)
        {
            task.RunSynchronously();
        }

        public static T RunSync<T>(this Task<T> task)
        {
            return task.GetAwaiter().GetResult();
        }

        public static void RunAsync(this Task task)
        {
            Task.Run(async () => await task);
        }

        public static T RunAsync<T>(this Task<T> task)
        {
            return Task.Run(async () => await task).Result;
        }
    }
}
