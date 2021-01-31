using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class BIController : Controller
    {
        // GET: BI
        public ActionResult Dashboard()
        {
            this.ViewData["toptencustomers"] = BusinessManager.GetTopTenCustomers();
            this.ViewData["toptenorders"] = BusinessManager.GetTopTenOrders();
            return View();
        }

     
    }
}