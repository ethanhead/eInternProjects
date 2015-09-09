using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;
using System.Data.Entity;

namespace AptFinder.DAL
{
    public class ApartmentContext : DbContext
    {
        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
    }
}