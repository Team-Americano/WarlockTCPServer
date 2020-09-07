using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.POCOs
{
    public class DraftPOCO : POCO
    {
        public List<Actor> Party { get; set; }
    }
}
