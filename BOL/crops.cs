using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BOL
{
    public class crops
    {
        [Key]
        [Required]
        public int cropID { get; set;}

        public string crop_name { get; set; }
        public DateTime added_on { get; set;}

        public string category { get; set; }
        public string description { get; set;}
        public int quantity { get; set; }
        public int unit_price {get; set;}

        public string image { get; set; }


        public crops()
        {

        }

        public crops(int cropID, string crop_name, DateTime added_on, string category, string description, int quantity, int unit_price, string image)
        {
            this.cropID = cropID;
            this.crop_name = crop_name;
            this.added_on = added_on;
            this.category = category;
            this.description = description;
            this.quantity = quantity;
            this.unit_price = unit_price;
            this.image = image;
                
        }
        
    }
}
