using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("Product")] // thêm bảng vào database
    public class Product
    {
        [Key]
        public int productId { get; set; }

        [DisplayName("Denominations")]
        [StringLength(200)]
        public string productName { get; set; }


        public float price { get; set; }

        [StringLength(1000)]
        public string description { get; set; }


        //Khoá ngoại
        [Display(Name = "Network Operator")]
        [ForeignKey("NetworkServiceProvider")]
        public int nspId { get; set; }
        public NetworkServiceProvider NetworkServiceProvider { get; set; }

        [ForeignKey("Service")]
        public int svId { get; set; }
        public Service Service { get; set; }
    }
}
