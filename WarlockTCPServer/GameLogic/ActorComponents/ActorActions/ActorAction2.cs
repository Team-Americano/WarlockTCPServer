using System;
using System.Collections.Generic;
using System.Text;
using static WarlockTCPServer.Constants.ActorTargeters;
using static WarlockTCPServer.Constants.ActorAppliedEffects;
using WarlockTCPServer.POCOs;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions
{
    public class ActorAction2
    {
        public Effect[] Effects { get; set; }

        public ActorAction2(Effect[] effects)
        {
            Effects = effects;
        }

        // TODO: Return collection of render commands
        // TODO: Add try/catch statement?
        public RenderQueueEntry[] Execute(Actor source, IEnumerable<Actor> friendlyParty, IEnumerable<Actor> enemyParty)
        {
            var rqes = new List<RenderQueueEntry>();

            var playerReadyEntry = new RenderQueueEntry()
            {
                TargetCardIds = new[] { source.CardId },
                Animation = "ReadyAttack"
            };

            rqes.Add(playerReadyEntry);

            var targetIds = new List<short>();

            foreach (var effect in Effects)
            {
                var newTargets = Targeters[effect.Targeter](friendlyParty, enemyParty);
                
                foreach (var newTarget in newTargets)
                {
                    if (newTarget != null)
                    {
                        targetIds.Add(AppliedEffects[effect.AppliedEffect](source, newTarget));
                    }
                }

                var newRQE = new RenderQueueEntry()
                {
                    TargetCardIds = targetIds.ToArray(),
                    Animation = effect.Animation
                };

                rqes.Add(newRQE);
            }

            return rqes.ToArray();
        }
    }
}
