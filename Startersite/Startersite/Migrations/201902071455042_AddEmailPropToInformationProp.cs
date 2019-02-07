namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailPropToInformationProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Information", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Information", "Email");
        }
    }
}
