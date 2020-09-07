using System.Collections.Generic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        public Queue<Actor> DrawPile { get; set; }
        public Queue<Actor> DiscardPile { get; set; }
    }
}
