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
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class NotifiersController : ApiController
    {

        private ApplicationDbContext context;

        public NotifiersController()
        {
            context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList()
                ;
            notifications.ForEach(n => n.Read());

            context.SaveChanges();
            return Ok();
        }
        public IEnumerable<NotificationDto> GetNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.FollowRestaurant.User)
                .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
            //{ 
            //    DateTime = n.DateTime,
            //    Gig = new GigDto
            //    {
            //        Artist = new UserDto
            //        {
            //            Id = n.Gig.Artist.Id,
            //            Name = n.Gig.Artist.Name
            //        },
            //        DateTime = n.Gig.DateTime,
            //        Id = n.Gig.Id,
            //        IsCanceled = n.Gig.IsCanceled,
            //        Venue = n.Gig.Venue
            //    },
            //    OriginalDateTime = n.OriginalDateTime,
            //    OriginalVenue = n.OriginalVenue,
            //    Type = n.Type
            //});
        }
    }
}
