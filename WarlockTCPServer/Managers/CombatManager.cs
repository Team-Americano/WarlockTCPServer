using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Managers
{
    public static class CombatManager
    {
        // will return a queue of render command objects
        public static Queue<object> AttackPhase(GameState game)
        {
            Queue<object> RQE = new Queue<object>();
            // pass in a boolean for who goes first, this is temporarily hardcoded
            bool player1Priority = game.RoundCounter % 2 == 0 ? true : false;
            var p1Actor = GetNextActor(game.Player1.Party);
            var p2Actor = GetNextActor(game.Player2.Party);
            while (p1Actor != null || p2Actor != null)
            {
                if (p2Actor == null || p1Actor.Speed.CurrentValue > p2Actor.Speed.CurrentValue)
                {
                    // invoke action and record rendering instructions
                    //RQE.enqueue = p1Actor.ActorAction...
                    p1Actor.HasGone = true;
                }
                else if (p1Actor == null || p1Actor.Speed.CurrentValue < p2Actor.Speed.CurrentValue)
                {
                    // invoke action and record rendering instructions
                    //RQE.enqueue = p2Actor.ActorAction...
                    p2Actor.HasGone = true;
                }
                else
                {
                    if (player1Priority)
                    {
                        // invoke action and record rendering instructions
                        //RQE.enqueue = p1Actor.ActorAction...
                        p1Actor.HasGone = true;
                    }
                    else
                    {
                        // invoke action and record rendering instructions
                        //RQE.enqueue = p2Actor.ActorAction...
                        p2Actor.HasGone = true;
                    }
                    player1Priority = !player1Priority;
                }
                p1Actor = GetNextActor(game.Player1.Party);
                p2Actor = GetNextActor(game.Player2.Party);

            }
            // TODO: Determine Points for the Round
            ResetStats(game);
            return RQE;
        }

        private static Actor GetNextActor(IEnumerable<Actor> actors)
        {
            Actor highest = new Actor();
            highest.Speed.CurrentValue = -10000;
            foreach (var actor in actors)
            {
                if (actor.Health.CurrentValue > 0 && actor.HasGone == false && actor.Speed.CurrentValue > highest.Speed.CurrentValue)
                    highest = actor;
            }
            return highest.Speed.CurrentValue == -10000 ? null : highest;
        }

        private static void ResetStats(GameState game)
        {
            foreach (var card in game.Player1.Party)
            {
                card.Attack.CurrentValue = card.Attack.BaseValue;
                card.Defense.CurrentValue = card.Defense.BaseValue;
                card.Health.CurrentValue = card.Health.BaseValue;
                card.Speed.CurrentValue = card.Speed.BaseValue;
                card.Precision.CurrentValue = card.Precision.BaseValue;
                card.ManaCost.CurrentValue = card.ManaCost.BaseValue;
                card.HasGone = false;
            }

            foreach (var card in game.Player2.Party)
            {
                card.Attack.CurrentValue = card.Attack.BaseValue;
                card.Defense.CurrentValue = card.Defense.BaseValue;
                card.Health.CurrentValue = card.Health.BaseValue;
                card.Speed.CurrentValue = card.Speed.BaseValue;
                card.Precision.CurrentValue = card.Precision.BaseValue;
                card.ManaCost.CurrentValue = card.ManaCost.BaseValue;
                card.HasGone = false;
            }
        }
    }
}
