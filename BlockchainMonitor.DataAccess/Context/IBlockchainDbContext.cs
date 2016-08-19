using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Participants;

namespace BlockchainMonitor.DataAccess.Context
{
    public interface IBlockchainDbContext
    {
        IRepository<int, Participant> Participants { get; }

        IRepository<int, Node> Nodes { get; }

        IRepository<int, Block> Blocks { get; }

        IRepository<int, SmartContract> SmartContracts { get; }

        IRepository<string, Transaction> Transactions { get; }
    }
}
