using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCWebApp.Models
{
    /*
        I would use a single Context class inheriting from IdentityDbContext. 
        This way you can have the context be aware of any relations between 
        your classes and the IdentityUser and Roles of the IdentityDbContext. 
        There is very little overhead in the IdentityDbContext, it is 
        basically a regular DbContext with two DbSets. One for the users and
        one for the roles.
    */
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /*
        Voeg hieronder de klasses toe waarvan je wilt dat ze (middels een migratie) ook in de database komen.
        */
        public DbSet<Product> Products { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Image> Images { get; set; }

        public override int SaveChanges()
        {
            // From http://benjii.me/2014/03/track-created-and-modified-fields-automatically-with-entity-framework-code-first/
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                    ((BaseEntity)entity.Entity).Created = DateTime.Now;
                ((BaseEntity)entity.Entity).Modified = DateTime.Now;
            }

            return base.SaveChanges();
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}