using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace MondayOnlineShopWeb.Controllers
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
            Credentials newcredentials = new Credentials
            {
                Username = username,
                Password = password
            };
            bool status = BusinessManager.validatelogin1(username, password);

            if(status)
            {
                int f = BusinessManager.validatelogin(username, password);
                // Session.Add("customrdata",f);
                this.Session.Add("customrdata", f);
                Customer thecustomer = BusinessManager.getcustByID(f);
                this.Session.Add("thecustomer", thecustomer);
                return this.RedirectToAction("SelectAllFarmers", "crops");
            }

            return View();//

        }



       

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register_Post(string firstname,string lastname,string email,string password ,string cpassword,string contact, string address,string pincode)
        {
            if (password == cpassword)
            {
                Customer c = new Customer
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password,
                    Contact = contact,
                    address = address,
                    pincode = pincode
                };
                bool status = BusinessManager.regUser(c);
                if (status)
                {
                    return RedirectToAction("login", "Accounts");
                }
            }

            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("login", "Accounts");
        }
    }

  

}