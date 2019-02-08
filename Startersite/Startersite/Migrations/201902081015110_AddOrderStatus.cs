namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.String());
            AddColumn("dbo.Orders", "Total", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Orders", "OrderTotal");
            DropColumn("dbo.Orders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderTotal", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Date");
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
