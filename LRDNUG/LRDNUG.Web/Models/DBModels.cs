using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LRDNUG.Web.Models
{
    public class Location
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public string Zip { get; set; }
        public string MapUrl { get; set; }
    }

    public class Meeting
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Title")]
        public string PresentationTitle { get; set; }
        [Required]
        [DisplayName("Speaker Name")]
        public string SpeakerName { get; set; }
        [DisplayName("Speaker Bio")]
        public string SpeakerBio { get; set; }
        [DisplayName("Twitter Handle")]
        public string SpeakerTwitter { get; set; }
        [DisplayName("Topic Description")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Date of Presentation")]
        public DateTime Date { get; set; }

        [DisplayName("Starting Time")]
        public string StartTime { get; set; }
        [Required]
        [DisplayName("Month & Year")]
        public string MonthYear { get; set; }
        public virtual Location Location { get; set; }
        [DisplayName("Survey URL (if applicable)")]
        public string SurveyURL { get; set; }
    }

    public class Sponsors
    {
        public int ID { get; set; }
        [Required]
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