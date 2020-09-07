using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarlockTCPServer.Constants;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using WarlockTCPServer.Managers.GameStateData;

namespace WarlockTCPServer.Managers
{
    public static class DrawManager
    {
        public static List<Actor> DrawCards(Player player, GameState game)
        {
            var start = player.Hand.Count;
            var maxHand = PlayerConstants.MaxHandSize;
            var cardsToDraw = maxHand - start;

            if (cardsToDraw > 0)
            {
                var deck = game.Deck;
                var drawnCards = DeckManager.Draw(deck, cardsToDraw);
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
