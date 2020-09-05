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
        public Deck Deck { get; set; }
    }
}
