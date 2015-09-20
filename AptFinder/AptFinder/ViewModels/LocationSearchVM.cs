using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Models;

namespace AptFinder.ViewModels
{
    public class LocationSearchVM
    {
        public IEnumerable<Location> locations { get; set; }
        public List<Image> images { get; set; }
    }
}