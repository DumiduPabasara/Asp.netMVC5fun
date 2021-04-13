using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FoodHub.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FoodHub.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly); //ask for Assembly property of MvcApplication (from Global.asax.cs) type
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly); 

            //please register this type, InMemoryRestaurantData => autoFac knows this type now and use that type when someone needs something that implements IRestaurantData
            builder.RegisterType<InMemoryRestaurantData>()
                .As<IRestaurantData>()
                .SingleInstance(); //singleton

            var container = builder.Build(); //construct autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}