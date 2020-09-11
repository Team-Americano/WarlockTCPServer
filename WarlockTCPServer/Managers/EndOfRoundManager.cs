using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using WarlockTCPServer.GameLogic;

namespace WarlockTCPServer.Managers
{
    public static class EndOfRoundManager
    {
        public static void IncreaseMana(GameState game) 
        {
            short manaCounter = 2;
            short howManyRoundsIncreaseManaCount = 2;

            if (game.RoundCounter % howManyRoundsIncreaseManaCount == 0)
            {
                manaCounter++;
            }

            game.Player1.Mana += manaCounter;
            game.Player2.Mana += manaCounter;
        }
    }
}
