using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers
{
    public class RestaurantController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }
    }
}