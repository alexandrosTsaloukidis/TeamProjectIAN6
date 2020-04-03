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
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext context;

        public CategoriesController()
        {
            context = new ApplicationDbContext();
        }

        // GET /api/educations

        public IHttpActionResult GetCategories(string query = null)
        {

            var categoriesQuery = context.Categories.AsQueryable();
            if (!String.IsNullOrWhiteSpace(query))
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(query));

            var categories = categoriesQuery.ToList()
                .Select(Mapper.Map<Category, CategoryDto>);
            return Ok(categories);
        }

        [HttpPost]
        public IHttpActionResult NewCategory(CategoryDto categoryDto)
        {

            return Ok();
        }
    }
}
