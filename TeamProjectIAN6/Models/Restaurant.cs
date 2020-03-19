using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }

        public string Category { get; set; }

        public int LocationID { get; set; }
        public Parking Parking { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public double PostalCode { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}