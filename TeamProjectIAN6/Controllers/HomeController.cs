using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeamProjectIAN6.Models;

namespace TeamProjectIAN6.Controllers
{
    public class HomeController : Controller
    {

        private ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Feed");
            else
                return RedirectToAction("Cover");
        }

        public ActionResult Feed()
        {
            return View();
        }

        public ActionResult Cover()
        {
            return View();
        }


        [Authorize]
        public ActionResult PlacesToGo()
        {
            var restaurants = context.Restaurants.Where(r => r.IsOpened).ToList();
            return View(restaurants);

        }


    }
}