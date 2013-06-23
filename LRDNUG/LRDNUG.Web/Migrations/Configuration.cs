using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<LRDNUGWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LRDNUGWebContext context)
        {
            var locations = new List<Location>
                {
                    new Location
                        {
                            Name = "The Joint",
                            Street1 = "301 Main St",
                            City = "North Little Rock",
                            State = "AR",
                            Zip = "72114",
                            MapUrl = "http://goo.gl/maps/JNVgF"
                        }
                };

            locations.ForEach(s => context.Locations.AddOrUpdate(l => l.Name, s));
            context.SaveChanges();

            var meetings = new List<Meeting>
                {
                    new Meeting
                        {
                            Date = DateTime.Parse("1/1/2013"),
                            Description = "Test Topic Description",
                            Location = locations.First(),
                            MonthYear = "January 2013",
                            PresentationTitle = "Test Presentation Title",
                            SpeakerBio = "Test Speaker Bio",
                            SpeakerName = "John Doe",
                            SpeakerTwitter = "@JohnDoeSpeaker",
                            StartTime = "5:30pm",
                            SurveyURL = "http://surveymonkey.com/testtopic"
                        }
                };

            meetings.ForEach(s => context.Meetings.AddOrUpdate(l => l.Date, s));
            context.SaveChanges();
        }
    }
}