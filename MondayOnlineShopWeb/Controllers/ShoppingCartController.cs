using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            if (existingCart != null)
                return View(existingCart);
            else
            {
                string message = "your cart is empty ,Please select some items to add in cart";
                return RedirectToAction("emptycarterror/message=" + message, "shoppingcart");
             }
        }

       

       /* public ActionResult Remove1(int id)
        {

            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            Item i = new Item();
           *//* List<Item> itemlist = new List<Item>();*//*
            foreach (Item item in existingCart.items)
            {
                if(item.cropID==id)
                {
                    i.cropID = item.cropID;
                    i.crop_name = item.crop_name;
                    i.fid = item.fid;
                    i.unit_price = item.unit_price;
                    i.total = item.total;
                    i.quantity = item.quantity;
                    i.image = item.image;
                }

            }
            existingCart.items.Remove(i);
            return RedirectToAction("index", "shoppingCart");
        }*/

        public ActionResult AddToCart(int id)
        {
            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;

            crops c = BusinessManager.getcrop(id);
            
            return View(c);
        }
    

    [HttpPost]
        public ActionResult AddToCart(int cropID, string crop_name, string image,int quantity,int unit_price)
        {
            int fid = 0;
            if (Session["FARMERID"] != null)
            {
                fid = int.Parse(this.Session["FARMERID"].ToString());
            }

            Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
            Item newItem = new Item { cropID =cropID, crop_name =crop_name, image =image, quantity =quantity, unit_price =unit_price ,total=quantity* unit_price,fid=fid };
            crops c = BusinessManager.getcrop(cropID);
            if (c.quantity >= quantity)
            {
                existingCart.items.Add(newItem);
            }
            else
            {
                this.ViewBag.Message = "your requested quantity is not available plese check the available quantity on details page";
                return RedirectToAction("AddToCarterror/"+cropID, "shoppingCart");

            }

            return RedirectToAction("index", "shoppingCart");
        }


        public ActionResult Order()
        {//orderid, customerID, cropID, quantity, total_amount, address, fid, crop_name
            if (Session["customrdata"] != null)//fid session
            {
                int id = 0;
                Customer thecustomer = null;
                if (Session["thecustomer"] != null)
                {
                    thecustomer = (Customer)Session["thecustomer"];
                }
                
                    if (Session["FARMERID"] != null)
                {
                     id = int.Parse(Session["FARMERID"].ToString());
                }
                int userData = int.Parse(Session["customrdata"].ToString());

                Cart existingCart = this.HttpContext.Session["shoppingcart"] as Cart;
                List<Item> ilist = new List<Item>();
                foreach (Item i in existingCart.items)
                {
                    BusinessManager.AddToOrder(i, userData, thecustomer.address, id);
                    ilist.Add(i);
                    crops c = BusinessManager.getcrop(i.cropID);
                    int totalLeft = c.quantity - i.quantity;
                    BusinessManager.updateCropquantity(i.cropID, totalLeft);

                }
                existingCart.items.Clear();
                ViewData["ilist"] = ilist;

                return View();//add view

             
            }
            return RedirectToAction("login", "Accounts");
        }

        public ActionResult viewPreviousOrders()
        {

            if (Session["customrdata"] != null)
            {
                int userData = int.Parse(Session["customrdata"].ToString());
                List<orders> ilist = BusinessManager.getOrdersById(userData);
                if (ilist != null)
                {
                    ViewData["ilist"] = ilist;
                    return View();//add view
                }
                else
                {
                    string message = "your cart is empty ,Please select some items to add in cart";
                    return RedirectToAction("emptycarterror/message=" + message, "shoppingcart");
                }
                

            }
            return RedirectToAction("login", "Accounts");
            
        }
        public ActionResult emptycarterror(string message)
        {
            this.ViewBag.message = message;
            return View();
        }

        public ActionResult AddToCarterror(int id)
        {
            this.ViewBag.Message = "your requested quantity is not available please check the available quantity on details page";
            this.ViewBag.cropID = id;
            return View();

        }
        public ActionResult displayAllorders(int id)
        {
            List<orders> olist = BusinessManager.getOrderByFarmer(id);
            ViewData["orders"] = olist;
            return View();
        }

        public ActionResult GetValidOrders()
        {
            List<orders> olist = BusinessManager.GetValidOrder();
            ViewData["orders"] = olist;
            return View();
        }
    }
}