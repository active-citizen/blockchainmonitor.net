using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.DataModels.Blockchain
{
    public class Block
    {
        [Key()]
        public int Id { get; set; }

        public int Number { get; set; }

        public List<Transaction> Transactions { get; set; }

        public string Hash { get; set; }

        public bool IsClosed { get; set; }

    }
}
