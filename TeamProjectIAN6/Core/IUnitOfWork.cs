using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProjectIAN6.Core.Repositories;
using TeamProjectIAN6.Persistence.Repositories;
using TeamProjectIAN6.Repositories;

namespace TeamProjectIAN6.Core
{
    public interface IUnitOfWork
    {
        IBusinessRepository Businesses { get; }
        ILifeInfoRepository LifeInfos { get; }
        ICategoryRepository Categories { get; }

        ILocationRepository Locations { get; }
        IAreaRepository Areas { get; }

        IEventPlaceRepository EventPlaces {get;}

        IRestaurantOwnershipRepository RestaurantOwnerships { get;}
        

        void Complete();



    }
}
