using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;
namespace DAL
{
    public static class DBManager
    {
        public static readonly string connString = string.Empty;
        static DBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }
        public static crops GetByID(int id)
        {
            crops thecrops = new crops();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from crops WHERE cropID=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //cropID, crop_name, added_on, category, description, quantity, unit_price, image

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    thecrops.cropID = int.Parse(row["cropID"].ToString());
                    thecrops.crop_name = row["crop_name"].ToString();
                    thecrops.added_on = DateTime.Parse(row["added_on"].ToString());
                    thecrops.category = row["category"].ToString();
                    thecrops.description = row["description"].ToString();
                    thecrops.quantity = int.Parse(row["quantity"].ToString());
                    thecrops.unit_price = int.Parse(row["unit_price"].ToString());
                    thecrops.image = row["image"].ToString();



                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return thecrops;
        }
        public static List<crops> GetAllProducts()
        {
            List<crops> allCrops = new List<crops>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from crops";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //cropID, crop_name, added_on, category, description, quantity, unit_price, image
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    crops crop = new crops();
                    crop.cropID = int.Parse(row["cropID"].ToString());
                    crop.crop_name = row["crop_name"].ToString();
                    crop.added_on = DateTime.Parse(row["added_on"].ToString());
                    crop.category = row["category"].ToString();
                    crop.description = row["description"].ToString();
                    crop.quantity = int.Parse(row["quantity"].ToString());
                    crop.unit_price = int.Parse(row["unit_price"].ToString());
                    crop.image = row["image"].ToString();
                    allCrops.Add(crop);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return allCrops;
        }

      /*  public static object GetTopthreecrops()
        {
           

        }
*/
        public static bool updateCropquantity(int cid, int qty_left)
        {
            //cid, qty_left
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "Update crops set quantity = '" + qty_left + "' Where  cropid='" + cid + "'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;

        }


        public static List<CropFarmer> getcropFarmerBYFarmerID(int id)
        {
            List<CropFarmer> listcrop = new List<CropFarmer>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from cropfarmerxref WHERE farmerID=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //cropID, crop_name, added_on, category, description, quantity, unit_price, image

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    CropFarmer thecrops = new CropFarmer();
                    thecrops.cid = int.Parse(row["cropID"].ToString());
                    thecrops.fid = int.Parse(row["farmerID"].ToString());
                    thecrops.added_on = DateTime.Parse(row["added_on"].ToString());
                    thecrops.qty_left = int.Parse(row["qty_left"].ToString());
                    listcrop.Add(thecrops);

                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return listcrop;
        }

        public static List<orders> getOrderByFarmer(int id)
        {

            List<orders> o = new List<orders>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from orders WHERE fid=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //orderid, customerID, cropID, quantity, total_amount

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    orders order = new orders();
                    order.orderid = int.Parse(row["orderid"].ToString());
                    order.customerID = int.Parse(row["customerID"].ToString());
                    order.cropID = int.Parse(row["cropID"].ToString());
                    order.quantity = int.Parse(row["quantity"].ToString());
                    order.total_amount = int.Parse(row["total_amount"].ToString());
                    order.crop_name = row["crop_name"].ToString();
                    order.address = row["address"].ToString();
                    order.ordered_date = DateTime.Parse(row["ordered_date"].ToString());
                    o.Add(order);


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return o;
        }

    public static List<farmers> SelectAllFarmers()
        {
            List<farmers> allfarmers = new List<farmers>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from farmers";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //farmerID, FisrtName, LastName, emailID, password, contact, address
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    farmers farmer = new farmers();
                    farmer.farmerId = int.Parse(row["farmerId"].ToString());
                    farmer.FirstName = row["FisrtName"].ToString();
                    farmer.LastName = row["LastName"].ToString();
                    farmer.Email = row["emailID"].ToString();
                    farmer.password = row["password"].ToString();
                    farmer.address = row["address"].ToString();
                    farmer.contact = row["contact"].ToString();
                    allfarmers.Add(farmer);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return allfarmers;
        }

        public static CropFarmer getcropFarmer(int id)
        {
            CropFarmer thecrops = new CropFarmer();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from cropfarmerxref WHERE cropID=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //cropID, crop_name, added_on, category, description, quantity, unit_price, image

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    thecrops.cid = int.Parse(row["farmerID"].ToString());
                    thecrops.fid = int.Parse(row["cropID"].ToString());
                    thecrops.added_on = DateTime.Parse(row["added_on"].ToString());
                    thecrops.qty_left = int.Parse(row["qty_left"].ToString());

                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return thecrops;
        }

        public static bool validate(string username, string password)//customers validate 
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT fisrtname,password FROM customers where fisrtname = @username and Password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@username", username));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));

