using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WarlockTCPServer.GameLogic.ActorComponents;

namespace WarlockTCPServer.POCOs
{
    public class DrawPOCO : POCO
    {
        [JsonProperty("Hand")]
        public List<Actor> Hand;

        [JsonProperty("Round")]
        public short Round;
    }
}
