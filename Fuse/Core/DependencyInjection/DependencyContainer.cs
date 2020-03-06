using Fuse.API;
using Fuse.Core.Console;
using System;
using Unity;

namespace Fuse.Core.DependencyInjection
{
    public class DependencyContainer : IDependencyContainer
    {
        private IUnityContainer Container { get; }

        public DependencyContainer()
        {
            Container = new UnityContainer();
            Container.RegisterInstance<IDependencyContainer>(this);
        }

        private ILogger Logger
        {
            get
            {
                TryResolve<ILogger>(out var logger);
                return logger;
            }
        }

        public void RegisterInstance<T>(T instance, string mappingName = null)
        {
            Log<T>($"Registering instance <{instance.GetType().Name}> for <{typeof(T).Name}>", mappingName);

            if (mappingName != null)
                Container.RegisterInstance(mappingName, instance);
            else
                Container.RegisterInstance(instance);
        }

        public void RegisterSingleton<TBase, TImpl>(string mappingName = null) where TImpl : TBase
        {
            Log<TBase>($"Registering singleton <{typeof(TImpl).Name}> for <{typeof(TBase).Name}>", mappingName);

            if (mappingName != null)
                Container.RegisterSingleton<TBase, TImpl>(mappingName);
            else
                Container.RegisterSingleton<TBase, TImpl>();
        }

        public T Resolve<T>(string mappingName = null)
        {
            Log<T>($"Resolving <{typeof(T).Name}>", mappingName);

            if (IsRegistered<T>(mappingName))
                return Container.Resolve<T>();

            FuseConsole.Error($"Could not resolve <{typeof(T)}>; mappingName: '{mappingName}'");
            throw new ServiceNotRegisteredException();
        }

        public bool TryResolve<T>(out T output, string mappingName = null)
        {
            Log<T>($"Trying to resolve <{typeof(T).Name}>", mappingName);

            if (IsRegistered<T>(mappingName))
            {
                output = Resolve<T>(mappingName);
                return true;
            }

            output = default;
            return false;
        }

        public bool IsRegistered<T>(string mappingName = null) => Container.IsRegistered<T>(mappingName);
        public bool IsRegistered(Type type, string mappingName = null) => Container.IsRegistered(type, mappingName);

        private bool IsLogger<T>() => typeof(ILogger).IsAssignableFrom(typeof(T));

        private void Log<TInterface>(string text, string mappingName = null)
        {
            if (!IsLogger<TInterface>())
            {
                if (mappingName == null)
                    Logger?.Log(text);
                else
                    Logger?.Log(text + ", mapping name: '{mappingName}'");
            }
        }
    }
}
