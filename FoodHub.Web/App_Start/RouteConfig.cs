using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FoodHub.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // /trace.axd/1/2/3/4
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // /home/contact/1
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //try this commenting above and see how details works (it pass id as a optional parameters /details/5?id=1 is also work)
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{key}",
            //    defaults: new { controller = "Home", action = "Index", key = UrlParameter.Optional }
            //);
        }
    }
}
