using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AptFinder.Concrete;
using AptFinder.Abstract;
using AptFinder.Models;
using Ninject;

namespace AptFinder.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver 
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        public void AddBindings()
        {
            kernel.Bind<ILocationRepository>().To<EFLocationRepository>();
            kernel.Bind<IApartmentRepository>().To<EFApartmentRepository>();
            kernel.Bind<ILandlordRepository>().To<EFLandlordRepository>();
            kernel.Bind<ITenantRepository>().To<EFTenantRepository>();
            kernel.Bind<IContext>().To<EFContext>();
        }
    }
}