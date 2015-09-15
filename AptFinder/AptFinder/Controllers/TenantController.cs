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
            TenantProfileVM viewModel = new TenantProfileVM();

            var tenant = TRepo.Tenants.Where(t => t.TenantID == id).First();
            var location = LocRepo.Locations.Where(l => l.LocationID == tenant.LocationID).First();            

            viewModel.apartment = AptRepo.Apartments.Where(a => a.ApartmentID == tenant.ApartmentID).First();
            viewModel.landlord = LLRepo.Landlords.Where(ll => ll.LandlordID == location.LandlordID).First();
            viewModel.housemates = TRepo.Tenants.Where(t => t.ApartmentID == tenant.ApartmentID);
            viewModel.tenant = tenant;
            viewModel.location = location;
    
            return View(viewModel);
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

        public void RemoveTenant(TenantToRemove tenant)
        {
            var tenantEntity = TRepo.Tenants.Where(t => t.TenantID == tenant.tenantID).First();

            using (var entities = context.AptContext)
            {
                entities.Tenant.Attach(tenantEntity);
                entities.Tenant.Remove(tenantEntity);
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
        public int tenantID { get; set; }
    }
}