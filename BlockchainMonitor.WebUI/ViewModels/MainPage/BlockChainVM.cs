using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockchainMonitor.WebUI.ViewModels.MainPage
{
    public class BlockChainVM
    {
        public List<BlockVM> AllBlocks { get; set; }

        public StatisticVM Statistic { get; set; }

        public List<Transaction> LastTransactions { get; set; }

        public List<Participant> AllParticipants { get; set; }

    }
}