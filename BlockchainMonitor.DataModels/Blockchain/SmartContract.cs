using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.DataModels.Blockchain
{
    public class SmartContract
    {
        [Key()]
        public int Id { get; set; }

        public byte [] ChainCodeId { get; set; }

        public virtual List<Transaction> Transactions { get; set; }

        public byte [] ChainCode { get; set; }
    }
}