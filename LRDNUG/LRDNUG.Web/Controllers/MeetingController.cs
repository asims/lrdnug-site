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
                                           .FirstOrDefault();

            if (nextMeeting == null)
            {
                return View("NoUpComingMeeting");
            }
            return View("NextMeeting", nextMeeting);
        }

        public ActionResult PastMeetings()
        {
            IQueryable<Meeting> pastMeetings = DBContext.Meetings.WhereMeetingIsInPast(DateTime.Now);
            return View("PastMeetings", pastMeetings);
        }
    }
}