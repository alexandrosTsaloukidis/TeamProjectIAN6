using System.Collections.Generic;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetLocations();

        Location GetLocation(string name);

        void AddLocation(Location location);
    }
}