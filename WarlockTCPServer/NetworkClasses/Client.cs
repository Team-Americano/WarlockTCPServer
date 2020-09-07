using Microsoft.Playfab.Gaming.GSDK.CSharp;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace WarlockTCPServer.NetworkClasses
{
    public class Client : ConnectedPlayer
    {
        public Client(string playerid) : base(playerid)
        {
        }

        public TcpClient TcpClient { get; private set; }
    }
}
