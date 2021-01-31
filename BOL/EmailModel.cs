using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace BOL

{
    public class EmailModel
    {
        [Required, Display(Name = "Your name")]
        public string toname { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string toemail { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }
    }
}  