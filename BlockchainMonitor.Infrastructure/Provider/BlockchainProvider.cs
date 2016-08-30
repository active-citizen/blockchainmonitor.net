using BlockchainMonitor.DataModels;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataAccess;
using BlockchainMonitor.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using BlockchainMonitor.DataModels.Participants;
using BlockchainMonitor.RedisClient;

namespace BlockchainMonitor.Infrastructure.Provider
{
    public class BlockchainProvider : IBlockchainProvider
    {
        private readonly IBlockchainDbContext _blockchainDbContext;
        private readonly IRepository _redis;

        public BlockchainProvider(IBlockchainDbContext blockchainDbContext, IRepository redis)
        {
            _blockchainDbContext = blockchainDbContext;
            _redis = redis;
        }

        public List<Block> GetAllBlocks()
        {
            return _blockchainDbContext.Blocks.GetAll().ToList();
        }

        public List<Transaction> GetLastTransactions()
        {
            return _redis.GetLastTransactions() ?? new List<Transaction>();
        }

        public Statistics GetAllStatistics()
        {
            var stat = new Statistics()
            {
                BlocksCount = 123,
                TransactionsCount = 23444,
                SmartContractsCount = 23,
                ValidatingNodesCount = 4,
                NonValidatingNodesCount = 4,
                DataBaseSizeGB = 1.3,
            };
            return stat;
        }

        public List<Participant> GetAllParticipants()
        {
            return _blockchainDbContext.Participants.GetAll().ToList();
        }
    }
}