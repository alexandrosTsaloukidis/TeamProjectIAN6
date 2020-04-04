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

        private int capacity;
        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (CurrentClientPopulation <= Capacity)
                    capacity = value;
                else
                    capacity = CurrentClientPopulation;
            }
        }
        public int? CategoryID { get; set; }

        [ValidVat]
        public string Vat { get; set; }

        public int LocationID { get; set; }
        public Location Location { get; set; }
        public Parking Parking { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public int CurrentClientPopulation { get; set; } = 0;

        public int AvailableCapacity 
        {
            get
            {
                return Capacity - CurrentClientPopulation;
            }  
        
        }
        public double PostalCode { get; set; }
        public bool IsOpened { get; set; }

        public void Open()
        {
            IsOpened = true;
        }

        public void Close()
        {
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