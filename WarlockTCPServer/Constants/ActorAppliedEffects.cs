using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Constants
{
    public static class ActorAppliedEffects
    {
        // TODO: Return a RQE command object
        public delegate object Effector(Actor source, Actor target);
        #region AppliedEffect Methods
        public static object StandardDamage(Actor source, Actor target)
        {
            Random random = new Random();
            var damage = source.Attack.CurrentValue;

            // crit roll
            double threshold = source.Precision.CurrentValue / 100d;
            double hitChance = random.NextDouble();
            if (hitChance < threshold)
                damage *= 2;

            // defense calculation
            var damageReduction = 100d / (100 + target.Defense.CurrentValue);
            damage = (short)(damageReduction * damage);

            target.Health.CurrentValue -= damage;

            // lowest health can be is 0
            if (target.Health.CurrentValue < 0)
                target.Health.CurrentValue = 0;

            // TODO: Add RQE for target damage or target death
            return new object();
        }
        #endregion

        public static Dictionary<DeckConstants.AppliedEffect, Effector> AppliedEffects = new Dictionary<DeckConstants.AppliedEffect, Effector>()
        {
            { DeckConstants.AppliedEffect.StandardDamage, StandardDamage }
        };
    }
}
