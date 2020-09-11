using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.POCOs
{
    class GameStatePOCO : POCO
    {
        public short RoundCounter { get; set; }
        public List<Actor> Player1Party { get; set; }
        public string Player1Id { get; set; }
        public List<Actor> Player2Party { get; set; }
        public string Player2Id { get; set; }
    }
}
