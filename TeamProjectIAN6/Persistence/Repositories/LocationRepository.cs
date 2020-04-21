using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }


        public Location GetLocation(string name)
        {
            return _context.Locations.SingleOrDefault(c => c.Name == name);
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
        }
    }
}