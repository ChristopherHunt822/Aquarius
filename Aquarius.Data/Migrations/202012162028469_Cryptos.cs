namespace Aquarius.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cryptos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Crypto",
                c => new
                    {
                        CryptoID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Symbol = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CryptoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Crypto");
        }
    }
}
