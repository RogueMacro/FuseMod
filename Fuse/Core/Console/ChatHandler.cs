using Fuse.API;

namespace Fuse.Core.Console
{
    public abstract class ChatHandler
    {
        public static ChatHandler Current;

        protected virtual void OnInit()
        {
        }

        public delegate void OnChatEventHandler(IPlayer player, string text);

        public abstract event OnChatEventHandler OnChat;

        public abstract void Say(string text, params (string, object)[] args);
    }
}