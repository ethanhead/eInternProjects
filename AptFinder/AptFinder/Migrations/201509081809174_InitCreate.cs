namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        ApartmentID = c.Int(nullable: false, identity: true),
                        LocationID = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Beds = c.Int(nullable: false),
                        Baths = c.Int(nullable: false),
                        IsPetFriendly = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ApartmentID);
            
            CreateTable(
                "dbo.Landlords",
                c => new
                    {
                        LandlordID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Company = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.LandlordID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LandlordID = c.Int(nullable: false),
                        PictureFolder = c.String(),
                        Latitude = c.Single(nullable: false),
                        Longitude = c.Single(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        TenantID = c.Int(nullable: false, identity: true),
                        ApartmentID = c.Int(nullable: false),
                        LocationID = c.Int(nullable: false),
                        Name = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TenantID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenants");
            DropTable("dbo.Locations");
            DropTable("dbo.Landlords");
            DropTable("dbo.Apartments");
        }
    }
}
