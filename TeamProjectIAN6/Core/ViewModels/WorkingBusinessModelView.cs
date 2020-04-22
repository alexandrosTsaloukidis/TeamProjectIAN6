using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamProjectIAN6.ViewModels
{
    public class WorkingBusinessModelView
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int Capacity { get; set; }

        public string Category { get; set; }

        public string Location { get; set; }
        public string Area { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public int? CurrenCapacity { get; set; }
        public bool IsOpened { get; set; }
        public double Lattitude { get; set; } 
        public double Longitude { get; set; }

        public string PhoneNumber { get; set; }
        public double PostalCode { get; set; }
     
    }
}