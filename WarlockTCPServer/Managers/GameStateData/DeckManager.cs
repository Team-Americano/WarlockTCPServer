using System;
using System.Collections.Generic;
using WarlockTCPServer.Builders;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Managers.GameStateData
{
    public static class DeckManager
    {
        public static void Fill(Deck deck, string deckName)
        {
            var deckBuilder = new DeckBuilder();
            var cards = deckBuilder.Build(deckName);
            deck.DrawPile = new Queue<Actor>(cards);
        }

        public static void Fill(Deck deck, List<(Characters, int)> deckScaffold)
        {
            var deckBuilder = new DeckBuilder();
            var cards = deckBuilder.Build(deckScaffold);
            deck.DrawPile = new Queue<Actor>(cards);
        }

        public static void Fill(Deck deck, IEnumerable<Actor> customDeck)
        {
            deck.DrawPile = new Queue<Actor>(customDeck);
        }

        public static void Shuffle(Deck deck)
        {
            // Fisher-Yates algorithm
            var random = new Random();
            var cards = deck.DrawPile.ToArray();
            int n = cards.Length;
            while (n > 1)
            {
                int k = random.Next(n--);
                var temp = cards[n];
                cards[n] = cards[k];
                cards[k] = temp;
            }
            deck.DrawPile = new Queue<Actor>(cards);
        }

        public static void Reshuffle(Deck deck)
        {
            while (deck.DiscardPile.Count > 0)
            {
                deck.DrawPile.Enqueue(deck.DiscardPile.Dequeue());
            }
            Shuffle(deck);
        }

        public static Actor[] Draw(Deck deck, int cardAmount)
        {
            var drawnCards = new Actor[cardAmount];
            for (int i = 0; i < cardAmount; i++)
            {
                if (deck.DrawPile.Count <= 0) Reshuffle(deck);
                drawnCards[i] = deck.DrawPile.Dequeue();
            }
            return drawnCards;
        }

        public static void Discard(Deck deck, IEnumerable<Actor> discardCards)
        {
            if (deck.DiscardPile == null) deck.DiscardPile = new Queue<Actor>();
            foreach (var card in discardCards)
            {
                deck.DiscardPile.Enqueue(card);
            }
        }

        #region Defunct
        //#region Fill overloads
        //public void Fill(string deckName)
        //{
        //    var deckBuilder = new DeckBuilder();
        //    CardSet = deckBuilder.Build(deckName);
        //}

        //public void Fill(List<(Characters, int)> deckScaffold)
        //{
        //    var deckBuilder = new DeckBuilder();
        //    CardSet = deckBuilder.Build(deckScaffold);
        //}

        //public void Fill(Actor[] customDeck)
        //{
        //    CardSet = customDeck;
        //}
        //#endregion

        //public void Queue()
        //{
        //    DrawPile = new Queue<Actor>(CardSet);
        //}

        //public void Shuffle()
        //{
        //    // Fisher-Yates algorithm
        //    var random = new Random();
        //    var cards = DrawPile.ToArray();
        //    int n = cards.Length;
        //    while (n > 1)
        //    {
        //        int k = random.Next(n--);
        //        var temp = cards[n];
        //        cards[n] = cards[k];
        //        cards[k] = temp;
        //    }
        //    DrawPile = new Queue<Actor>(cards);
        //}

        //public void Reshuffle()
        //{
        //    while (DiscardPile.Count > 0)
        //    {
        //        DrawPile.Enqueue(DiscardPile.Dequeue());
        //    }
        //    Shuffle();
        //}

        //public Actor[] Draw(int cardAmount)
        //{
        //    var drawnCards = new Actor[cardAmount];
        //    for (int i = 0; i < cardAmount; i++)
        //    {
        //        if (DrawPile.Count <= 0)
        //            Reshuffle();
        //        drawnCards[i] = DrawPile.Dequeue();
        //    }
        //    return drawnCards;
        //}

        //public void Discard(IEnumerable<Actor> discardCards)
        //{
        //    if (DiscardPile == null) DiscardPile = new Queue<Actor>();
        //    foreach (var card in discardCards)
        //    {
        //        DiscardPile.Enqueue(card);
        //    }
        //}
        #endregion
    }
}
