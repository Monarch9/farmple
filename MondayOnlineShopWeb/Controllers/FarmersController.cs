using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace MondayOnlineShopWeb.Controllers
{
    public class FarmersController : Controller
    {
        // GET: Farmers

        public ActionResult FarmerIndex()
        {
            int userData = 0;
            if (Session["UserData"]!=null)
            {
                 userData = int.Parse(Session["UserData"].ToString()) ;
            }
            else
            {
                return View("LoginFarmer");

            }
            ViewBag.id = userData;
            return View();
        }



        public ActionResult LoginFarmer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginFarmer(string username, string password)
        {
            Credentials newcredentials = new Credentials
            {
                Username = username,
                Password = password
            };
            bool status = BusinessManager.validateFarmer(username, password);

            if (status)
            {
                int f = BusinessManager.GetFarmers(username,password);
                Session["UserData"] = f;
                
                return this.RedirectToAction("FarmerIndex", "Farmers");
            }

            return View();

        }
        public ActionResult RegFarmer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegFarmer(String firstname, String lastname, String email, String password, String cpassword, String contact, String address)
        {
            if (password == cpassword)
            {
                farmers c = new farmers
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    password = password,
                    contact = contact,
                    address = address
                };
                bool status = BusinessManager.regFarmer(c);
                if (status)
                {
                    return RedirectToAction("loginFarmer", "farmers");
                }

            }


            // var customer = new Customer();


            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("loginfarmer", "farmers");
        }
    }
    
}