namespace DSTVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RegisterFlows", "IdNumberOrPassport", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterFlows", "IdNumberOrPassport", c => c.String());
        }
    }
}
