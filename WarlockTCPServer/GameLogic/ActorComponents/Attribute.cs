using Newtonsoft.Json;

namespace WarlockTCPServer.GameLogic.ActorComponents
{
    public class Attribute
    {
        [JsonProperty("BaseValue")]
        public short BaseValue { get; set; }
        [JsonProperty("CurrentValue")]
        public short CurrentValue { get; set; }
    }
}
