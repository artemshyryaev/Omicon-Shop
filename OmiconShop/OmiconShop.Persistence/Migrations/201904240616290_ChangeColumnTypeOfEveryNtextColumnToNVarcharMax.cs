namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnTypeOfEveryNtextColumnToNVarcharMax : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAddresses", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.UserAddresses", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.UserPersonalInformations", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserPersonalInformations", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.UserPersonalInformations", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "ImageUrl", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Products", "Type", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Products", "Description", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserPersonalInformations", "PhoneNumber", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserPersonalInformations", "Surname", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserPersonalInformations", "Name", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserAddresses", "Address", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserAddresses", "City", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.UserAddresses", "Country", c => c.String(nullable: false, storeType: "ntext"));
        }
    }
}
