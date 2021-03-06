﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    // State update 600
    public enum CommandId
    {
        test = 42,
        hello = 100,
        startUp = 101,
        draw = 200,
        draft = 300,
        acknowlegdeDraft = 301,
        partyReposition = 400,
        acknowlegdeReposition = 401,
        combat = 500,
        combatEnd = 501,
        gameStateUpdate = 600
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
                { CommandId.acknowlegdeDraft, AcknowledgeDraft },
                { CommandId.partyReposition, PartyReposition },
                { CommandId.acknowlegdeReposition, AcknowledgeReposition }
            };
        }

        public static void SetupNewGame()
        {
            // =============== This is hard coded NEEDS TO BE CHANGED ================
            // probably could add a property of running in game state and have it changed once it's initialized. 
            Games.Add(new GameState());

            Games[0].Player1.ClientId = NetworkManager.Clients[0].PlayerId;
            Games[0].Player2.ClientId = NetworkManager.Clients[1].PlayerId;

            Games[0].RoundCounter = 1;

            Games[0].Player1.Mana = 0;
            Games[0].Player2.Mana = 0;

            Games[0].Player1.Score = 0;
            Games[0].Player2.Score = 0;

            Games[0].Player1.Hand = new List<Actor>();
            Games[0].Player2.Hand = new List<Actor>();

            Games[0].Player1.Party = new List<Actor>();
            Games[0].Player2.Party = new List<Actor>();
            // =======================================================================

            SendGameSetup(Games[0]);
        }

        public static Task SendGameSetup(GameState game)
        {
            GameSetupPOCO poco = new GameSetupPOCO()
            {
                Player1Id = Games[0].Player1.ClientId,
                Player2Id = Games[0].Player2.ClientId
            };

            Packet packet = new Packet()
            {
                CommandId = (short)CommandId.startUp,
                POCOJson = JsonConvert.SerializeObject(poco)
            };

            NetworkManager.SendPacketsAll(packet);

            return Task.FromResult(0);
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

            bool player1Priority = Games[0].RoundCounter % 1 == 0 ? true : false;
            if (player1Priority)
            {
                Draw(Games[0].Player1.ClientId);
                WaitForDraftPacket(Games[0].Player1.ClientId);

                UpdateAllClient(Games[0]);

                Draw(Games[0].Player2.ClientId);
                WaitForDraftPacket(Games[0].Player2.ClientId);
            }
            else
            {
                Draw(Games[0].Player2.ClientId);
                WaitForDraftPacket(Games[0].Player2.ClientId);

                UpdateAllClient(Games[0]);

                Draw(Games[0].Player1.ClientId);
                WaitForDraftPacket(Games[0].Player1.ClientId);
            }

            UpdateAllClient(Games[0]);

            Combat();
            WaitForCombatEnd(Games[0].Player1.ClientId);
            WaitForCombatEnd(Games[0].Player2.ClientId);

            EndOfRoundLogic(Games[0]);

            UpdateAllClient(Games[0]); // Not sure if we need this.


            //while (NetworkManager.Packets.Count > 0)
            //{
            //    lock (NetworkManager.Packets)
            //    {
            //        foreach (var packet in NetworkManager.Packets)
            //        {
            //            HandleCommand(packet);
            //        }
            //    }
            //}
        }

        public static Task HandleCommand(Packet packet)
        {
            var commandId = (CommandId)packet.CommandId;

            if (_commands.ContainsKey(commandId))
            {
                _commands[commandId].Invoke(packet);
                NetworkManager.Packets.Remove(packet);
            }

            return Task.FromResult(0);
        }

        public static Task Test(Packet packet)
        {
            TestPOCO poco = JsonConvert.DeserializeObject<TestPOCO>(packet.POCOJson);
            var commandId = (CommandId)packet.CommandId;
            Console.WriteLine(poco.Line);
            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            if (client != null)
            {
                NetworkManager.SendPacket(client.TcpClient, packet);
            }

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

            DrawPOCO drawPoco = new DrawPOCO
            {
                Hand = hand,
                Round = Games[0].RoundCounter
            };

            var pocoStr = JsonConvert.SerializeObject(drawPoco);

            Packet packet = new Packet
            {
                CommandId = (short)CommandId.draw,
                PlayerId = playerId,
                POCOJson = pocoStr
            };

            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            if (playerId != null)
            {
                Console.WriteLine(packet.CommandId);
                Console.WriteLine(packet.POCOJson);
                NetworkManager.SendPacket(client.TcpClient, packet);
            }
            else
            {
                throw new Exception("There was an error with the hand");
            }

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

            return Task.FromResult(0);
        }

        public static Task AcknowledgeDraft(Packet packet)
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

            if (client != null)
            {
                NetworkManager.SendPacket(client.TcpClient, outputPacket);
            }

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

        private static Task WaitForDraftPacket(string playerId)
        {
            // ================= Yes we know its hacky =====================
            Packet draftPacket = null;

            while (draftPacket == null)
            {
                lock (NetworkManager.Packets)
                {
                    draftPacket = NetworkManager.Packets.Where(x => x.CommandId == (short)CommandId.draft && x.PlayerId == playerId).FirstOrDefault();
                }

                NetworkManager.ReceivePackets();

                Thread.Sleep(100);
            }

            if (draftPacket.CommandId == (short)CommandId.draft)
            {
                HandleCommand(draftPacket);
            }
            else
            {
                throw new Exception("There was an error in the order");
            }

            return Task.FromResult(0);
        }

        private static Task Combat()
        {
            var combatQueue = CombatManager.RunAttackPhase(Games[0]);

            CombatPOCO combatPoco = new CombatPOCO()
            {
                RenderQueueEntries = combatQueue
            };

            Packet packet = new Packet()
            {
                CommandId = (short)CommandId.combat,
                POCOJson = JsonConvert.SerializeObject(combatPoco)
                // May need to add player
            };

            Console.WriteLine(packet.CommandId);
            Console.WriteLine(packet.POCOJson);
            NetworkManager.SendPacketsAll(packet);

            return Task.FromResult(0);
        }

        private static Task WaitForCombatEnd(string playerId)
        {
            Packet combatEndPacket = null;

            while (combatEndPacket == null)
            {
                lock (NetworkManager.Packets)
                {
                    combatEndPacket = NetworkManager.Packets.Where(x => x.CommandId == (short)CommandId.combatEnd && x.PlayerId == playerId).FirstOrDefault();
                }

                NetworkManager.ReceivePackets();

                Thread.Sleep(100);
            }

            return Task.FromResult(0);
        }

        private static Task UpdateAllClient(GameState game)
        {
            GameStatePOCO gameStatePOCO = new GameStatePOCO()
            {
                Player1Party = Games[0].Player1.Party,
                Player1Id = Games[0].Player1.ClientId,
                Player2Party = Games[0].Player2.Party,
                Player2Id = Games[0].Player2.ClientId,
                RoundCounter = Games[0].RoundCounter
            };

            Packet packet = new Packet()
            {
                CommandId = (short)CommandId.gameStateUpdate,
                POCOJson = JsonConvert.SerializeObject(gameStatePOCO)
            };

            Console.WriteLine(packet.CommandId);
            Console.WriteLine(packet.POCOJson);
            NetworkManager.SendPacketsAll(packet);

            return Task.FromResult(0);
        }

        private static Task EndOfRoundLogic(GameState game)
        {
            int winAmount = 3;
            if (Games[0].Player1.Score >= winAmount)
            {
                PlayerWins(Games[0].Player1);
            }
            else if (Games[0].Player2.Score >= winAmount)
            {
                PlayerWins(Games[0].Player2);
            }

            Games[0].RoundCounter++;

            EndOfRoundManager.IncreaseMana(Games[0]);

            return Task.FromResult(0);
        }

        private static Task PlayerWins(Player player)
        {
            Console.WriteLine($"{player} wins the game.");
            NetworkManager.Running = false;

            return Task.FromResult(0);
        }

    }
}
