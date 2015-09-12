using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AptFinder.Abstract;
using AptFinder.DAL;

namespace AptFinder.Concrete
{
    public class EFContext : IContext
    {
        ApartmentContext AC = new ApartmentContext();

        public ApartmentContext AptContext
        {
            get { return AC; }
        }
    }
}