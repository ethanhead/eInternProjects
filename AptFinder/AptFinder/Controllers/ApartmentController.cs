using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;

namespace AptFinder.Controllers
{
    public class ApartmentController : Controller
    {        
        private IApartmentRepository AptRepo;
        private ILocationRepository LocRepo;

        public ApartmentController(IApartmentRepository aRepo, ILocationRepository lRepo)
        {
            AptRepo = aRepo;
            LocRepo = lRepo;
        }

        public ActionResult ApartmentPage(int LocID)
        {
            ViewBag.thisLocation = LocRepo.Locations.Where(l => l.LocationID == LocID);
            var apartmentsAtLoc = AptRepo.Apartments.Where(a => a.LocationID == LocID);

            ViewBag.maxPrice = apartmentsAtLoc.Select(i=>i.Price).Max();
            ViewBag.minPrice = apartmentsAtLoc.Select(i => i.Price).Min();

            ViewBag.apartments = apartmentsAtLoc;          

            return View();
        }
    }
}