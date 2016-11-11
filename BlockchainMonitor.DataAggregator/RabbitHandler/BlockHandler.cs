using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockchainMonitor.DataAccess.Context;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.RabbitClient;
using BlockchainMonitor.RedisClient;

namespace BlockchainMonitor.DataAggregator.RabbitHandler
{
    public class BlockHandler : MessageHandlerBase<Block>
    {
        private readonly IBlockchainDbContext _database;
        private readonly IRepository _redis;

        public BlockHandler(IBlockchainDbContext context, IRepository redis)
        {
            _database = context;
            _redis = redis;
        }

        public override void Handle(Block block)
        {
            if (_database.Blocks.GetById(block.Id) == null)
                _database.Blocks.Insert(block);


        }
    }
}
