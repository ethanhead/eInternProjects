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
        private IContext context;

        public int PageSize = 3;

        public LocationController(ILandlordRepository ll, IApartmentRepository a,
            ILocationRepository lo, ITenantRepository t, IContext con)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
            context = con;
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

        public void AddLocation(NewLocation loc)
        {           
            using (var entities = context.AptContext)
            {
                entities.Location.Add(
                    new Location
                    {
                        LandlordID = loc.landID,
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
                entities.Location.Attach(LocEntity);
                entities.Location.Remove(LocEntity);
                entities.SaveChanges();
            }
        }

        public ActionResult LocationSearch ()
        {

            return View(LocRepo.Locations
                .OrderBy(p => p.Name)
                .Skip((PageSize-3)*PageSize)
                .Take(PageSize));
        }       
    }

    public class NewLocation
    {
        public int landID { get; set; }
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