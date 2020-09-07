using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Managers
{
    public static class PartyRepositionManager
    {
        public static List<Actor> PartyReposition(Player player, List<Actor> party) // or user
        {
            player.Party = party;

            return player.Party;
        }
    }
}
