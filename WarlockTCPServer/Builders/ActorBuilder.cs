using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Builders
{
    public static class ActorBuilder
    {
        public static Actor Build(Characters cardChoice, short cardId)
        {
            var associations = CharacterLegend[cardChoice];
            var originStats = OriginStats[associations.Item1];
            var classStats = ClassStats[associations.Item2];
            var rarityStats = RarityStats[associations.Item3];

            string name = associations.Item4;
            string origin = originStats.origin;
            string @class = classStats.@class;
            string rarity = rarityStats.rarity;
            short health = (short)(originStats.health + classStats.health + rarityStats.health);
            short defense = (short)(originStats.defense + classStats.defense + rarityStats.defense);
            short attack = (short)(originStats.attack + classStats.attack + rarityStats.attack);
            short speed = (short)(originStats.speed + classStats.speed + rarityStats.speed);
            short precision = (short)(originStats.precision + classStats.precision + rarityStats.precision);
            short manaCost = rarityStats.manaCost;

            // TODO: Add actions/abilites to actor instantiation
            Actor actor = new Actor(cardId, origin, @class, name, health, defense, attack, speed, precision, manaCost, rarity, null);
            return actor;
        }


        #region Defunct
        //public static Actor CreateActor(short cardId, ActorClass actorClass)
        //{
        //    Actor actor;
        //    try
        //    {
        //        switch (actorClass)
        //        {
        //            case ActorClass.Brute:
        //                actor = new Actor(cardId, BruteHealth, BruteDefense, BruteAttack, BruteSpeed, BrutePrecision, actorClass.ToString());
        //                break;
        //            case ActorClass.Warden:
        //                actor = new Actor(cardId, WardenHealth, WardenDefense, WardenAttack, WardenSpeed, WardenPrecision);
        //                break;
        //            case ActorClass.Sorcerer:
        //                actor = new Actor(cardId, SorcererHealth, SorcererDefense, SorcererAttack, SorcererSpeed, SorcererPrecision);
        //                break;
        //            case ActorClass.Enchanter:
        //                actor = new Actor(cardId, EnchanterHealth, EnchanterDefense, EnchanterAttack, EnchanterSpeed, EnchanterPrecision);
        //                break;
        //            case ActorClass.Trapper:
        //                actor = new Actor(cardId, TrapperHealth, TrapperDefense, TrapperAttack, TrapperSpeed, TrapperPrecision);
        //                break;
        //            case ActorClass.Stalker:
        //                actor = new Actor(cardId, StalkerHealth, StalkerDefense, StalkerAttack, StalkerSpeed, StalkerPrecision);
        //                break;
        //            default:
        //                actor = new Actor();
        //                break;
        //        }
        //        return actor;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("There was an error while trying to create an Actor: " + e);
        //        return new Actor(cardId, 0, 0, 0, 0, 0);
        //    }
        //}
        #endregion
    }
}
