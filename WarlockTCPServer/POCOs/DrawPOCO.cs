using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.POCOs
{
    public class DrawPOCO : POCO
    {
        public List<Actor> Hand { get; set; }
    }
}
