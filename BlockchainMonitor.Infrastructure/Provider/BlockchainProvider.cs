﻿using BlockchainMonitor.DataModels;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Aggregated;
using BlockchainMonitor.DataAccess;
using BlockchainMonitor.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainMonitor.Infrastructure.Provider
{
    public class BlockchainProvider : IBlockchainProvider
    {
        private readonly IBlockchainDbContext blockchainDbContext;

        public BlockchainProvider(IBlockchainDbContext blockchainDbContext)
        {
            this.blockchainDbContext = blockchainDbContext;
        }

        public List<Block> GetAllBlocks()
        {
            return blockchainDbContext.Blocks.GetAll().ToList();
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
    }
}