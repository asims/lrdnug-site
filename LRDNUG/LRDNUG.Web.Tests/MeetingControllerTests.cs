using System;
using System.Web.Mvc;
using LRDNUG.Web.Controllers;
using LRDNUG.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace LRDNUG.Web.Tests
{
    [TestClass]
    public class MeetingControllerTests
    {
        protected IMeetingRepository MeetingRepository { get; set; }

        [TestInitialize]
        public void Setup()
        {
            MeetingRepository = MockRepository.GenerateMock<IMeetingRepository>();
        }

        private MeetingController GetController()
        {
            return new MeetingController(MeetingRepository);
        }


        [TestMethod]
        public void IfNoUpcomingMeeting_NextMeeting_Should_Return_NoMeeting()
        {
            Meeting upcomingMeeting = null;
            MeetingRepository.Stub(x => x.NextUpcomingMeeting(DateTime.MinValue))
                             .IgnoreArguments()
                             .Return(upcomingMeeting);

            var controller = GetController();

            var result = controller.NextMeeting() as ViewResult;

            Assert.AreEqual("NoUpComingMeeting",result.ViewName);

        }


        [TestMethod]
        public void IfUpcomingMeetingExists_NextMeeting_Should_Return_ThatMeeting()
        {
            Meeting upcomingMeeting = new Meeting() {Date = DateTime.Now, ID = 200};
            MeetingRepository.Stub(x => x.NextUpcomingMeeting(DateTime.MinValue))
                             .IgnoreArguments()
                             .Return(upcomingMeeting);

            var controller = GetController();

            var result = controller.NextMeeting() as ViewResult;

            Assert.AreEqual("NextMeeting", result.ViewName);

        }
    }
}