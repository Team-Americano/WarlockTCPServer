using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlockTCPServer.Constants;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Managers
{
    public static class DrawManager
    {
        public static List<Actor> DrawCards(Player player, GameState game) // or user
        {
            // 1. get current player's current hand size
            // 2. draw the difference between current players hands size and max hand
            // 3. send the new hand to the GameManager

            var start = player.Hand.Count;
            var maxHand = PlayerConstants.MaxHandSize;
            var cardsToDraw = maxHand - start;

            if (cardsToDraw > 0)
            {
                var drawnCards = game.Deck.Draw(cardsToDraw);
                foreach (var actor in drawnCards)
                {
                    player.Hand.Add(actor);
                }   
                return player.Hand;
            }

            return player.Hand;
        }
    }
}
