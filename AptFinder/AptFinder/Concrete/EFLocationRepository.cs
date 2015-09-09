using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Abstract;
using AptFinder.Models;
using AptFinder.DAL;

namespace AptFinder.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private ApartmentContext context = new ApartmentContext();

        public IEnumerable<Location> Locations
        {
            get { return context.Location; }
        }
    }
}