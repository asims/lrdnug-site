using System;
using System.Linq;
using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class MeetingController : BaseController
    {
        public ActionResult Index()
        {
            return NextMeeting();
        }

        public ActionResult NextMeeting()
        {
            Meeting nextMeeting = DBContext.Meetings
                                           .WhereIsNextMeeting(DateTime.Now)
                                           .OrderBy(x => x.Date)
                                           .FirstOrDefault();

            if (nextMeeting == null)
            {
                return View("NoUpComingMeeting");
            }
            return View("NextMeeting", nextMeeting);
        }

        public ActionResult PastMeetings()
        {
            IQueryable<Meeting> pastMeetings = DBContext.Meetings.WhereMeetingIsInPast(DateTime.Now).OrderByDescending(x => x.Date);
            return View("PastMeetings", pastMeetings);
        }

        public ActionResult Detail(int id)
        {
            var meeting = DBContext.Meetings.FirstOrDefault(x => x.ID == id);
            if (meeting == null)
            {
                return RedirectToAction("PastMeetings");
            }

            return View(meeting);
        }

        public ActionResult DetailByMonthYear(string month, int year)
        {
            var monthyear = month + " " + year.ToString();
            var meeting = DBContext.Meetings.FirstOrDefault(x => x.MonthYear == monthyear);
            if (meeting == null)
            {
                return RedirectToAction("PastMeetings");
            }

            return View("Detail", meeting);
        }
    }
}