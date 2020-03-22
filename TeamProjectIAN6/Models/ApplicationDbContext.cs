using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Visit> Visits { get; set; }

        public DbSet<Education> Educations { get; set; }

        public DbSet<Occupation> Occupations { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<RestaurantOwnership> RestaurantOwnerships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Parking>()
                .HasKey(p => p.RestaurantId)
                ;

            modelBuilder.Entity<Restaurant>()
                .HasOptional(r => r.Parking)
                .WithRequired(p => p.Restaurant)
                ;

        }

        public ApplicationDbContext()
            : base("TeamProjectDatabase", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}