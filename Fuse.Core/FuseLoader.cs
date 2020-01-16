using System;
using System.Diagnostics;
using System.Reflection;

namespace Fuse.Core
{
    public static class FuseLoader
    {
        public static void Plug()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = versionInfo.ProductVersion;
            Console.WriteLine($"FuseMod {version}");
        }
    }
}
