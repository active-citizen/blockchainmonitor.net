using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.ComponentModel;

namespace BlockchainMonitor.WebUI.Models.Participants
{
    public class Server
    {
        [Description("IP адрес")]
        public IPAddress IPAddress { get; set; }

        public Status Status { get; set; }

        public bool IsValidated { get; set; }
    }

    public enum Status
    {
        Dead = 0,
        Alive = 1,
    }
}