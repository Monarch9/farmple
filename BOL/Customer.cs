using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BOL
{

    // POCO Object  : Plain Old CLR Object
    //same as  POJO object of java : Plain Old Java Object

    public class Customer
    {
        [Key]
        [Required]
        public int customerId { get; set; }

       [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Password{ get; set; }

        [Required]
        public string Contact { get; set; }
       
        [Required]
        public string address { get; set; }

        [Required]
        public string pincode { get; set; }
        
        [Display(Name="Email Address")]
        [Required(ErrorMessage ="The email address must be mentioned...")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

    }
}
