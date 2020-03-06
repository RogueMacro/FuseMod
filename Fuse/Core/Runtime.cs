using Fuse.API;
using Fuse.Core.Commands;
using Fuse.Core.Console;
using Fuse.Core.DependencyInjection;
using Fuse.Core.Logging;
using Fuse.Core.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Fuse.Core
{
    public class Runtime : IRuntime
    {
        public IDependencyContainer Container { get; private set; }
        public List<Task> Tasks { get; private set; }

        public void Init()
        {
            InitAsync().Wait();
        }

        public async Task InitAsync()
        {
            Container = new DependencyContainer();
            Container.RegisterInstance<IRuntime>(this);

            new AssemblyResolver(Container).ResolveAssemblies();

            Container.RegisterSingleton<ISettings, Settings>();
            var settings = Container.Resolve<ISettings>();

            if (settings.GetBool("DebugMode"))
                Container.RegisterSingleton<ILogger, DebugLogger>();
            else
                Container.RegisterSingleton<ILogger, FileLogger>();

            Container.RegisterSingleton<ICommandHandler, DefaultCommandHandler>("default_command_handler");
        }

        public void RegisterTask(Task task)
        {
            Tasks.Add(task);
        }

        public async Task RegisterTaskAsync(Task task)
        {
            Tasks.Add(task);
            await task;
        }

        public async Task<T> RegisterTaskAsync<T>(Task<T> task)
        {
            Tasks.Add(task);
            return await task;
        }

        public string GetPath(string path) => Path.Combine(WorkingDirectory, path);
        public string ConfigFile => File.ReadAllText(GetPath("config.xml"));

        public string WorkingDirectory { get; }
    }
}
