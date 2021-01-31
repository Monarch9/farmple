using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;

namespace OnlineShoppingWeb.Controllers
{
    public class BIController : Controller
    {
        // GET: BI
        public ActionResult Dashboard()
        {
            this.ViewData["topTenCustomers"] = BusinessManager.GetTopTenCustomers();

            this.ViewData["topTenOrders"] = BusinessManager.GetTopTenOrders();

            return View();
        }
    }
}