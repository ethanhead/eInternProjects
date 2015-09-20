using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AptFinder.DAL
{
    public class ApartmentContext : IdentityDbContext<ApplicationUser>
    {
        public ApartmentContext()
            : base("ApartmentContext")
        {

        }

        public DbSet<Apartment> Apartment { get; set; }
        public DbSet<Landlord> Landlord { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Tenant> Tenant { get; set; }
        public DbSet<Image> Image { get; set; }
    }
}