namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderInformationEntity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "UserId_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "UserId_UserId" });
            CreateTable(
                "dbo.OrderInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.Double(nullable: false),
                        Country = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Address2 = c.String(),
                        City = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Delivery = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "DeliveryMethod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PaymentMehod", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "orderInformation_Id", c => c.Int());
            CreateIndex("dbo.Orders", "orderInformation_Id");
            AddForeignKey("dbo.Orders", "orderInformation_Id", "dbo.OrderInformations", "Id");
            DropColumn("dbo.Orders", "UserName");
            DropColumn("dbo.Orders", "UserId_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "UserId_UserId", c => c.Int());
            AddColumn("dbo.Orders", "UserName", c => c.String());
            DropForeignKey("dbo.Orders", "orderInformation_Id", "dbo.OrderInformations");
            DropIndex("dbo.Orders", new[] { "orderInformation_Id" });
            DropColumn("dbo.Orders", "orderInformation_Id");
            DropColumn("dbo.Orders", "PaymentMehod");
            DropColumn("dbo.Orders", "DeliveryMethod");
            DropTable("dbo.OrderInformations");
            CreateIndex("dbo.Orders", "UserId_UserId");
            AddForeignKey("dbo.Orders", "UserId_UserId", "dbo.Users", "UserId");
        }
    }
}
