using Fuse.API;
using Unity;

namespace Fuse.Core.DependencyInjection
{
    public class DependencyContainer : IDependencyContainer
    {
        public UnityContainer Container { get; }

        public DependencyContainer()
        {
            Container = new UnityContainer();
            Container.RegisterInstance<IDependencyContainer>(this);
        }

        public void RegisterInstance<T>(T instance, string name = null)
        {
            // TODO: Add logging

            if (name != null)
                Container.RegisterInstance(name, instance);
            else
                Container.RegisterInstance(instance);
        }

        public void RegisterSingleton<TBase, TImpl>(string name = null) where TImpl : TBase
        {
            // TODO: Add logging

            if (name != null)
                Container.RegisterSingleton<TBase, TImpl>(name);
            else
                Container.RegisterSingleton<TBase, TImpl>();

        }

        public T Resolve<T>()
        {
            return Container.Resolve<T>();
        }















        //    public DependencyContainer(IContainer container)
        //    {
        //        _container = container;
        //    }

        //    public event EventHandler<LifetimeScopeBeginningEventArgs> ChildLifetimeScopeBeginning;
        //    public event EventHandler<LifetimeScopeEndingEventArgs> CurrentScopeEnding;
        //    public event EventHandler<ResolveOperationBeginningEventArgs> ResolveOperationBeginning;

        //    public void AddSingleton<TInterface, TClass>() where TClass : class, TInterface
        //    {
        //        var updater = new ContainerBuilder();
        //        updater.RegisterType<TClass>().As<TInterface>();
        //        _container = updater.Rebuild(_container);
        //    }

        //    public void AddSingleton<T>(T instance) where T : class
        //    {
        //        //_container.AddSingleton(instance);
        //    }

        //    public object Resolve<T>()
        //    {
        //        //foreach (var dependency in _container)
        //        //{
        //        //    if (dependency.ServiceType == typeof(T))
        //        //    {
        //        //        System.Console.WriteLine("Resolved: " + dependency.ImplementationInstance + " for " + dependency.ServiceType);
        //        //        return dependency.ImplementationInstance;
        //        //    }
        //        //    else
        //        //    {
        //        //        System.Console.WriteLine($"{typeof(T)} is not {dependency.ServiceType}");
        //        //    }
        //        //}

        //        return null;
        //    }

        //    public ILifetimeScope BeginLifetimeScope()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ILifetimeScope BeginLifetimeScope(object tag)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ILifetimeScope BeginLifetimeScope(Action<ContainerBuilder> configurationAction)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ILifetimeScope BeginLifetimeScope(object tag, Action<ContainerBuilder> configurationAction)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public object ResolveComponent(ResolveRequest request)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public void Dispose()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public System.Threading.Tasks.ValueTask DisposeAsync()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    private IContainer _container { get; set; }

        //    public IDisposer Disposer => throw new NotImplementedException();

        //    public object Tag => throw new NotImplementedException();

        //    public IComponentRegistry ComponentRegistry => throw new NotImplementedException();
        //}
    }
}
