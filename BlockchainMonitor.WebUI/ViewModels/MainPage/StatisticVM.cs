using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class StatisticsVM
    {
        public int BlocksCount { get; set; }

        public int TransactionsCount { get; set; }

        public double DataBaseSizeGB { get; set; }

        public int SmartContractsCount { get; set; }

        public int ValidatingNodesCount { get; set; }

        public int NonValidatingNodesCount { get; set; }
    }
}