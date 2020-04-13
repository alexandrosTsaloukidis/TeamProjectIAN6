using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Interfaces;
using TeamProjectIAN6.ViewModels;

namespace TeamProjectIAN6.Models
{
    public class Restaurant : IBusiness
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
                    return Math.Round((double)CurrentCapacity / Capacity);
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
        public Location Location { get; set; }
        public Parking Parking { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }
 
        public double PostalCode { get; set; }
        public bool IsOpened { get; set; }

        public bool IsDeleted { get; set; }
        public void Open()
        {
            IsOpened = true;
        }

        public void Close()
        {
            IsOpened = false;
        }

        public void Delete()
        {
            IsDeleted = true;
            IsOpened = false;
        }
        public int? AreaID { get; set; }
        public Area Area { get; set; }
        //public Image ProfilePic { get; set; }
        public Category Category { get; set; }
        public ICollection<Opening> Openings { get; set; }

        public ICollection<RestaurantOwnership> RestaurantOwnerships { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }


    
       
    }
}