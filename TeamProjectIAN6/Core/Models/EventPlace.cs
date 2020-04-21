using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class EventPlace
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }


        protected EventPlace ()
        { }

        private EventPlace(Restaurant restaurant)
        {
            RestaurantId = restaurant.ID;
            Name = restaurant.Name;
        }

        public static EventPlace CreateEventPlace(Restaurant restaurant)
        {
            var eventPlace = new EventPlace(restaurant);
            return eventPlace;
        }
    }
}