                    object result = cmd.ExecuteScalar(); //only matching first row  and column generally this is id
                    if (result != null)
                    {
                        status = true;
                    }
                    con.Close();


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return status;

        }

        public static List<orders> getOrdersById(int userData)  //get order by customer ID
        {
            List<orders> o = new List<orders>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from orders WHERE customerID=" + userData;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //orderid, customerID, cropID, quantity, total_amount

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    orders order = new orders();
                    order.orderid = int.Parse(row["orderid"].ToString());
                    order.customerID = int.Parse(row["customerID"].ToString());
                    order.cropID = int.Parse(row["cropID"].ToString());
                    order.quantity = int.Parse(row["quantity"].ToString());
                    order.total_amount = int.Parse(row["total_amount"].ToString());
                    order.crop_name = row["crop_name"].ToString();
                    order.address = row["address"].ToString();
                    o.Add(order);


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return o;
        }


        public static void AddToOrder(Item i, int userData, string address,int  id)
        {
            try
            {
                DateTime date = DateTime.Now;
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    //orderid, customerID, cropID, quantity, total_amount
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO orders (orderid, customerID, cropID,crop_name, quantity, total_amount,address,fid,ordered_date) " +
                                                "VALUES ( default, @customerID,@cropID,@crop_name,@quantity,@total_amount,@address,@fid,@ordered_date)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));

                    cmd.Parameters.Add(new MySqlParameter("@customerID", userData));
                    cmd.Parameters.Add(new MySqlParameter("@cropID", i.cropID));
                    cmd.Parameters.Add(new MySqlParameter("@crop_name", i.crop_name));
                    cmd.Parameters.Add(new MySqlParameter("@quantity", i.quantity));
                    cmd.Parameters.Add(new MySqlParameter("@total_amount", i.total));
                    cmd.Parameters.Add(new MySqlParameter("@address",address));
                    cmd.Parameters.Add(new MySqlParameter("@ordered_date", date));
                    cmd.Parameters.Add(new MySqlParameter("@fid",id));

                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
        }

        public static List<orders> GetValidOrder()
        {
            List<orders> o = new List<orders>();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = " select * from orders where ordered_date > curdate() - 10";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //orderid, customerID, cropID, quantity, total_amount

                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    orders order = new orders();
                    order.orderid = int.Parse(row["orderid"].ToString());
                    order.customerID = int.Parse(row["customerID"].ToString());
                    order.cropID = int.Parse(row["cropID"].ToString());
                    order.quantity = int.Parse(row["quantity"].ToString());
                    order.total_amount = int.Parse(row["total_amount"].ToString());
                    order.crop_name = row["crop_name"].ToString();
                    order.address = row["address"].ToString();
                    order.ordered_date = DateTime.Parse(row["ordered_date"].ToString());
                    o.Add(order);


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return o;








        }

        public static bool AddCrop_xref(int id, int cid, DateTime date, int quantity)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO cropfarmerxref (farmerId, cropID, qty_left, added_on) " +
                                                "VALUES ( @farmerId, @cropID, @qty_left, @added_on)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //farmerId, cropID, qty_left, added_on
                    cmd.Parameters.Add(new MySqlParameter("@farmerId", id));
                    cmd.Parameters.Add(new MySqlParameter("@cropID", cid));
                    cmd.Parameters.Add(new MySqlParameter("@qty_left", quantity));
                    cmd.Parameters.Add(new MySqlParameter("@added_on", date));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;



        }

        public static bool deletecrop(int id, int fid)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE from cropfarmerxref  WHERE cropId=@Id and farmerId=@fid";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", id));
                    cmd.Parameters.Add(new MySqlParameter("@fid", fid));

                    cmd.ExecuteNonQuery();

                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }

        public static List<crops> getproductsforFarmer(int id)
        {
            List<crops> allCrops = new List<crops>();
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from crops";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                //cropID, crop_name, added_on, category, description, quantity, unit_price, image
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    crops crop = new crops();
                    crop.cropID = int.Parse(row["cropID"].ToString());
                    crop.crop_name = row["crop_name"].ToString();
                    crop.added_on = DateTime.Parse(row["added_on"].ToString());
                    crop.category = row["category"].ToString();
                    crop.description = row["description"].ToString();
                    crop.quantity = int.Parse(row["quantity"].ToString());
                    crop.unit_price = int.Parse(row["unit_price"].ToString());
                    crop.image = row["image"].ToString();
                    allCrops.Add(crop);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return allCrops;

        }

