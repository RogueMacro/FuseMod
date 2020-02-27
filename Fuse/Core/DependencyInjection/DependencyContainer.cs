using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Fuse.Core.DependencyInjection
{
    public class DependencyContainer
    {
        public DependencyContainer()
        {
            Collection = new ServiceCollection();
        }

        public void AddSingleton<T>(T instance) where T : class
        {
            Collection.AddSingleton(instance);
        }

        public object Resolve<T>()
        {
            foreach (var dependency in Collection)
            {
                if (dependency.ServiceType == typeof(T))
                {
                    System.Console.WriteLine("Resolved: " + dependency.ImplementationInstance + " for " + dependency.ServiceType);
                    return dependency.ImplementationInstance;
                }
                else
                {
                    System.Console.WriteLine($"{typeof(T)} is not {dependency.ServiceType}");
                }
            }

            return null;
        }

        public ServiceCollection Collection { get; }
    }



















    //public class DependencyContainer
    //{
    //    private readonly List<IService> instances;
    //    private readonly List<Type> types;

    //    public DependencyContainer(IEnumerable<IService> instances = null, IEnumerable<Type> types = null)
    //    {
    //        this.instances = instances.ToList() ?? new List<IService>();
    //        this.types = types.ToList() ?? new List<Type>();
    //    }

    //    public void Register<TInterface, TClass>() where TClass : class, TInterface
    //    {
    //        types.Add(typeof(TClass));
    //    }

    //    public void Register<TInterface>(TInterface value) where TInterface : IService
    //    {
    //        instances.Add(value);
    //    }

    //    public object ResolveInstance<T>()
    //    {
    //        foreach (var instance in instances)
    //        {
    //            if (instance is T)
    //                return (T) instance;
    //        }

    //        return null;
    //    }

    //    public object ResolveType<T>()
    //    {
    //        foreach (var type in types)
    //        {
    //            if (type is T)
    //                return type;
    //        }

    //        return null;
    //    }

    //    public object Resolve<T>()
    //    {
    //        return ResolveInstance<T>() ?? ResolveType<T>();
    //    }

    //    public IEnumerable<T> ResolveAll<T>()
    //    {

    //    }
    //}

    //public interface IService
    //{

    //}

    ////public interface IProxyableService
    ////{

    ////}

    //public interface IServiceProxy<T> : IService
    //{
    //    IEnumerable<T> ProxyServices { get; }
    //}

    //public abstract class ServiceProxy<T> : DynamicObject, IServiceProxy<T> where T : class, IService
    //{
    //    public ServiceProxy()
    //    {
    //        Container = new DependencyContainer();
    //    }

    //    public ServiceProxy(IEnumerable<T> instances = null, IEnumerable<Type> types = null)
    //    {
    //        Container = new DependencyContainer(instances, types);
    //    }

    //    public IEnumerable<T> ProxyServices
    //    {
    //        get
    //        {
    //            return Container.ResolveAll<T>();
    //        }
    //    }

    //    public DependencyContainer Container { get; private set; }
    //}
}
