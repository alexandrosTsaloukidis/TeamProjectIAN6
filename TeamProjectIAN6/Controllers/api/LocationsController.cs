using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class LocationsController : ApiController
    {

        private ApplicationDbContext context;

        public LocationsController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/educations

        public IHttpActionResult GetLocations(string query = null)
        {

            var locationsQuery = context.Locations.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
                locationsQuery = locationsQuery.Where(l => l.Name.Contains(query));

            var locations = locationsQuery.ToList()
                .Select(Mapper.Map<Location, LocationDto>);
          return Ok(locations);
        }

        [HttpPost]
        public IHttpActionResult NewLocaction(LocationDto locationDto)
        {

            return Ok();
        }


    }
}
