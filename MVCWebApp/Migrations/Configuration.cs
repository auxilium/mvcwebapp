namespace MVCWebApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCWebApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCWebApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCWebApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUserAndRole(context);
        }

        bool AddUserAndRole(MVCWebApp.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole(Statics.RoleNames.Administrator));
            ir = rm.Create(new IdentityRole(Statics.RoleNames.CanManageUsers));
            ir = rm.Create(new IdentityRole(Statics.RoleNames.CanEdit));


            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));


            var admin = new ApplicationUser()
            {
                UserName = "admin@MVCWebApp.nl",
                Email = "admin@MVCWebApp.nl",
                EmailConfirmed = true
            };
            ir = um.Create(admin, "password");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(admin.Id, Statics.RoleNames.Administrator);

            var user = new ApplicationUser()
            {
                UserName = "user@MVCWebApp.nl",
                Email = "user@MVCWebApp.nl",
                EmailConfirmed = true
            };
            ir = um.Create(user, "password");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, Statics.RoleNames.CanManageUsers);

            return ir.Succeeded;
        }
    }
}
