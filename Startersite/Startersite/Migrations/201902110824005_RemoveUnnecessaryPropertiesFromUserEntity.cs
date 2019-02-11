namespace Startersite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUnnecessaryPropertiesFromUserEntity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
