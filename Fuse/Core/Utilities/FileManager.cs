using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fuse.Core.Utilities
{
    public class FileManager
    {
        public List<string> Directories { get; private set; }
        public string Path => string.Join("/", Directories);

        public bool IsPathValid() => Directory.Exists(Path);
        public bool DirectoryExists(string name) => Directory.Exists(Path.ExtendPath(name));
        public void CreateDirectory(string name) => Directory.CreateDirectory(ExtendPath(name));
        public void CreateFile(string name) => File.Create(ExtendPath(name));
        public void WriteToFile(string filename, string text) => File.WriteAllText(Path.ExtendPath(filename), text);

        public FileManager(string path)
        {
            Directories = path
                .Replace('\\', '/')
                .Split('/')
                .ToList();
        }

        public void Cd(string path)
        {
            path = path.Replace("\\", "/");

            var last = "";

            while (!string.IsNullOrEmpty(path))
            {
                if (path.StartsWith("./"))
                    path = path.Remove(0, 2);

                if (path.StartsWith("/"))
                    path = path.Remove(0, 1);

                if (path.StartsWith(".."))
                {
                    path = path.Remove(0, 2);
                    Directories.RemoveAt(Directories.Count - 1);
                }
                else if (path.Contains(":"))
                {
                    Directories = path.Split('/').ToList();
                    break;
                }
                else
                {
                    Directories.AddRange(path.Split('/'));
                    break;
                }

                if (path == last)
                    break;

                last = path;
            }
        }

        public void MoveToNew(string name)
        {
            CreateDirectory(name);
            Cd(name);
        }

        public string ExtendPath(string extended)
        {
            if (Path.EndsWith("/"))
                return Path.Remove(Path.Length - 1, 1).ExtendPath(extended);

            if (extended.StartsWith("/"))
                return Path.ExtendPath(extended.Remove(0, 1));

            return Path + "/" + extended;
        }
    }

    public static class PathHelper
    {
        public static string ExtendPath(this string path, params string[] extended)
            => path + "/" + string.Join("/", extended);
    }
}