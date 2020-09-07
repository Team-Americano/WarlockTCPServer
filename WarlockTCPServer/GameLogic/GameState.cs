using WarlockTCPServer.Managers.GameStateData;

namespace WarlockTCPServer.GameLogic
{
    public class GameState
    {
        public short RoundCounter { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Deck Deck { get; set; }

        /// <summary>
        /// Constructor without parameters builds the deck with the standard layout.
        /// </summary>
        public GameState()
        {
            Deck = new Deck();
            DeckManager.Fill(Deck, "BaseDeck");
            DeckManager.Shuffle(Deck);
        }

        public GameState(string deckName)
        {
            Deck = new Deck();
            DeckManager.Fill(Deck, deckName);
            DeckManager.Shuffle(Deck);
        }
    }
}
