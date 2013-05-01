using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{   
    public class SponsorsController : Controller
    {
		private readonly ISponsorsRepository sponsorsRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public SponsorsController() : this(new SponsorsRepository())
        {
        }

        public SponsorsController(ISponsorsRepository sponsorsRepository)
        {
			this.sponsorsRepository = sponsorsRepository;
        }

        //
        // GET: /Sponsors/

        public ViewResult Index()
        {
            return View(sponsorsRepository.All);
        }

        //
        // GET: /Sponsors/Details/5

        public ViewResult Details(int id)
        {
            return View(sponsorsRepository.Find(id));
        }

        //
        // GET: /Sponsors/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Sponsors/Create

        [HttpPost]
        public ActionResult Create(Sponsors sponsors)
        {
            if (ModelState.IsValid) {
                sponsorsRepository.InsertOrUpdate(sponsors);
                sponsorsRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Sponsors/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(sponsorsRepository.Find(id));
        }

        //
        // POST: /Sponsors/Edit/5

        [HttpPost]
        public ActionResult Edit(Sponsors sponsors)
        {
            if (ModelState.IsValid) {
                sponsorsRepository.InsertOrUpdate(sponsors);
                sponsorsRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Sponsors/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(sponsorsRepository.Find(id));
        }

        //
        // POST: /Sponsors/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            sponsorsRepository.Delete(id);
            sponsorsRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                sponsorsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

