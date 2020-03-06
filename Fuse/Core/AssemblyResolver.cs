using Fuse.API;
using Fuse.Core.Console;
using Fuse.Core.Utilities;
using System;
using System.Linq;
using System.Reflection;

namespace Fuse.Core
{
    public class AssemblyResolver : IAssemblyResolver
    {
        private IDependencyContainer Container { get; }

        public AssemblyResolver(IDependencyContainer container)
        {
            Container = container;
        }

        public void ResolveAssemblies()
        {
            using var taskRunner = TaskRunner.NestedScopeRunner;

            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames = assembly.GetManifestResourceNames().Where(n => n.EndsWith(".dll"));

            foreach (var name in resourceNames)
            {
                taskRunner.Run(() => ResolveAssembly(name));
            }

            System.Console.WriteLine("Tasks ran");

            taskRunner.Wait();

            FuseConsole.Info("Resolved assemblies");
        }

        public void ResolveAssembly(string name)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name))
            {
                try
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);

                    Assembly.Load(assemblyData);
                }
                catch (BadImageFormatException)
                {
                    FuseConsole.Error("Could not load library '{name}'; invalid architecture");
                }
            }
        }
    }
}
