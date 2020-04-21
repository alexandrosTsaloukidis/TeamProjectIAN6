using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Interfaces;
using TeamProjectIAN6.ViewModels;

namespace TeamProjectIAN6.Models
{
    public class RestaurantDto : IBusiness
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Capacity { get; set; }
        public int? CurrentCapacity { get; set; }
        public int? CategoryID { get; set; }

        public double? RelativeCapacity
        {
            get
            {
                if (CurrentCapacity != null)
                    return Math.Round( 100 * ((double)CurrentCapacity / Capacity));
                else
                    return null;
            }

        }

        public int? AbsoluteCapacity
        {
            get
            {
                if (CurrentCapacity != null)
                    return Capacity - CurrentCapacity;
                else
                    return null;
            }

        }

        [ValidVat]
        public string Vat { get; set; }

        public int LocationID { get; set; }
        public LocationDto Location { get; set; }
        public Parking Parking { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }

        public double PostalCode { get; set; }
        public bool IsOpened { get; set; }

        public bool IsDeleted { get; set; }
   
        public int? AreaID { get; set; }
        public AreaDto Area { get; set; }
        //public Image ProfilePic { get; set; }
        public CategoryDto Category { get; set; }
      

    }
}