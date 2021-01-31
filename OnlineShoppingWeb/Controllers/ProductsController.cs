using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingWeb.Models;
using BOL;
using BLL;

namespace OnlineShoppingWeb.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Product> allProducts = BusinessManager.GetAllProducts();
            this.ViewData["products"] = allProducts;
            return View();
        }

        //

        //to get particular product
        public ActionResult Details(int id)
        {
            Product theProduct = BusinessManager.GetProduct(id);
            return View(theProduct);
        }

        //to insert a new product
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(int id,string title,string descrip,double unitprice,int quantity,string ImageURl)
        {
            Product newProduct = new Product        //new object is created by raking user parameter
            { 
                ID = id,
                Title = title,
                Descrip = descrip,
                UnitPrice = unitprice,
                Quantity = quantity,
                ImageUrl = ImageURl
            };

            bool status = BusinessManager.Insert(newProduct);      //now this object passed to business manager to add in DB
            if(status)                                            //inserted succesfull
            {
                this.RedirectToAction("index", "Products");
            }
            return View();
        }

        public ActionResult Inventory()
        {
            List<Product> allProducts = BusinessManager.GetAllProducts();
            this.ViewData["allproducts"] = allProducts;
            return View();
        }

        //to remove existing product
        public ActionResult Delete(int product_id)
        {
            
            return View();
        }

        //to update existing product

    
        public ActionResult Update(int product_id)
        {
            Product existingProduct = new Product();
            existingProduct = BusinessManager.GetProduct(product_id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Update(int id, string title, string descrip, int unitprice, int quantity, string imageUrl)
        {
            Product newProuduct = new Product
            {
                ID = id,
                Title = title,
                Descrip = descrip,
                UnitPrice = unitprice,
                Quantity = quantity,
                ImageUrl = imageUrl
        };
        bool status = BusinessManager.Update(newProuduct);
            return View();
        }

        
    }
}