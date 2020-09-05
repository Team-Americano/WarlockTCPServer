using System;

namespace WarlockTCPServer.GameLogic
{
    public class Actor
    {
        public short CardId { get; set; } // #1 through #N for each card in deck of length N
        public string Origin { get; set; }
        public string Class { get; set; }
        public string Name { get; set; }
        public short Health { get; set; }
        public short Defense { get; set; }
        public short Attack { get; set; }
        public short Speed { get; set; }
        public short Precision { get; set; }
        public short ManaCost { get; set; }
        public string Rarity { get; set; }
        public Action ActorAction { get; set; }

        public Actor()
        {

        }

        public Actor
        (
            short cardId,
            string origin,
            string @class,
            string name,
            short health,
            short defense,
            short attack,
            short speed,
            short precision,
            short manaCost,
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
