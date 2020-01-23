using System;
using System.Collections.Generic;

namespace Fuse.Core
{
    public class SayInfo
    {
        public KeyValuePair<string, object>[] Args { get; }
        public string Text { get; }

        public SayInfo(string text, KeyValuePair<string, object>[] args)
        {
            Args = args;
            Text = text;
        }
    }
}
