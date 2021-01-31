using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
namespace MondayOnlineShopWeb.Controllers
{
    public class cropsController : Controller
    {
        // GET: crops
        public ActionResult RegisterCrops()
        {
            if (Session["UserData"] != null)
            {
                var userData = Session["UserData"];

                List<crops> cList = BusinessManager.GetAllProducts();
                ViewData["allProducts"] = cList;
                return View();
            }
            return RedirectToAction("loginfarmer", "farmers");
        }
        [HttpPost]
        public ActionResult RegisterCrops( int  cid,int quantity,int unit_price)
        {
            if (Session["UserData"] != null)
            {
                int id =int.Parse( Session["UserData"].ToString());

                //            bool status = BusinessManager.AddCrop(c);
                DateTime date = DateTime.Now;
                int totalquantity = 0;
                crops c = new crops();
                List<CropFarmer> cf = BusinessManager.getcropfarmerByID(id);
                foreach(CropFarmer  i in cf)
                {
                    if(i.cid== cid)
                    {
                         c = BusinessManager.getcrop(cid);
                        totalquantity = c.quantity + i.qty_left;
                        i.qty_left = totalquantity;
                        i.added_on = DateTime.Now;
                        BusinessManager.updateCrop(i); 
                        BusinessManager.updateCropquantity(cid, totalquantity);
                    }
                    
                }
                BusinessManager.AddCrop_xref(id, cid, date, quantity);
                 c = BusinessManager.getcrop(cid);
                CropFarmer cf1 = BusinessManager.getcropFarmer(cid);
                 totalquantity = c.quantity + cf1.qty_left;
                BusinessManager.updateCropquantity(cid, totalquantity);//main crop table
                return RedirectToAction("displayAllCrops", "crops");
            }
            return RedirectToAction("loginfarmer", "farmers");
        }
        public ActionResult Update(int id)
        {
           crops crop = BusinessManager.getcrop(id);

            return View(crop);
        }

        [HttpPost]
        public ActionResult Update(int cid,string crop_name, int quantity,int unit_price)
        {

            if (Session["UserData"] != null)
            {
                int id = int.Parse(Session["UserData"].ToString());

                CropFarmer c = new CropFarmer
                {
                    fid = id,
                    cid = cid,
                    added_on = DateTime.Now,
                    qty_left = quantity
                    };
                crops c1 = BusinessManager.getcrop(cid);
              int totalquantity = c1.quantity + c.qty_left;
                c.qty_left = totalquantity;
                BusinessManager.updateCrop(c);
              bool status=  BusinessManager.updateCropquantity(cid, totalquantity);
                if (status)
                {
                    return RedirectToAction("displayAllCrops", "crops");
                }
                else
                    return View();
            }
            return RedirectToAction("loginfarmerdis", "farmers");

        }


       

        public ActionResult displayAllCrops()//display crops to farmer which are only added by that particular farmer
        {
            //CropFarmer cf=new 
            if (Session["UserData"] != null)
                
            {
                int id = int.Parse(Session["UserData"].ToString());

                List<CropFarmer> croplist = BusinessManager.getcropfarmerByID(id);
                List<crops> cList = new List<crops>();
                foreach(CropFarmer i in croplist)
                {
                    crops c = new crops();
                        c=BusinessManager.getcrop(i.cid);
                    cList.Add(c);
                }
                ViewData["allProducts"] = cList;
                return View();
            }
            return RedirectToAction("loginfarmer", "farmers");
        }


        public ActionResult DisplayAllCropsForCustomers(int id)
        {
            List<CropFarmer> croplist = BusinessManager.getcropfarmerByID(id);
            //add farmerID to session
            this.Session.Add("FARMERID", id);
            List<crops> cList = new List<crops>();
            foreach (CropFarmer i in croplist)
            {
                crops c = new crops();
                c = BusinessManager.getcrop(i.cid);
                cList.Add(c);
            }
            ViewBag.farmerId = id;
            ViewData["allProducts"] = cList;
            return View();
        }

    
            public ActionResult SelectAllFarmers()
        {
            List<farmers> flist = new List<farmers>();
            flist = BusinessManager.SelectAllFarmers();
            ViewData["allfarmers"] = flist;

            return View();
        }


        public ActionResult detailsforCustomers(int id)
        {
            crops c = BusinessManager.getcrop(id);
            
            return View(c);
        }

        public ActionResult details(int id)
        {
            crops c = BusinessManager.getcrop(id);
           
            return View(c);
        }
        public ActionResult delete(int id)
        {
            int fid = int.Parse(Session["UserData"].ToString());
            bool status = BusinessManager.deletecrop(id,fid);

            if(status)
            {
                return RedirectToAction("displayAllCrops", "crops");
            }

            return RedirectToAction("displayAllCrops", "crops");
        }
    }
}