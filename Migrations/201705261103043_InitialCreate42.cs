namespace DSTVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate42 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billings",
                c => new
                    {
                        BillingID = c.Int(nullable: false, identity: true),
                        CustomerNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BillingID);
            
            AddColumn("dbo.Customers", "Billing_BillingID", c => c.Int());
            CreateIndex("dbo.Customers", "Billing_BillingID");
            AddForeignKey("dbo.Customers", "Billing_BillingID", "dbo.Billings", "BillingID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Billing_BillingID", "dbo.Billings");
            DropIndex("dbo.Customers", new[] { "Billing_BillingID" });
            DropColumn("dbo.Customers", "Billing_BillingID");
            DropTable("dbo.Billings");
        }
    }
}
