using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BOL;
namespace OnlineShoppingWeb.Controllers
{

    //Processing incomming Requests
    //Generating Model
    //Sending Model to View

    public class ProdutsController : Controller
    {
        //To get all list of Products
        // GET: Produts
        public ActionResult Index()
        {
             List<Product> allProducts = BusinessManager.GetAllProducts();
             this.ViewData["products"] = allProducts;
            return View(allProducts);
        }

        //To get particular Product
        public ActionResult Details(int id)
        {
          
            return View(theProduct);
        }

        //to insert new Product
        public ActionResult Insert()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Insert(Product newProduct)
        {
            return View();
        }
        //to update existing product
        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(Product existingProduct)
        {
            return View();
        }

        //To remove existing product
        public ActionResult Delete( int id)
        {
            return View();
        }
    }
}