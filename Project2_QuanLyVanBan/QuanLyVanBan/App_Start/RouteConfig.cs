using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyVanBan
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Document Category",
                url: "tai-lieu/{metatitle}-{id}",
                defaults: new { controller = "Document", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyVanBan.Controllers" }
            );

            routes.MapRoute(
                name: "Result Document",
                url: "tai-lieu/{searchString}",
                defaults: new { controller = "Document", action = "ListDocSearch", searchString = UrlParameter.Optional },
                namespaces: new[] { "QuanLyVanBan.Controllers" }
            );

            routes.MapRoute(
                name: "Document Detail",
                url: "chi-tiet/{metatitle}-{id}",
                defaults: new { controller = "Document", action = "Detail", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyVanBan.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "QuanLyVanBan.Controllers" }
            );
        }
    }
}
