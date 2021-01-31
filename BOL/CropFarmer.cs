using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class CropFarmer
    {
        [Required]
        public int fid { get; set; }

        [Required]
        public int cid { get; set; }

        public int qty_left { get; set; }

        public DateTime added_on { get; set; }


    }
}
