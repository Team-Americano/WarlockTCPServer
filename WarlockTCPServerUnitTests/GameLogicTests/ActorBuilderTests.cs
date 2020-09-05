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
            Actor actual = Build(Characters.Skeleton, 1);

            Assert.NotNull(actual);
            Assert.Equal(1, actual.CardId);
            Assert.Equal("Undead", actual.Origin);
            Assert.Equal("Warden", actual.Class);
            Assert.Equal("Skeleton", actual.Name);
            Assert.Equal(70, actual.Health);
            Assert.Equal(50, actual.Defense);
            Assert.Equal(25, actual.Attack);
            Assert.Equal(20, actual.Speed);
            Assert.Equal(5, actual.Precision);
            Assert.Equal(1, actual.ManaCost);
            Assert.Equal("Common", actual.Rarity);
            Assert.Equal(null, actual.ActorAction);
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
