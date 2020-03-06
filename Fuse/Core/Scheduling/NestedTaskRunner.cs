using Fuse.API;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fuse.Core.Utilities
{
    public struct NestedTaskRunner : IDisposable, ITaskRunner
    {
        private List<Task> Tasks;

        public void AddTask(Task task)
        {
            if (Tasks == null)
                Tasks = new List<Task>();

            Tasks.Add(task);
        }

        public void Run(Action action)
        {
            AddTask(Task.Run(action));
        }

        public void Run(Task task)
        {
            AddTask(task);
        }

        public void Wait()
        {
            Task.WaitAll(Tasks.ToArray());
        }

        public void Dispose()
        {
            Wait();
        }
    }
}
