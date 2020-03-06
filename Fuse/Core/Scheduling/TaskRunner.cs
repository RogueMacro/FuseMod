using Fuse.API;

namespace Fuse.Core.Utilities
{
    public static class TaskRunner
    {
        public static ITaskRunner ScopedRunner => new ScopedTaskRunner();
        public static ITaskRunner NestedScopeRunner => new NestedTaskRunner();
    }
}
