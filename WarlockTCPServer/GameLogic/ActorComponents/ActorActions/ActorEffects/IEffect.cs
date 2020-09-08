using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions.ActorEffects
{
    public interface IEffect
    {
        void ApplyEffect(Actor source, Actor target);
    }
}
