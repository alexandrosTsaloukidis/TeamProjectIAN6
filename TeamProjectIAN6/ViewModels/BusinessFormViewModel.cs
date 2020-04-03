using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.ViewModels
{
    public class BusinessFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int Capacity { get; set; }

        public string Category { get; set; }

     
        [Required]
        public string Location { get; set; }

        [Required]
        public string Area { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; } 

      
        public double Lattitude { get; set; }  // todo to remove
        public double Longitude { get; set; } // todo to remove

        public double PostalCode { get; set; }

        [Required]
        [ValidVat]
        public string VatNumber { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<Area> Areas { get; set; }
    }
}