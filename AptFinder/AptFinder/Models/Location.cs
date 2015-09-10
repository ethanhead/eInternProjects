using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptFinder.Models
{
    public class Location
    {
        public String Name { get; set; }
        public int LocationID { get; set; }
        public int LandlordID { get; set; }
        public String PictureFolder { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int Zip { get; set; }
        public String Description { get; set; }
    }
}