using System;

namespace Fuse.Core.Utilities
{
    public abstract class ContainerResolver<T>
    {
        public void ResolveContainer(Container<T> container)
        {
            foreach (var item in container.container)
            {
                Resolve(item);
            }
        }

        public abstract void Resolve(T item);
    }
}
