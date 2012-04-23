using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using FundDataMaintenaceBusiness.Interfaces;
using FundDataMaintenaceBusiness.Models;
using FundDataMaintenaceBusiness.Services;
using FundDataMaintenaceBusiness.Settings;
using FundDataMaintenance.Helpers;
using FundDataMaintenance.Infrastructure;
using FundDataMaintenance.Models;
using FundDataMaintenanceData;
using FundDataMaintenanceRepository.Interfaces;
using FundDataMaintenanceRepository.Repositories;
using Microsoft.Practices.Unity;
using AuthenticationService = FundDataMaintenaceBusiness.Services.AuthenticationService;

namespace FundDataMaintenance
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Umbrella", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {

            /* ... */
            IUnityContainer container = InitializeContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static IUnityContainer InitializeContainer()
        {
            IUnityContainer container = new UnityContainer();
            //container.RegisterType<ITodoRepository, TodosRepository>(injectionConstructor);
            var injectionConstructor = new InjectionConstructor(ConfigurationManager.ConnectionStrings["FDAEntities"].ConnectionString);
            container.RegisterType<FDAEntities>(injectionConstructor)
            .RegisterType<IUmbrellaRepository, UmbrellaRepository>()
            .RegisterType<IReferenceRepository, ReferenceRepository>()
            .RegisterType<IPartyRepository, PartyRepository>()
            .RegisterType<IUmbrellaService, UmbrellaService>()
            .RegisterType<IAuthenticationService, AuthenticationService>()
            .RegisterType <IActiveDirectorySettings, ActiveDirectorySettings>()
            ;
            //new InjectionConstructor(ConfigurationManager.ConnectionStrings["FDAEntities"].ConnectionString);
            return container;
        }
    }
}