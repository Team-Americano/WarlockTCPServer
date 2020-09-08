using System;
using System.Collections.Generic;
using System.Text;

namespace WarlockTCPServer.POCOs
{
    public class CombatPOCO : POCO
    {
        public RenderQueueEntry[] RenderQueueEntries { get; set; }
    }
}
