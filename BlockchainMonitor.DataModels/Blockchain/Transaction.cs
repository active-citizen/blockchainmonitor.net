using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.DataModels.Blockchain
{
    public class Transaction
    {
        [Key()]
        public string Id { get; set; }

        public SmartContract SmartContract { get; set; }

        public Block Block { get; set; }

        public DateTime Time { get; set; }

        public byte [] Data { get; set; }

        //const int _maxDataLength = 10;
        //[Description("Данные")]
        //public string ShortData
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(Data)) return String.Empty;
        //        return Data.Length <= _maxDataLength ? Data : Data.Substring(0, _maxDataLength);
        //    }
        //}
    }
}