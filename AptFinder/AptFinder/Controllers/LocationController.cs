using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;

namespace AptFinder.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository repo;
        public int PageSize = 3;

        public LocationController(ILocationRepository locRepo)
        {
            repo = locRepo;
        }

        public ActionResult LocationSearch ()
        {

            return View(repo.Locations
                .OrderBy(p => p.Name)
                .Skip((PageSize-3)*PageSize)
                .Take(PageSize));
        }
    }
}