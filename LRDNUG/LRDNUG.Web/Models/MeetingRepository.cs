using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LRDNUG.Web.Models
{ 
    public class MeetingRepository : IMeetingRepository
    {
        LRDNUGWebContext context = new LRDNUGWebContext();

        public IQueryable<Meeting> All
        {
            get { return context.Meetings; }
        }

        public Meeting NextUpcomingMeeting(DateTime todaysDate)
        {
            DateTime startRange = todaysDate;
            DateTime endRange = todaysDate.AddMonths(1);
            return context.Meetings.FirstOrDefault(x => x.Date >= startRange && x.Date <= endRange);
        }

        public Meeting Find(int id)
        {
            return context.Meetings.Find(id);
        }

        public void InsertOrUpdate(Meeting meeting)
        {
            if (meeting.ID == default(int)) {
                // New entity
                context.Meetings.Add(meeting);
            } else {
                // Existing entity
                context.Entry(meeting).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var meeting = context.Meetings.Find(id);
            context.Meetings.Remove(meeting);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<Meeting> PastMeetings(DateTime todaysDate)
        {
            return context.Meetings.Where(x => x.Date <= todaysDate);
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IMeetingRepository : IDisposable
    {
        IQueryable<Meeting> All { get; }
        Meeting NextUpcomingMeeting(DateTime todaysDate);
        Meeting Find(int id);
        void InsertOrUpdate(Meeting meeting);
        void Delete(int id);
        void Save();
        IEnumerable<Meeting> PastMeetings(DateTime todaysDate);
    }
}