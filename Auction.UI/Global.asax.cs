using Auction.Data;
using Auction.UI.App_Start;
using Auction.UI.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
namespace Auction.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        

        protected void Application_Start()
        {
           Database.SetInitializer(new InitialData());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegistreBundles(BundleTable.Bundles);
            DIConfig.Config();
            AutoMapperConfiguration.Configure();
        }
    }
}
