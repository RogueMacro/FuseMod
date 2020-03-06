using Fuse.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuse.Core.Utilities
{
    public class ScopedTaskRunner : ITaskRunner
    {
        private List<Task> Tasks { get; set; }

        public ScopedTaskRunner()
        {
            Tasks = new List<Task>();
        }

        public void Run(Action action)
        {
            Tasks.Add(Task.Run(action));
        }

        public void Run(Task task)
        {
            Tasks.Add(task);
        }

        public void Wait()
        {
            Task.WaitAll(Tasks.ToArray());
        }

        public void Dispose()
        {
            Wait();
        }

        ~ScopedTaskRunner()
        {
            Dispose();
        }
    }
}
