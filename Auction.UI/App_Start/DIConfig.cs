using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac.Builder;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Service;
using System.Web.Mvc;
using Auction.Service.CloudStorage;

namespace Auction.UI.App_Start
{
    public static class DIConfig
    {

        public static void Config()
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerRequest();
            builder.RegisterType<CloudinaryStorage>().As<ICloudStorage>().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            IContainer container =  builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }




    }
}