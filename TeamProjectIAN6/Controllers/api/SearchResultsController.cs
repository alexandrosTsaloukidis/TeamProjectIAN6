using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TeamProjectIAN6.Core;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class SearchResultsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public SearchResultsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IHttpActionResult GetSearchResults(string location = null, string area = null, string category = null)
        {
            string userId = User.Identity.GetUserId();
            var restaurantsQuery = unitOfWork.Businesses.GetRestaurantsQuerable(userId, location, area, category);
            var userFollowings = unitOfWork.FollowRestaurants.GetUserFollowings(userId);
            if (userFollowings.Count > 0)
            {
                foreach (var restaurant in restaurantsQuery)
                    foreach (var userFollowing in userFollowings)
                    {
                        if (restaurant.ID == userFollowing.RestaurantId)
                            restaurant.ChangeToUnfollowing();
                    }
                  

            }

            unitOfWork.Complete();

            var restaurants = restaurantsQuery.ToList()
             .Select(Mapper.Map<Restaurant, RestaurantDto>);



            return Ok(restaurants);
        }
    }
}
