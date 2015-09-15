using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;

namespace AptFinder.ViewModels
{
    public class EditLocationVM
    {
        public Dictionary<int, List<Tenant>> tenants { get; set; }
        public IEnumerable<Apartment> apartments { get; set; }
        public Location location { get; set; }
        public IEnumerable<Image> images { get; set; }
        public Landlord landlord { get; set; }
    }
}