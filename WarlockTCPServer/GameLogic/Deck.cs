using System;
using System.Collections.Generic;
using WarlockTCPServer.Builders;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Constants.DeckConstants;


namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        public Queue<Actor> DrawPile { get; set; }
        public Queue<Actor> DiscardPile { get; set; }
    }
}
