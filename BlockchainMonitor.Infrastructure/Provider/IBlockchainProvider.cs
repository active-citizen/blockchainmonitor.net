using System.Collections.Generic;
using BlockchainMonitor.DataModels.Blockchain;

namespace BlockchainMonitor.Infrastructure.Provider
{
    public interface IBlockchainProvider
    {
        List<Block> GetAllBlocks();
    }
}