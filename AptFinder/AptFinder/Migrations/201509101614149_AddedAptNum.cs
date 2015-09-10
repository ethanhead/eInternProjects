namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAptNum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "ApartmentNum", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apartments", "ApartmentNum");
        }
    }
}
