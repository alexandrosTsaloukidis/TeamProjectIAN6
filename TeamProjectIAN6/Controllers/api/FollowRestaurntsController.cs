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
using TeamProjectIAN6.Core.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class FollowRestaurntsController : ApiController
    {
        private ApplicationDbContext context;

        public FollowRestaurntsController()
        {
            context = new ApplicationDbContext();
        }

        //POST api/openings

        [HttpPost]
        private IHttpActionResult Unfollow(FollowRestaurantDto followRestaurantDto)
        {

            //context.FollowRestaurants.FirstOrDefault(f => f.RestaurantId == followRestaurantDto.RestaurantId && f.UnfollowDate == null)
            //    .SetDateTimeUnfollow(DateTime.Now);


            //context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowRestaurantDto followRestaurantDto)
        {
            var userId = User.Identity.GetUserId();

            if (context.FollowRestaurants.Any(f => f.RestaurantId == followRestaurantDto.RestaurantId && f.UnfollowDate == null))
                Unfollow(followRestaurantDto);

            //else
            //{
            //    var followRestaurant = new FollowRestaurant(userId, followRestaurantDto.RestaurantId, DateTime.Now);
      
            //    context.FollowRestaurants.Add(followRestaurant);

            //    context.SaveChanges();



            //}

            return Ok();
        }

    }
}
