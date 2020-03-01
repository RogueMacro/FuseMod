namespace Fuse.API
{
    public interface IDependencyContainer
    {
        void RegisterInstance<T>(T instance, string name = null);
        void RegisterSingleton<TBase, TImpl>(string name = null) where TImpl : TBase;
    }
}