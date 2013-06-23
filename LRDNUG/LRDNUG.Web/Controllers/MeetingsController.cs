using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly IMeetingRepository meetingRepository;

        public MeetingsController() : this(new MeetingRepository())
        {
        }

        public MeetingsController(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public ViewResult Index()
        {
            return View(meetingRepository.All);
        }

        public ViewResult Details(int id)
        {
            return View(meetingRepository.Find(id));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                meetingRepository.InsertOrUpdate(meeting);
                meetingRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            return View(meetingRepository.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                meetingRepository.InsertOrUpdate(meeting);
                meetingRepository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(meetingRepository.Find(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            meetingRepository.Delete(id);
            meetingRepository.Save();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                meetingRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}