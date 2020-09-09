using Newtonsoft.Json;
using System;
using WarlockTCPServer.GameLogic.ActorComponents.ActorActions;

namespace WarlockTCPServer.GameLogic.ActorComponents
{
    public class Actor
    {
        [JsonProperty("CardId")]
        public short CardId { get; set; } // #1 through #N for each card in deck of length N
        [JsonProperty("Origin")]
        public string Origin { get; set; }
        [JsonProperty("Class")]
        public string Class { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Health")]
        public Attribute Health { get; set; }
        [JsonProperty("Defense")]
        public Attribute Defense { get; set; }
        [JsonProperty("Attack")]
        public Attribute Attack { get; set; }
        [JsonProperty("Speed")]
        public Attribute Speed { get; set; }
        [JsonProperty("Precision")]
        public Attribute Precision { get; set; }
        [JsonProperty("ManaCost")]
        public Attribute ManaCost { get; set; }
        [JsonProperty("Rarity")]
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
            ActorAction2 actorAction
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
