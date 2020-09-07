using System;
using System.Collections.Generic;
using System.Text;
using WarlockTCPServer.POCOs;

namespace WarlockTCPServer.NetworkClasses
{
    public class Packet
    {
        public short CommandId { get; set; }
        public string PlayerId { get; set; }
        public string POCOJson { get; set; }
    }
}
