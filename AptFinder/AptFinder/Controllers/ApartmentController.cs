using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;

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

        public ActionResult ApartmentPage(int id)
        {
            ViewBag.thisLocation = LocRepo.Locations.Where(l => l.LocationID == id).First();
            var apartmentsAtLoc = AptRepo.Apartments.Where(a => a.LocationID == id);

            ViewBag.maxRent = apartmentsAtLoc.Select(i=>i.Rent).Max();
            ViewBag.minRent = apartmentsAtLoc.Select(i => i.Rent).Min();

            ViewBag.apartments = apartmentsAtLoc;          

            return View();
        }
    }
}