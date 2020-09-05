using System.Collections.Generic;
using WarlockTCPServer.Builders;
using static WarlockTCPServer.Constants.DeckConstants;


namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        private Actor[] DrawPile { get; set; }
        private Actor[] DiscardPile { get; set; }

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

        public void Fill(Actor[] customDeck)
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
