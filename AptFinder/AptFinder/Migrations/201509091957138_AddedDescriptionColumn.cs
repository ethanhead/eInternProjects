namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Description");
        }
    }
}
