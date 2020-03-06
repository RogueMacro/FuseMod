using System;
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

        public static async Task RunAsync(this Task task)
        {
            await Task.Run(async () => await task);
        }

        public static async Task<T> RunAsync<T>(this Task<T> task)
        {
            return await Task.Run(async () => await task);
        }

        public static async Task<T> RunAsync<T>(this Func<T> func, params object[] args)
        {
            return (T) await Task.Run(() => func.DynamicInvoke(args));
        }

        public static async Task<T> RunAsync<T>(this Func<T> func)
        {
            return await Task.Run(func.Invoke);
        }

        public static async Task RunAsync(this Action action)
        {
            await Task.Run(action);
        }
    }
}
