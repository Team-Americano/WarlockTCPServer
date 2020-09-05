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
            Assert.Equal(expected, actual);
        }
    }
}
