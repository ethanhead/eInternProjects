namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeZipInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Zip", c => c.String());
        }
    }
}
