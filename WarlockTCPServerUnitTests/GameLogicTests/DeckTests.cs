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
    }
}
