namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKey : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BasketLines", name: "Orders_OrderId", newName: "Order_OrderId");
            RenameIndex(table: "dbo.BasketLines", name: "IX_Orders_OrderId", newName: "IX_Order_OrderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BasketLines", name: "IX_Order_OrderId", newName: "IX_Orders_OrderId");
            RenameColumn(table: "dbo.BasketLines", name: "Order_OrderId", newName: "Orders_OrderId");
        }
    }
}
