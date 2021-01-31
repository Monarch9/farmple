using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BOL;
using BLL;

namespace OnlineShoppingWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            List<Product> allProducts = BusinessManager.GetAllProducts();
           // this.Application.Add("allproducts", allProducts);  // store all products in to app. variable

          
        }

        protected void Session_Start()
        {
            Cart theCart = new Cart();
            this.Session.Add("cart", theCart);
        }

        protected void Session_End()
        {
          Cart theCart= (Cart) this.Session["cart"];
          theCart.Items.Clear();
        }

        protected void Application_Error()
        {
            // Global lever error handling logic

        }
    }
}
