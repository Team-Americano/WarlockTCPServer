using System;
using System.Collections.Generic;
using WarlockTCPServer.Builders;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Constants.DeckConstants;


namespace WarlockTCPServer.GameLogic
{
    public class Deck
    {
        public Actor[] CardSet { get; set; }
        public Queue<Actor> DrawPile { get; set; }
        public Queue<Actor> DiscardPile { get; set; }

        #region Fill() overloads
        public void Fill(string deckName)
        {
            var deckBuilder = new DeckBuilder();
            CardSet = deckBuilder.Build(deckName);
        }

        public void Fill(List<(Characters, int)> deckScaffold)
        {
            var deckBuilder = new DeckBuilder();
            CardSet = deckBuilder.Build(deckScaffold);
        }

        public void Fill(Actor[] customDeck)
        {
            CardSet = customDeck;
        }
        #endregion

        public void Queue()
        {
            DrawPile = new Queue<Actor>(CardSet);
        }

        public void Shuffle()
        {
            // Fisher-Yates algorithm
            var random = new Random();
            var cards = DrawPile.ToArray();
            int n = cards.Length;
            while (n > 1)
            {
                int k = random.Next(n--);
                var temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
            DrawPile = new Queue<Actor>(cards);
        }

        public void Reshuffle()
        {
            while (DiscardPile.Count > 0)
            {
                DrawPile.Enqueue(DiscardPile.Dequeue());
            }
            Shuffle();
        }

        public Actor[] Draw(int cardAmount)
        {
            var drawnCards = new Actor[cardAmount];
            for (int i = 0; i < cardAmount; i++)
            {
                if (DrawPile.Count <= 0)
                    Reshuffle();
                drawnCards[i] = DrawPile.Dequeue();
            }
            return drawnCards;
        }
    }
}
