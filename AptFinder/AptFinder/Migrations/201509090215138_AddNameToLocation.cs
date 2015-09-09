namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Name");
        }
    }
}
