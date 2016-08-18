using System.Collections.Generic;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Aggregated;

namespace BlockchainMonitor.Infrastructure.Provider
{
    public interface IBlockchainProvider
    {
        List<Block> GetAllBlocks();

        Statistics GetAllStatistics();
    }
}