using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class MeetingController : Controller
    {
        public MeetingController(IMeetingRepository meetingRepository)
        {
            MeetingRepository = meetingRepository;
            Mapper.CreateMap<Meeting, MeetingViewModel>();
        }

        private IMeetingRepository MeetingRepository { get; set; }


        public ActionResult NextMeeting()
        {
            var nextMeeting = MeetingRepository.NextUpcomingMeeting(DateTime.Now);

            if (nextMeeting == null)
            {
                return View("NoUpComingMeeting");
            }

            var model = Mapper.Map<Meeting, MeetingViewModel>(nextMeeting);
            return View("NextMeeting", model);
        }

        public ActionResult PastMeetings()
        {
            var pastMeetings = MeetingRepository.PastMeetings(DateTime.Now).ToList();
            return View("PastMeetings",  Mapper.Map<List<Meeting>, List<MeetingViewModel>>(pastMeetings));
        }


        public ActionResult Index()
        {
            return NextMeeting();
        }
    }
}