﻿using System;
using System.Collections.Generic;
using System.Text;
using static WarlockTCPServer.Constants.ActorTargeters;
using static WarlockTCPServer.Constants.ActorAppliedEffects;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions
{
    public class ActorAction2
    {
        private Effect[] _effects;

        public ActorAction2(Effect[] effects)
        {
            _effects = effects;
        }

        // TODO: Return collection of render commands
        // TODO: Add try/catch statement?
        public IEnumerable<object> Execute(Actor source, IEnumerable<Actor> friendlyParty, IEnumerable<Actor> enemyParty)
        {
            var commands = new List<object>(); // command objects
            foreach (var effect in _effects)
            {
                var newTargets = Targeters[effect.Targeter](friendlyParty, enemyParty);
                foreach (var newTarget in newTargets)
                {
                    if (newTarget != null)
                    {
                        var renderCommand = AppliedEffects[effect.AppliedEffect](source, newTarget);
                        commands.Add(renderCommand);
                    }
                }
            }
            return commands;
        }
    }
}
