using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Abstract;
using AptFinder.Models;

namespace AptFinder.Controllers
{
    public class TenantController : Controller
    {

        private ILocationRepository LocRepo;
        private ITenantRepository TRepo;
        private IApartmentRepository AptRepo;
        private ILandlordRepository LLRepo;
        private IContext context;

        public TenantController(ILandlordRepository ll, IApartmentRepository a, 
                                ILocationRepository lo, ITenantRepository t, IContext con)
        {
            TRepo = t;
            AptRepo = a;
            LocRepo = lo;
            LLRepo = ll;
            context = con;
        }

        public ActionResult TenantProfile(int id)
        {
            var tenant = TRepo.Tenants.Where(t => t.TenantID == id).First();
            var location = LocRepo.Locations.Where(l => l.LocationID == tenant.LocationID).First();            

            ViewBag.Apartment = AptRepo.Apartments.Where(a => a.ApartmentID == tenant.ApartmentID).First();
            ViewBag.Landlord = LLRepo.Landlords.Where(ll => ll.LandlordID == location.LandlordID).First();
            ViewBag.Housemates = TRepo.Tenants.Where(t => t.ApartmentID == tenant.ApartmentID);
            ViewBag.Tenant = tenant;
            ViewBag.Location = location;

            return View();
        }

        public void AddTenant(newTenant tenant)
        {
            using (var entities = context.AptContext)
            {
                entities.Tenant.Add(
                    new Tenant
                    {
                      Name = tenant.tenantName,
                      Phone = tenant.tenantPhone,
                      Email = tenant.tenantEmail,
                      LocationID = tenant.location,
                      ApartmentID = tenant.tenantApt
                    }
                );

                entities.SaveChanges();
            }
        }
    }
    public class newTenant
    {
        public int tenantApt { get; set; }
        public String tenantName { get; set; }
        public String tenantPhone { get; set; }
        public String tenantEmail { get; set; }
        public int location { get; set; }
    }
    public class TenantToRemove
    {
        public int location { get; set; }
    }
}