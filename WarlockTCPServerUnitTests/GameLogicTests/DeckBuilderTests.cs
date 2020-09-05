using System;
using Xunit;
using WarlockTCPServer.Builders;
using static WarlockTCPServer.Constants.DeckPresets;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class DeckBuilderTests
    {
        [Fact]
        public void MakesTheCorrectDeckUsingTheDeckName()
        {
            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.Build("BaseDeck");



            Assert.NotNull(deck);
            Assert.Equal(108, deck.Length);
        }

        [Fact]
        public void MakesTheCorrectDeckUsingTheDeckScaffold()
        {
            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.Build(BaseDeck);



            Assert.NotNull(deck);
            Assert.Equal(108, deck.Length);
        }
    }
}
