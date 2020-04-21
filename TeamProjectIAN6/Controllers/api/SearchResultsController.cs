using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TeamProjectIAN6.Core;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers.api
{
    public class SearchResultsController : ApiController
    {
        private readonly IUnitOfWork unitOfWork;

        public SearchResultsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public IHttpActionResult GetSearchResults(string location = null, string area = null, string category = null)
        {
           var restaurantsQuery = unitOfWork.Businesses.GetRestaurantsQuerable(location, area, category);
           var restaurants = restaurantsQuery.ToList()
             .Select(Mapper.Map<Restaurant, RestaurantDto>);
            return Ok(restaurants);
        }
    }
}
