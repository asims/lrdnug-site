using System.Web.Security;
using LRDNUG.Web.Models;
using WebMatrix.WebData;

namespace LRDNUG.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LRDNUG.Web.Models.LRDNUGWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LRDNUG.Web.Models.LRDNUGWebContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Locations.AddOrUpdate(
              p => p.Name,
              new Location { Name = "The Joint", City = "North Little Rock", State = "AR", Street1 = "301 Main St", Zip="72114" },
              new Location { Name = "Pulaski Tech", City = "North Little Rock", State = "AR", Street1 = "3000 W Scenic Dr", Street2 = "Student Center Lecture room 212", Zip="72118" }
            );

            WebSecurity.InitializeDatabaseConnection("LRDNUGWebContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);

            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
        }
    }
}
