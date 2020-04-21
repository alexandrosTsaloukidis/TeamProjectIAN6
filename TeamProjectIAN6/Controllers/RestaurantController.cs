using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Core;
using TeamProjectIAN6.Models;
using TeamProjectIAN6.Repositories;
using TeamProjectIAN6.ViewModels;


namespace TeamProjectIAN6.Controllers
{
    public class RestaurantController : Controller
    {
       // private readonly ApplicationDbContext context;
       // private readonly BusinessRepository businessRepository;
        private readonly IUnitOfWork unitOfWork;
           
        public RestaurantController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
        }
        

        //GET
        [Authorize]
        public ActionResult EnterTheBusiness(int id)
        {
            string userId = User.Identity.GetUserId();
            var business = unitOfWork.Businesses.GetRestaurant(id, userId);
            var viewModel = business.CreateWorkingBusinessModelView();
            return View("EnterTheBusiness", viewModel);
        }


        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnterTheBusiness(WorkingBusinessModelView viewModel)
        {
            var userId = User.Identity.GetUserId();
            var restaurant = unitOfWork.Businesses.GetRestaurant(viewModel.Id, userId);
            restaurant.WorkTheBusiness(viewModel);
            unitOfWork.Complete();
            var lifeInfo = restaurant.CreateLifeInfo(viewModel);
            unitOfWork.LifeInfos.AddLifeInfo(lifeInfo);
            unitOfWork.Complete();
            return View("EnterTheBusiness", viewModel);
        }

        //GET
        [Authorize]
        public ActionResult RegisterBusiness()
        {

            var viewModel = new BusinessFormViewModel
            {
                Categories = unitOfWork.Categories.GetCategories(),
                Locations = unitOfWork.Locations.GetLocations(),
                Areas = unitOfWork.Areas.GetAreas(),
                Heading = "Register a business"

            };

            return View("RegisterBusiness", viewModel);



        }


        //POST
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterBusiness([Bind(Exclude = "Logo")]BusinessFormViewModel businessFormViewModel)
        {

            if (!ModelState.IsValid)
            {
                businessFormViewModel.Categories = unitOfWork.Categories.GetCategories();
                businessFormViewModel.Locations = unitOfWork.Locations.GetLocations();
                businessFormViewModel.Areas = unitOfWork.Areas.GetAreas();
                businessFormViewModel.Heading = "Register business";
                return View("RegisterBusiness", businessFormViewModel);

              
            }


            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase poImgFile = Request.Files["Logo"];

                using (var binary = new BinaryReader(poImgFile.InputStream))
                {
                    imageData = binary.ReadBytes(poImgFile.ContentLength);
                }
            }

            string userId = User.Identity.GetUserId();


            CheckUpdateCategoryLOcationArea(businessFormViewModel);
            businessFormViewModel.Areas = unitOfWork.Areas.GetAreas();
            businessFormViewModel.Locations = unitOfWork.Locations.GetLocations();
            businessFormViewModel.Categories = unitOfWork.Categories.GetCategories();

            var restaurant = Restaurant.RegisterARestaurantWithOwnership(businessFormViewModel, imageData);
            


            unitOfWork.Businesses.AddRestaurant(restaurant);

            unitOfWork.Complete();

            unitOfWork.RestaurantOwnerships.AddRestaurantOwnership(RestaurantOwnership.CeateRestaurantOwnership(restaurant, userId));

            unitOfWork.EventPlaces.AddEventPlace(EventPlace.CreateEventPlace(restaurant));

            unitOfWork.Complete();

            return RedirectToAction("MyBusinesses", "Restaurant");


        }

        //GET
        [Authorize]
        public ActionResult MyBusinesses()
        {
            var userId = User.Identity.GetUserId();
            var businesses = unitOfWork.Businesses.GetMultipleRestaurants(userId);
            return View(businesses);
        }


        // GET: Restaurant
        // Get edit
        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var restaurant =unitOfWork.Businesses.GetRestaurant(id, userId);

            var viewModel = BusinessFormViewModel.CreateBusinessFormViewModel(restaurant, unitOfWork.Categories.GetCategories(),
                                                                              unitOfWork.Locations.GetLocations(), unitOfWork.Areas.GetAreas());
        

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
                viewModel.Categories = unitOfWork.Categories.GetCategories();
                viewModel.Locations = unitOfWork.Locations.GetLocations();
                viewModel.Areas = unitOfWork.Areas.GetAreas();
                return View("RegisterBusiness", viewModel);
            }

            // find corresponding gig
            var userId = User.Identity.GetUserId();
            var restaurant = unitOfWork.Businesses.GetRestaurant(viewModel.Id, userId);

            CheckUpdateCategoryLOcationArea(viewModel);


            viewModel.Areas = unitOfWork.Areas.GetAreas();
            viewModel.Locations = unitOfWork.Locations.GetLocations();
            viewModel.Categories = unitOfWork.Categories.GetCategories();

            restaurant.UpdateRestaurant(viewModel);
            unitOfWork.Complete();
            return RedirectToAction("MyBusinesses", "Restaurant");
        }


        private void CheckUpdateCategoryLOcationArea(BusinessFormViewModel viewModel)
        {
            var category = unitOfWork.Categories.GetCategory(viewModel.Category);
            if (category == null)
            {
                category = new Category() { Name = viewModel.Category };
                unitOfWork.Categories.AddCategory(category);
                unitOfWork.Complete();
            }

            var location = unitOfWork.Locations.GetLocation(viewModel.Location);
            if (location == null)
            {
                location = new Location() { Name = viewModel.Location };
                unitOfWork.Locations.AddLocation(location);
                unitOfWork.Complete();
            }


            var area = unitOfWork.Areas.GetArea(viewModel.Area);
            if (area == null)
            {
                area = new Area() { Name = viewModel.Area };
                unitOfWork.Areas.AddArea(area);
                unitOfWork.Complete();
            }

        }
    }
}