using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class LifeInfo
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public DateTime DateTimeSaved { get; set; }

        public int? CurrentCapacity { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}