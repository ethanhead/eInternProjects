using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.DAL;
using AptFinder.Models;
using AptFinder.Abstract;

namespace AptFinder.Concrete
{
    public class EFImageRepository : IImageRepository
    {
        private ApartmentContext context = new ApartmentContext();

        public IEnumerable<Image> Images
        {
            get { return context.Image; }
        }
    }
}