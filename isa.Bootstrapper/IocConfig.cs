using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Isa.Bootstrapper;
using Isa.Core.Repositories;
using Isa.Core.Services.Services;
using Isa.Infrastructures.Repositories;
using Isa.Infrastructures.Services.Services;
using Isa.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Isa.Infrastructures.Repositories.Repositories;
using Isa.Core.Repositories.Repositories;
using Isa.Infrastructures.Repositories.Data;
using AutoMapper;
using AideCaviardage.Services.DomainMapping;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(IocConfig), "RegisterDependencies")]
namespace Isa.Bootstrapper
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();
            builder.RegisterType(typeof(SalesContext)).As(typeof(IEntitiesContext)).InstancePerRequest();
            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType(typeof(InvoiceService)).As(typeof(IInvoiceService)).InstancePerRequest();
            builder.RegisterType(typeof(ClientService)).As(typeof(IClientService)).InstancePerRequest();

            //  builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();



            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            


        }
    }
}
