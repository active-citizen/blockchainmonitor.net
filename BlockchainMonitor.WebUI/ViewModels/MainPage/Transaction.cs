using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class Transaction
    {
        [Key()]
        [Description("Идентификатор")]
        public string Id { get; set; }

        [Description("Смартконтракт")]
        public string SmartContractId { get; set; }

        [Description("Время")]
        public DateTime Time { get; set; }

        [Description("Данные")]
        public string Data { get; set; }
    }
}