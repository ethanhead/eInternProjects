namespace AptFinder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AptFinder.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<AptFinder.DAL.ApartmentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(AptFinder.DAL.ApartmentContext context)
        {
            var landlords = new List<Landlord>
            {
                new Landlord { LandlordID = 1, Name = "Shyla Buff", Phone = "123-133-5555", Company = "Buffco", Email = "buff@buff.com" }
            };

            landlords.ForEach(s => context.Landlord.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}
