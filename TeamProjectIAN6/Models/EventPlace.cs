using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class EventPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}