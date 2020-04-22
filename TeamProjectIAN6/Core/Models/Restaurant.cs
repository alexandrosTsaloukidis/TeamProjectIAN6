using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Models;
using TeamProjectIAN6.Core.ViewModels;
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
                    return Math.Round(100 * ((double)CurrentCapacity / Capacity)); 
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

        public string PhoneNumber { get; set; }
        public byte[] Logo { get; set; }
        public ICollection<Opening> Openings { get; private set; }

        public ICollection<RestaurantOwnership> RestaurantOwnerships { get; private set; }
        public ICollection<Visit> Visits { get; private set; }


        public Restaurant()
        {
            Openings = new Collection<Opening>();
            RestaurantOwnerships = new Collection<RestaurantOwnership>();
            Visits = new Collection<Visit>();


        }


        private Restaurant(BusinessFormViewModel businessFormViewModel)
        {
            Name = businessFormViewModel.Name;
            Capacity = businessFormViewModel.Capacity;
            CategoryID = businessFormViewModel.Categories.SingleOrDefault(c => c.Name == businessFormViewModel.Category).Id;
            AreaID = businessFormViewModel.Areas.SingleOrDefault(a => a.Name == businessFormViewModel.Area).Id;
            LocationID = businessFormViewModel.Locations.SingleOrDefault(l => l.Name == businessFormViewModel.Location).ID;
            StreetName = businessFormViewModel.StreetName;
            StreetNumber = businessFormViewModel.StreetNumber;
            Lattitude = businessFormViewModel.Lattitude;
            Longitude = businessFormViewModel.Longitude;
            PostalCode = businessFormViewModel.PostalCode;
            Vat = businessFormViewModel.VatNumber;
            PhoneNumber = businessFormViewModel.PhoneNumber;
            Category = businessFormViewModel.Categories.SingleOrDefault(c => c.Name == businessFormViewModel.Category);
            Area = businessFormViewModel.Areas.SingleOrDefault(a => a.Name == businessFormViewModel.Area);
            Location = businessFormViewModel.Locations.SingleOrDefault(l => l.Name == businessFormViewModel.Location);
        }

        public WorkingBusinessModelView CreateWorkingBusinessModelView()
        {
            var viewModel = new WorkingBusinessModelView()
            {

                Id = this.ID,
                Name = this.Name,
                Capacity = this.Capacity,
                Category = this.Category.Name,
                Area = this.Area.Name,
                Location = this.Location.Name,
                StreetName = this.StreetName,
                StreetNumber = this.StreetNumber,
                Lattitude = this.Lattitude,
                Longitude = this.Longitude,
                PostalCode = this.PostalCode,
                CurrenCapacity = this.CurrentCapacity,
                IsOpened = this.IsOpened,
                PhoneNumber = this.PhoneNumber
                
               
            };

            return viewModel;
        }


        public SearchViewModel CreateSearchViewModel(string location, string area, string category)
        {
            var viewModel = new SearchViewModel()
            {
                Id = this.ID,
                Name = this.Name,
                Capacity = this.Capacity,
                Category = this.Category.Name,
                Area = this.Area.Name,
                Location = this.Location.Name,
                StreetName = this.StreetName,
                StreetNumber = this.StreetNumber,
                Lattitude = this.Lattitude,
                Longitude = this.Longitude,
                PostalCode = this.PostalCode,
                CurrentCapacity = this.CurrentCapacity,
                IsOpened = this.IsOpened,
                AbsoluteCapacity = this.AbsoluteCapacity,
                RelativeCapacity = this.RelativeCapacity,
                PhoneNumber = this.PhoneNumber,
                LocationSequence = location,
                AreaSequence = area,
                CategorySequence = category


            };

            return viewModel; 
        }

        public void WorkTheBusiness(WorkingBusinessModelView viewModel)
        {
            viewModel.Name = this.Name;
            viewModel.IsOpened = this.IsOpened;

            if (this.Capacity < viewModel.Capacity)
                this.Capacity = viewModel.Capacity;
            this.CurrentCapacity = viewModel.CurrenCapacity;
        }


        public LifeInfo CreateLifeInfo(WorkingBusinessModelView viewModel)
        {
            LifeInfo lifeInfo = new LifeInfo()
            {
                RestaurantID = viewModel.Id,
                CurrentCapacity = viewModel.CurrenCapacity,
                DateTimeSaved = DateTime.Now
            };

            return lifeInfo;
        }

        public static Restaurant RegisterARestaurantWithOwnership(BusinessFormViewModel businessFormViewModel, byte[] imageData)
        {
            var restaurant = new Restaurant(businessFormViewModel);
            restaurant.Logo = imageData; 
            return restaurant;
        }

        public void UpdateRestaurant (BusinessFormViewModel viewModel)
        {
            this.Vat = viewModel.VatNumber;
            this.Name = viewModel.Name;
            this.Capacity = viewModel.Capacity;
            this.CategoryID = viewModel.Categories.SingleOrDefault(c => c.Name == viewModel.Category).Id;
            this.AreaID = viewModel.Areas.SingleOrDefault(a => a.Name == viewModel.Area).Id;
            this.LocationID = viewModel.Locations.SingleOrDefault(l => l.Name == viewModel.Location).ID;
            this.StreetName = viewModel.StreetName;
            this.StreetNumber = viewModel.StreetNumber;
            this.Lattitude = viewModel.Lattitude;
            this.Longitude = viewModel.Longitude;
            this.PostalCode = viewModel.PostalCode;
            this.PhoneNumber = viewModel.PhoneNumber;
            this.Category = viewModel.Categories.SingleOrDefault(c => c.Name == viewModel.Category);
            this.Area = viewModel.Areas.SingleOrDefault(a => a.Name == viewModel.Area);
            this.Location = viewModel.Locations.SingleOrDefault(l => l.Name == viewModel.Location);
        }

        public ICollection<FollowRestaurant> FollowRestaurants { get; set; }
    }
}