using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        private Actor.Actor[] DrawPile { get; set; }
        private Actor.Actor[] DiscardPile { get; set; }

        public Deck(Actor.Actor[] cards)
        {
            DrawPile = cards;
        }
    }
}
