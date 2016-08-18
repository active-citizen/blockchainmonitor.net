namespace BlockchainMonitor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IPAddressChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nodes", "IPAddress", c => c.String());
            DropColumn("dbo.Nodes", "IPAddress_Address");
            DropColumn("dbo.Nodes", "IPAddress_ScopeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nodes", "IPAddress_ScopeId", c => c.Long(nullable: false));
            AddColumn("dbo.Nodes", "IPAddress_Address", c => c.Long(nullable: false));
            DropColumn("dbo.Nodes", "IPAddress");
        }
    }
}
