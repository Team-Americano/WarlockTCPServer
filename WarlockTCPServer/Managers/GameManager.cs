using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarlockTCPServer.GameLogic;
using WarlockTCPServer.GameLogic.ActorComponents;
using WarlockTCPServer.NetworkClasses;
using WarlockTCPServer.POCOs;

namespace WarlockTCPServer.Managers
{
    // Tests 100
    // Draw Phase 200
    // Draft Phase 300
    // Reposition Phase 400
    // Combat Commands 500
    public enum CommandId
    {
        test = 42,
        hello = 100,
        draw = 200,
        draft = 300,
        acknowlegdeDraft = 301,
        partyReposition = 400,
        acknowlegdeReposition = 401
    }

    public static class GameManager
    {
        private delegate Task Command(Packet packet);
        private static Dictionary<CommandId, Command> _commands;
        public static List<GameState> Games = new List<GameState>(); // Stopped Testing here
        // will include a static dic of game states

        public static void Setup()
        {
            _commands = new Dictionary<CommandId, Command>()
            {
                { CommandId.test, Test },
                { CommandId.hello, Hello },
                //{ CommandId.draw, Draw },
                { CommandId.draft, Draft },
                { CommandId.acknowlegdeDraft, AcknowlegdeDraft },
                { CommandId.partyReposition, PartyReposition },
                { CommandId.acknowlegdeReposition, AcknowledgeReposition }
            };

            SetupNewGame();
        }

        public static void SetupNewGame()
        {
            // =============== This is hard coded NEEDS TO BE CHANGED ================
            // probably could add a property of running in game state and have it changed once it's initialized. 
            Games.Add(new GameState());

            Games[0].Player1.ClientId = NetworkManager.Clients[0].PlayerId;
            // Games[0].Player2.ClientId = NetworkManager.Clients[1].PlayerId; Commented out for testing

            Games[0].Player1.Mana = 0;
            Games[0].Player2.Mana = 0; 

            Games[0].Player1.Score = 0;
            Games[0].Player2.Score = 0;

            Games[0].Player1.Hand = new List<Actor>();
            Games[0].Player2.Hand = new List<Actor>();

            Games[0].Player1.Party = new List<Actor>();
            Games[0].Player2.Party = new List<Actor>();
            // =======================================================================
        }

        public static void RunGameLoop()
        {
            // ============== Planned Turn Order =============
            // 1. Choose who goes first - state machine
            // 2. 1st player that round Draws
            // 3. 1st player that round drafts
            // 4. 1st player that round repos party
            // 5. Update both clients with that info
            // 6. 2nd player that round Draws
            // 7. 2nd player that round drafts
            // 8. 2nd player that round repos party
            // 9. Update both clients with that info
            // 10. Combat logic (game)
            // 11. Send those commands to the client
            // 12. End round logic
            // 13. Updated client based off of end round logic
            // ================================================

            while (NetworkManager.Packets.Count > 0)
            {
                lock (NetworkManager.Packets)
                {
                    foreach (var packet in NetworkManager.Packets)
                    {
                        HandleCommand(packet);
                    }
                }
            }
        }

        public static void HandleCommand(Packet packet)
        {
            var commandId = (CommandId)packet.CommandId;

            if (_commands.ContainsKey(commandId))
            {
                _commands[commandId].Invoke(packet);
            }
        }

        public static Task Test(Packet packet)
        {
            TestPOCO poco = JsonConvert.DeserializeObject<TestPOCO>(packet.POCOJson);
            var commandId = (CommandId)packet.CommandId;
            Console.WriteLine(poco.Line);
            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            //if (client != null)
            //{
            //    NetworkManager.SendPacket(client.TcpClient, packet);
            //}

            return Task.FromResult(0);
        }

        public static Task Hello(Packet packet)
        {
            Console.WriteLine("Hello");

            return Task.FromResult(0);
        }


