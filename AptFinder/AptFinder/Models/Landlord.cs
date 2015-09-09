using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptFinder.Models
{
    public class Landlord
    {
        public int LandlordID { get; set; }
        public String Name { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
    }
}