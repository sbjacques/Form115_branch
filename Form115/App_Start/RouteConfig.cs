using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Form115 {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            
            routes.MapRoute(
                "Blog",                                           // Route name
                "Hotel/Details/{id}/{startDate}/{endDate}",       // URL with parameters
                new { controller = "Hotel", action = "DetailsPeriode" }  // Parameter defaults
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
