using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;

namespace AptFinder.Controllers
{
    public class LandlordController : Controller
    {
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILocationRepository LocRepo;
        private ILandlordRepository LLRepo;

        public  LandlordController(ILandlordRepository ll, IApartmentRepository a, ILocationRepository lo, ITenantRepository t)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
        }

        public ActionResult PopulateTenantTable()
        {
            return View();
        }

        public ActionResult PopulateProfile(int id)
        {
            var LLlocations = LocRepo.Locations.Where(l => l.LandlordID == id);

            ViewBag.Locations = LLlocations;
            ViewBag.Landlord  = LLRepo.Landlords.Where( ll => ll.LandlordID == id).First();

            return View();
        }
    }
}