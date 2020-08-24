using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Models;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Core.Dtos
{
    public class NotificationDto
    {
        public DateTime DateTime { get; set; }
        public NotificationType Type { get; set; }
        public FollowRestaurantDto FollowRestaurant { get; set; }
    }
}