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
            if (random.NextDouble() > (source.Precision.CurrentValue / 100))
                damage *= 2;

            // defense calculation
            var damageReduction = 100 / (100 + target.Defense.CurrentValue);
            damage = (short)(damageReduction * damage);

            target.Health.CurrentValue -= damage;
            // TODO: Add RQE for target damage or target death

            return new object();
        }
        #endregion

        public static Dictionary<string, Effector> AppliedEffects = new Dictionary<string, Effector>()
        {
            { "StandardDamage", StandardDamage }
        };
    }
}
