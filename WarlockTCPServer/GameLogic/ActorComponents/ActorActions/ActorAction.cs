using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.ActorComponents.ActorActions.ActorEffects;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions
{
    public class ActorAction
    {
        private IEffect[] _effects;

        public ActorAction(IEffect[] effects)
        {
            _effects = effects;
        }

        public Actor[] GetTargets(Actor[] enemyParty)
        {
            // 1. Find which side the actor belongs to
            // 2. Run some logic to find the targets for the actor
            // 3. Return all targets (that aren't dead)

            foreach (var enemy in enemyParty)
            {
                if (enemy.Health.CurrentValue > 0) return new Actor[] { enemy };
            }
            return new Actor[0];
        }

        public void Execute(Actor source, Actor[] enemyParty)
        {
            var targets = GetTargets(enemyParty);
            if (targets.Length > 0)
            {
                foreach (var target in targets)
                {
                    foreach (var effect in _effects)
                    {
                        effect.ApplyEffect(source, target);
                    }
                }
                // TODO: Add RQE for rendering action effect
            }
        }
    }
}
