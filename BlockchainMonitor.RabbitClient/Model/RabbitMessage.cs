using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.RabbitClient.Model
{
    public class RabbitMessage
    {
        public Type ObjType { get; set; }

        public string JsonObject { get; set; }
    }
}
