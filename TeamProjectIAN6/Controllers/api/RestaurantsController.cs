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

namespace TeamProjectIAN6.Controllers.api
{
    public class RestaurantsController : ApiController
    {

        private ApplicationDbContext context;

        public RestaurantsController()
        {
            context = new ApplicationDbContext();
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
