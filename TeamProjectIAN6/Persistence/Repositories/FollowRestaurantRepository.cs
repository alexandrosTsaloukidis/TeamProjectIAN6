using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core.Models;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class FollowRestaurantRepository : IFollowRestaurantRepository
    {

        private readonly ApplicationDbContext _context;

        public FollowRestaurantRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddRestaurantFollowing(FollowRestaurant followRestaurant)
        {
            _context.FollowRestaurants.Add(followRestaurant);
        }

        public bool CheckIfAlreadyFollows(string userId, int restaurntId)
        {
            return _context.FollowRestaurants.Any(f => f.UserId == userId && f.RestaurantId == restaurntId && f.UnfollowDate == null);
        }

        public List<FollowRestaurant> GetUserFollowings(string userId)
        {
           return _context.FollowRestaurants.Where(fr => fr.UserId == userId).ToList();
        }
    }
}