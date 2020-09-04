using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WarlockTCPServer.NetworkClasses
{
    public class Client
    {
        public string PlayerId { get; private set; }
        public TcpClient TcpClient { get; private set; }

        public Client(string playerId, TcpClient tcpClient)
        {
            PlayerId = playerId;
            TcpClient = tcpClient;
        }
    }
}
