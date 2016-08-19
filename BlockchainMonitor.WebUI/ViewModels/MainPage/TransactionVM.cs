using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class TransactionVM
    {
        public string Id { get; set; }

        public string SmartContractId { get; set; }

        public DateTime Time { get; set; }

        public byte [] Data { get; set; }
    }
}