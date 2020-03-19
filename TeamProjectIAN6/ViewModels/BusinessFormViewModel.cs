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
        public int LocationID { get; set; }

        [Required]
        [ValidVat]
        public string VatNumber { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}