namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPropToOrderEntity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "OrderInformation_Id", newName: "OrderInformationId");
            RenameIndex(table: "dbo.Orders", name: "IX_OrderInformation_Id", newName: "IX_OrderInformationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_OrderInformationId", newName: "IX_OrderInformation_Id");
            RenameColumn(table: "dbo.Orders", name: "OrderInformationId", newName: "OrderInformation_Id");
        }
    }
}
