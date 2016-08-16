using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.Models.Transactions
{
    public class SmartContract
    {
        [Key()]
        [Description("Идентификатор")]
        public string Id { get; set; }

        [Description("Транзакции")]
        public List<Transaction> Transactions { get; set; }
    }
}