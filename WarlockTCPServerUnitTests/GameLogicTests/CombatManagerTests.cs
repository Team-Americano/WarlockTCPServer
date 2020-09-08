using Xunit;
using System.Linq;
using WarlockTCPServer.GameLogic;
using static WarlockTCPServer.Managers.CombatManager;
using static WarlockTCPServer.Managers.GameStateData.DeckManager;

namespace WarlockTCPServerUnitTests.GameLogicTests
{
    public class CombatManagerTests
    {
        [Fact]
        public void CombatRunsWithoutException()
        {
            GameState game = new GameState();
            game.Player1.Party = Draw(game.Deck, 6).ToList();
            game.Player2.Party = Draw(game.Deck, 6).ToList();

            // TODO: Test for correct command output
            var plainObject = RunAttackPhase(game);

            Assert.NotNull(plainObject);
        }
    }
}
