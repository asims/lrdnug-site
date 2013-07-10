using System.Data;
using System.Web.Mvc;
using LRDNUG.Web.Controllers;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class MeetingsController : BaseController
    {
        public ViewResult Index()
        {
            return View(DBContext.Meetings);
        }

        public ViewResult Details(int id)
        {
            return View(DBContext.Meetings.Find(id));
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
                DBContext.Meetings.Add(meeting);
                Success(string.Format("Meeting for '{0}' was added.", meeting.MonthYear));
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            return View(DBContext.Meetings.Find(id));
        }


        [HttpPost]
        public ActionResult Edit(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                DBContext.Meetings.Attach(meeting);
                DBContext.Entry(meeting).State = EntityState.Modified;
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View(DBContext.Meetings.Find(id));
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Meeting meeting = DBContext.Meetings.Find(id);
            DBContext.Meetings.Remove(meeting);

            return RedirectToAction("Index");
        }
    }
}