using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Models;
using TeamProjectIAN6.ViewModels;

namespace TeamProjectIAN6.Controllers
{
    public class RestaurantController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        //GET
        [Authorize]
        public ActionResult EnterTheBusiness(int id)
        {
            string userId = User.Identity.GetUserId();
            var business = context.RestaurantOwnerships.Where(ro => ro.ApplicationUserId == userId && ro.RestaurantId == id)
                                                       .Select(ro=>ro.Restaurant)
                                                       .FirstOrDefault();

            var viewModel = new WorkingBusinessModelView()
            {

                Id = business.ID,
                Name = business.Name,
                Capacity = business.Capacity,
                Category = context.Categories.SingleOrDefault(c => c.Id == business.CategoryID).Name,
                Area = context.Areas.SingleOrDefault(a => a.Id == business.AreaID).Name,
                Location = context.Locations.SingleOrDefault(l => l.ID == business.LocationID).Name,
                StreetName = business.StreetName,
                StreetNumber = business.StreetNumber,
                Lattitude = business.Lattitude,
                Longitude = business.Longitude,
                PostalCode = business.PostalCode,
                CurrenCapacity = business.CurrentCapacity,
                IsOpened = business.IsOpened
            };

            return View("EnterTheBusiness", viewModel);
        }


        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnterTheBusiness(WorkingBusinessModelView viewModel)
        {
            var userId = User.Identity.GetUserId();
            var restaurant = context.RestaurantOwnerships
                .Where(r => r.RestaurantId == viewModel.Id && r.ApplicationUserId == userId)
                .Select(r => r.Restaurant).SingleOrDefault()
                ;

            viewModel.Name = restaurant.Name;
            viewModel.IsOpened = restaurant.IsOpened;

            if (restaurant.Capacity < viewModel.Capacity)
                restaurant.Capacity = viewModel.Capacity;
            restaurant.CurrentCapacity = viewModel.CurrenCapacity;
            context.SaveChanges();
            LifeInfo lifeInfo = new LifeInfo()
            {
                RestaurantID = viewModel.Id,
                CurrentCapacity = viewModel.CurrenCapacity,
                DateTimeSaved = DateTime.Now
            };
            context.LifeInfos.Add(lifeInfo);
            context.SaveChanges();
            return View("EnterTheBusiness", viewModel);
        }

        //GET
        [Authorize]
        public ActionResult RegisterBusiness()
        {

            var viewModel = new BusinessFormViewModel
            {
                Categories = context.Categories.ToList(),
                Locations = context.Locations.ToList(),
                Areas = context.Areas.ToList(),
                Heading = "Register a business"

            };

            return View("RegisterBusiness", viewModel);



        }


        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterBusiness(BusinessFormViewModel businessFormViewModel)
        {

            if (!ModelState.IsValid)
            {
                businessFormViewModel.Categories = context.Categories.ToList();
                businessFormViewModel.Locations = context.Locations.ToList();
                businessFormViewModel.Areas = context.Areas.ToList();
                businessFormViewModel.Heading = "Register business";
                return View("RegisterBusiness", businessFormViewModel);
            }

            string userId = User.Identity.GetUserId();


            var category = context.Categories.SingleOrDefault(c => c.Name == businessFormViewModel.Category);
            if (category == null)
            {
                category = new Category() { Name = businessFormViewModel.Category };
                context.Categories.Add(category);
                context.SaveChanges();
            }

            var location = context.Locations.SingleOrDefault(l => l.Name == businessFormViewModel.Location);
            if (location == null)
            {
                location = new Location() { Name = businessFormViewModel.Location };
                context.Locations.Add(location);
                context.SaveChanges();
            }


            var area = context.Areas.SingleOrDefault(a => a.Name == businessFormViewModel.Area);
            if (area == null)
            {
                area = new Area() { Name = businessFormViewModel.Area };
                context.Areas.Add(area);
                context.SaveChanges();
            }

            var restaurant = new Restaurant()
            {
                Name = businessFormViewModel.Name,
                Capacity = businessFormViewModel.Capacity,
                CategoryID = context.Categories.SingleOrDefault(c => c.Name == businessFormViewModel.Category).Id,
                AreaID = context.Areas.SingleOrDefault(a => a.Name == businessFormViewModel.Area).Id,
                LocationID = context.Locations.SingleOrDefault(l => l.Name == businessFormViewModel.Location).ID,
                StreetName = businessFormViewModel.StreetName,
                StreetNumber = businessFormViewModel.StreetNumber,
                Lattitude = businessFormViewModel.Lattitude,
                Longitude = businessFormViewModel.Longitude,
                PostalCode = businessFormViewModel.PostalCode,
                Vat = businessFormViewModel.VatNumber,


            };

            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            context.RestaurantOwnerships.Add(new RestaurantOwnership()
            {
                ApplicationUserId = userId,
                RestaurantId = restaurant.ID,
                StartOwnershipDateTime = DateTime.Now
            });

            context.EventPlaces.Add(new EventPlace()
            {
                RestaurantId = restaurant.ID,
                Name = restaurant.Name
            });

            context.SaveChanges();

            return RedirectToAction("MyBusinesses", "Restaurant");


        }

