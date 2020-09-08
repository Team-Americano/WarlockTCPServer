using Xunit;
using WarlockTCPServer.GameLogic.ActorComponents;
using static WarlockTCPServer.Builders.ActorBuilder;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Constants.ActorTargeters;
using Targeter = WarlockTCPServer.Constants.DeckConstants.Targeter;
using System.Linq;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class ActorTargeterTests
    {
        [Fact]
        public void FirstAliveWorks()
        {
            var enemy1 = Build(Characters.Skeleton, 1);
            enemy1.Health.CurrentValue = 0;
            var enemy2 = Build(Characters.Gazer, 2);
            var enemy3 = Build(Characters.Revenant, 3);
            var friendlies = new Actor[] { null };
            var enemies = new Actor[] { enemy1, enemy2, enemy3 };

            var targeted = Targeters[Targeter.FirstAlive](friendlies, enemies).ToArray();

            Assert.NotNull(targeted);
            Assert.Single(targeted);
            Assert.Equal(enemy2, targeted[0]);
        }
    }
}
