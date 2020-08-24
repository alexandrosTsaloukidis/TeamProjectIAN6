using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;
using System.Data.Entity;
namespace TeamProjectIAN6.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {

        private readonly ApplicationDbContext _context;

        public BusinessRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IQueryable<Restaurant> GetRestaurantsQuerable(string userID, string location = null, string area = null, string category = null)
        {

            var restaurants = _context.Restaurants.Where(r => r.IsOpened).
                              Include(r => r.Location)
                              .Include(r => r.Category)
                              .Include(r => r.Area)
                              .AsQueryable();

            if (!String.IsNullOrEmpty(location))
            {
                restaurants = restaurants.Where(r => location.Contains(r.Location.Name));
            }

            if (!String.IsNullOrEmpty(area))
            {
                restaurants = restaurants.Where(r => area.Contains(r.Area.Name));
            }

            if (!String.IsNullOrEmpty(category))
            {
                restaurants = restaurants.Where(r => category.Contains(r.Category.Name));
            }

            foreach (var restaurant in restaurants)
                restaurant.FollowRestaurants = _context.FollowRestaurants.Where(f => f.RestaurantId == restaurant.ID &&
                                                                                     f.UserId == userID).ToList();

            return restaurants;
        }

        

        public Restaurant GetRestaurant(int restaurantId, string userId)
        {
            var restaurant = _context.RestaurantOwnerships.Where(ro => ro.ApplicationUserId == userId && ro.RestaurantId == restaurantId)
                                                       .Select(ro => ro.Restaurant)
                                                       .Include(r => r.Location)
                                                       .Include(r => r.Area)
                                                       .Include(r => r.Category)
                                                       .FirstOrDefault();

            return restaurant;
        }




        public void AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
        }

        public List<Restaurant> GetMultipleRestaurants(string userId)
        {
            return _context.RestaurantOwnerships
                                .Where(ro => ro.ApplicationUserId == userId)
                                .Select(ro => ro.Restaurant).Where(r => !r.IsDeleted).ToList();

        }



    }
}