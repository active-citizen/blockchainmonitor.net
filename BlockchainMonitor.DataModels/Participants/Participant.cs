using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.DataModels.Participants
{
    public class Participant
    {
        [Key()]
        public int Id { get; set; }

        public string Name { get; set; }

        public string WebSite { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public virtual List<Node> Nodes { get; set; }
    }
}