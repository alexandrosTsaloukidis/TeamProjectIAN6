using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class RestaurantOwnership
    {

        public int Id { get; private set; }
        public string ApplicationUserId { get; private set; }

        public int? RestaurantId { get; private set; }
        public DateTime StartOwnershipDateTime { get; private set; }
        public DateTime? QuitOwnershipDateTime { get; private set; }

        public ApplicationUser ApplicationUser { get; private set; }
        public Restaurant Restaurant { get; private set; }

        protected RestaurantOwnership()
        { }


        private RestaurantOwnership(Restaurant restaurant, string userId)
        {
            ApplicationUserId = userId;
            RestaurantId = restaurant.ID;
            StartOwnershipDateTime = DateTime.Now;
        }

        public static RestaurantOwnership CeateRestaurantOwnership(Restaurant restaurant, string userId)
        {
            var restaurantOwnership = new RestaurantOwnership(restaurant, userId);
            return restaurantOwnership;
        }
    }
}