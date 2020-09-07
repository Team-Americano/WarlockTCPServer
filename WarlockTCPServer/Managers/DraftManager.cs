using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Managers
{
    public static class DraftManager
    {
        public static List<Actor> DraftParty(Player player, List<Actor> party)
        {
            // update mana
            // update hand            

            player.Party = party;

            return player.Party;
        }
    }
}
