using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeamProjectIAN6.Dtos;
using TeamProjectIAN6.Models;
using System.Data.Entity;

namespace TeamProjectIAN6.Controllers.api
{
    public class OpeningsController : ApiController
    {
        private ApplicationDbContext context;

        public OpeningsController()
        {
            context = new ApplicationDbContext();
        }

        //POST api/openings

        [HttpPost]
        private IHttpActionResult Close(OpeningDto openingDto)
        {

            context.Openings.FirstOrDefault(o => o.RestaurantId == openingDto.RestaurantId && o.DateTimeClose == null)
                .SetDateTimeClose(DateTime.Now, User.Identity.GetUserId());

            context.Restaurants.FirstOrDefault(r => r.ID == openingDto.RestaurantId).Close();

            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }


            

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Open(OpeningDto openingDto)
        {
            var userId = User.Identity.GetUserId();

            if (context.Openings.Any(o => o.RestaurantId == openingDto.RestaurantId && o.DateTimeClose == null))
                Close(openingDto);

            else
            {
                var opening = new Opening
                {
                    UserId = userId,
                    RestaurantId = openingDto.RestaurantId,
                    Restaurant = context.Restaurants.FirstOrDefault(r => r.ID == openingDto.RestaurantId),
                    DateTimeOpen = DateTime.Now
                };

                context.Openings.Add(opening);

                context.Restaurants.FirstOrDefault(r => r.ID == openingDto.RestaurantId).Open();

                context.SaveChanges();

                

            }

            return Ok();
        }

    }
}
