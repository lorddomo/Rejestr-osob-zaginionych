using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Rejestr_osób_zaginionych.Models
{
    public class LostViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "We need to know the name of the lost person")]
        public string Name { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "We need to know the last name of the lost person")]
        public string LastName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "We need to know the age of the lost person")]
        public string Age { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "We need to know the sex of the lost person")]
        public string Sex { get; set; }

        [Display(Name = "Last place seen")]
        [Required(ErrorMessage = "You need to give us the last place where person was seen")]
        public string LastSeenPlace { get; set; }

        [Display(Name = "Date of last seen")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "You need to give us a date when person was seen")]
        public string LastSeenDate { get; set; }
    }
}
