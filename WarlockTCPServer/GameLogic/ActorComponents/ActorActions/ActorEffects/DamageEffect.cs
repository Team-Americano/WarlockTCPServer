using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions.ActorEffects
{
    public class DamageEffect : IEffect
    {
        public void ApplyEffect(Actor source, Actor target)
        {
            Random random = new Random();
            var damage = source.Attack.CurrentValue;

            // crit roll
            if (random.NextDouble() > (source.Precision.CurrentValue / 100))
                damage *= 2;

            // defense calculation
            var damageReduction = 100 / (100 + target.Defense.CurrentValue);
            damage = (short)(damageReduction * damage);

            target.Health.CurrentValue -= damage;
            // TODO: Add RQE for target damage or target death
        }
    }
}
