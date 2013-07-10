using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BootstrapMvcSample;
using BootstrapSupport;
using LRDNUG.Web.Models;

namespace LRDNUG.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        public MvcApplication()
        {
            BeginRequest +=
                (sender, args) => { HttpContext.Current.Items["CurrentLRDNUGWebContext"] = new LRDNUGWebContext(); };
            EndRequest += (sender, args) =>
                {
                    using (var session = (LRDNUGWebContext) HttpContext.Current.Items["CurrentLRDNUGWebContext"])
                    {
                        if (session == null)
                            return;

                        if (Server.GetLastError() != null)
                            return;

                        session.SaveChanges();
                    }
                };
        }

        protected void Application_Start()
        {
            // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<LRDNUG.Web.Models.LRDNUGWebContext>());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapBundleConfig.RegisterBundles(BundleTable.Bundles);
            ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            AuthConfig.RegisterAuth();
        }
    }
}