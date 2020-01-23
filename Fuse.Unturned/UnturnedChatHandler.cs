using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using SDG.Unturned;
using UnityEngine;
using Fuse.Core;
using SDG.Framework.Translations;

namespace Fuse.Unturned
{
    public class UnturnedChatHandler : ChatHandler
    {
        public override event OnChatEventHandler OnChat;

        public static void SetAsCurrent()
        {
            var chatHandler = new UnturnedChatHandler();
            ChatManager.onChatted += chatHandler.OnChatted;
            Current = chatHandler;
        }

        private void OnChatted(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool rich, string text, ref bool visible)
        {
            Console.WriteLine("Received chat: " + text);
            Console.WriteLine("From: " + player.player.name);

            var unturnedPlayer = new UnturnedPlayer(player);
            OnChat?.Invoke(unturnedPlayer, text);

            if (!text.StartsWith("/"))
                return;

            CommandHandler.HandleCommand(text);
        }

        public override void Say(string text, params KeyValuePair<string, object>[] args)
        {
            var isRich = (bool) args.GetOrDefault("isRich", false);
            
            var color = args.ContainsKey("color")
                ? (Color) args.GetOrDefault("color", Color.white)
                : (bool) args.GetOrDefault("isServerMessage", false)
                    ? Color.green
                    : Color.white;

            ChatManager.say(text, color, isRich);
        }
    }
}
