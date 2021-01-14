namespace Aquarius.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Total : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchase", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sale", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Purchase", "Total");
            DropColumn("dbo.Sale", "Total");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sale", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Purchase", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Sale", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.Purchase", "Quantity", c => c.Double(nullable: false));
        }
    }
}
