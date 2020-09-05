using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarlockTCPServer.NetworkClasses;
using WarlockTCPServer.POCOs;

namespace WarlockTCPServer.Managers
{
    public enum CommandId
    {
        test = 42,
        hello = 100
    }

    public static class GameManager
    {
        private delegate Task Command(Packet packet);
        private static Dictionary<CommandId, Command> _commands;
        // will include a static dic of game states

        public static void Setup()
        {
            _commands = new Dictionary<CommandId, Command>()
            {
                {CommandId.test, Test }
                //{CommandId.hello, Hello }
            };
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
            TestPOCO poco = (TestPOCO)packet.POCO;
            var commandId = (CommandId)packet.CommandId;
            Console.WriteLine(poco.Line);
            var client = NetworkManager.Clients.Where(x => x.PlayerId == packet.PlayerId).FirstOrDefault();

            if (client != null)
            {
                NetworkManager.SendPacket(client.TcpClient, packet);
            }

            return Task.FromResult(0);
        }

    }
}
