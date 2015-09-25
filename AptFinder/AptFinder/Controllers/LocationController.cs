using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;
using System.IO;
using AptFinder.ViewModels;

namespace AptFinder.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository LocRepo;
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILandlordRepository LLRepo;
        private IContext context;
        private IImageRepository imageRepo;

        public int PageSize = 3;

        public LocationController(ILandlordRepository ll, IApartmentRepository a,
            ILocationRepository lo, ITenantRepository t, IContext con, IImageRepository img)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
            context = con;
            imageRepo = img;
        }



        public ActionResult UploadImage(int id)
        {
            var location = LocRepo.Locations.Where(loc => loc.LocationID == id).First();
            var landlord = LLRepo.Landlords.Where(l => l.UserID == location.UserID).First();  

            HttpPostedFileBase photo = Request.Files["photo"];

            string localDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Assets/photos",id.ToString());
            //If directory does not exist...
            if (!Directory.Exists(localDirectory))
            {
                Directory.CreateDirectory(localDirectory);
            }
            

            if (photo != null && photo.ContentLength > 0)
            {
                var fileName = Path.GetFileName(photo.FileName);               

                using (var entities = context.AptContext)
                {
                    entities.Image.Add(
                        new Image
                        {
                            ImagePath = fileName,
                            UserID = landlord.UserID,
                            LocationID = location.LocationID
                        }
                    );

                    entities.SaveChanges();
                }                
                var localPath = Path.Combine(localDirectory, fileName);
                photo.SaveAs(localPath);
            }
            return RedirectToAction("EditLocation", "Location", new { id = location.LocationID });

        }


        public ActionResult LocationSearch(searchResults results)
        {
            LocationSearchVM viewModel = new LocationSearchVM();

            var filteredLocs =
                from loc in LocRepo.Locations
                join apt in AptRepo.Apartments on loc.LocationID equals apt.LocationID
                where loc.City.Contains(results.City) &&
                            loc.State.Contains(results.State) &&
                            results.Beds == (apt.Beds > 4 ? 4 : apt.Beds) &&
                            results.Beds == (apt.Baths > 3 ? 3 : apt.Baths) &&
                            apt.Rent >= results.minRent &&
                            apt.Rent <= results.maxRent &&
                            apt.IsAvailable
                select loc;

            viewModel.locations = filteredLocs.Distinct();

            List<Image> imgs = new List<Image>();


            foreach (var loc in filteredLocs.Distinct())
            {
                if (imageRepo.Images.Where(i => i.LocationID == loc.LocationID).Count() > 0)
                {
                    imgs.Add(imageRepo.Images.Where(i => i.LocationID == loc.LocationID).First());
                }
                else
                {
                    imgs = null;
                }                                                                 
            }

            viewModel.images = imgs;

            return View(viewModel);
        }

        public ActionResult EditLocation(int id)
        {
            EditLocationVM viewModel = new EditLocationVM();

            var apts = AptRepo.Apartments.Where(a => a.LocationID == id);
            Dictionary<int, List<Tenant>> Tenants = new Dictionary<int, List<Tenant>>();

            foreach (var a in apts)
            {
                Tenants.Add(a.ApartmentID, TRepo.Tenants.Where(t => t.ApartmentID == a.ApartmentID).ToList());
            }

            viewModel.apartments = apts;
            var loc = LocRepo.Locations.Where(l => l.LocationID == id).First();
            viewModel.location = loc;
            var landlord = LLRepo.Landlords.Where(ll => ll.UserID == loc.UserID).First();
            viewModel.images = imageRepo.Images.Where(i => i.LocationID == id);
            viewModel.tenants = Tenants;
            viewModel.landlord = landlord;
            
            return View(viewModel);
        }

        public ActionResult ApartmentTable(int id)
        {
            EditLocationVM viewModel = new EditLocationVM();

            var apts = AptRepo.Apartments.Where(a => a.LocationID == id);
            Dictionary<int, List<Tenant>> Tenants = new Dictionary<int, List<Tenant>>();

            foreach (var a in apts)
            {
                Tenants.Add(a.ApartmentID, TRepo.Tenants.Where(t => t.ApartmentID == a.ApartmentID).ToList());
            }

            viewModel.apartments = apts;
            var loc = LocRepo.Locations.Where(l => l.LocationID == id).First();

            viewModel.location = loc; 

            viewModel.landlord = LLRepo.Landlords.Where(ll => ll.UserID == loc.UserID).First();
            viewModel.tenants = Tenants;
            return PartialView("AptTable",viewModel);
        }

        public void AddLocation(NewLocation loc)
        {           
            using (var entities = context.AptContext)
            {
                entities.Location.Add(
                    new Location
                    {
                        UserID = loc.userID,
                        Latitude = loc.lat, 
                        Longitude = loc.lng, 
                        Street = loc.Street, 
                        City = loc.City,  
                        State = loc.State,
                        Zip = loc.Zip, 
                        Name = loc.Name,
                        Description = loc.Description 
                    }
                );

                entities.SaveChanges();
            }
        }

        public void RemoveLocation(LocationToRemove loc)
        {
            var LocEntity = LocRepo.Locations.Where(l => l.LocationID == loc.locID).First();

            using (var entities = context.AptContext)
            {
                if (AptRepo.Apartments.Select(a => a.LocationID).Count() > 0)
                {
                    var locApts = AptRepo.Apartments.Where(a => a.LocationID == loc.locID);
                    foreach (var l in locApts)
                    {
                        entities.Apartment.Attach(l);
                        entities.Apartment.Remove(l);
                        entities.SaveChanges();                        
                    }
                    
                }
                entities.Location.Attach(LocEntity);
                entities.Location.Remove(LocEntity);
                entities.SaveChanges();
            }
        }   
    }

    public class searchResults
    {
        public String City { get; set; }
        public String State { get; set; }
        public float minRent { get; set; }
        public float maxRent { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
    }

    public class NewLocation
    {
        public String userID { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public int Zip { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }

    public class LocationToRemove
    {
        public int locID { get; set; } 
    }
}