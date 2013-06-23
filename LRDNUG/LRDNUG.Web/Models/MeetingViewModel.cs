using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRDNUG.Web.Models
{
    public class MeetingViewModel
    {
        public string PresentationTitle { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerBio { get; set; }
        public string SpeakerTwitter { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string StartTime { get; set; }
        public string MonthYear { get; set; }
        public string SurveyURL { get; set; }
        
        public string LocationName { get; set; }
        public string LocationStreet1 { get; set; }
        public string LocationStreet2 { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string LocationZip { get; set; }
        public string LocationMapUrl { get; set; }

        
    }
}