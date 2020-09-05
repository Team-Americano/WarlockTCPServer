using System;
using System.Collections.Generic;
using Xunit;
using WarlockTCPServer.Builders;
using static WarlockTCPServer.Constants.DeckPresets;
using System.Collections;
using System.Diagnostics;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class DeckBuilderTests
    {
        [Fact]
        public void MakesTheCorrectDeckUsingTheDeckName()
        {
            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.Build("BaseDeck");

            Dictionary<string, int> tracker = new Dictionary<string, int>
            {
                { "Warden", 0 },
                { "Brute", 0 },
                { "Enchanter", 0 },
                { "Sorcerer", 0 },
                { "Trapper", 0 },
                { "Stalker", 0 },

                { "Undead", 0 },
                { "Glacial", 0 },
                { "Infernal", 0 },
                { "Bestial", 0 },
                { "Aberrant", 0 },
                { "Aquatic", 0 },

                { "Common", 0 },
                { "Uncommon", 0 },
                { "Rare", 0 }
            };
            foreach (var card in deck)
            {
                tracker[card.Class]++;
                tracker[card.Origin]++;
                tracker[card.Rarity]++;
            }

            Assert.NotNull(deck);
            Assert.Equal(108, deck.Length);
            Assert.Equal(18, tracker["Warden"]);
            Assert.Equal(27, tracker["Brute"]);
            Assert.Equal(12, tracker["Enchanter"]);
            Assert.Equal(18, tracker["Sorcerer"]);
            Assert.Equal(15, tracker["Trapper"]);
            Assert.Equal(18, tracker["Stalker"]);
            Assert.Equal(18, tracker["Undead"]);
            Assert.Equal(18, tracker["Glacial"]);
            Assert.Equal(18, tracker["Infernal"]);
            Assert.Equal(18, tracker["Bestial"]);
            Assert.Equal(18, tracker["Aberrant"]);
            Assert.Equal(18, tracker["Aquatic"]);
            Assert.Equal(54, tracker["Common"]);
            Assert.Equal(36, tracker["Uncommon"]);
            Assert.Equal(18, tracker["Rare"]);
        }

        [Fact]
        public void MakesTheCorrectDeckUsingTheDeckScaffold()
        {
            var deckBuilder = new DeckBuilder();
            var deck = deckBuilder.Build(BaseDeck);

            Dictionary<string, int> tracker = new Dictionary<string, int>
            {
                { "Warden", 0 },
                { "Brute", 0 },
                { "Enchanter", 0 },
                { "Sorcerer", 0 },
                { "Trapper", 0 },
                { "Stalker", 0 },

                { "Undead", 0 },
                { "Glacial", 0 },
                { "Infernal", 0 },
                { "Bestial", 0 },
                { "Aberrant", 0 },
                { "Aquatic", 0 },

                { "Common", 0 },
                { "Uncommon", 0 },
                { "Rare", 0 }
            };
            foreach (var card in deck)
            {
                tracker[card.Class]++;
                tracker[card.Origin]++;
                tracker[card.Rarity]++;
            }

            Assert.NotNull(deck);
            Assert.Equal(108, deck.Length);
            Assert.Equal(18, tracker["Warden"]);
            Assert.Equal(27, tracker["Brute"]);
            Assert.Equal(12, tracker["Enchanter"]);
            Assert.Equal(18, tracker["Sorcerer"]);
            Assert.Equal(15, tracker["Trapper"]);
            Assert.Equal(18, tracker["Stalker"]);
            Assert.Equal(18, tracker["Undead"]);
            Assert.Equal(18, tracker["Glacial"]);
            Assert.Equal(18, tracker["Infernal"]);
            Assert.Equal(18, tracker["Bestial"]);
            Assert.Equal(18, tracker["Aberrant"]);
            Assert.Equal(18, tracker["Aquatic"]);
            Assert.Equal(54, tracker["Common"]);
            Assert.Equal(36, tracker["Uncommon"]);
            Assert.Equal(18, tracker["Rare"]);
        }
    }
}
