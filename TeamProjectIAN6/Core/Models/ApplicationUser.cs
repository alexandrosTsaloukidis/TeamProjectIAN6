﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TeamProjectIAN5.Models;
using TeamProjectIAN6.Core.Models;

namespace TeamProjectIAN6.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public DateTime DateOfBirth { get; set; }

        public int Age 
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }  
        }

        public Gender Gender { get; set; }



        public int? EducationId { get; set; }
        public Education Education { get; set; }

        public int? OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        public byte[] UserPhoto { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public ICollection<UserNotification> UserNotifications { get; set; }

        public ICollection<Opening> Users { get; set; }
        public ICollection<Opening> UserClosers { get; set; }

        public ICollection<RestaurantOwnership> RestaurantOwnerships { get; set; }

        public ICollection<FollowRestaurant> FollowRestaurants { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


        public ApplicationUser()
        {

            UserNotifications = new Collection<UserNotification>();
        }

        public void Notify(Notification notification)
        {
            UserNotifications.Add(new UserNotification(this, notification));
        }
    }

    
}