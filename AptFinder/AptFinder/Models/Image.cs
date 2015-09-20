using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AptFinder.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public String ImagePath { get; set; }
        public String UserID { get; set; }
        public int LocationID { get; set; }
    }
}