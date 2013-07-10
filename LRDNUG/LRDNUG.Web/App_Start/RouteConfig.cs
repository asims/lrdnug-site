using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using LRDNUG.Web.Controllers;
using NavigationRoutes;

namespace LRDNUG.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Meeting", action = "Index", id = UrlParameter.Optional }


            );

            routes.MapNavigationRoute<MeetingController>("Next Meeting", c => c.NextMeeting());
            routes.MapNavigationRoute<MeetingController>("Past Meetings", c => c.PastMeetings());
        }
    }
}