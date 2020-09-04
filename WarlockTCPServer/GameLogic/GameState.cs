using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic
{
    public class GameState
    {
        public short RoundCounter { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Actor.Actor[] DrawDeck { get; set; }
        public Actor.Actor[] DiscardDeck { get; set; }

        public GameState(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
    }
}
