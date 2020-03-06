using System;

namespace Fuse.API
{
    public interface IDependencyContainer
    {
        bool IsRegistered<T>(string mappingName = null);
        bool IsRegistered(Type type, string mappingName = null);
        void RegisterInstance<T>(T instance, string mappingName = null);
        void RegisterSingleton<TBase, TImpl>(string mappingName = null) where TImpl : TBase;
        T Resolve<T>(string mappingName = null);
        bool TryResolve<T>(out T output, string mappingName = null);
    }
}