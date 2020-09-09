using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.GameLogic.ActorComponents.ActorActions
{
    public class Effect
    {
        public Targeter Targeter { get; set; }
        public AppliedEffect AppliedEffect { get; set; }
        public string Animation { get; set; }

        public Effect(Targeter targeter, AppliedEffect appliedEffect, string animation)
        {
            Targeter = targeter;
            AppliedEffect = appliedEffect;
            Animation = animation;
        }
    }
}
