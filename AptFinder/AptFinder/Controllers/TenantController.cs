using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;

namespace AptFinder.Controllers
{
    public class TenantController : Controller
    {

        private ILocationRepository LocRepo;
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILandlordRepository LLRepo;

        public TenantController(ILandlordRepository ll, IApartmentRepository a, ILocationRepository lo, ITenantRepository t)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
        }

        public ActionResult TenantProfile()
        {
            //ViewBag.Tenant = 
            //ViewBag.Apartment =
            //ViewBag.Location =
            //ViewBag.Landlord = 
            return View();
        }
    }
}