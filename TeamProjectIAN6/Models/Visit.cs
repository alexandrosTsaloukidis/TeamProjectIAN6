using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Models
{
    public class Visit
    {
        public int ID { get; set; }
        public int ApplicationUserId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime? ArrivalDateTime { get; set; }
        public DateTime? DepartureDateTime { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}