using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlockchainMonitor.DataModels.Participants
{
    public class Node
    {
        [Key()]
        public int Id { get; set; }

        public string Name { get; set; }

        public string IPAddress { get; set; }

        public Participant Participant { get; set; }

        public bool IsValidator { get; set; }
    }
}