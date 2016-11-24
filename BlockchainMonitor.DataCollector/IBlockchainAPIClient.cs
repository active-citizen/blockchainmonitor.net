using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataCollector.Model;

namespace BlockchainMonitor.DataCollector
{
    public interface IBlockchainAPIClient
    {
        BlockchainState GetBlockchainState();
        Block GetBlock(uint id);
        Transaction GetTransaction(string id);
    }
}
