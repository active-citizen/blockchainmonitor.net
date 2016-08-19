using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainMonitor.DataModels.Aggregated
{
    public class Statistics
    {
        public int BlocksCount { get; set; }

        public int TransactionsCount { get; set; }

        public int SmartContractsCount { get; set; }

        public int ValidatingNodesCount { get; set; }

        public int NonValidatingNodesCount { get; set; }

        public double DataBaseSizeGB { get; set; }


    }
}
