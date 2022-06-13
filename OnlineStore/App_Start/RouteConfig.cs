using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineStore.Controllers"}
            );
            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineStore.Controllers" }
            );
            routes.MapRoute(
                name: "Contact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineStore.Controllers" }
            );
            routes.MapRoute(
                name: "Register",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineStore.Controllers" }
            );
            routes.MapRoute(
              name: "Create Contact",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Contact", action = "Create", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineStore.Controllers" }
          );
            routes.MapRoute(
               name: "Add cart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineStore.Controllers" }
           );
            routes.MapRoute(
               name: "Update cart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "UpdateItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineStore.Controllers" }
           );
            routes.MapRoute(
               name: "Delete cart",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "DeleteItem", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineStore.Controllers" }
           );
            routes.MapRoute(
               name: "Payment",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "Payment", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineStore.Controllers" }
           );
            routes.MapRoute(
              name: "Contact Success",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Contact", action = "Success", id = UrlParameter.Optional },
              namespaces: new[] { "OnlineStore.Controllers" }
          );
            routes.MapRoute(
               name: "Payment Success",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
               namespaces: new[] { "OnlineStore.Controllers" }
           );
            routes.MapRoute(
                name: "Detail",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineStore.Controllers" }
            );
        }
    }
}
