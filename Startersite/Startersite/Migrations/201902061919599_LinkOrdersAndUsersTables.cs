namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkOrdersAndUsersTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.Int());
            CreateIndex("dbo.Orders", "UserId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
