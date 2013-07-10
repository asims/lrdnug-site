using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class BaseController : BootstrapBaseController
    {

        public LRDNUGWebContext DBContext { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DBContext = (LRDNUGWebContext)HttpContext.Items["CurrentLRDNUGWebContext"];
        }
    }
}