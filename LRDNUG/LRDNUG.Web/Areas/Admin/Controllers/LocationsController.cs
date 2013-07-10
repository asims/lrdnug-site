using System.Data;
using System.Web.Mvc;
using LRDNUG.Web.Controllers;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LocationsController : BaseController
    {
        public ViewResult Index()
        {
            return View(DBContext.Locations);
        }


        public ViewResult Details(int id)
        {
            return View(DBContext.Locations.Find(id));
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                DBContext.Locations.Add(location);
                Success(string.Format("Location named '{0}' was added.", location.Name));
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(DBContext.Locations.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                DBContext.Locations.Attach(location);
                DBContext.Entry(location).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View(DBContext.Locations.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = DBContext.Locations.Find(id);
            DBContext.Locations.Remove(location);

            return RedirectToAction("Index");
        }
    }
}