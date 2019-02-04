namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderEntity : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrderInformations", newName: "Information");
            DropForeignKey("dbo.Products", "Orders_OrderId", "dbo.Orders");
            DropIndex("dbo.Orders", new[] { "orderInformation_Id" });
            DropIndex("dbo.Products", new[] { "Orders_OrderId" });
            CreateTable(
                "dbo.BasketLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Qty = c.Double(nullable: false),
                        Orders_OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Orders_OrderId)
                .Index(t => t.Orders_OrderId);
            
            AddColumn("dbo.Orders", "CustomerEmail", c => c.String());
            AddColumn("dbo.Orders", "OrderTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.Information", "Name", c => c.String());
            AlterColumn("dbo.Information", "Surname", c => c.String());
            AlterColumn("dbo.Information", "Country", c => c.String());
            AlterColumn("dbo.Information", "Address", c => c.String());
            AlterColumn("dbo.Information", "City", c => c.String());
            AlterColumn("dbo.Information", "ZipCode", c => c.String());
            CreateIndex("dbo.Orders", "OrderInformation_Id");
            DropColumn("dbo.Information", "Email");
            DropColumn("dbo.Orders", "DeliveryMethod");
            DropColumn("dbo.Orders", "PaymentMehod");
            DropColumn("dbo.Products", "Orders_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Orders_OrderId", c => c.Int());
            AddColumn("dbo.Orders", "PaymentMehod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "DeliveryMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Information", "Email", c => c.String(nullable: false));
            DropForeignKey("dbo.BasketLines", "Orders_OrderId", "dbo.Orders");
            DropIndex("dbo.BasketLines", new[] { "Orders_OrderId" });
            DropIndex("dbo.Orders", new[] { "OrderInformation_Id" });
            AlterColumn("dbo.Information", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Information", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Orders", "OrderTotal");
            DropColumn("dbo.Orders", "CustomerEmail");
            DropTable("dbo.BasketLines");
            CreateIndex("dbo.Products", "Orders_OrderId");
            CreateIndex("dbo.Orders", "orderInformation_Id");
            AddForeignKey("dbo.Products", "Orders_OrderId", "dbo.Orders", "OrderId");
            RenameTable(name: "dbo.Information", newName: "OrderInformations");
        }
    }
}
