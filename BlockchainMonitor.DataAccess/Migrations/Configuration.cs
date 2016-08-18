namespace BlockchainMonitor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;

    internal sealed partial class Configuration : DbMigrationsConfiguration<BlockchainMonitor.DataAccess.Context.BlockchainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlockchainMonitor.DataAccess.Context.BlockchainDbContext context)
        {
            DefaultPartners(context);
            SampleBlocks(context);
        }
    }
}
