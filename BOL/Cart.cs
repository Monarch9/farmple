using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
   public  class Cart
    {

        public List<Item> items = new List<Item>();
        public int gettotal(List<Item> items)
        {
            int sum = 0;
            foreach(Item i in items)
            {
                sum += i.total;
            }
            return sum;
        }
    }
}
