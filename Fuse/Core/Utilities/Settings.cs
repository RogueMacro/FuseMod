using Fuse.API;
using Fuse.Core.Console;
using Fuse.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Fuse.Core.Utilities
{
    public class Settings : ISettings
    {
        private readonly XDocument Document;

        public Settings()
        {
            Document = XDocument.Parse(Resources.DefaultConfig);

#if DEBUG
            OverrideProperties(Resources.DebugConfig);
#endif
        }

        public bool GetBool(string name)
        {
            var setting = GetSetting(name);
            var parsed = bool.TryParse(setting, out var boolSetting);

            if (parsed)
                return boolSetting;

            return FuseConsole.Error<bool>($"Could not convert '{name}' to bool");
        }

        public int GetInt(string name)
        {
            var setting = GetSetting(name);
            var parsed = int.TryParse(setting, out var intSetting);

            if (parsed)
                return intSetting;

            return FuseConsole.Error<int>($"Could not convert '{name}' to int");

        }

        public float GetFloat(string name)
        {
            var setting = GetSetting(name);
            var parsed = float.TryParse(setting, out var floatSetting);

            if (parsed)
                return floatSetting;

            return FuseConsole.Error<float>($"Could not convert '{name}' to float");
        }

        public string GetSetting(string name)
        {
            foreach (var element in Document.Root.Descendants())
            {
                if (element.Name == name)
                    return element.Value;
            }

            return FuseConsole.Error<string>($"Could not find setting: '{name}'");
        }

        public void OverrideProperties(string xml)
        {
            var document = XDocument.Parse(xml);

            foreach (var element in document.Root.Descendants())
                SetProperty(element.Name.ToString(), element.Value);
        }

        public void SetProperty(string name, string value)
        {
            if (IsProperty(name))
                Document.Root.Descendants(name).Single().SetValue(value);
            else
                Document.Root.Add(new XElement(name, value));
        }

        public bool IsProperty(string name) => Document.Root.Descendants().Any(e => e.Name == name);
    }
}
