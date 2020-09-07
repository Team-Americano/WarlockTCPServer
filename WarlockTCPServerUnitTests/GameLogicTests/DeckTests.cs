using System;
using Xunit;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Constants.DeckPresets;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Builders.ActorBuilder;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class DeckTests
    {
        [Fact]
        public void DeckFillWorksWithDeckName()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");

            Assert.NotNull(deck.CardSet);
            Assert.Equal(108, deck.CardSet.Length);
        }

        [Fact]
        public void DeckFillWorksWithDeckScaffold()
        {
            Deck deck = new Deck();
            deck.Fill(BaseDeck);

            Assert.NotNull(deck.CardSet);
            Assert.Equal(108, deck.CardSet.Length);
        }

        [Fact]
        public void DeckFillWorksWithCustomDeck()
        {
            Actor[] customDeck = new Actor[10];
            for (int i = 0; i < customDeck.Length; i++)
            {
                customDeck[i] = Build(Characters.Skeleton, (short)i);
            }

            Deck deck = new Deck();
            deck.Fill(customDeck);

            Assert.NotNull(deck.CardSet);
            Assert.Equal(10, deck.CardSet.Length);
        }

        [Fact]
        public void DeckQueueWorks()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");

            deck.Queue();

            Assert.NotNull(deck.DrawPile);
            Assert.Equal(108, deck.DrawPile.Count);
        }

        [Fact]
        public void DeckShuffleWorks()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");
            deck.Queue();
            var preShuffle = deck.DrawPile;

            deck.Shuffle();
            var postShuffle = deck.DrawPile;

            Assert.NotNull(deck.DrawPile);
            Assert.Equal(108, preShuffle.Count);
            Assert.Equal(108, postShuffle.Count);
            Assert.NotEqual(preShuffle, postShuffle);
        }

        [Fact]
        public void DeckDrawWorks()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");
            deck.Queue();

            var drawnCards = deck.Draw(7);

            Assert.NotNull(drawnCards);
            Assert.Equal(7, drawnCards.Length);
            Assert.Equal(101, deck.DrawPile.Count);
        }

        [Fact]
        public void DeckDiscardWorks()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");
            deck.Queue();
            var drawnCards = deck.Draw(7);

            deck.Discard(drawnCards);

            Assert.NotNull(deck.DiscardPile);
            Assert.Equal(7, deck.DiscardPile.Count);
        }

        [Fact]
        public void DeckReshuffleWorks()
        {
            Deck deck = new Deck();
            deck.Fill("BaseDeck");
            deck.Queue();
            var drawnCards = deck.Draw(7);
            deck.Discard(drawnCards);

            deck.Reshuffle();

            Assert.Equal(108, deck.DrawPile.Count);
            Assert.Equal(0, deck.DiscardPile.Count);
        }
    }
}
