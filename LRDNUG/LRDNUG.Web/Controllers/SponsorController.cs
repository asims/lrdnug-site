using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LRDNUG.Web.Controllers
{
    public class SponsorController : BaseController
    {
        public ActionResult Index()
        {
            var sponsors = DBContext.Sponsors.ToList();
            return View(sponsors);
        }

    }
}
