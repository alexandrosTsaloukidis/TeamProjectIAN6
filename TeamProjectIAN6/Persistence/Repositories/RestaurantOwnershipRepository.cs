using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class RestaurantOwnershipRepository : IRestaurantOwnershipRepository
    {


        private readonly ApplicationDbContext _context;

        public RestaurantOwnershipRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddRestaurantOwnership(RestaurantOwnership restaurantOwnership)
        {
            _context.RestaurantOwnerships.Add(restaurantOwnership);
        }

    }
}