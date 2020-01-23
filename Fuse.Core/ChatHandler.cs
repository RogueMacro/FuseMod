using System.Collections.Generic;

namespace Fuse.Core
{
    public abstract class ChatHandler
    {
        public static ChatHandler Current;

        //private List<SayInfo> _sayWhenReady = new List<SayInfo>();

        public delegate void OnChatEventHandler(IPlayer player, string text);
        public abstract event OnChatEventHandler OnChat;

        public abstract void Say(string text, params KeyValuePair<string, object>[] args);
    }
}
