using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

    }
}