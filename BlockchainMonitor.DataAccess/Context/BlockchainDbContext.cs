using System;
using System.Data.Entity;
using BlockchainMonitor.DataModels.Blockchain;
using BlockchainMonitor.DataModels.Participants;

namespace BlockchainMonitor.DataAccess.Context
{
    public class BlockchainDbContext : DbContext, IBlockchainDbContext
    {
        private readonly IRepository<int, Participant> _participants;
        private readonly IRepository<int, Node> _nodes;
        private readonly IRepository<int, Block> _blocks;
        private readonly IRepository<int, SmartContract> _smartContracts;
        private readonly IRepository<string, Transaction> _transactions;

        static BlockchainDbContext()
        {
            // Workaround for SqlClient provider missing in the site bin folder after build
            var ensureSqlClientProvider = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public BlockchainDbContext()
            : base("BlockchainMonitor")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlockchainDbContext, Migrations.StaticContent.Configuration>(true));

            _participants = new RepositoryBase<int, Participant>(this, i => i.Id);
            _nodes = new RepositoryBase<int, Node>(this, i => i.Id);
            _blocks = new RepositoryBase<int, Block>(this, i => i.Id);
            _smartContracts = new RepositoryBase<int, SmartContract>(this, i => i.Id);
            _transactions = new RepositoryBase<string, Transaction>(this, i => i.Id);
        }

        IRepository<int, Participant> IBlockchainDbContext.Participants
        {
            get
            {
                return _participants;
            }
        }

        IRepository<int, Node> IBlockchainDbContext.Nodes
        {
            get
            {
                return _nodes;
            }
        }

        IRepository<int, Block> IBlockchainDbContext.Blocks
        {
            get
            {
                return _blocks;
            }
        }

        IRepository<int, SmartContract> IBlockchainDbContext.SmartContracts
        {
            get
            {
                return _smartContracts;
            }
        }

        IRepository<string, Transaction> IBlockchainDbContext.Transactions
        {
            get
            {
                return _transactions;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Participant>().ToTable("Participants");
            modelBuilder.Entity<Node>().ToTable("Nodes");
            modelBuilder.Entity<Block>().ToTable("Blocks");
            modelBuilder.Entity<SmartContract>().ToTable("SmartContracts");
            modelBuilder.Entity<Transaction>().ToTable("Transactions");
        }
    }
}