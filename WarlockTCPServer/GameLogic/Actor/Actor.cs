using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic.Actor
{
    /// <summary>
    /// Actors are comprised of an Identifier, Health stat, Defense stat, Attack stat, Speed Stat, and Precision stat. These stats are generated based on a randomly assigned Class. Their abilites are chosen based on a randonly assigned Origin. Rarity is an independent factor meant to uniquely change any of these properties.
    /// </summary>
    public class Actor
    {
        public short CardId { get; set; } // #1 to N for each deck of length N
        public short Health { get; set; }
        public short Defense { get; set; }
        public short Attack { get; set; }
        public short Speed { get; set; }
        public short Precision { get; set; }
        public short ManaCost { get; set; }
        public Action ActorAction { get; set; }

        // Hidden properties
        public string Origin { get; set; }
        public string Class { get; set; }
        public short Rarity { get; set; }

        #region Constructors
        public Actor()
        {

        }

        public Actor
            (
                short cardId,
                short health,
                short defense,
                short attack,
                short speed,
                short precision
            )
        {
            CardId = cardId;
            Health = health;
            Defense = defense;
            Attack = attack;
            Speed = speed;
            Precision = precision;
        }

        public Actor
            (
                short cardId,
                short health,
                short defense,
                short attack,
                short speed,
                short precision,
                string @class
            )
        {
            CardId = cardId;
            Health = health;
            Defense = defense;
            Attack = attack;
            Speed = speed;
            Precision = precision;
            Class = @class;
        }

        public Actor
    (
        short cardId,
        short health,
        short defense,
        short attack,
        short speed,
        short precision,
        short manaCost,
        Action actorAction,
        string origin,
        string @class,
        short rarity
    )
        {
            CardId = cardId;
            Health = health;
            Defense = defense;
            Attack = attack;
            Speed = speed;
            Precision = precision;
            ManaCost = manaCost;
            ActorAction = actorAction;
            Origin = origin;
            Class = @class;
            Rarity = rarity;
        }
        #endregion
    }
}
