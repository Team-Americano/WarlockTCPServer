using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions
{
    public class Effect
    {
        public string Targeter { get; set; }
        public string AppliedEffect { get; set; }

        public Effect(string targeter, string appliedEffect)
        {
            Targeter = targeter;
            AppliedEffect = appliedEffect;
        }
    }
}
