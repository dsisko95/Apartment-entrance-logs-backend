using BusinessLayer;
using DataLayer;
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace MonitoringApartments
{
    public class NinjectResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {
        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void Dispose()
        {
        }

        private void AddBindings(IKernel kernel)
        {
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            // Ovde se dodaju binding klase između interfejsa i njegovih implementatora
            kernel.Bind<IApartmentRepository>().To<ApartmentRepository>().InSingletonScope();
            kernel.Bind<IApartmentBusiness>().To<ApartmentBusiness>().InSingletonScope();
            kernel.Bind<ICityBusiness>().To<CityBusiness>().InSingletonScope();
            kernel.Bind<ICityRepository>().To<CityRepository>().InSingletonScope();
            kernel.Bind<IClientBusiness>().To<ClientBusiness>().InSingletonScope();
            kernel.Bind<IClientRepository>().To<ClientRepository>().InSingletonScope();
            kernel.Bind<IMonitoringBusiness>().To<MonitoringBusiness>().InSingletonScope();
            kernel.Bind<IMonitoringRepository>().To<MonitoringRepository>().InSingletonScope();
            kernel.Bind<IOwnerRepository>().To<OwnerRepository>().InSingletonScope();
            kernel.Bind<IOwnerBusiness>().To<OwnerBusiness>().InSingletonScope();
            return kernel;
        }
    }
}