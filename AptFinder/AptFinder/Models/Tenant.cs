using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptFinder.Models
{
    public class Tenant
    {
        public int TenantID { get; set; }
        public int ApartmentID { get; set; }
        public int LocationID { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
    }
}