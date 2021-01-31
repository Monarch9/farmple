using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingWeb.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if(username=="ravi" && password == "seed")
            {
                return this.RedirectToAction("index", "home");
            }
            return View(); 
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string firstname, string lastname, int age, 
                                     string email, string contactnumber, string location)
        {
            //get this all data and store in database
            

            return View();

        }
    }
}