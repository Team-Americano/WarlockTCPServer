using Xunit;
using System.Runtime;
using System.Collections.Generic;
using System.Text;
using static WarlockTCPServer.Builders.ActorBuilder;
using static WarlockTCPServer.Constants.DeckConstants;
using static WarlockTCPServer.Constants.ActorAppliedEffects;
using AppliedEffect = WarlockTCPServer.Constants.DeckConstants.AppliedEffect;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class ActorAppliedEffectTests
    {
        [Fact]
        public void StandardDamageWorks()
        {
            var source = Build(Characters.Skeleton, 1);
            var target = Build(Characters.Zombie, 2);
            int healthBefore = target.Health.CurrentValue;
            var command = AppliedEffects[AppliedEffect.StandardDamage](source, target);

            // TODO: Check specifics of the command object
            Assert.NotNull(command);
            Assert.True(target.Health.CurrentValue < healthBefore);
        }
    }
}
