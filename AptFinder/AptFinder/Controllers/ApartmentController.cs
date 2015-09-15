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


    public class ApartmentController : Controller
    {        
        private IApartmentRepository AptRepo;
        private ILocationRepository LocRepo;
        private IContext context;
        private IImageRepository imageRepo;

        public ApartmentController(IApartmentRepository aRepo, ILocationRepository lRepo, IContext con, IImageRepository img)
        {
            AptRepo = aRepo;
            LocRepo = lRepo;
            context = con;
            imageRepo = img;
        }
        
        public ActionResult ApartmentPage(int id)
        {

            ApartmentPageVM viewModel = new ApartmentPageVM();
            
            var thisLocation = LocRepo.Locations.Where(l => l.LocationID == id).First();
            var apartmentsAtLoc = AptRepo.Apartments.Where(a => a.LocationID == id);
            viewModel.images = imageRepo.Images.Where(i => i.LocationID == id);
            viewModel.location = thisLocation;
            viewModel.maxRent = apartmentsAtLoc.Select(i=>i.Rent).Max();
            viewModel.minRent = apartmentsAtLoc.Select(i => i.Rent).Min();            
            viewModel.apartments = apartmentsAtLoc;          

            return View(viewModel);
        }       

        [HttpPost]
        public void AddApartment(newApartment Apt)
        {
            using (var entities = context.AptContext)
            {
                entities.Apartment.Add(
                    new Apartment
                    {
                        ApartmentNum = Apt.aptnum,
                        Beds = Apt.bednum,
                        Baths = Apt.bathnum,
                        IsPetFriendly = Apt.pets,
                        IsAvailable = Apt.available,
                        Rent = Apt.rent,
                        LocationID = Apt.location                        
                    }                 
                );
                                
                entities.SaveChanges();      
            } 
        }

        [HttpPost]
        public void RemoveApartment(ApartmentToRemove apt)
        {
            var aptEntity = AptRepo.Apartments.Where(a => a.ApartmentID == apt.aptID).First();

            using(var entities = context.AptContext)
            {
                entities.Apartment.Attach(aptEntity);
                entities.Apartment.Remove(aptEntity);
                entities.SaveChanges();
            }
        }
    }
    public class newApartment
    {
        public String aptnum { get; set; }
        public int bednum { get; set; }
        public int bathnum { get; set; }
        public bool pets { get; set; }
        public bool available { get; set; }
        public float rent { get; set; }
        public int location { get; set; }
    }
    public class ApartmentToRemove
    {
        public int aptID { get; set; }
    }
}