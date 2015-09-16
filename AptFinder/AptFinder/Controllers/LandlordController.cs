using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;
using AptFinder.ViewModels;

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

        public ActionResult PopulateProfile(int id)
        {

            PopulateProfileVM viewModel = new PopulateProfileVM();

            viewModel.locations = LocRepo.Locations.Where(l => l.LandlordID == id);
            viewModel.landlord = LLRepo.Landlords.Where( ll => ll.LandlordID == id).First();

            return View(viewModel);
        }

        public ActionResult LocationTable(int id)
        {

            PopulateProfileVM viewModel = new PopulateProfileVM();

            viewModel.locations = LocRepo.Locations.Where(l => l.LandlordID == id);
            viewModel.landlord = LLRepo.Landlords.Where(ll => ll.LandlordID == id).First();

            return PartialView(viewModel);
        }
    }
}