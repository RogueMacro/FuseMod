using System;
using SDG.Unturned;
using UnityEngine;

namespace Fuse.Unturned
{
    public static class ChatHandler
    {
        public delegate void OnChatEventHandler(SteamPlayer player, string text);

        public static event OnChatEventHandler OnChat;
        public static event OnChatEventHandler OnCommand;

        public static void Init()
        {
            ChatManager.onChatted += OnChatted;
        }

        private static void OnChatted(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool rich, string text, ref bool visible)
        {
            OnChat?.Invoke(player,  text);

            if (text.StartsWith("/"))
            {
                OnCommand?.Invoke(player, text);

                CommandHandler.HandleCommand(text);
            }
        }

        public static void Say(string text, Color color, bool isRich = false)
        {
            ChatManager.say(text, color, isRich);
        }
    }
}
