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

        public IEnumerable<EducationDto> GetEducations()
        {
            var educations = context.Educations;

            return educations.Select(Mapper.Map<Education, EducationDto>);
        }

    }
}
