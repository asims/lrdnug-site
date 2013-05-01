using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public class MeetingController : Controller
    {
        public ActionResult NextMeeting()
        {
            var model = new MeetingModel
            {
                Month = "May",
                Date = "Thursday May 9, 2013",
                Time = "5:30 Mixer / 6:00 - 7:30 Speaker",
                SpeakerBio =
                    @"By day, Joe is a Senior Software Engineer at Acxiom corporation where he spends his time developing 'big data' distributed Java/C++ applications on Linux. By night, he tinkers with with other technologies including game development engines like Unity3D.",
                SpeakerName = "Joe Hurdle (@joecodemonkey)",
                Title = "Intro to Unity 3D",
                Description =
                    @"This presentation will give developers an introduction to the Unity game engine. It will delve into both the editor and the engine's use of C# as a scripting language. A simple game called " +
                    @"Can Shooter will be used to illustrate in the simplest terms possible how scripts work in Unity and what it takes to put together a game.<br/><br/>" +
                    @"Prior to the meeting, attendees are encouraged to download Unity from the website, http://unity3d.com/unity/download/. Joe will also be providing a link where the completed Can Shooter game and it's source may be downloaded so it's possible to follow along."
            };
            return View("NextMeeting", model);
        }

        public ActionResult PastMeetings()
        {
            return View();
        }


        public ActionResult Index()
        {
            return NextMeeting();
        }
    }
}
