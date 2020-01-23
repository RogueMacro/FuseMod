using Fuse.Core;
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
