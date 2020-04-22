using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Core;
using TeamProjectIAN6.Core.Repositories;
using TeamProjectIAN6.Models;
using TeamProjectIAN6.Persistence.Repositories;
using TeamProjectIAN6.Repositories;

namespace TeamProjectIAN6.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBusinessRepository Businesses { get; private set; }

        public ILifeInfoRepository LifeInfos { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ILocationRepository Locations { get; private set; }

        public IAreaRepository Areas { get; private set; }

        public IRestaurantOwnershipRepository RestaurantOwnerships { get; private set; }

        public IFollowRestaurantRepository FollowRestaurants { get; private set; }

        public IEventPlaceRepository EventPlaces { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {

            _context = context;
            Businesses = new BusinessRepository(context);
            LifeInfos = new LifeInfoRepository(context);
            Categories = new CategoryRepository(context);
            Locations = new LocationRepository(context);
            Areas = new AreaRepository(context);
            RestaurantOwnerships = new RestaurantOwnershipRepository(context);
            EventPlaces = new EventPlaceRepository(context);
            FollowRestaurants = new FollowRestaurantRepository(context);
        }

        public void Complete() 
        {
            _context.SaveChanges();
        }


    }
}