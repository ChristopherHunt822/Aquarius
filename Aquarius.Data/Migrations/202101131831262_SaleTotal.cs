namespace Aquarius.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SaleTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sale", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sale", "Total");
        }
    }
}
