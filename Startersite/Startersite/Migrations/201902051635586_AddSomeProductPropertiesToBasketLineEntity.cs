namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomeProductPropertiesToBasketLineEntity : DbMigration
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
                        CustomerEmail = c.String(),
                        OrderTotal = c.Double(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Information", t => t.OrderInformation_Id)
                .Index(t => t.OrderInformation_Id);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketLines", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderInformation_Id", "dbo.Information");
            DropIndex("dbo.Orders", new[] { "OrderInformation_Id" });
            DropIndex("dbo.BasketLines", new[] { "OrderId" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Information");
            DropTable("dbo.Orders");
            DropTable("dbo.BasketLines");
        }
    }
}
