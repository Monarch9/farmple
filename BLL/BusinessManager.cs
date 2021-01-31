using BOL;
using System.Collections.Generic;
using DAL;
using System;

namespace BLL
{
    public static class BusinessManager
    {

        public static crops GetProduct(int id)
        {
            /* return   new Product { ID = id, Title = "Gerbera", Description = "Wedding Flower", 
                                              UnitPrice = 6, Quantity = 5000 
                                              ,ImageUrl="/images/Transflower.jpg"};*/
           return  DBManager.GetByID(id);
        }
        public static List<crops> GetAllProducts()
        {
            List<crops> allcrops = new List<crops>();

            allcrops = DBManager.GetAllProducts();
            
            // fiter data 
            // sort data and send Analytical data back to  Controller action method
            // according to business logic modify data  and store back to data base

            return allcrops;

            /* allProducts.Add(new Product { ID = 1, Title = "Gerbera", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
             allProducts.Add(new Product { ID = 2, Title = "Rose", Description = "Valentine Flower", UnitPrice = 15, Quantity = 7000 });
             allProducts.Add(new Product { ID = 3, Title = "Lotus", Description = "Worship Flower", UnitPrice = 26, Quantity = 0 });
             allProducts.Add(new Product { ID = 4, Title = "Carnation", Description = "Pink carnations signify a mother's love, red is for admiration and white for good luck", UnitPrice = 16, Quantity = 27000 });
             allProducts.Add(new Product { ID = 5, Title = "Lily", Description = "Lilies are among the most popular flowers in the U.S.", UnitPrice = 6, Quantity = 1000 });
             allProducts.Add(new Product { ID = 6, Title = "Jasmine", Description = "Jasmine is a genus of shrubs and vines in the olive family", UnitPrice = 26, Quantity = 0 });
             allProducts.Add(new Product { ID = 7, Title = "Daisy", Description = "Give a gift of these cheerful flowers as a symbol of your loyalty and pure intentions.", UnitPrice = 36, Quantity = 159 });
             allProducts.Add(new Product { ID = 8, Title = "Aster", Description = "Asters are the September birth flower and the the 20th wedding anniversary flower.", UnitPrice = 16, Quantity = 67 });
             allProducts.Add(new Product { ID = 9, Title = "Daffodil", Description = "Wedding Flower", UnitPrice = 6, Quantity = 5000 });
             allProducts.Add(new Product { ID = 10, Title = "Dahlia", Description = "Dahlias are a popular and glamorous summer flower.", UnitPrice = 7, Quantity = 0 });
             allProducts.Add(new Product { ID = 11, Title = "Hydrangea", Description = "Hydrangea is the fourth wedding anniversary flower", UnitPrice = 12, Quantity = 0 });
             allProducts.Add(new Product { ID = 12, Title = "Orchid", Description = "Orchids are exotic and beautiful, making a perfect bouquet for anyone in your life.", UnitPrice = 10, Quantity = 700 });
             allProducts.Add(new Product { ID = 13, Title = "Statice", Description = "Surprise them with this fresh, fabulous array of Statice flowers", UnitPrice = 16, Quantity = 1500 });
             allProducts.Add(new Product { ID = 14, Title = "Sunflower", Description = "Sunflowers express your pure love.", UnitPrice = 8, Quantity = 2300 });
             allProducts.Add(new Product { ID = 15, Title = "Tulip", Description = "Tulips are the quintessential spring flower and available from January to June.", UnitPrice = 17, Quantity = 10000 });
           

            return allProducts;*/

        }

      /*  public static object GetTopthreecrops()
        {


            return DBManager.GetTopthreecrops();




        }
*/
        public static Customer getcustByID(int f)
        {
            return DBManager.GetCustomerByID(f);
        }

        public static List<CropFarmer> getcropfarmerByID(int id)
        {
            return DBManager.getcropFarmerBYFarmerID(id);
        }

        public static bool updateCropquantity(int cid, int qty_left)
        {
            return DBManager.updateCropquantity(cid, qty_left);
        }

        public static List<orders> GetValidOrder()
        {
            return DBManager.GetValidOrder();
        }


        public static CropFarmer getcropFarmer(int id)
        {
            return DBManager.getcropFarmer(id);
        }

        public static bool validatelogin1(string username, string password)
        {
            return DBManager.validate(username, password);
        }

        public static List<orders> getOrdersById(int userData)
        {
            return DBManager.getOrdersById(userData);

        }

        public static void AddToOrder(Item i,int userData, string  address,int id)
        {
             DBManager.AddToOrder(i, userData,address,id);
        }

        public static bool AddCrop_xref(int id, int cid, DateTime date, int quantity)
        {
            return DBManager.AddCrop_xref(id, cid, date, quantity);
        }

        public static bool deletecrop(int id,int fid)
        {
            return DBManager.deletecrop(id,fid);
        }

        public static List<farmers> SelectAllFarmers()
        {
            return DBManager.SelectAllFarmers();
        }

        public static List<crops> getProductforFarmer(int id)
        {
            return DBManager.getproductsforFarmer(id);
        }

        public static bool validateFarmer(string username, string password)
        {
            return DBManager.validateFarmer(username, password);
        }

        public static List<orders> getOrderByFarmer(int id)
        {
            return DBManager.getOrderByFarmer(id);
        }

        public static int GetFarmers(string username, string password)
        {
            return DBManager.getFarmers(username, password);
        }

        public static bool updateCrop(CropFarmer c)
        {
            return DBManager.updateCrop(c);
        }

        public static crops getcrop(int id)
        {
            return DBManager.GetByID(id);
        }

        public static bool regFarmer(farmers c)
        {
            return DBManager.registerFarmer(c);
        }

        

        public static bool AddCrop(crops c)
        {
            return DBManager.AddCrop(c);
        }


        public static bool regUser(Customer c)
        {
            return DBManager.regUser(c);   
        }

        public static int validatelogin(string username, string password)
        {
            return DBManager.validatelogin(username, password);

        }

      /*  public static bool Insert(Product newProduct)
        {
            return DBManager.Insert(newProduct);
        }*/
        public static bool Update(Product newProduct)
        {
            return DBManager.Update(newProduct);
        }


        //Analytical functionalities
        public static List<string> GetTopTenCustomers()
        {
            List<string> customers = new List<string>();
            customers.Add("Microsoft");
            customers.Add("IBM");
            customers.Add("Oracle");
            customers.Add("Google");
            customers.Add("Facebook");
            customers.Add("Infosys");
            customers.Add("Tcs");
            customers.Add("IET");
            customers.Add("IACSD");
            customers.Add("KnowIT");
            return customers;
        }

      
        public static List<string> GetTopTenOrders()
        {
            List<string> orders = new List<string>();
            orders.Add("Azure Programming");
            orders.Add("DotNet 5 Application Development");
            orders.Add("Spring Boot api for Microservices");
            orders.Add("MongoDB Programming");
            orders.Add("React JS Single Page Applications");
            orders.Add("Angular SPA with WebAPI");
            orders.Add("WPF Programming");
            orders.Add("Dev Ops  Training");
            orders.Add("SQL Programming");
            orders.Add("C++ Systems Programming");
            return orders;
        }







    }
}
