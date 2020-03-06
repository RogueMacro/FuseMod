using System;

namespace Fuse.Core.Utilities
{
    public class SettingNotFoundException : Exception
    {
        public SettingNotFoundException() : base()
        {
        }

        public SettingNotFoundException(object setting) : base($"Could not find setting: '{setting}'")
        {
        }
    }
}
