using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace BlockchainMonitor.WebUI.Hubs
{
    public class BlockchainHub : Hub
    {
        public void NewTransaction(int transactionsCount)
        {
            Clients.All.lastBlockTransactionCount(transactionsCount);
        }

        public static BlockchainHub Instance = new BlockchainHub();
    }
}