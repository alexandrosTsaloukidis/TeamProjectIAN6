using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Persistence.Repositories
{
    public class EventPlaceRepository : IEventPlaceRepository
    {


        private readonly ApplicationDbContext _context;

        public EventPlaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public void AddEventPlace(EventPlace eventPlace)
        {
            _context.EventPlaces.Add(eventPlace);
        }
    }
}