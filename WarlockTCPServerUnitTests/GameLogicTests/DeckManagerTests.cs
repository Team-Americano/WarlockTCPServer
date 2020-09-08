using Xunit;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Constants.DeckPresets;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Builders.ActorBuilder;
using static WarlockTCPServer.Managers.GameStateData.DeckManager;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class DeckManagerTests
    {
        [Fact]
        public void DeckFillWorksWithDeckName()
        {
            Deck deck = new Deck();
            Fill(deck, "BaseDeck");

            Assert.NotNull(deck.DrawPile);
            Assert.Equal(108, deck.DrawPile.Count);
        }

        [Fact]
        public void DeckFillWorksWithDeckScaffold()
        {
            Deck deck = new Deck();
            Fill(deck, BaseDeck);

            Assert.NotNull(deck.DrawPile);
            Assert.Equal(108, deck.DrawPile.Count);
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
            Fill(deck, customDeck);

            Assert.NotNull(deck.DrawPile);
            Assert.Equal(10, deck.DrawPile.Count);
        }

        [Fact]
        public void DeckShuffleWorks()
        {
            Deck deck = new Deck();
            Fill(deck, "BaseDeck");
            var preShuffle = deck.DrawPile;

            Shuffle(deck);
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
            Fill(deck, "BaseDeck");

            var drawnCards = Draw(deck, 7);

            Assert.NotNull(drawnCards);
            Assert.Equal(7, drawnCards.Length);
            Assert.Equal(101, deck.DrawPile.Count);
        }

        [Fact]
        public void DeckDiscardWorks()
        {
            Deck deck = new Deck();
            Fill(deck, "BaseDeck");
            var drawnCards = Draw(deck, 7);

            Discard(deck, drawnCards);

            Assert.NotNull(deck.DiscardPile);
            Assert.Equal(7, deck.DiscardPile.Count);
        }

        [Fact]
        public void DeckReshuffleWorks()
        {
            Deck deck = new Deck();
            Fill(deck, "BaseDeck");
            var drawnCards = Draw(deck, 7);
            Discard(deck, drawnCards);

            Reshuffle(deck);

            Assert.Equal(108, deck.DrawPile.Count);
            Assert.Equal(0, deck.DiscardPile.Count);
        }
    }
}
