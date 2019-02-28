namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUOMPropToBasketLineEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BasketLines", "Uom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BasketLines", "Uom");
        }
    }
}
