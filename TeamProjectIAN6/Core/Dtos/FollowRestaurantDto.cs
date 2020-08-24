using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Core.Models
{
    public class FollowRestaurantDto
    {

        public int RestaurantId { get; set; }

        public ApplicationUser User { get; set; }


    }
}