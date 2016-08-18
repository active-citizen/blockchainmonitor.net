using System.Collections.Generic;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataModels.Participants;

namespace BlockchainMonitor.Infrastructure.Provider
{
    public interface IBlockchainProvider
    {
        List<Block> GetAllBlocks();

        Statistics GetAllStatistics();

        List<Transaction> GetLastTransactions();

        List<Participant> GetAllParticipants();
    }
}