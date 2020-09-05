using System;
using System.Collections.Generic;
using System.Text;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        private Actor.Actor[] DrawPile { get; set; }
        private Actor.Actor[] DiscardPile { get; set; }

        public void Fill(List<(Characters, int)> deckBuild)
        {

        }

        public void Shuffle()
        {

        }

        public void Reshuffle()
        {

        }
    }
}
