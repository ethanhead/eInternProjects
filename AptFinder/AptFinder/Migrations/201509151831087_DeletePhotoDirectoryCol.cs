namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePhotoDirectoryCol : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "PictureFolder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Locations", "PictureFolder", c => c.String());
        }
    }
}
