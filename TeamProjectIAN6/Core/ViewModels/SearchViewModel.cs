using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Models;
using TeamProjectIAN6.Models;
using TeamProjectIAN6.ViewModels;

namespace TeamProjectIAN6.Core.ViewModels
{
    public class SearchViewModel
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


        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public double PostalCode { get; set; }

        public int? CurrentCapacity { get; set; }

        public int? AbsoluteCapacity { get; set; }

        public double? RelativeCapacity { get; set; }

        public bool IsOpened { get; set; }

        public bool IsFollowed { get; set; }

        public string PhoneNumber { get; set; }
        [Required]
        [ValidVat]
        public string VatNumber { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<Area> Areas { get; set; }

        public IEnumerable<FollowRestaurant> FollowRestaurants { get; set;}
        public string LocationSequence { get; set; }

        public string AreaSequence { get; set; }

        public string CategorySequence { get; set; }

        


    }
}