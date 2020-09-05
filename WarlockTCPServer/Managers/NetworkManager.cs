using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using WarlockTCPServer.NetworkClasses;

namespace WarlockTCPServer.Managers
{
    public static class NetworkManager
    {
        public static List<Client> Clients { get; set; }

        private static int _bufferSize = 1024 * 2;
        public static List<Packet> Packets { get; set; }
        private static int _maxPlayers = 2;
        private static int _port = 28852;
        private static IPAddress _ipAddress = IPAddress.Any;
        private static TcpListener _listener;

        private static int _timeStep = 10;
        public static bool Running { get; private set; } = false;

        public static void Start()
        {
            Clients = new List<Client>();
            Packets = new List<Packet>();

            _listener = new TcpListener(_ipAddress, _port);


            _listener.Start();
            FindClients();
            GameManager.Setup();
            Run();
        }

        public static void FindClients()
        {
            while (Clients.Count != _maxPlayers)
            {
                Console.WriteLine("Waiting for clients...");

                if (_listener.Pending())
                {
                    var client = _listener.AcceptTcpClient();
                    client.SendBufferSize = _bufferSize;
                    client.ReceiveBufferSize = _bufferSize;
                    var newClient = new Client(Clients.Count.ToString(), client);
                    Clients.Add(newClient);
                    SendHello(newClient.PlayerId, client);
                }

                Thread.Sleep(_timeStep);
            }
        }

        public static void SendHello(string playerId, TcpClient client)
        {
            Packet helloPacket = new Packet
            {
                PlayerId = playerId,
                CommandId = (short)CommandId.hello
            };

            Console.WriteLine($"Sending Hello to {playerId}");

            SendPacket(client, helloPacket);
        }

        public static void Run()
        {
            Running = true;

            while (Running)
            {
                ReceivePackets();
                CheckForDisconnects();
                Thread.Sleep(_timeStep);
            }

            DisconnectClientAll();
            _listener.Stop();
        }

        public static void ReceivePackets()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                var client = Clients[i].TcpClient;
                if (client.Available > 0)
                {
                    byte[] incoming = new byte[client.Available];
                    client.GetStream().Read(incoming, 0, incoming.Length);

                    string incomingStr = Encoding.UTF8.GetString(incoming);
                    Packet packet = JsonConvert.DeserializeObject<Packet>(incomingStr); // Install newtonsoft

                    Packets.Add(packet);
                }
            }
        }

        public static void SendPacket(TcpClient tcpClient, Packet packet)
        {
            string jsonStr = JsonConvert.SerializeObject(packet);
            byte[] buffer = Encoding.UTF8.GetBytes(jsonStr);
            tcpClient.GetStream().Write(buffer, 0, buffer.Length);
        }

        public static void SendPacketsAll(Packet packet)
        {
            foreach (var client in Clients)
            {
                SendPacket(client.TcpClient, packet);
            }
        }

        private static void CheckForDisconnects()
        {
            foreach (var client in Clients)
            {
                if (!client.TcpClient.Connected)
                {
                    DisconnectClient(client);
                }
            }
        }
        private static void DisconnectClientAll()
        {
            foreach (var client in Clients)
            {
                DisconnectClient(client);
            }
        }

        private static void DisconnectClient(Client client)
        {
            Clients.Remove(client);
            var tcpClient = client.TcpClient;
            tcpClient.GetStream().Close();
            tcpClient.Close();
        }

    }
}
