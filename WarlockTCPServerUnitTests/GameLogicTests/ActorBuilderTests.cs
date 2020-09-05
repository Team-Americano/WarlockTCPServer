using System;
using Xunit;
using WarlockTCPServer.GameLogic;
using static WarlockTCPServer.Builders.ActorBuilder;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class ActorBuilderTests
    {
        [Fact]
        public void MakesTheCorrectActor()
        {
            Actor expected = new Actor(1, "Undead", "Warden", "Skeleton", 70, 50, 25, 20, 5, 1, "Common", null);
            Actor actual = Build(Characters.Skeleton, 1);

            Assert.NotNull(actual);
            Assert.Equal(expected.CardId, actual.CardId);
            Assert.Equal(expected.Origin, actual.Origin);
            Assert.Equal(expected.Class, actual.Class);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Health, actual.Health);
            Assert.Equal(expected.Attack, actual.Attack);
            Assert.Equal(expected.Defense, actual.Defense);
            Assert.Equal(expected.Speed, actual.Speed);
            Assert.Equal(expected.Precision, actual.Precision);
            Assert.Equal(expected.ManaCost, actual.ManaCost);
            Assert.Equal(expected.Rarity, actual.Rarity);
            Assert.Equal(expected.ActorAction, actual.ActorAction);
        }

        [Fact]
        public void CreatesEntirelyNewObjectNotReferences()
        {
            Actor actor1 = Build(Characters.Chomper, 1);
            Actor actor2 = Build(Characters.Chomper, 1);

            Assert.NotSame(actor1, actor2);
        }
    }
}
