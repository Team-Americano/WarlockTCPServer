using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.Managers
{
    public static class DraftManager
    {
        public static Tuple<List<Actor>, List<Actor>, short> DraftParty(Player player, GameState game, List<Actor> party, List<Actor> hand, short mana)
        {
            short manaCounter = 2;
            short howManyRoundsIncreaseManaCount = 2;

            if (game.RoundCounter % howManyRoundsIncreaseManaCount == 0)
            {
                manaCounter++;
            }

            player.Mana += manaCounter;
            player.Hand = hand;
            player.Party = party;

            // Build logic for discarding actors from their party
            // put those actors in to the game.deck.discardpile

            Tuple<List<Actor>, List<Actor>, short> partyHandMana = new Tuple<List<Actor>, List<Actor>, short>
                (item1: player.Party, item2: player.Hand, item3: player.Mana);            

            return partyHandMana;
        }
    }
}
