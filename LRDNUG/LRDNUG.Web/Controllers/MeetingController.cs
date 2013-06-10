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
                Month = "June",
                Date = "Thursday June 13, 2013",
                Time = "5:30 Mixer / 6:00 - 7:30 Speaker",
                SpeakerBio =
                    @"Lee Ann Benson is currently a BI Consultant at Acxiom in Little Rock. Throughout her career she has helped close the gap between business users and IT by helping each group understand how the other operates and thinks. She has been in the Business Intelligence industry for over 10 years and holds a BSM - Accounting from Tulane University in New Orleans, LA.",
                SpeakerName = "Lee Ann Benson",
                Title = "Visually Design the User Journey",
                Description =
                    @"Vision is the most powerful and efficient way to communicate information in a technological world. Approximately 70% of our sense receptors are dedicated to vision. Understanding how the brain processes this information is essential to the effective design of web pages, applications, graphics and infographics that tell a story and lead users through the journey we want them to take. " +
                    @"<br/><br/>We will briefly discuss the mechanics of sight, preattentive processing, limitations to perception and memory and Gestalt Principles of Visual Perception that will influence how we design for understanding and clarity."
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
