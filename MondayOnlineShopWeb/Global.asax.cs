using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using BOL;
namespace MondayOnlineShopWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Cart theCart = new Cart();
            this.Session.Add("shoppingcart", theCart);
          
        }

        protected void Session_End()
        {
            Cart theExistingCart = this.Session["shoppingcart"] as Cart;
            theExistingCart.items.Clear();
        }

        protected void Application_Error()
        {

        }



    }
}
