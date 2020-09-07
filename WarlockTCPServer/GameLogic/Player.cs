using System.Collections.Generic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.GameLogic
{
    public class Player
    {
        public string ClientId { get; set; }
        public List<Actor> Party { get; set; }
        public List<Actor> Hand { get; set; }
        public short Mana { get; set; }
        public short Score { get; set; }

        // TODO: Add constructor(s)
    }
}
