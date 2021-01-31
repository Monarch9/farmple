using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace OnlineShoppingWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            Cart existingCart = (Cart)this.Session["shoppingcart"];
            return View(existingCart);
        }

        //public ActionResult AddToCart(int productID)
        //{
        //    return View();
        //}


        
        public ActionResult AddToCart(int id)
        {
            Product theProduct = BusinessManager.GetProduct(id);
            return View(theProduct);
        }


        [HttpPost]
        public ActionResult AddToCart(int id, string title,int quantity)
        {
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            Item newItem = new Item { ProductID = id, Quantity = quantity };
            existingCart.items.Add(newItem);
            return RedirectToAction("index", "products");


        }
        public ActionResult RemovFromCart(int ProductId)
        {

            return View();
        }
    }
}

