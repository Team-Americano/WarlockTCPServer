using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using WarlockTCPServer.POCOs;

namespace WarlockTCPServer.Managers
{
    public static class CombatManager
    {
        public static RenderQueueEntry[] RunAttackPhase(GameState game)
        {
            // TODO: Return a full queue of render commands
            List<RenderQueueEntry> RQE = new List<RenderQueueEntry>();
            // pass in a boolean for who goes first, this is temporarily hardcoded
            bool player1Priority = game.RoundCounter % 2 == 0 ? true : false;
            var p1Actor = GetNextActor(game.Player1.Party);
            var p2Actor = GetNextActor(game.Player2.Party);
            Actor nextActor = null;
            List<Actor> friendlyParty = new List<Actor>();
            List<Actor> enemyParty = new List<Actor>();

            while (p1Actor != null || p2Actor != null)
            {
                if (p1Actor == null)
                {
                    nextActor = p2Actor;
                    friendlyParty = game.Player2.Party;
                    enemyParty = game.Player1.Party;
                    goto ExecuteTurn;
                }

                if (p2Actor == null)
                {
                    nextActor = p1Actor;
                    friendlyParty = game.Player1.Party;
                    enemyParty = game.Player2.Party;
                    goto ExecuteTurn;
                }

                if (p1Actor.Speed.CurrentValue > p2Actor.Speed.CurrentValue)
                {
                    nextActor = p1Actor;
                    friendlyParty = game.Player1.Party;
                    enemyParty = game.Player2.Party;
                }
                else if (p2Actor.Speed.CurrentValue > p1Actor.Speed.CurrentValue)
                {
                    nextActor = p2Actor;
                    friendlyParty = game.Player2.Party;
                    enemyParty = game.Player1.Party;
                }
                else
                {
                    if (player1Priority)
                    {
                        nextActor = p1Actor;
                        friendlyParty = game.Player1.Party;
                        enemyParty = game.Player2.Party;
                    }
                    else
                    {
                        nextActor = p2Actor;
                        friendlyParty = game.Player2.Party;
                        enemyParty = game.Player1.Party;
                    }

                    player1Priority = !player1Priority;
                }

                ExecuteTurn:
                RQE.AddRange(nextActor.ActorAction.Execute(nextActor, friendlyParty, enemyParty));
                nextActor.HasGone = true;
                p1Actor = GetNextActor(game.Player1.Party);
                p2Actor = GetNextActor(game.Player2.Party);

            }
            AssignPoints(game);
            ResetStats(game);
            return RQE.ToArray();
        }

        private static Actor GetNextActor(IEnumerable<Actor> actors)
        {
            Actor highest = new Actor();
            highest.Speed = new GameLogic.ActorComponents.Attribute();
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

        private static void AssignPoints(GameState game)
        {
            int player1AliveActors = game.Player1.Party.Where(x => x.Health.CurrentValue > 0).Count();
            int player2AliveActors = game.Player2.Party.Where(x => x.Health.CurrentValue > 0).Count();

            if (player1AliveActors > player2AliveActors)
                game.Player1.Score++;
            else if (player1AliveActors < player2AliveActors)
                game.Player2.Score++;
        }
    }
}
