using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Models;

namespace TeamProjectIAN6.Models
{
    public class Notification
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public NotificationType Type { get; private set; }

        public int FollowRestaurantId { get; private set; }


        [Required]
        public FollowRestaurant FollowRestaurant { get; private set; }

        protected Notification()
        { }

        private Notification(NotificationType type, FollowRestaurant followRestaurant)
        {
            if (followRestaurant == null)
                throw new ArgumentNullException("followRestaurant");

            Type = type;
            FollowRestaurant = followRestaurant;
            DateTime = DateTime.Now;
        }

        public static Notification RestaurantFollowed(FollowRestaurant followRestaurant)
        {
            var notification = new Notification(NotificationType.BusinsessFollowed, followRestaurant);
            return notification;
        }

    }
}