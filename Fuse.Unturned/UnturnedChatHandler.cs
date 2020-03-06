using Fuse.Core.Commands;
using Fuse.Core.Console;
using SDG.Unturned;
using System;
using UnityEngine;

namespace Fuse.Unturned
{
    public class UnturnedChatHandler : ChatHandler
    {
        public override event OnChatEventHandler OnChat;

        protected override void OnInit()
        {
            ChatManager.onChatted += OnChatted;
        }

        private void OnChatted(SteamPlayer player, EChatMode mode, ref Color chatted, ref bool rich, string text, ref bool visible)
        {
            Console.WriteLine("Received chat: " + text);
            Console.WriteLine("From: " + player.player.name);

            var unturnedPlayer = new UnturnedPlayer(player);
            OnChat?.Invoke(unturnedPlayer, text);

            if (!text.StartsWith("/"))
                return;

            //DefaultCommandHandler.Current.HandleText(text);
        }

        public override void Say(string text, params (string, object)[] tArgs)
        {
            var args = tArgs.ToKeyValuePairArray();

            var isRich = (bool)args.GetOrDefault("isRich", false);

            var color = args.ContainsKey("color")
                ? (Color)args.GetOrDefault("color", Color.white)
                : (bool)args.GetOrDefault("isServerMessage", false)
                    ? Color.green
                    : Color.white;

            ChatManager.say(text, color, isRich);
        }
    }
}