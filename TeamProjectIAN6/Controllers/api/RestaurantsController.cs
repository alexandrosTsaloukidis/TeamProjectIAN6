using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamProjectIAN6.Dtos;
using TeamProjectIAN6.Models;
using System.Data.Entity;
using TeamProjectIAN6.Core;

namespace TeamProjectIAN6.Controllers.api
{
    public class RestaurantsController : ApiController
    {

        private ApplicationDbContext context;
        private readonly IUnitOfWork unitOfWork;

        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            context = new ApplicationDbContext();
            this.unitOfWork = unitOfWork;
        }


        // GET /api/restaurants

        public IHttpActionResult GetRestaurants(string query = null)
        {

            var restaurantsQuery = context.Restaurants
                                   .Include(r => r.Category)
                                   .Include(r=> r.Location)
                                   .Include(r=> r.Area)
                                   .Where(r => r.IsOpened)
                                   .AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
                restaurantsQuery = restaurantsQuery.Where(r =>  r.Name.Contains(query));

            string userId = User.Identity.GetUserId();
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

            var restaurants = restaurantsQuery.ToList()
                .Select(Mapper.Map<Restaurant, RestaurantDto>);

            return Ok(restaurants);
        }



        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var restaurant = context.RestaurantOwnerships
                             .Where(ro => ro.ApplicationUserId == userId && ro.RestaurantId == id)
                             .Select(ro => ro.Restaurant).FirstOrDefault();
                             

            if (restaurant.IsDeleted)
                return NotFound();

            restaurant.Delete();

            context.SaveChanges();

            return Ok();
        }


        [HttpPost]
        public IHttpActionResult NewRestaurant(RestaurantDto restaurantDto)
        {

            return Ok();
        }
    }
}
