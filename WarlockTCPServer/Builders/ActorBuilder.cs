using WarlockTCPServer.GameLogic.ActorComponents;
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

            Attribute health = new Attribute();
            Attribute defense = new Attribute();
            Attribute attack = new Attribute();
            Attribute speed = new Attribute();
            Attribute precision = new Attribute();
            Attribute manaCost = new Attribute();

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
