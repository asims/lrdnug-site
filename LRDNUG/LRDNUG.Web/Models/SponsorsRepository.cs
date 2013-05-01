using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LRDNUG.Web.Models
{ 
    public class SponsorsRepository : ISponsorsRepository
    {
        LRDNUGWebContext context = new LRDNUGWebContext();

        public IQueryable<Sponsors> All
        {
            get { return context.Sponsors; }
        }

        public IQueryable<Sponsors> AllIncluding(params Expression<Func<Sponsors, object>>[] includeProperties)
        {
            IQueryable<Sponsors> query = context.Sponsors;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Sponsors Find(int id)
        {
            return context.Sponsors.Find(id);
        }

        public void InsertOrUpdate(Sponsors sponsors)
        {
            if (sponsors.ID == default(int)) {
                // New entity
                context.Sponsors.Add(sponsors);
            } else {
                // Existing entity
                context.Entry(sponsors).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var sponsors = context.Sponsors.Find(id);
            context.Sponsors.Remove(sponsors);
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

    public interface ISponsorsRepository : IDisposable
    {
        IQueryable<Sponsors> All { get; }
        IQueryable<Sponsors> AllIncluding(params Expression<Func<Sponsors, object>>[] includeProperties);
        Sponsors Find(int id);
        void InsertOrUpdate(Sponsors sponsors);
        void Delete(int id);
        void Save();
    }
}