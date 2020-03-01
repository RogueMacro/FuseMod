using Fuse.API;
using SDG.Unturned;

namespace Fuse.Unturned
{
    public class UnturnedPlayer : IPlayer
    {
        public SteamPlayer Player { get; }

        public UnturnedPlayer(SteamPlayer player)
        {
            Player = player;
        }
    }
}