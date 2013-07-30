using System;
using System.Linq;
using LRDNUG.Web.Models;

namespace LRDNUG.Web.Controllers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, int currentPage, int defaultPage, int pageSize)
        {
            return query
                .Skip((currentPage - defaultPage)*pageSize)
                .Take(pageSize);
        }

        public static IQueryable<Meeting> WhereIsNextMeeting(this IQueryable<Meeting> query, DateTime todaysDate)
        {
            DateTime startRange = todaysDate.AddDays(-7);
            DateTime endRange = todaysDate.AddMonths(1);
            return query.Where(x => x.Date >= startRange && x.Date <= endRange);
        }

        public static IQueryable<Meeting> WhereMeetingIsInPast(this IQueryable<Meeting> query, DateTime todaysDate)
        {
            return query.Where(x => x.Date <= todaysDate);
        }
    }
}