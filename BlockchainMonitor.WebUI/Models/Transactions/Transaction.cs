using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.Models.Transactions
{
    public class Transaction
    {
        [Key()]
        [Description("Идентификатор")]
        public string Id { get; set; }

        [Description("Смарт контракт")]
        public SmartContract SmartContract { get; set; }

        [Description("Время транзакции")]
        public DateTime Time { get; set; }

        [Description("Данные")]
        public string Data { get; set; }

        const int _maxDataLength = 10;
        [Description("Данные")]
        public string ShortData
        {
            get
            {
                if (string.IsNullOrEmpty(Data)) return String.Empty;
                return Data.Length <= _maxDataLength ? Data : Data.Substring(0, _maxDataLength);
            }
        }
    }
}