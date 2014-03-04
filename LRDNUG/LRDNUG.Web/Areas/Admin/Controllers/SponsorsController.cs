using System.Data;
using System.Data.Entity;
using System.Web.Mvc;
using LRDNUG.Web.Controllers;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SponsorsController : BaseController
    {
        public ViewResult Index()
        {
            return View(DBContext.Sponsors);
        }


        public ViewResult Details(int id)
        {
            return View(DBContext.Sponsors.Find(id));
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Sponsors sponsors)
        {
            if (ModelState.IsValid)
            {
                DBContext.Sponsors.Add(sponsors);
                Success(string.Format("Sponsor named '{0}' was added.", sponsors.Name));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(DBContext.Sponsors.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Sponsors sponsors)
        {
            if (ModelState.IsValid)
            {
                DBContext.Sponsors.Attach(sponsors);
                DBContext.Entry(sponsors).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View(DBContext.Sponsors.Find(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Sponsors sponsor = DBContext.Sponsors.Find(id);
            DBContext.Sponsors.Remove(sponsor);

            return RedirectToAction("Index");
        }
    }
}