using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;

namespace AptFinder.ViewModels
{
    public class TenantProfileVM
    {
        public Apartment apartment { get; set; }
        public Location location { get; set; }
        public Landlord landlord { get; set; }
        public IEnumerable<Tenant> housemates { get; set; }
        public Tenant tenant { get; set; }
    }
}