using System.Collections.Generic;
using System.Linq;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Repositories
{
    public interface IBusinessRepository
    {
        Restaurant GetRestaurant(int restaurantId, string userId);

        List<Restaurant> GetMultipleRestaurants(string userId);
        void AddRestaurant(Restaurant restaurant);

        IQueryable<Restaurant> GetRestaurantsQuerable(string userID, string location, string area, string category);
   

    }
}