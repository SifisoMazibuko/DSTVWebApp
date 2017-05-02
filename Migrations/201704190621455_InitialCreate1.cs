namespace DSTVWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "userName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Shows", "ShowName", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "ShowDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "Genre", c => c.String(nullable: false));
            AlterColumn("dbo.Shows", "ChannelName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "SurName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "DOB", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Province", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.dsCustomers", "CustomerNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.dsCustomers", "accountHolderSurname", c => c.String(nullable: false));
            AlterColumn("dbo.dsCustomers", "accountHolderCountry", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "smartCardNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Payments", "CustomerNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Payments", "accountHolderSurname", c => c.String(nullable: false));
            AlterColumn("dbo.Payments", "accountHolderCountry", c => c.String(nullable: false));
            AlterColumn("dbo.RegisterFlows", "IdNumberOrPassport", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterFlows", "IdNumberOrPassport", c => c.String());
            AlterColumn("dbo.Payments", "accountHolderCountry", c => c.String());
            AlterColumn("dbo.Payments", "accountHolderSurname", c => c.String());
            AlterColumn("dbo.Payments", "CustomerNumber", c => c.String());
            AlterColumn("dbo.Payments", "smartCardNumber", c => c.String());
            AlterColumn("dbo.dsCustomers", "accountHolderCountry", c => c.String());
            AlterColumn("dbo.dsCustomers", "accountHolderSurname", c => c.String());
            AlterColumn("dbo.dsCustomers", "CustomerNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Password", c => c.String());
            AlterColumn("dbo.Customers", "Email", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Province", c => c.String());
            AlterColumn("dbo.Customers", "Country", c => c.String());
            AlterColumn("dbo.Customers", "Gender", c => c.String());
            AlterColumn("dbo.Customers", "DOB", c => c.String());
            AlterColumn("dbo.Customers", "SurName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            AlterColumn("dbo.Customers", "UserName", c => c.String());
            AlterColumn("dbo.Shows", "ChannelName", c => c.String());
            AlterColumn("dbo.Shows", "Genre", c => c.String());
            AlterColumn("dbo.Shows", "Category", c => c.String());
            AlterColumn("dbo.Shows", "ShowDescription", c => c.String());
            AlterColumn("dbo.Shows", "ShowName", c => c.String());
            AlterColumn("dbo.Admins", "password", c => c.String());
            AlterColumn("dbo.Admins", "userName", c => c.String());
        }
    }
}
