using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BOL
{
  public  class orders
    {
        //orderid, customerID, cropID, quantity, total_amount

        [Key]
        public int orderid { get; set; }


        [ForeignKey("cropID")]
        public int cropID { get; set; }

        [ForeignKey("customerID")]
        public int customerID { get; set; }
        public int quantity { get; set; }
        public int total_amount { get; set; }

        public string customer_name { get; set; }
        public string crop_name { get; set; }

        public string address { get; set; }

        public int fid { get; set; }

        public DateTime ordered_date { get; set; }
    }
}
