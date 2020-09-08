using Xunit;
using static WarlockTCPServer.Builders.ActorBuilder;
using static WarlockTCPServer.Constants.DeckConstants;
using WarlockTCPServer.GameLogic.ActorComponents;

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
            Assert.Equal(70, actual.Health.BaseValue);
            Assert.Equal(70, actual.Health.CurrentValue);
            Assert.Equal(50, actual.Defense.BaseValue);
            Assert.Equal(50, actual.Defense.CurrentValue);
            Assert.Equal(25, actual.Attack.BaseValue);
            Assert.Equal(25, actual.Attack.CurrentValue);
            Assert.Equal(20, actual.Speed.BaseValue);
            Assert.Equal(20, actual.Speed.CurrentValue);
            Assert.Equal(5, actual.Precision.BaseValue);
            Assert.Equal(5, actual.Precision.CurrentValue);
            Assert.Equal(1, actual.ManaCost.BaseValue);
            Assert.Equal(1, actual.ManaCost.CurrentValue);
            Assert.Equal("Common", actual.Rarity);
            Assert.NotNull(actual.ActorAction);
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
