﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Models;
using System.Data.Entity;
using AutoMapper;
using TeamProjectIAN6.Core.ViewModels;
using TeamProjectIAN6.Core;
using Microsoft.AspNet.Identity;

namespace TeamProjectIAN6.Controllers
{
    public class HomeController : Controller
    {


        private readonly IUnitOfWork unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        [Authorize]
        public ActionResult AdvancedSearchScreen()
        {
            return View("AdvancedSearch");
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Feed");
            else
                return RedirectToAction("Cover");
        }


        public ActionResult Searcher(string locationsToString, string areasToString, string categoriesToString)
        {
            string userId = User.Identity.GetUserId();
            var restaurants = unitOfWork.Businesses.GetRestaurantsQuerable(userId, locationsToString, areasToString, categoriesToString).ToList();
            if (restaurants == null || restaurants.Count == 0)
            {
                return HttpNotFound("No results for the requested query");
            }
            var searchViewModel = new List<SearchViewModel>();
            foreach (var restaurant in restaurants) 
            { 
                var alreadyFollows = unitOfWork.FollowRestaurants.CheckIfAlreadyFollows(userId, restaurant.ID);
                searchViewModel.Add(restaurant.CreateSearchViewModel(userId, alreadyFollows, locationsToString, areasToString, categoriesToString));
            }
            return View("SearchResultsView", searchViewModel);
        }

        public ActionResult Feed()
        {
            return View();
        }

        public ActionResult Cover()
        {
            return View();
        }


        [Authorize]
        public ActionResult PlacesToGo()
        {
            string userId = User.Identity.GetUserId();
            var restaurants = unitOfWork.Businesses.GetRestaurantsQuerable(userId, null, null, null).ToList();
            
            
            var searchViewModels = new List<SearchViewModel>();
            foreach (var restaurant in restaurants)
            {
                var alreadyFollows = unitOfWork.FollowRestaurants.CheckIfAlreadyFollows(userId, restaurant.ID);
                searchViewModels.Add(restaurant.CreateSearchViewModel(userId, alreadyFollows, null, null, null));
            }
            return View("SearchResultsView", searchViewModels);

        }





    }
}