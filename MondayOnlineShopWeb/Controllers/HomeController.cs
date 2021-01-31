using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace MondayOnlineShopWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
      /*  public ActionResult TopTen()
        {
            List<Customer> customers = BusinessManager.GetTopCustomers();
            return View(customers);       
        }*/
        public ActionResult Chart()
        {
            return View();
        }
       
        public ActionResult Services()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();
        }
    }
}