using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("Freeback")] // bảng được sinh ra trong database
    public class FreeBack
    {
        [Key]
        public int Id{ get; set; }


        [DisplayName(" Name")]
        [StringLength(200)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string name { get; set; }

        [Required(ErrorMessage = "Can't be left blankg")]
        [EmailAddress(ErrorMessage = "Email address is not in the correct format")]
        public string email{ get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number is not in the correct format")]
        [Required(ErrorMessage = "Phone number can not be left blank")]
        public string phone { get; set; }

        [StringLength(1000)]
        public string note{ get; set; }
    }
}
