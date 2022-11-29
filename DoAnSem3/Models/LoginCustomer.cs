using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    public class LoginCustomer
    {

        public string name { get; set; }

        [Required(ErrorMessage = "Email address is not empty")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is not blank")]
        public string password { get; set; }

        public string phone { get; set; }

        public float? totalPrice { get; set; }

        public bool? status { get; set; }

        public int role { get; set; }

    }
}
