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
    public class AreasController : ApiController
    {

        private ApplicationDbContext context;

        public AreasController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/educations

        public IHttpActionResult GetAreas(string query = null)
        {

            var areasQuery = context.Areas.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
                areasQuery = areasQuery.Where(a => a.Name.Contains(query));

            var areas = areasQuery.ToList()
                .Select(Mapper.Map<Area, AreaDto>);
            return Ok(areas);
        }

        [HttpPost]
        public IHttpActionResult NewArea(AreaDto areaDto)
        {

            return Ok();
        }
    }
}
