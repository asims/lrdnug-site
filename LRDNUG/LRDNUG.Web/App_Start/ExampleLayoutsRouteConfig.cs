using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using LRDNUG.Web.Controllers;
using NavigationRoutes;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>("Home", c => c.Index());
            routes.MapNavigationRoute<MeetingController>("Meetings", c => c.Index())
                  .AddChildRoute<MeetingController>("Next Meeting", c => c.NextMeeting())
                  .AddChildRoute<MeetingController>("Past Meetings", c => c.PastMeetings());
           // routes.MapNavigationRoute<SponsorsController>("Sponsors", c => c.Sponsors());

            routes.MapNavigationRoute<ExampleLayoutsController>("Example Layouts", c => c.Starter())
                  .AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
                  .AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid())
                  .AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn())
                ;
        }
    }
}
