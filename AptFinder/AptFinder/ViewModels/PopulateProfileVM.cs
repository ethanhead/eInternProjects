using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;

namespace AptFinder.ViewModels
{
    public class PopulateProfileVM
    {
        public IEnumerable<Location> locations { get; set; }
        public Landlord landlord { get; set; }
    }
}