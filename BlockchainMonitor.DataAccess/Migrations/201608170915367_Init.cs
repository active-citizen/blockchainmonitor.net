namespace BlockchainMonitor.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WebSite = c.String(),
                        Description = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IPAddress_Address = c.Long(nullable: false),
                        IPAddress_ScopeId = c.Long(nullable: false),
                        IsValidator = c.Boolean(nullable: false),
                        Participant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Participants", t => t.Participant_Id)
                .Index(t => t.Participant_Id);
            
            //CreateTable(
            //    "dbo.Blocks",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Number = c.Int(nullable: false),
            //            Hash = c.String(),
            //            IsClosed = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Transactions",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Time = c.DateTime(nullable: false),
            //            Data = c.Binary(),
            //            Block_Id = c.Int(),
            //            SmartContract_Id = c.Int(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.Blocks", t => t.Block_Id)
            //    .ForeignKey("dbo.SmartContracts", t => t.SmartContract_Id)
            //    .Index(t => t.Block_Id)
            //    .Index(t => t.SmartContract_Id);
            
            CreateTable(
                "dbo.SmartContracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChainCodeId = c.Binary(),
                        ChainCode = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "SmartContract_Id", "dbo.SmartContracts");
            DropForeignKey("dbo.Transactions", "Block_Id", "dbo.Blocks");
            DropForeignKey("dbo.Nodes", "Participant_Id", "dbo.Participants");
            DropIndex("dbo.Transactions", new[] { "SmartContract_Id" });
            DropIndex("dbo.Transactions", new[] { "Block_Id" });
            DropIndex("dbo.Nodes", new[] { "Participant_Id" });
            DropTable("dbo.SmartContracts");
            DropTable("dbo.Transactions");
            DropTable("dbo.Blocks");
            DropTable("dbo.Nodes");
            DropTable("dbo.Participants");
        }
    }
}
