using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class Parking
    {
        public int RestaurantId { get; set; }
        public int ParkingCapacity { get; set; }
        public Restaurant Restaurant { get; set; }

    }
}