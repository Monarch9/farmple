using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;

namespace OnlineShoppingWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            this.ViewBag.message = " Welcome to  ASP.NET MVC Application";
            DateTime today = DateTime.Now;
            this.ViewBag.today = today;
            return View();
        }

        public ActionResult AboutUs()
        {
            Person thePerson = new Person
            {
                Owner = "Ravi Tambade",
                Company = "Transflower Learning Pvt. Ltd",
                Email = "ravi_tambade@hotmail.com",
                ContactNumber = "9881735801"
            };

            this.ViewData["director"] = thePerson;

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}