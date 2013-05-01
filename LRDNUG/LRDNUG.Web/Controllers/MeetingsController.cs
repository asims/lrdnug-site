using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{   
    public class MeetingsController : Controller
    {
		private readonly IMeetingRepository meetingRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public MeetingsController() : this(new MeetingRepository())
        {
        }

        public MeetingsController(IMeetingRepository meetingRepository)
        {
			this.meetingRepository = meetingRepository;
        }

        //
        // GET: /Meetings/

        public ViewResult Index()
        {
            return View(meetingRepository.All);
        }

        //
        // GET: /Meetings/Details/5

        public ViewResult Details(int id)
        {
            return View(meetingRepository.Find(id));
        }

        //
        // GET: /Meetings/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Meetings/Create

        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid) {
                meetingRepository.InsertOrUpdate(meeting);
                meetingRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /Meetings/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(meetingRepository.Find(id));
        }

        //
        // POST: /Meetings/Edit/5

        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (ModelState.IsValid) {
                meetingRepository.InsertOrUpdate(meeting);
                meetingRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /Meetings/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(meetingRepository.Find(id));
        }

        //
        // POST: /Meetings/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            meetingRepository.Delete(id);
            meetingRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                meetingRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

