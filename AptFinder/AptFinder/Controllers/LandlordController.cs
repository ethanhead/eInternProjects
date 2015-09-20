using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;
using AptFinder.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace AptFinder.Controllers
{
    public class LandlordController : Controller
    {
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILocationRepository LocRepo;
        private ILandlordRepository LLRepo;
        private IContext context;

        public  LandlordController(ILandlordRepository ll, IApartmentRepository a, ILocationRepository lo, ITenantRepository t, IContext con)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
            context = con;
        }
     

        public ActionResult PopulateProfile(string id)
        {
            if (User.Identity.GetUserId() != id)
            {
                return RedirectToAction("Login", "Account");
            }
            PopulateProfileVM viewModel = new PopulateProfileVM();

            viewModel.locations = LocRepo.Locations.Where(l => l.UserID == id);
            viewModel.landlord = LLRepo.Landlords.Where( ll => ll.UserID == id).First();

            return View(viewModel);
        }

        public ActionResult LocationTable(string id)
        {

            PopulateProfileVM viewModel = new PopulateProfileVM();

            viewModel.locations = LocRepo.Locations.Where(l => l.UserID == id);
            viewModel.landlord = LLRepo.Landlords.Where(ll => ll.UserID == id).First();

            return PartialView(viewModel);
        }
    }
    public class RegisterResult
    {
        public String LandlordID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
    }
}