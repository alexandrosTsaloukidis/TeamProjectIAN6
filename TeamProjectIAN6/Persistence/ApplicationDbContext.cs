using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Persistence.EntityConfigurations;

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

        public DbSet<Opening> Openings { get; set; }

        public DbSet<LifeInfo> LifeInfos { get; set; }

        public DbSet<RestaurantOwnership> RestaurantOwnerships { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<EventPlace> EventPlaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Parking>()
                .HasKey(p => p.RestaurantId)
                ;

            //modelBuilder.Entity<Restaurant>()
            //    .HasOptional(r => r.Parking)
            //    .WithRequired(p => p.Restaurant)
            //    ;

            modelBuilder.Configurations.Add(new RestaurantConfiguration());

            modelBuilder.Entity<Opening>()
                .HasOptional(o => o.User)
                .WithMany(u => u.Users)
                .HasForeignKey(o => o.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Opening>()
                .HasOptional(o => o.UserCloser)
                .WithMany(u => u.UserClosers)
                .HasForeignKey(o => o.UserCloserId)
                .WillCascadeOnDelete(false);

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