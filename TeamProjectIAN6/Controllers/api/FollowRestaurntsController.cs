using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamProjectIAN6.Core;
using TeamProjectIAN6.Core.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class FollowRestaurntsController : ApiController
    {

        private readonly IUnitOfWork unitOfWork;

        public FollowRestaurntsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IHttpActionResult FollowRestaurantAction(FollowRestaurantDto followRestaurantDto)
        {
            var userId = User.Identity.GetUserId();
            if (unitOfWork.FollowRestaurants.CheckIfAlreadyFollows(userId, followRestaurantDto.RestaurantId))
                return BadRequest("Soo unfollow functionality");

            var folllowRestaurant = FollowRestaurant.CreateFollowRestaurant(userId, followRestaurantDto.RestaurantId, DateTime.Now);
            unitOfWork.FollowRestaurants.AddRestaurantFollowing(folllowRestaurant);
            return Ok();
        }
    }
}
