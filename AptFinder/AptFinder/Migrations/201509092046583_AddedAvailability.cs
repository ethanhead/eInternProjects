namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "IsAvailable");
        }
    }
}
