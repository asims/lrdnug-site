using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class SponsorsController : Controller
    {
        private readonly ISponsorsRepository sponsorsRepository;

        public SponsorsController() : this(new SponsorsRepository())
        {
        }

        public SponsorsController(ISponsorsRepository sponsorsRepository)
        {
            this.sponsorsRepository = sponsorsRepository;
        }


        public ViewResult Index()
        {
            return View(sponsorsRepository.All);
        }


        public ViewResult Details(int id)
        {
            return View(sponsorsRepository.Find(id));
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
                sponsorsRepository.InsertOrUpdate(sponsors);
                sponsorsRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(sponsorsRepository.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Sponsors sponsors)
        {
            if (ModelState.IsValid)
            {
                sponsorsRepository.InsertOrUpdate(sponsors);
                sponsorsRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View(sponsorsRepository.Find(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            sponsorsRepository.Delete(id);
            sponsorsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sponsorsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}