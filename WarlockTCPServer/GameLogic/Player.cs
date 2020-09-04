using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.GameLogic
{
    public class Player
    {
        public string ClientId { get; set; }
        public Actor.Actor[] Party { get; set; }
        public Actor.Actor[] Hand { get; set; }
        public short Mana { get; set; }
        public short Score { get; set; }
    }
}
