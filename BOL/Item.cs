using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public  class Item
    {
        public int cropID { get; set; }

        public string crop_name { get; set; }
         public int quantity { get; set; }
        public int unit_price { get; set; }
        public int total { get; set; }
        public string image { get; set; }

        public int fid { get; set; }
        
    }
}