        public static Task Draw(string playerId)
        {
            List<Actor> hand = new List<Actor>();

            if (playerId == Games[0].Player1.ClientId)
            {
                hand = DrawManager.DrawCards(Games[0].Player1, Games[0]);
            }
            else if (playerId == Games[0].Player2.ClientId)
            {
                hand = DrawManager.DrawCards(Games[0].Player2, Games[0]);
            }
            else
            {
                throw new Exception("There was no player selected.");
            }

            DrawPOCO drawPoco = new DrawPOCO { Hand = hand };

            Packet packet = new Packet
            {
                CommandId = (short)CommandId.draw,
                PlayerId = playerId,
                POCOJson = JsonConvert.SerializeObject(drawPoco)
            };

            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            //if (playerId != null)
            //{
            //    NetworkManager.SendPacket(client.TcpClient, packet);
            //}


            return Task.FromResult(0);
        }

        public static Task Draft(Packet packet)
        {
            DraftPOCO poco = JsonConvert.DeserializeObject<DraftPOCO>(packet.POCOJson);

            Tuple<List<Actor>, List<Actor>, short> partyHandMana = null;

            if (packet.PlayerId == Games[0].Player1.ClientId)
            {
                partyHandMana = DraftManager.DraftParty(Games[0].Player1, Games[0], poco.Party, poco.Hand, poco.Mana);
            }
            else if (packet.PlayerId == Games[0].Player2.ClientId)
            {
                partyHandMana = DraftManager.DraftParty(Games[0].Player2, Games[0], poco.Party, poco.Hand, poco.Mana);
            }

            DraftPOCO draftPoco = new DraftPOCO
            {
                Party = partyHandMana.Item1,
                Hand = partyHandMana.Item2,
                Mana = partyHandMana.Item3
            };

            Packet outputPacket = new Packet
            {
                CommandId = (short)CommandId.draft,
                PlayerId = packet.PlayerId,
                POCOJson = JsonConvert.SerializeObject(draftPoco)
            };

            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            //if (client != null)
            //{
            //    NetworkManager.SendPacket(client.TcpClient, outputPacket);
            //}

            return Task.FromResult(0);
        }

        public static Task AcknowlegdeDraft(Packet packet)
        {
            // ANTI-CHEATING
            // =================== Acknowledge Draft ============
            // 1. Send a green flag for the player to continue

            return Task.FromResult(0);
        }

        public static Task PartyReposition(Packet packet)
        {
            // ================ Party Reposition ===============
            // 1. get the current player
            // 2. Send current player to the Party Reposition Manger
            // 3. Get the new party array/list and send it to the Network Manager

            PartyRepositionPOCO poco = JsonConvert.DeserializeObject<PartyRepositionPOCO>(packet.POCOJson);
            List<Actor> party = new List<Actor>();

            if (packet.PlayerId == Games[0].Player1.ClientId)
            {
                party = PartyRepositionManager.PartyReposition(Games[0].Player1, poco.Party);
            }
            else if (packet.PlayerId == Games[0].Player2.ClientId)
            {
                party = PartyRepositionManager.PartyReposition(Games[0].Player2, poco.Party);
            }

            PartyRepositionPOCO outputPoco = new PartyRepositionPOCO()
            {
                Party = party
            };

            Packet outputPacket = new Packet
            {
                CommandId = (short)CommandId.partyReposition,
                PlayerId = packet.PlayerId,
                POCOJson = JsonConvert.SerializeObject(outputPoco)
            };

            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            //if (client != null)
            //{
            //    NetworkManager.SendPacket(client.TcpClient, outputPacket);
            //}

            return Task.FromResult(0);
        }

        public static Task AcknowledgeReposition(Packet packet)
        {
            // ANTI-CHEATING
            // =========================  Acknowledge Repo ==================
            // 1. Send a green flag to the players
            // 2. send the new updated state to the clients.
            // 3. Start the Combat phase?

            return Task.FromResult(0);
        }

    }
}
