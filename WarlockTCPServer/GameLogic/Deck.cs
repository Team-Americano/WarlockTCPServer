using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.Builders;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        private Actor.Actor[] DrawPile { get; set; }
        private Actor.Actor[] DiscardPile { get; set; }

        //private Actor.Actor[] ExilePile { get; set; } // stretch goal functionality

        #region Fill functions
        public void Fill(string deckName)
        {
            var deckBuilder = new DeckBuilder();
            DrawPile = deckBuilder.Build(deckName);
        }

        public void Fill(List<(Characters, int)> deckScaffold)
        {
            var deckBuilder = new DeckBuilder();
            DrawPile = deckBuilder.Build(deckScaffold);
        }

        public void Fill(Actor.Actor[] customDeck)
        {
            DrawPile = customDeck;
        }
        #endregion

        public void Shuffle()
        {

        }

        public void Reshuffle()
        {

        }
    }
}
