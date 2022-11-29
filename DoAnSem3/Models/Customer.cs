using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("Customer")] // tên bảng được sinh ra trong database

    public class Customer
    {
        [Key]
        public int customerId { get; set; }
            
        [DisplayName("Account name")]
        [StringLength(200)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string customerName { get; set; }

        [Required(ErrorMessage = "Can't be left blankg")]
        [EmailAddress(ErrorMessage = "Email address is not in the correct format")]
        public string email { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number is not in the correct format")]
        [Required(ErrorMessage = "Phone number can not be left blank")]
        public string phone { get; set; }

        public string phoneNsp { get; set; }

        public string password { get; set; }

        public float? totalPrice { get; set; }

        public bool status { get; set; }

        public int role { get; set; }

        public ICollection<Banking> Bankings { get; set; }
        public ICollection<Order> Orders{ get; set; }
    }
}