/*        public static bool Insert(Product newProduct)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {

                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO flowers (Id,Title ,Description, UnitPrice, Quantity, ImageUrl) " +
                                                "VALUES (@Id, @Title, @Description, @UnitPrice, @Quantity,@ImageUrl)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", newProduct.ID));
                    cmd.Parameters.Add(new MySqlParameter("@Title", newProduct.Title));
                    cmd.Parameters.Add(new MySqlParameter("@Description", newProduct.Description));
                    cmd.Parameters.Add(new MySqlParameter("@UnitPrice", newProduct.UnitPrice));
                    cmd.Parameters.Add(new MySqlParameter("@Quantity", newProduct.Quantity));
                    cmd.Parameters.Add(new MySqlParameter("@ImageUrl", newProduct.ImageUrl));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }
*/
        public static bool validateFarmer(string username, string password)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT fisrtname,password FROM farmers where fisrtname = @username and Password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@username", username));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));

                    object result = cmd.ExecuteScalar(); //only matching first row 
                    if (result != null)
                    {
                        status = true;
                    }
                    con.Close();


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return status;
        }

        public static bool updateCrop(CropFarmer c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "Update cropfarmerxref set qty_left = '" + c.qty_left + "',added_on='" + c.added_on + "' Where  cropid='" + c.cid + "'";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;



        }

        public static bool registerFarmer(farmers c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO farmers (fisrtname,lastname,emailID,password,contact, address) " +
                                                "VALUES ( @FirstName, @Lastname, @emailId, @password,@contact,@address)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", c.FirstName));
                    cmd.Parameters.Add(new MySqlParameter("@Lastname", c.LastName));
                    cmd.Parameters.Add(new MySqlParameter("@emailId", c.Email));
                    cmd.Parameters.Add(new MySqlParameter("@password", c.password));
                    cmd.Parameters.Add(new MySqlParameter("@contact", c.contact));
                    cmd.Parameters.Add(new MySqlParameter("@address", c.address));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;

        }

        public static bool AddCrop(crops c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO crops (crop_name,added_on,category,description,quantity,unit_price,image) " +
                                                "VALUES (@crop_name, @added_on, @category, @description, @quantity,@unit_price,@ImageUrl)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@crop_name", c.crop_name));
                    cmd.Parameters.Add(new MySqlParameter("@added_on", c.added_on));
                    cmd.Parameters.Add(new MySqlParameter("@category", c.category));
                    cmd.Parameters.Add(new MySqlParameter("@description", c.description));
                    cmd.Parameters.Add(new MySqlParameter("@quantity", c.quantity));
                    cmd.Parameters.Add(new MySqlParameter("@unit_price", c.unit_price));
                    cmd.Parameters.Add(new MySqlParameter("@ImageUrl", c.image));
                    cmd.ExecuteNonQuery();
                    con.Close();


                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;



        }


        public static bool regUser(Customer c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "INSERT INTO customers (FisrtName ,lastname,emailId,password,contact,address,pincode) " +
                                                "VALUES ( @FirstName, @Lastname, @emailId, @password,@contact,@address,@pincode)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.Parameters.Add(new MySqlParameter("@FirstName", c.FirstName));
                    cmd.Parameters.Add(new MySqlParameter("@Lastname", c.LastName));
                    cmd.Parameters.Add(new MySqlParameter("@emailId", c.Email));
                    cmd.Parameters.Add(new MySqlParameter("@password", c.Password));
                    cmd.Parameters.Add(new MySqlParameter("@contact", c.Contact));
                    cmd.Parameters.Add(new MySqlParameter("@address", c.address));
                    cmd.Parameters.Add(new MySqlParameter("@pincode", c.pincode));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }

        public static int validatelogin(string username, string password)
        {
            int status1 = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT customerid FROM customers where fisrtname = @username and Password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@username", username));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));

                    object result = cmd.ExecuteScalar(); //only matching first row  first col(id)
                    if (result != null)
                    {
                        status1 = (int)result;
                    }
                    con.Close();


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return status1;




        }

        public static bool Update(Product existingProduct)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from fruits";
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder cmdbuilder = new MySqlCommandBuilder(da);
                da.Fill(ds);
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;
                DataRow datarow = ds.Tables[0].Rows.Find(existingProduct.ID);
                datarow["Title"] = existingProduct.Title;
                datarow["Description"] = existingProduct.Description;
                datarow["UnitPrice"] = existingProduct.UnitPrice;
                datarow["Quantity"] = existingProduct.Quantity;
                datarow["ImageUrl"] = existingProduct.ImageUrl;
                da.Update(ds);
                status = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException e)
            {
                string msg = e.Message;
            }
            return status;
        }
        public static bool Delete(int id)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE from fruits  WHERE Id=@Id";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@Id", id));
                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;
        }

        public static int getFarmers(string username, string password)
        {
            int status1 = 0;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "SELECT farmerid FROM farmers where fisrtname = @username and Password = @password";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@username", username));
                    cmd.Parameters.Add(new MySqlParameter("@password", password));

                    object result = cmd.ExecuteScalar(); //only matching first row 
                    if (result != null)
                    {
                        status1 = (int)result;
                    }
                    con.Close();


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return status1;




        }

        public static Customer GetCustomerByID(int id)
        {
            Customer thecustomers = new Customer();

            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "Select * from customers WHERE customerID=" + id;
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;
            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);
            DataSet ds = new DataSet();
            try
            {


                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    thecustomers.customerId = int.Parse(row["customerId"].ToString());
                    thecustomers.FirstName = row["FisrtName"].ToString();
                    thecustomers.LastName = row["LastName"].ToString();
                    thecustomers.address = row["address"].ToString();
                    thecustomers.Contact = row["Contact"].ToString();
                    thecustomers.Email = row["EmailID"].ToString();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            // implementation 
            return thecustomers;
        }
    }
}
