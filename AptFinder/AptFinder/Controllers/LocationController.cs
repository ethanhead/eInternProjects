using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;

namespace AptFinder.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository LocRepo;
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILandlordRepository LLRepo;

        public int PageSize = 3;

        public LocationController(ILandlordRepository ll, IApartmentRepository a, ILocationRepository lo, ITenantRepository t)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
        }

        public ActionResult EditLocation(int id)
        {

            var apts = AptRepo.Apartments.Where(a => a.LocationID == id);
            Dictionary<int, List<Tenant>> Tenants = new Dictionary<int, List<Tenant>>();

            foreach (var a in apts)
            {
                Tenants.Add(a.ApartmentID, TRepo.Tenants.Where(t => t.ApartmentID == a.ApartmentID).ToList());
            }

            ViewBag.Apartments = apts;
            ViewBag.Location = LocRepo.Locations.Where(l => l.LocationID == id).First();
            ViewBag.Landlord = LLRepo.Landlords.Where(ll => ll.LandlordID == id).First();
            ViewBag.Tenants = Tenants;
            return View();
        }

        public ActionResult LocationSearch ()
        {

            return View(LocRepo.Locations
                .OrderBy(p => p.Name)
                .Skip((PageSize-3)*PageSize)
                .Take(PageSize));
        }
    }
}