using System.Collections.Generic;
using WarlockTCPServer.GameLogic.ActorComponents;
using WarlockTCPServer.GameLogic.ActorComponents.ActorActions;
using Effect = WarlockTCPServer.GameLogic.ActorComponents.ActorActions.Effect;
using EffectEnum = WarlockTCPServer.Constants.DeckConstants.Effect;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Builders
{
    public static class ActorBuilder
    {
        public static Actor Build(Characters cardChoice, short cardId)
        {
            // gathering character information
            var associations = CharacterLegend[cardChoice];
            var originStats = OriginStats[associations.Item1];
            var classStats = ClassStats[associations.Item2];
            var rarityStats = RarityStats[associations.Item3];

            Attribute health = new Attribute();
            Attribute defense = new Attribute();
            Attribute attack = new Attribute();
            Attribute speed = new Attribute();
            Attribute precision = new Attribute();
            Attribute manaCost = new Attribute();

            // attaching stats
            string name = associations.Item4;
            string origin = originStats.origin;
            string @class = classStats.@class;
            string rarity = rarityStats.rarity;
            health.BaseValue = (short)(originStats.health + classStats.health + rarityStats.health);
            health.CurrentValue = (short)(originStats.health + classStats.health + rarityStats.health);
            defense.BaseValue = (short)(originStats.defense + classStats.defense + rarityStats.defense);
            defense.CurrentValue = (short)(originStats.defense + classStats.defense + rarityStats.defense);
            attack.BaseValue = (short)(originStats.attack + classStats.attack + rarityStats.attack);
            attack.CurrentValue = (short)(originStats.attack + classStats.attack + rarityStats.attack);
            speed.BaseValue = (short)(originStats.speed + classStats.speed + rarityStats.speed);
            speed.CurrentValue = (short)(originStats.speed + classStats.speed + rarityStats.speed);
            precision.BaseValue = (short)(originStats.precision + classStats.precision + rarityStats.precision);
            precision.CurrentValue = (short)(originStats.precision + classStats.precision + rarityStats.precision);
            manaCost.BaseValue = rarityStats.manaCost;
            manaCost.CurrentValue = rarityStats.manaCost;

            // attaching effects
            List<Effect> actorEffects = new List<Effect>();
            var characterEffectDetailsList = CharacterEffects[cardChoice];
            foreach (var effectDetailsReference in characterEffectDetailsList)
            {
                var effectDetails = Effects[effectDetailsReference];
                Targeter targeter = effectDetails.Item1;
                AppliedEffect appliedEffect = effectDetails.Item2;
                Effect effect = new Effect(targeter, appliedEffect);
                actorEffects.Add(effect);
            }
            Effect[] effectArray = actorEffects.ToArray();
            ActorAction2 actorAction = new ActorAction2(effectArray);

            Actor actor = new Actor(cardId, origin, @class, name, health, defense, attack, speed, precision, manaCost, rarity, actorAction);
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
