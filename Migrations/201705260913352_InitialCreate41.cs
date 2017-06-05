namespace DSTVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate41 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixEnquires",
                c => new
                    {
                        FixId = c.Int(nullable: false, identity: true),
                        CustomerNumber = c.String(nullable: false, maxLength: 8),
                        ErrorCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.FixId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FixEnquires");
        }
    }
}
