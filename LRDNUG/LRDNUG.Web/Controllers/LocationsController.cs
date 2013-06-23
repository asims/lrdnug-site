using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationRepository locationRepository;

        public LocationsController() : this(new LocationRepository())
        {
        }

        public LocationsController(ILocationRepository locationRepository)
        {
            this.locationRepository = locationRepository;
        }

        public ViewResult Index()
        {
            return View(locationRepository.All);
        }


        public ViewResult Details(int id)
        {
            return View(locationRepository.Find(id));
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
                locationRepository.InsertOrUpdate(location);
                locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(locationRepository.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                locationRepository.InsertOrUpdate(location);
                locationRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View(locationRepository.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            locationRepository.Delete(id);
            locationRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}