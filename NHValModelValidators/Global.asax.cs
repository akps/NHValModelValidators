﻿using System.Web.Mvc;
using System.Web.Routing;
using NHValModelValidators.Validation;

namespace NHValModelValidators
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            ModelValidatorProviders.Providers.Clear(); //Remove the default data annotations validations

            ModelValidatorProviders.Providers.Add(new NHibernateValidatorProvider()); //Server side validation provider
            ModelValidatorProviders.Providers.Add(new NHibernateValidatorClientProvider()); //Client side validation provider
        }
    }
}