using System;
using WarlockTCPServer.GameLogic.ActorComponents.ActorActions;

namespace WarlockTCPServer.GameLogic.ActorComponents
{
    public class Actor
    {
        public short CardId { get; set; } // #1 through #N for each card in deck of length N
        public string Origin { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public Attribute Health { get; set; }
        public Attribute Defense { get; set; }
        public Attribute Attack { get; set; }
        public Attribute Speed { get; set; }
        public Attribute Precision { get; set; }
        public Attribute ManaCost { get; set; }
        public string Rarity { get; set; }
        public ActorAction2 ActorAction { get; set; }
        public bool HasGone { get; set; } = false;

        public Actor()
        {
            // explicit empty constructor
        }

        public Actor
        (
            short cardId,
            string origin,
            string @class,
            string name,
            Attribute health,
            Attribute defense,
            Attribute attack,
            Attribute speed,
            Attribute precision,
            Attribute manaCost,
            string rarity,
            Action actorAction
        )
        {
            CardId = cardId;
            Origin = origin;
            Class = @class;
            Name = name;
            Health = health;
            Defense = defense;
            Attack = attack;
            Speed = speed;
            Precision = precision;
            ManaCost = manaCost;
            Rarity = rarity;
            ActorAction = actorAction;
        }
    }
}
