using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LRDNUG.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "MeetingMonthYear",
                url: "pastmeetings/{year}/{month}",
                defaults: new { controller = "Meeting", action = "DetailByMonthYear", month = DateTime.Now.Month, year = DateTime.Now.Year, area = "" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Meeting", action = "Index", id = UrlParameter.Optional, area = "" }
            );
        }
    }
}