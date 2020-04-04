using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Controllers;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.ViewModels
{
    public class BusinessFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public int Capacity { get; set; }

        public string Category { get; set; }

     
        [Required]
        public string Location { get; set; }

        [Required]
        public string Area { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; } 

      
        public double Lattitude { get; set; }  // todo to remove
        public double Longitude { get; set; } // todo to remove

        public double PostalCode { get; set; }
        public string Heading { get; set; }
        [Required]
        [ValidVat]
        public string VatNumber { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Location> Locations { get; set; }

        public IEnumerable<Area> Areas { get; set; }


        public string Action
        {
            get
            {
                Expression<Func<RestaurantController, ActionResult>> create =
                    (c => c.RegisterBusiness(this));
                Expression<Func<RestaurantController, ActionResult>> update =
                    (c => c.EditBusiness(this));

                var action = (Id != 0) ? update : create;
                var actionName = (action.Body as MethodCallExpression).Method.Name;

                return actionName;
            }
        }
    }
}