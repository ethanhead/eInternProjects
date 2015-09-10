using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptFinder.Models
{
    public class Apartment
    {
        public int ApartmentID { get; set; }
        public int LocationID { get; set; }
        public float Rent { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool IsAvailable { get; set; }
    }
}