using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class Participant
    {
        public bool IsAlive { get; set; }

        public Uri ImageUri { get; set; }

        public int ServersAmount { get; set; }

    }
}