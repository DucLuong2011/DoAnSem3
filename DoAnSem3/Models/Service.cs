using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnSem3.Models
{
    [Table("Service")] // thêm bảng vào database 
    public class Service
    {
        [Key]
        public int svId { get; set; }

        [DisplayName("Service")]
        [StringLength(200)]
        [Required(ErrorMessage = "Can't be left blank")]
        public string svName { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public bool status { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
