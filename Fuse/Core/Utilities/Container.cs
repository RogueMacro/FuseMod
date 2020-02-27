using System;
using System.Collections.Generic;

namespace Fuse.Core.Utilities
{
    public abstract class Container<T>
    {
        public List<T> container { get; }

        public void RegisterInstance(T item)
        {
            container.Add(item);
        }

        public void ResolveAssemblies<TResolver>()
        {
            var resolver = (ContainerResolver<T>) Activator.CreateInstance(typeof(TResolver));
            resolver.ResolveContainer(this);
        }
    }
}
