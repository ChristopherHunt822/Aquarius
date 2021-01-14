namespace Aquarius.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acct",
                c => new
                    {
                        AcctID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        AcctType = c.Int(nullable: false),
                        TotalValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OpenedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        InvestorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AcctID)
                .ForeignKey("dbo.Investor", t => t.InvestorID, cascadeDelete: false)
                .Index(t => t.InvestorID);
            
            CreateTable(
                "dbo.Investor",
                c => new
                    {
                        InvestorID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InvestorID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        AcctID = c.Int(nullable: false),
                        Symbol = c.Int(nullable: false),
                        PurchaseDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Quantity = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PurchaseID)
                .ForeignKey("dbo.Acct", t => t.AcctID, cascadeDelete: true)
                .Index(t => t.AcctID);
            
            CreateTable(
                "dbo.Sale",
                c => new
                    {
                        SaleID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        AcctID = c.Int(nullable: false),
                        Symbol = c.Int(nullable: false),
                        SaleDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Quantity = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SaleID)
                .ForeignKey("dbo.Acct", t => t.AcctID, cascadeDelete: true)
                .Index(t => t.AcctID);
            
            CreateTable(
                "dbo.Crypto",
                c => new
                    {
                        CryptoID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Symbol = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CryptoID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Sale", "AcctID", "dbo.Acct");
            DropForeignKey("dbo.Purchase", "AcctID", "dbo.Acct");
            DropForeignKey("dbo.Acct", "InvestorID", "dbo.Investor");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Sale", new[] { "AcctID" });
            DropIndex("dbo.Purchase", new[] { "AcctID" });
            DropIndex("dbo.Acct", new[] { "InvestorID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Crypto");
            DropTable("dbo.Sale");
            DropTable("dbo.Purchase");
            DropTable("dbo.Investor");
            DropTable("dbo.Acct");
        }
    }
}
