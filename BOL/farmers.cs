using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{
    public class farmers
    {
        
        [Required]
        public int farmerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string contact { get; set; }

        [Required]
        public string address { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address must be mentioned...")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }




    }
}