        //GET
        [Authorize]
        public ActionResult MyBusinesses()
        {
            var userId = User.Identity.GetUserId();
            var businesses = context.RestaurantOwnerships
                               .Where(ro => ro.ApplicationUserId == userId)
                               .Select(ro => ro.Restaurant).Where(r => !r.IsDeleted);
                               ;
            return View(businesses);
        }


        // GET: Restaurant
        // Get edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var restaurant = context.RestaurantOwnerships
                .Where(r => r.RestaurantId == id && r.ApplicationUserId == userId)
                .Select(r => r.Restaurant).SingleOrDefault()
                ;

            var viewModel = new BusinessFormViewModel
            {
                Categories = context.Categories.ToList(),
                Locations = context.Locations.ToList(),
                Areas = context.Areas.ToList(),
                Id = restaurant.ID,
                VatNumber = restaurant.Vat,
                Name = restaurant.Name,
                Capacity = restaurant.Capacity,
                Category = context.Categories.SingleOrDefault(c => c.Id == restaurant.CategoryID).Name,
                Area = context.Areas.SingleOrDefault(a => a.Id == restaurant.AreaID).Name,
                Location = context.Locations.SingleOrDefault(l => l.ID == restaurant.LocationID).Name,
                StreetName = restaurant.StreetName,
                StreetNumber = restaurant.StreetNumber,
                Lattitude = restaurant.Lattitude,
                Longitude = restaurant.Longitude,
                PostalCode = restaurant.PostalCode,
                Heading = "Edit a business"
            };

            return View("RegisterBusiness", viewModel);
        }


        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EditBusiness(BusinessFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = context.Categories.ToList();
                viewModel.Locations = context.Locations.ToList();
                viewModel.Areas = context.Areas.ToList();
                return View("RegisterBusiness", viewModel);
            }

            // find corresponding gig
            var userId = User.Identity.GetUserId();
            var restaurant = context.RestaurantOwnerships
                .Where(r => r.RestaurantId == viewModel.Id && r.ApplicationUserId == userId)
                .Select(r => r.Restaurant).SingleOrDefault()
                ;

            var category = context.Categories.SingleOrDefault(c => c.Name == viewModel.Category);
            if (category == null)
            {
                category = new Category() { Name = viewModel.Category };
                context.Categories.Add(category);
                context.SaveChanges();
            }

            var location = context.Locations.SingleOrDefault(l => l.Name == viewModel.Location);
            if (location == null)
            {
                location = new Location() { Name = viewModel.Location };
                context.Locations.Add(location);
                context.SaveChanges();
            }


            var area = context.Areas.SingleOrDefault(a => a.Name == viewModel.Area);
            if (area == null)
            {
                area = new Area() { Name = viewModel.Area };
                context.Areas.Add(area);
                context.SaveChanges();
            }


            restaurant.Vat = viewModel.VatNumber;
            restaurant.Name = viewModel.Name;
            restaurant.Capacity = viewModel.Capacity;
            restaurant.CategoryID = context.Categories.SingleOrDefault(c => c.Name == viewModel.Category).Id;
            restaurant.AreaID = context.Areas.SingleOrDefault(a => a.Name == viewModel.Area).Id;
            restaurant.LocationID = context.Locations.SingleOrDefault(l => l.Name == viewModel.Location).ID; 
            restaurant.StreetName = viewModel.StreetName;
            restaurant.StreetNumber = viewModel.StreetNumber;
            restaurant.Lattitude = viewModel.Lattitude;
            restaurant.Longitude = viewModel.Longitude;
            restaurant.PostalCode = viewModel.PostalCode;

            context.SaveChanges();

            return RedirectToAction("MyBusinesses", "Restaurant");
        }



    }
}