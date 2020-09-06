namespace WarlockTCPServer.GameLogic
{
    public class Player
    {
        public string ClientId { get; set; }
        public Actor[] Party { get; set; }
        public Actor[] Hand { get; set; }
        public short Mana { get; set; }
        public short Score { get; set; }

        // TODO: Add constructor(s)
    }
}
