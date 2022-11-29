using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }
        public string numberPhone { get; set; }
        public string nameCustomer { get; set; }
        public string nameService { get; set; }
        public string description { get; set; }

        [DisplayName("Order date")]
        public DateTime createAt { get; set; } = DateTime.Now;
        public bool status { get; set; }

        //Khoá ngoại
        [ForeignKey("Product")]
        public int productId { get; set; }

        public Product Product { get; set; }
    }
}
