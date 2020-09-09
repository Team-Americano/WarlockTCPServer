using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic;

namespace WarlockTCPServer.POCOs
{
    public class CombatPOCO : POCO
    {



        public Queue<object> RQE { get; set; } // TODO: Change object to thing
        public GameState Game { get; set; }
    }
}
