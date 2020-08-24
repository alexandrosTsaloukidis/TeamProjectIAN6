using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Core.Models
{
    public class FollowRestaurant
    {
        public int ID { get; set; }
        public string UserId { get; set; }

        public int RestaurantId { get; set; }

        public DateTime? FollowDate { get; set; }

        public DateTime? UnfollowDate { get; set; }

        public ApplicationUser User { get; set; }
        public Restaurant Restaurant { get; set; }

        protected FollowRestaurant() 
        { }

        public FollowRestaurant (string userID, int restaurantID, DateTime followDate)
        {
            UserId = userID;
            RestaurantId = restaurantID;
            FollowDate = followDate;

        }


        public void SetDateTimeUnfollow(DateTime dateTime)
        {
            UnfollowDate = dateTime;
           
        }

        public static FollowRestaurant CreateFollowRestaurant (string userID, int restaurantID, DateTime followDate)
        {
            return new FollowRestaurant(userID, restaurantID, followDate);
        }
    }
}