using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRDNUG.Web.Models
{
    public class MeetingModel
    {
        public string Title { get; set; }
        public string SpeakerName { get; set; }
        public string SpeakerBio { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Month { get; set; }
    }
}