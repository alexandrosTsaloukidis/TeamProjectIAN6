using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Core.Models
{
    public class FollowRestaurantDto
    {
        public int ID { get; set; }
        public string UserId { get; set; }

        public int RestaurantId { get; set; }

        public DateTime? FollowDate { get; set; }

        public DateTime? UnfollowDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}