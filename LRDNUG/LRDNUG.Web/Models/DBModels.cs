using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LRDNUG.Web.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string MapUrl { get; set; }
    }

    public class Meeting
    {
        public int ID { get; set; }
        public string PresentationTitle { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerBio { get; set; }
        public string SpeakerTwitter { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string MonthYear { get; set; }
        public virtual Location Location { get; set; }
        public string SurveyURL { get; set; }
    }

    public class Sponsors
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public string LogoUrl { get; set; }
    }

    public class MeetingStats
    {
        public int ID { get; set; }
        public string Notes { get; set; }
        public int Attendence { get; set; }

    }
}