using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;

namespace AptFinder.ViewModels
{
    public class ApartmentPageVM
    {
        public Location location { get; set; }
        public IEnumerable<Apartment> apartments { get; set; }
        public IEnumerable<Image> images { get; set; }
        public float minRent { get; set; }
        public float maxRent { get; set; }      
    }
}