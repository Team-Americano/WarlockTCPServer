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
            #region Alternate
            //// first attacker, needs to be consistent with the draw and draft phase priorities
            //bool player1Priority = game.RoundCounter % 2 == 0 ? true : false;

            //// *** NOTE: Needs to be remade to accomodate more flexibility *** 
            //// When speeds attributes can be affected during the attack phase encounters
            //// this leaves the current speed list inaccurate as it is generated based on
            //// speeds before an interactions occcur.

            //// creates list of distinct speeds between both parties ordered greatest to least (before combat interactions, assuming Speed will be unchanged)
            var speeds = game.Player1.Party.Select(actor => actor.Speed.CurrentValue)
                        .Union(game.Player2.Party.Select(actor => actor.Speed.CurrentValue))
                        .OrderByDescending(num => num);

            //foreach (var speed in speeds)
            //{
            //    var p1Actors = game.Player1.Party.Where(x => x.Speed.CurrentValue == speed).ToList();
            //    var p2Actors = game.Player2.Party.Where(x => x.Speed.CurrentValue == speed).ToList();
            //    bool player1Turn = player1Priority;
            //    while (p1Actors.Count > 0 && p2Actors.Count > 0)
            //    {
            //        if (player1Turn && )
            //        {

            //        }
            //    }


            //}
            #endregion
            for (int speedTracker = 100; speedTracker >= 0; speedTracker--)
            {
                bool p1GoesFirst = player1Priority;
                while (FindNextEligibleActor(game.Player1.Party, speedTracker) != null ||
                       FindNextEligibleActor(game.Player2.Party, speedTracker) != null)
                {
                    Actor actor;
                    if (p1GoesFirst)
                    {
                        actor = FindNextEligibleActor(game.Player1.Party, speedTracker);
                        // invoke action and record rendering instructions
                        //RQE.enqueue = actor.ActorAction...
                        actor.HasGone = true;
                    }
                    else
                    {
                        actor = FindNextEligibleActor(game.Player2.Party, speedTracker);
                        // invoke action and record rendering instructions
                        //RQE.enqueue = actor.ActorAction...
                        actor.HasGone = true;
                    }
                    p1GoesFirst = !p1GoesFirst;
                }
                //var p1Actors = game.Player1.Party.Where(x => x.Speed.CurrentValue == speedTracker).ToList();
                //var p2Actors = game.Player2.Party.Where(x => x.Speed.CurrentValue == speedTracker).ToList();
                //bool p1GoesFirst = player1Priority;
                //while (p1Actors.Count > 0 || p2Actors.Count > 0)
                //{
                //    if (p1GoesFirst && p1Actors.Count > 0)
                //    {
                //        // invoke action and record rendering instructions
                //        //RQE.enqueue = p1Actors[0].ActorAction...
                //        p1Actors[0].HasGone = true;
                //        p1Actors.RemoveAt(0);
                //    }
                //    else if (!p1GoesFirst && p2Actors.Count > 0)
                //    {
                //        // invoke action and record rendering instructions
                //        //RQE.enqueue = p2Actors[0].ActorAction...
                //        p2Actors[0].HasGone = true;
                //        p2Actors.RemoveAt(0);
                //    }
                //    p1GoesFirst = !p1GoesFirst;
                //}
            }
            // RESET Stat function
            return RQE;
        }

        private static Actor FindNextEligibleActor(IEnumerable<Actor> actors, int targetSpeed)
        {
            foreach (var actor in actors)
            {
                if (actor.Health.CurrentValue > 0 && actor.HasGone == false && actor.Speed.CurrentValue == targetSpeed)
                    return actor;
            }
            return null;
        }
    }
}
