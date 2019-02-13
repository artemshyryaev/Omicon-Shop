namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasketLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductName = c.String(),
                        Price = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Total = c.Double(nullable: false),
                        CustomerEmail = c.String(),
                        Date = c.DateTime(nullable: false),
                        OrderInformationId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.OrderInformationId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.OrderInformationId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.Double(nullable: false),
                        Country = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Delivery = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "OrderInformationId", "dbo.Information");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "OrderInformationId" });
            DropIndex("dbo.BasketLines", new[] { "OrderId" });
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Information");
            DropTable("dbo.Orders");
            DropTable("dbo.BasketLines");
        }
    }
}
