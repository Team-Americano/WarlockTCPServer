using Microsoft.Playfab.Gaming.GSDK.CSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using WarlockTCPServer.NetworkClasses;

namespace WarlockTCPServer.Managers
{
    public static class NetworkManager
    {
        public static List<ConnectedPlayer> Clients { get; set; }

        private static int _bufferSize = 1024 * 2;
        public static List<Packet> Packets { get; set; }
        private static int _maxPlayers = 1;
        private static int _port = 28852;
        private static IPAddress _ipAddress = IPAddress.Any;
        private static TcpListener _listener;
        
        private static int _timeStep = 30;
        public static bool Running { get; private set; } = false;

        public static void Start()
        {
            Clients = new List<ConnectedPlayer>();
            Packets = new List<Packet>();

            _listener = new TcpListener(_ipAddress, _port);

            try
            {
                GameserverSDK.Start();
            }
            catch (GSDKInitializationException initEx)
            {
                GameserverSDK.LogMessage("Cannot start GSDK. Please make sure the MockAgent is running. ");
                GameserverSDK.LogMessage($"Got Exception: {initEx.ToString()}");
                return;
            }

            GameserverSDK.RegisterShutdownCallback(OnShutdown);
            GameserverSDK.RegisterHealthCallback(IsHealthy);
            GameserverSDK.RegisterMaintenanceCallback(OnMaintenanceScheduled);

            _listener.Start();
            if(GameserverSDK.ReadyForPlayers()) FindClients();
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

                    string playerTag = Clients.Count.ToString();
                    var newClient = new Client(playerTag, client);

                    Clients.Add(newClient);
                    GameserverSDK.UpdateConnectedPlayers(Clients);

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
                GameManager.RunGameLoop();
                Thread.Sleep(_timeStep);
            }

            OnShutdown();
        }

        private static void OnShutdown()
        {
            GameserverSDK.LogMessage("Shutting down...");
            DisconnectClientAll();
            _listener.Stop();
        }

        private static bool IsHealthy()
        {
            return Running;
        }

        private static void OnMaintenanceScheduled(DateTimeOffset time)
        {
            Console.WriteLine("Maintenance scheduled at " + time.ToString());
        }

        public static void ReceivePackets()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                var client = GetTcpClient(i);
                if (client.Available > 0)
                {
                    byte[] incoming = new byte[client.Available];
                    client.GetStream().Read(incoming, 0, incoming.Length);

                    string incomingStr = Encoding.UTF8.GetString(incoming);
                    Packet packet = JsonConvert.DeserializeObject<Packet>(incomingStr);

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
            for (int i = 0; i < Clients.Count; i++)
            {
                SendPacket(GetTcpClient(i), packet);
            }
        }

        private static void CheckForDisconnects()
        {
            for (int i = 0; i < Clients.Count; i++)
            {
                var client = GetTcpClient(i);

                if (!client.Connected)
                {
                    DisconnectClient(Clients[i]);
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

        private static void DisconnectClient(ConnectedPlayer client)
        {
            Clients.Remove(client);
            var tcpClient = GetTcpClient(int.Parse(client.PlayerId));
            tcpClient.GetStream().Close();
            tcpClient.Close();
        }

        public static TcpClient GetTcpClient(int id)
        {
            var client = (Client)Clients[id];
            return client.TcpClient;
        }

    }
}
