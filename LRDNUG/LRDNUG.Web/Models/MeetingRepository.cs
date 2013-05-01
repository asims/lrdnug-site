using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public IQueryable<Meeting> AllIncluding(params Expression<Func<Meeting, object>>[] includeProperties)
        {
            IQueryable<Meeting> query = context.Meetings;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
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

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IMeetingRepository : IDisposable
    {
        IQueryable<Meeting> All { get; }
        IQueryable<Meeting> AllIncluding(params Expression<Func<Meeting, object>>[] includeProperties);
        Meeting Find(int id);
        void InsertOrUpdate(Meeting meeting);
        void Delete(int id);
        void Save();
    }
}