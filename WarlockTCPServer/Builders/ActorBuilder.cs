using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.Actor;
using static WarlockTCPServer.Constants.DeckConstants;

namespace WarlockTCPServer.Builders
{
    public static class ActorBuilder
    {
        public static Actor CreateActor(short cardId, ActorClass actorClass)
        {
            Actor actor;
            try
            {
                switch (actorClass)
                {
                    case ActorClass.Brute:
                        actor = new Actor(cardId, BruteHealth, BruteDefense, BruteAttack, BruteSpeed, BrutePrecision, actorClass.ToString());
                        break;
                    case ActorClass.Warden:
                        actor = new Actor(cardId, WardenHealth, WardenDefense, WardenAttack, WardenSpeed, WardenPrecision);
                        break;
                    case ActorClass.Sorcerer:
                        actor = new Actor(cardId, SorcererHealth, SorcererDefense, SorcererAttack, SorcererSpeed, SorcererPrecision);
                        break;
                    case ActorClass.Enchanter:
                        actor = new Actor(cardId, EnchanterHealth, EnchanterDefense, EnchanterAttack, EnchanterSpeed, EnchanterPrecision);
                        break;
                    case ActorClass.Trapper:
                        actor = new Actor(cardId, TrapperHealth, TrapperDefense, TrapperAttack, TrapperSpeed, TrapperPrecision);
                        break;
                    case ActorClass.Stalker:
                        actor = new Actor(cardId, StalkerHealth, StalkerDefense, StalkerAttack, StalkerSpeed, StalkerPrecision);
                        break;
                    default:
                        actor = new Actor();
                        break;
                }
                return actor;
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error while trying to create an Actor: " + e);
                return new Actor(cardId, 0, 0, 0, 0, 0);
            }
        }
    }
}
