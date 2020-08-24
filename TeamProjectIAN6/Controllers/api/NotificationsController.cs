using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamProjectIAN6.Core.Dtos;
using TeamProjectIAN6.Core.Models;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext context;

        public NotificationsController()
        {
            context = new ApplicationDbContext();
        }


        [HttpPost]
        private IHttpActionResult Unfollow(FollowRestaurantDto followRestaurantDto)
        {

            context.FollowRestaurants.FirstOrDefault(f => f.RestaurantId == followRestaurantDto.RestaurantId && f.UnfollowDate == null)
                .SetDateTimeUnfollow(DateTime.Now);


            context.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public IHttpActionResult GetNotifications(FollowRestaurantDto followRestaurantDto)
        {

            if (context.FollowRestaurants.Any(f => f.RestaurantId == followRestaurantDto.RestaurantId && f.UnfollowDate == null))
                Unfollow(followRestaurantDto);

            else
            {
                var owners = context.RestaurantOwnerships
                                    .Where(ro => ro.RestaurantId == followRestaurantDto.RestaurantId)
                                    .Select(ro => ro.ApplicationUser);

                var userId = User.Identity.GetUserId();
                var followRestaurant = new FollowRestaurant(userId, followRestaurantDto.RestaurantId, DateTime.Now);
                var notification = Notification.RestaurantFollowed(followRestaurant);


                foreach (var owner in owners)
                {
                    context.Notifications.Add(notification);
                    owner.Notify(notification);
                    foreach (var userNotification in owner.UserNotifications)
                        context.UserNotifications.Add(userNotification);
                }


                context.SaveChanges();
            }
            return Ok();

        }
    }
}
