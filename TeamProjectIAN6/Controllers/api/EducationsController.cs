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
    public class EducationsController : ApiController
    {
        private ApplicationDbContext context;

        public EducationsController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/educations

        public IHttpActionResult GetEducations(string query = null)
        {

            var educationsQuery = context.Educations.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
                educationsQuery = educationsQuery.Where(e => e.Name.Contains(query));

            var educations = educationsQuery.ToList()
                .Select(Mapper.Map<Education, EducationDto>);
            return Ok(educations);
        }

        [HttpPost]
        public IHttpActionResult NewEducation(EducationDto educationDto)
        {

            return Ok();
        }
    }
}
