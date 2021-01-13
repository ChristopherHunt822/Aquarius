namespace Aquarius.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AcctName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acct", "AcctName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Acct", "AcctName");
        }
    }
}
